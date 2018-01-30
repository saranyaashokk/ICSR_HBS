using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer;
using DataLayer.ViewModels;
using System.Globalization;
using System.Configuration;
using System.Web.UI;
using System.Data;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Reflection;
using System.Net.Mime;


namespace HBS_System.Controllers
{
    public class BookHallController : Controller
    {
        HBBusinessLayer hbl = new HBBusinessLayer();

        // GET: BookHall

        [HttpGet]
        public ActionResult Search_Book()
        {
            HallVM hvm = new HallVM();
            hvm.halls = hbl.Get_HallNames();
            hvm.d_halls = hbl.Get_d_HallNames();
            hvm.d_slots = hbl.get_dining_slot();
            hvm.resTypeOptions = hbl.Get_reservationType();
            hvm.dd_deps = hbl.Get_faculty_departments();
            hvm.dd_cfac_deps = hbl.Get_faculty_departments();
            return View(hvm);
        }

        [HttpPost]
        [ActionName("Search_Book")]
        public ActionResult Search_Book(HallVM hallVM)
        {
            try
            {
                hallVM.halls = hbl.Get_HallNames();
                hallVM.d_halls = hbl.Get_d_HallNames();
                hallVM.d_slots = hbl.get_dining_slot();
                hallVM.resTypeOptions = hbl.Get_reservationType();
                hallVM.dd_deps = hbl.Get_faculty_departments();
                hallVM.dd_cfac_deps = hbl.Get_faculty_departments();

                TryUpdateModel(hallVM);


                hallVM.hallId = Convert.ToInt32(Session["fixed_hallId"] as String);
                hallVM.hallName = Session["fixed_hallName"] as String;
                hallVM.start_date = Convert.ToDateTime(Session["fixed_startDate"] as String);
                hallVM.end_date = Convert.ToDateTime(Session["fixed_endDate"] as String);
                hallVM.start_time = Session["fixed_startTime"] as String;
                hallVM.end_time = Session["fixed_endTime"] as String;
                hallVM.reservation_amount = Convert.ToInt32(Session["fixed_reservationAmount"]);
                // hallVM.StartDate_trim =(Session["fixed_startDate"] as String).Substring(0,10);


                if (ModelState.IsValid)
                {
                    DataTable dtBooking_result = hbl.AddReservation(hallVM);

                    if (dtBooking_result.Rows.Count == 1)
                    {
                        //send email notification
                        try
                        {
                            using (MailMessage message = new MailMessage("saranyaashokk@gmail.com", hallVM.fac_emailId)) //hallVM.fac_emailId))
                            {
                                message.Subject = "ICSR - Hall booking Notification";
                                message.Body = dtBooking_result.Rows[0]["facultyName"].ToString();

                                string sAttachment_name = string.Empty;

                                if (Convert.ToInt32(dtBooking_result.Rows[0]["res_typeId"]) == 1)
                                {
                                    sAttachment_name = "/Files_to_be_downloaded/Internal_Form.pdf";
                                }
                                else if (Convert.ToInt32(dtBooking_result.Rows[0]["res_typeId"]) == 2)
                                {
                                    sAttachment_name = "/Files_to_be_downloaded/External_Form.pdf";
                                }
                                else if (Convert.ToInt32(dtBooking_result.Rows[0]["res_typeId"]) == 3)
                                {
                                    sAttachment_name = "/Files_to_be_downloaded/Without_Charges_Form.pdf";
                                }

                                Attachment attach = new Attachment(Server.MapPath(sAttachment_name));
                                message.Attachments.Add(attach);

                                message.CC.Add(hallVM.EM_emailId);

                                if (hallVM.CFac_emailId != null)
                                {
                                    if (IsEmailValid(hallVM.CFac_emailId) == true)
                                        message.CC.Add(hallVM.CFac_emailId);
                                }
                                message.IsBodyHtml = false;
                                SmtpClient smtp = new SmtpClient();
                                smtp.UseDefaultCredentials = false;
                                smtp.Host = "smtp.gmail.com";   //"smtp2.iitm.ac.in";
                                smtp.EnableSsl = true;
                                NetworkCredential NetworkCred = new NetworkCredential("saranyaashokk@gmail.com", "truediamonds");

                                smtp.Credentials = NetworkCred;
                                smtp.Port = 587;        //465
                                smtp.Send(message);

                                ViewBag.Message = "Booking Initiated .. Kindly check your email for the form to be filled and submitted for approval";
                                ViewBag.alert = "success";

                                int iSend_email_log = hbl.email_log(Convert.ToInt32(dtBooking_result.Rows[0]["reservationId"]), message.From.ToString(),
                                    message.To.ToString(), "cc1", "cc2", "cc3", message.Subject, message.Body, sAttachment_name, 0);
                            }
                        }
                        catch (Exception ex)
                        {
                            ViewBag.Message = "Technical Error ! Kindly contact the concerned official of ICSR";
                            ViewBag.alert = "warning";
                        }
                    }
                    else
                    {
                        ViewBag.Message = "Sorry ! Booking failed . Check back for hall availability";
                        ViewBag.alert = "error";
                    }
                }
                else
                {
                    ViewData["iReserved_hall"] = 0;
                }
                return View(hallVM);
                //return Json(new { success = true, data = ViewBag.Message });
            }
            catch (Exception ex)
            {
                return View(hallVM);
            }
        }


