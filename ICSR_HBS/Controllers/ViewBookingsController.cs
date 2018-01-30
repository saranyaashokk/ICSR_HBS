using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Net;
using System.Net.Mail;
using System.Web.Mvc;
using BusinessLayer;
using DataLayer.Models;
using DataLayer.ViewModels;
using PagedList;
using FastMember;
using System.Linq.Dynamic;
using System.Globalization;

namespace ICSR_HBS.Controllers
{
    public class ViewBookingsController : Controller
    {
        HBBusinessLayer hbl = new HBBusinessLayer();

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult GetData(string start, string end)
        {
            IFormatProvider culture = new CultureInfo("en-US", true);
            DateTime? dtStart = null;
            DateTime? dtEnd = null;
            if (start != null && start != string.Empty)
                dtStart = DateTime.ParseExact(start, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            else
                dtStart = DateTime.ParseExact(DateTime.Now.ToShortDateString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
            if (end != null && end != string.Empty)
                dtEnd = DateTime.ParseExact(string.Concat(end, " ", "23:59:00.000"), "dd/MM/yyyy HH:mm:ss.fff", culture);

            List<Admin_View_booking> bookings = hbl.bookings(dtStart, dtEnd).ToList();
            return Json(new { data = bookings }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Index(Admin_View_booking avb)
        {

            return View(avb);
        }



        [HttpGet]
        public ActionResult AddOrEdit(int iBooking_id = 0)
        {
            return View(new Admin_View_booking());
        }

        [HttpGet]
        public ActionResult AddOrEdit()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Delete(int iBooking_id)
        {
            try
            {
                int iDel_booking = hbl.iRemove_booking(iBooking_id);
                if(iDel_booking == 0)
                    return Json(new { success = false, message = "Cannot be cancelled" });
                else
                    return Json(new { success = true, message = "Deleted successfully" });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "Operation Failure" }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult Approve(int iBooking_id)
        {
            try
            {
                DataTable dtApprove_Booking = hbl.dtApprove_booking(iBooking_id);

                if (Convert.ToInt32(dtApprove_Booking.Rows[0]["result"]) == 2)
                {
                    //send mail that the booking has been approved

                    using (MailMessage message = new MailMessage("saranyaashokk@gmail.com", dtApprove_Booking.Rows[0]["faculty_email"].ToString())) //hallVM.fac_emailId))
                    {
                        message.CC.Add(dtApprove_Booking.Rows[0]["em_email"].ToString());

                        if (dtApprove_Booking.Rows[0]["collaborative_email"].ToString() != string.Empty)
                            message.CC.Add(dtApprove_Booking.Rows[0]["collaborative_email"].ToString());


                        message.Subject = "ICSR - Hall booking Notification";
                        message.Body = "Congratulation ! Your Booking (" + iBooking_id.ToString() + ") have been approved";

                        message.IsBodyHtml = false;
                        SmtpClient smtp = new SmtpClient();
                        smtp.UseDefaultCredentials = false;
                        smtp.Host = "smtp.gmail.com";   //"smtp2.iitm.ac.in";
                        smtp.EnableSsl = true;
                        NetworkCredential NetworkCred = new NetworkCredential("saranyaashokk@gmail.com", "truediamonds");

                        smtp.Credentials = NetworkCred;
                        smtp.Port = 587;        //465
                        smtp.Send(message);
                    }
                        return Json(new { success = true, message = "Approved !" });
                }
                else if (Convert.ToInt32(dtApprove_Booking.Rows[0]["result"]) == iBooking_id)
                    return Json(new { success = true, message = "Approved already" });
                else //if (iApprove_Booking == 0)
                    return Json(new { success = false, message = "Cannot be approved" });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "Operation Failure" }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult Res_Info_popup(int iBooking_id)
        {
            try
            {
                List<reservationInfo> ls_res_info = hbl.ls_Reservation_Info(iBooking_id).ToList();
                reservationInfo _reservationInfo = ls_res_info.Single(x => x.reservationId == iBooking_id);
                return PartialView("Res_Info_popup", _reservationInfo);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        [HttpPost]
        public ActionResult view_info(int iBooking_id)
        {
            try
            {
                List<reservationInfo> ls_res_info = hbl.ls_Reservation_Info(iBooking_id).ToList();
                reservationInfo _reservationInfo = ls_res_info.Single(x => x.reservationId == iBooking_id);

                List<string> strArray = new List<string>() {
                        "Booking ID : " + ls_res_info[0].reservationId.ToString(),
                        "Reservation Type : " + ls_res_info[0].res_type.ToString(),
                        "Faculty : "  + ls_res_info[0].facultyName.ToString() + "(" +  ls_res_info[0].dd_deptName.ToString() + ")",
                         ls_res_info[0].fac_mobile_no.ToString() + " / " +  ls_res_info[0].fac_tele_no.ToString()+ " / " +  ls_res_info[0].fac_emailId.ToString(),
                         "Event Manager : " + ls_res_info[0].event_manager_name.ToString() ,
                          ls_res_info[0].EM_mobile_no.ToString() + " / " +  ls_res_info[0].EM_emailId.ToString()

                    };

                if(ls_res_info[0].collaborative_faculty != null)
                {
                    strArray.Add(
                        "Collaborative Faculty : " + ls_res_info[0].collaborative_faculty.ToString()                        
                        );
                    strArray.Add(ls_res_info[0].CFac_mobile_no.ToString() + " / " + ls_res_info[0].CFac_tele_no.ToString() + " / " + ls_res_info[0].CFac_emailId.ToString());
                }

                strArray.Add("Booking Amount : " + ls_res_info[0].reservation_amount.ToString());

                //List<string> ls = ls_res_info.Cast<string>().ToList();
                string output = string.Join(", ", strArray);
                return Json(new { success = true, data = output });
            }
            catch (Exception ex)
            {
                return null;
            }
        }

    }
}