        public ActionResult BookNow(HallVM hallVM)
        {
            ModelState.Clear();
            try
            {
                hallVM.halls = hbl.Get_HallNames();
                hallVM.d_halls = hbl.Get_d_HallNames();
                hallVM.d_slots = hbl.get_dining_slot();
                hallVM.resTypeOptions = hbl.Get_reservationType();
                hallVM.dd_deps = hbl.Get_faculty_departments();
                hallVM.dd_cfac_deps = hbl.Get_faculty_departments();



                hallVM.hallId = Convert.ToInt32(Session["fixed_hallId"] as String);
                hallVM.hallName = Session["fixed_hallName"] as String;
                hallVM.start_date = Convert.ToDateTime(Session["fixed_startDate"] as String);
                hallVM.end_date = Convert.ToDateTime(Session["fixed_endDate"] as String);
                hallVM.start_time = Session["fixed_startTime"] as String;
                hallVM.end_time = Session["fixed_endTime"] as String;
                hallVM.reservation_amount = Convert.ToInt32(Session["fixed_reservationAmount"]);
                // hallVM.StartDate_trim =(Session["fixed_startDate"] as String).Substring(0,10);


                TryUpdateModel(hallVM);

                string s = hallVM.start_date.ToString();

                if (ModelState.IsValid)
                {
                    DataTable dtBooking_result = hbl.AddReservation(hallVM);

                    if (dtBooking_result.Rows.Count == 1)
                    {
                        //send email notification
                        try
                        {
                            using (MailMessage message = new MailMessage("saranyaashokk@gmail.com", hallVM.fac_emailId)) //hallVM.fac_emailId))
                            {
                                message.Subject = "ICSR - Hall booking Notification";
                                message.Body = dtBooking_result.Rows[0]["facultyName"].ToString();

                                string sAttachment_name = string.Empty;

                                if (Convert.ToInt32(dtBooking_result.Rows[0]["res_typeId"]) == 1)
                                {
                                    sAttachment_name = "/Files_to_be_downloaded/Internal_Form.pdf";
                                }
                                else if (Convert.ToInt32(dtBooking_result.Rows[0]["res_typeId"]) == 2)
                                {
                                    sAttachment_name = "/Files_to_be_downloaded/External_Form.pdf";
                                }
                                else if (Convert.ToInt32(dtBooking_result.Rows[0]["res_typeId"]) == 3)
                                {
                                    sAttachment_name = "/Files_to_be_downloaded/Without_Charges_Form.pdf";
                                }

                                Attachment attach = new Attachment(Server.MapPath(sAttachment_name));
                                message.Attachments.Add(attach);

                                message.CC.Add(hallVM.EM_emailId);

                                if (hallVM.CFac_emailId != null)
                                {
                                    if (IsEmailValid(hallVM.CFac_emailId) == true)
                                        message.CC.Add(hallVM.CFac_emailId);
                                }
                                message.IsBodyHtml = false;
                                SmtpClient smtp = new SmtpClient();
                                smtp.UseDefaultCredentials = false;
                                smtp.Host = "smtp.gmail.com";   //"smtp2.iitm.ac.in";
                                smtp.EnableSsl = true;
                                NetworkCredential NetworkCred = new NetworkCredential("saranyaashokk@gmail.com", "truediamonds");

                                smtp.Credentials = NetworkCred;
                                smtp.Port = 587;        //465
                                smtp.Send(message);

                               // ViewBag.Message = "Booking Initiated .. Kindly check your email for the form to be filled and submitted for approval";

                                int iSend_email_log = hbl.email_log(Convert.ToInt32(dtBooking_result.Rows[0]["reservationId"]), message.From.ToString(),
                                    message.To.ToString(), "cc1", "cc2", "cc3", message.Subject, message.Body, sAttachment_name, 0);
                                return Json(new { success = true, title = "Booking Initiated", message = "Kindly check your email for the form to be filled and submitted for approval!" });
                            }
                        }

                        catch (Exception ex)
                        {
                            return Json(new { success = true, title = "Booking Initiated", message = "Kindly contact ICSR team if mail not received!" });
                        }
                    }
                    else
                    {
                        return Json(new { success = false, title = "Something went wrong" ,message = "Booking cannot be Initiated !" });
                    }
                }
                else
                {
                    return Json(new { success = false, title = "Something went wrong", message = "Booking cannot be Initiated !" });
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, title = "Something went wrong", message = "Kindly fill all the required fields !" });
            }
        }            


        public bool IsEmailValid(string cFacemailaddress)
        {
            try
            {
                MailAddress m = new MailAddress(cFacemailaddress);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        public ActionResult check_hallAvailability(string hallID, string hallName, string startDate, string startTime, string endDate, string endTime)
        {
            try
            {
                Session["fixed_hallId"] = hallID;
                Session["fixed_hallName"] = hallName;
                Session["fixed_startDate"] = startDate;
                Session["fixed_endDate"] = endDate;
                Session["fixed_startTime"] = startTime;
                Session["fixed_endTime"] = endTime;
                
                System.Threading.Thread.Sleep(200); 

                TimeSpan tsStart_time = DateTime.ParseExact(startTime, "hh:mm tt", CultureInfo.InvariantCulture).TimeOfDay;
                TimeSpan tsEnd_time = DateTime.ParseExact(endTime, "hh:mm tt", CultureInfo.InvariantCulture).TimeOfDay;
                DateTime dtStart = DateTime.ParseExact(startDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                DateTime dtEnd = DateTime.ParseExact(endDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);

                if ((dtStart != dtEnd) || (dtStart == dtEnd && tsStart_time < tsEnd_time))
                {
                    DataTable dtReservedHalls = hbl.HallAvailability(Convert.ToInt32(hallID), dtStart, tsStart_time, dtEnd, tsEnd_time);
                    Session["fixed_reservationAmount"] = Convert.ToInt32(dtReservedHalls.Rows[0]["reservation_amount"]);
                    ViewBag.payable_amount = Convert.ToInt32(dtReservedHalls.Rows[0]["reservation_amount"]);
                    if (Convert.ToInt32(dtReservedHalls.Rows[0]["approved_bookings"]) > 0)
                    {
                        var result = new { Result = "not_available", payable_amount = Convert.ToInt32(dtReservedHalls.Rows[0]["reservation_amount"]) };
                        return Json(result, JsonRequestBehavior.AllowGet);
                    }
                    else if (Convert.ToInt32(dtReservedHalls.Rows[0]["pending_approval_bookings"]) > 0)
                    {
                        var result = new { Result = "available_warn", payable_amount = Convert.ToInt32(dtReservedHalls.Rows[0]["reservation_amount"]) };
                        return Json(result, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        var result = new { Result = "available", payable_amount = Convert.ToInt32(dtReservedHalls.Rows[0]["reservation_amount"]) };
                        return Json(result, JsonRequestBehavior.AllowGet);
                    }                   
                }
                else
                {
                    var result = new { Result = "time_error" };
                    return Json(result);
                }
            }
            catch (Exception ex)
            {
                var result = new { Result = "error" };
                return Json(result);
            }
        }    

        public ActionResult sweet_alert()
        {
            return View();
        }
    }
}
