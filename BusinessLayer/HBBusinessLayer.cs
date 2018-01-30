using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web;
using System.Web.Mvc;
using DataLayer.Models;
using DataLayer.ViewModels;
using System.Globalization;

namespace BusinessLayer
{
    public class HBBusinessLayer
    {
        string sConn = ConfigurationManager.ConnectionStrings["HBDataModel"].ConnectionString;

        /// <summary>
        /// Gets hall names - this is used to populate dropdownlist
        /// </summary>
        /// <returns></returns>
        public List<SelectListItem> Get_HallNames()
        {            
            List<SelectListItem> hall = new List<SelectListItem>();
            using (SqlConnection con = new SqlConnection(sConn))
            {
                string sQuery = " select hallId, CONCAT(hallName, ' ' , '(', hall_capacity, ')') hallName from tbl_halls where hallStatusId = 1 order by display_order asc";
                using (SqlCommand cmd = new SqlCommand(sQuery))
                {
                    cmd.Connection = con;
                    con.Open();
                    SqlDataReader sdr = cmd.ExecuteReader();
                    while (sdr.Read())
                    {
                        hall.Add(new SelectListItem
                        {
                            Value = sdr["hallId"].ToString(),
                            Text = sdr["hallName"].ToString()
                        });
                    }
                }
            }
            return hall;
        }

        /// <summary>
        /// Gets dining hall names - this is used to populate dropdownlist
        /// </summary>
        /// <returns></returns>
        public List<SelectListItem> Get_d_HallNames()
        {
            List<SelectListItem> hall = new List<SelectListItem>();
            using (SqlConnection con = new SqlConnection(sConn))
            {
                string sQuery = " select d_hallId, CONCAT(d_hallName, ' ' , '(', d_hall_capacity, ')') d_hallName from tbl_dining_halls where hallStatusId = 1";
                using (SqlCommand cmd = new SqlCommand(sQuery))
                {
                    cmd.Connection = con;
                    con.Open();
                    SqlDataReader sdr = cmd.ExecuteReader();
                    while (sdr.Read())
                    {
                        hall.Add(new SelectListItem
                        {
                            Value = sdr["d_hallId"].ToString(),
                            Text = sdr["d_hallName"].ToString()
                        });
                    }
                }
            }
            return hall;
        }

        /// <summary>
        /// Gets dining hall slot - this is used to populate dropdownlist
        /// </summary>
        /// <returns></returns>
        public List<SelectListItem> get_dining_slot()
        {
            List<SelectListItem> hall = new List<SelectListItem>();
            using (SqlConnection con = new SqlConnection(sConn))
            {
                string sQuery = "select dining_slot_id, concat(dining_slot_name, ' (',  CONVERT(varchar(15),from_time,100) , ' to ',  CONVERT(varchar(15),to_time,100) , ')') dining_slot_name from tbl_mst_dininghall_slot";
                using (SqlCommand cmd = new SqlCommand(sQuery))
                {
                    cmd.Connection = con;
                    con.Open();
                    SqlDataReader sdr = cmd.ExecuteReader();
                    while (sdr.Read())
                    {
                        hall.Add(new SelectListItem
                        {
                            Value = sdr["dining_slot_id"].ToString(),
                            Text = sdr["dining_slot_name"].ToString()
                        });
                    }
                }
            }
            return hall;
        }


        /// <summary>
        /// Checking Hall availability - returns no of reservation already made for the particular time
        /// </summary>
        /// <param name="iHallId"></param>
        /// <param name="startDate"></param>
        /// <param name="startTime"></param>
        /// <param name="endDate"></param>
        /// <param name="endTime"></param>
        /// <returns></returns>

        public DataTable HallAvailability(int iHallId , DateTime startDate , TimeSpan startTime, DateTime endDate, TimeSpan endTime)
        {
            using (SqlConnection con = new SqlConnection(sConn))
            {
                SqlCommand cmd = new SqlCommand("sp_check_availability", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter paramHallId = new SqlParameter();
                paramHallId.ParameterName = "@hallId";
                paramHallId.Value = iHallId;// search.hallId;
                cmd.Parameters.Add(paramHallId);

                SqlParameter paramStartDate = new SqlParameter();
                paramStartDate.ParameterName = "@start_date";
                paramStartDate.Value = startDate; //search.start_date;
                cmd.Parameters.Add(paramStartDate);

                SqlParameter paramStartTime = new SqlParameter();
                paramStartTime.ParameterName = "@start_time";
                paramStartTime.Value = startTime; //search.start_date;
                cmd.Parameters.Add(paramStartTime);

                SqlParameter paramEndDate = new SqlParameter();
                paramEndDate.ParameterName = "@end_date";
                paramEndDate.Value = endDate; // search.end_date;
                cmd.Parameters.Add(paramEndDate);

                SqlParameter paramEndTime = new SqlParameter();
                paramEndTime.ParameterName = "@end_time";
                paramEndTime.Value = endTime; // search.end_date;
                cmd.Parameters.Add(paramEndTime);

                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                DataTable dtAvailable_bookings = new DataTable();
                da.Fill(dtAvailable_bookings);
                da.Dispose();
                return dtAvailable_bookings;
            }
        }
        /// <summary>
        /// Gets reservation Type names - this is used to populate dropdownlist
        /// </summary>
        /// <returns></returns>
        public List<SelectListItem> Get_reservationType()
        {
            List<SelectListItem> types = new List<SelectListItem>();
            using (SqlConnection con = new SqlConnection(sConn))
            {
                string sQuery = "select res_typeId, res_type, is_payment from tbl_mst_reservation_type";
                using (SqlCommand cmd = new SqlCommand(sQuery))
                {
                    cmd.Connection = con;
                    con.Open();
                    SqlDataReader sdr = cmd.ExecuteReader();
                    while (sdr.Read())
                    {
                        types.Add(new SelectListItem
                        {
                            Value = sdr["res_typeId"].ToString(),
                            Text = sdr["res_type"].ToString()
                        });
                    }
                }
            }
            return types;
        }

        /// <summary>
        /// Gets reservation Type names - this is used to populate dropdownlist
        /// </summary>
        /// <returns></returns>
        public List<SelectListItem> Get_faculty_departments()
        {
            List<SelectListItem> deps = new List<SelectListItem>();
            using (SqlConnection con = new SqlConnection(sConn))
            {
                string sQuery = "select deptId, deptName, deptCode from tbl_mst_dept_IIT where is_active = 1;";
                using (SqlCommand cmd = new SqlCommand(sQuery))
                {
                    cmd.Connection = con;
                    con.Open();
                    SqlDataReader sdr = cmd.ExecuteReader();
                    while (sdr.Read())
                    {
                        deps.Add(new SelectListItem
                        {
                            Value = sdr["deptId"].ToString(),
                            Text = sdr["deptCode"].ToString() + " " + "" + " " + sdr["deptName"].ToString()
                        });
                    }
                }
            }
            return deps;
        }

        public DataTable AddReservation(HallVM hallVM)
        {
            using (SqlConnection con = new SqlConnection(sConn))
            {
                SqlCommand cmd = new SqlCommand("sp_add_reservation", con);
                cmd.CommandType = CommandType.StoredProcedure;

                #region sqlparam

                SqlParameter paramHallId = new SqlParameter();
                paramHallId.ParameterName = "@hallId";
                paramHallId.Value = hallVM.hallId;
                cmd.Parameters.Add(paramHallId);

                SqlParameter paramResTypeId = new SqlParameter();
                paramResTypeId.ParameterName = "@res_typeId";
                paramResTypeId.Value = hallVM.res_typeId;
                cmd.Parameters.Add(paramResTypeId);

                SqlParameter paramStartDate = new SqlParameter();
                paramStartDate.ParameterName = "@start_date";
                paramStartDate.Value = hallVM.start_date; 
                cmd.Parameters.Add(paramStartDate);

                SqlParameter paramStartTime = new SqlParameter();
                paramStartTime.ParameterName = "@start_time";
                paramStartTime.Value = hallVM.start_time;
                cmd.Parameters.Add(paramStartTime);

                SqlParameter paramEndDate = new SqlParameter();
                paramEndDate.ParameterName = "@end_date";
                paramEndDate.Value = hallVM.end_date;
                cmd.Parameters.Add(paramEndDate);

                SqlParameter paramEndTime = new SqlParameter();
                paramEndTime.ParameterName = "@end_time";
                paramEndTime.Value = hallVM.end_time;
                cmd.Parameters.Add(paramEndTime);

                SqlParameter paramPrg_title = new SqlParameter();
                paramPrg_title.ParameterName = "@programme_title";
                paramPrg_title.Value = hallVM.programme_title;
                cmd.Parameters.Add(paramPrg_title);

                SqlParameter paramIscollaborative = new SqlParameter();
                paramIscollaborative.ParameterName = "@is_collaborative";
                paramIscollaborative.Value = hallVM.is_collaborative;
                cmd.Parameters.Add(paramIscollaborative);

                SqlParameter paramFac_name = new SqlParameter();
                paramFac_name.ParameterName = "@facultyName";
                paramFac_name.Value = hallVM.facultyName;
                cmd.Parameters.Add(paramFac_name);

                SqlParameter paramFac_depId = new SqlParameter();
                paramFac_depId.ParameterName = "@deptId";
                paramFac_depId.Value = hallVM.dd_fac_deptId;
                cmd.Parameters.Add(paramFac_depId);

                SqlParameter paramFac_tele = new SqlParameter();
                paramFac_tele.ParameterName = "@tele_no";
                paramFac_tele.Value = hallVM.fac_tele_no;
                cmd.Parameters.Add(paramFac_tele);

                SqlParameter paramFac_mobile = new SqlParameter();
                paramFac_mobile.ParameterName = "@mobile_no";
                paramFac_mobile.Value = hallVM.fac_mobile_no;
                cmd.Parameters.Add(paramFac_mobile);

                SqlParameter paramFac_email = new SqlParameter();
                paramFac_email.ParameterName = "@emailId";
                paramFac_email.Value = hallVM.fac_emailId;
                cmd.Parameters.Add(paramFac_email);

                SqlParameter param_em_name = new SqlParameter();
                param_em_name.ParameterName = "@event_manager_name";
                param_em_name.Value = hallVM.event_manager_name;
                cmd.Parameters.Add(param_em_name);

                SqlParameter param_em_mobile = new SqlParameter();
                param_em_mobile.ParameterName = "@em_mobile_no";
                param_em_mobile.Value = hallVM.EM_mobile_no;
                cmd.Parameters.Add(param_em_mobile);

                SqlParameter paramEm_email = new SqlParameter();
                paramEm_email.ParameterName = "@em_emailId";
                paramEm_email.Value = hallVM.EM_emailId;
                cmd.Parameters.Add(paramEm_email);

                SqlParameter paramCfac_name = new SqlParameter();
                paramCfac_name.ParameterName = "@collaborative_faculty";
                if (hallVM.collaborative_faculty == null)
                    paramCfac_name.Value = DBNull.Value;
                else
                    paramCfac_name.Value = hallVM.collaborative_faculty;
                cmd.Parameters.Add(paramCfac_name);

                SqlParameter paramCfac_depId = new SqlParameter();
                paramCfac_depId.ParameterName = "@cfac_deptId";
                if(hallVM.dd_cfac_deptId == null)
                    paramCfac_depId.Value = DBNull.Value;
                else
                    paramCfac_depId.Value = hallVM.dd_cfac_deptId;
                cmd.Parameters.Add(paramCfac_depId);

                SqlParameter paramCfac_tele = new SqlParameter();
                paramCfac_tele.ParameterName = "@cfac_tele_no";
                if(hallVM.CFac_tele_no == null)
                    paramCfac_tele.Value = DBNull.Value;
                else
                    paramCfac_tele.Value = hallVM.CFac_tele_no;
                cmd.Parameters.Add(paramCfac_tele);

                SqlParameter paramCfac_mobile = new SqlParameter();
                paramCfac_mobile.ParameterName = "@cfac_mobile_no";
                if(hallVM.CFac_mobile_no == null)
                    paramCfac_mobile.Value = DBNull.Value;
                else
                    paramCfac_mobile.Value = hallVM.CFac_mobile_no;
                cmd.Parameters.Add(paramCfac_mobile);

                SqlParameter paramCfac_email = new SqlParameter();
                paramCfac_email.ParameterName = "@cfac_emailId";
                if(hallVM.CFac_emailId == null)
                    paramCfac_email.Value = DBNull.Value;
                else
                    paramCfac_email.Value = hallVM.CFac_emailId;
                cmd.Parameters.Add(paramCfac_email);

#endregion                
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                DataTable dtBooking_result = new DataTable();
                da.Fill(dtBooking_result);
                da.Dispose();
                return dtBooking_result;
            }            
        }

        /// <summary>
        /// Logs the email sent details
        /// </summary>
        /// <param name="iReservation_id"></param>
        /// <param name="sFrom_mailId"></param>
        /// <param name="sTo_mailId"></param>
        /// <param name="sCc1_mail_id"></param>
        /// <param name="sCc12mail_id"></param>
        /// <param name="sCc3_mail_id"></param>
        /// <param name="sMail_subject"></param>
        /// <param name="sMail_body"></param>
        /// <param name="sAttachment_filename"></param>
        /// <param name="iIs_reminder_mail"></param>
        /// <returns></returns>
        public int email_log(int iReservation_id, string sFrom_mailId, string sTo_mailId, string sCc1_mail_id, string sCc2_mail_id, string sCc3_mail_id,
                    string sMail_subject, string sMail_body, string sAttachment_filename, int iIs_reminder_mail)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(sConn))
                {
                    SqlCommand cmd = new SqlCommand("sp_email_log", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    #region sqlparam

                    SqlParameter paramreservationId = new SqlParameter();
                    paramreservationId.ParameterName = "@reservationId";
                    paramreservationId.Value = iReservation_id;
                    cmd.Parameters.Add(paramreservationId);

                    SqlParameter paramFrom_mail = new SqlParameter();
                    paramFrom_mail.ParameterName = "@from_mailId";
                    paramFrom_mail.Value = sFrom_mailId;
                    cmd.Parameters.Add(paramFrom_mail);

                    SqlParameter paramTo_mail = new SqlParameter();
                    paramTo_mail.ParameterName = "@to_mailId";
                    paramTo_mail.Value = sTo_mailId;
                    cmd.Parameters.Add(paramTo_mail);

                    SqlParameter paramCC1_mail = new SqlParameter();
                    paramCC1_mail.ParameterName = "@cc1_mailId";
                    paramCC1_mail.Value = sCc1_mail_id;
                    cmd.Parameters.Add(paramCC1_mail);

                    SqlParameter paramCC2_mail = new SqlParameter();
                    paramCC2_mail.ParameterName = "@cc2_mailId";
                    paramCC2_mail.Value = sCc2_mail_id;
                    cmd.Parameters.Add(paramCC2_mail);

                    SqlParameter paramCC3_mail = new SqlParameter();
                    paramCC3_mail.ParameterName = "@cc3_mailId";
                    paramCC3_mail.Value = sCc3_mail_id;
                    cmd.Parameters.Add(paramCC3_mail);

                    SqlParameter paramMail_subject = new SqlParameter();
                    paramMail_subject.ParameterName = "@mail_subject";
                    paramMail_subject.Value = sMail_subject;
                    cmd.Parameters.Add(paramMail_subject);

                    SqlParameter paramMail_body = new SqlParameter();
                    paramMail_body.ParameterName = "@mail_body";
                    paramMail_body.Value = sMail_body;
                    cmd.Parameters.Add(paramMail_body);

                    SqlParameter paramAttachment = new SqlParameter();
                    paramAttachment.ParameterName = "@attachment_file_name";
                    paramAttachment.Value = sAttachment_filename;
                    cmd.Parameters.Add(paramAttachment);

                    SqlParameter paramIs_reminder = new SqlParameter();
                    paramIs_reminder.ParameterName = "@is_reminder";
                    paramIs_reminder.Value = iIs_reminder_mail;
                    cmd.Parameters.Add(paramIs_reminder);

                    #endregion

                    con.Open();
                    int i = Convert.ToInt32(cmd.ExecuteScalar());
                    return i;
                }
            }
            catch (Exception ex)
            {
                return 0;
            }
        }


        public IEnumerable<Admin_View_booking> bookings(DateTime? dtStart, DateTime? dtEnd)
        {
            try
            {
                using (HBDataModel hbd = new HBDataModel())
                {
                    List<Admin_View_booking> bookings_ls = hbd.Database.SqlQuery<Admin_View_booking>
                                    ("EXEC [dbo].[sp_booking_list]  {0}, {1}", dtStart, dtEnd).ToList();

                    return bookings_ls;
                }
            }
            catch(Exception ex)
            {
                return null;
            }
        }
        
        public int iRemove_booking(int iReservationId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(sConn))
                {
                    SqlCommand cmd = new SqlCommand("sp_delete_booking", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter paramReserId = new SqlParameter();
                    paramReserId.ParameterName = "@reservationId";
                    paramReserId.Value = iReservationId;
                    cmd.Parameters.Add(paramReserId);

                    con.Open();

                    int iDelete = Convert.ToInt32(cmd.ExecuteScalar());
                    return iDelete;
                }                
            }
            catch(Exception ex)
            {
                return 0;
            }
        }


        public IEnumerable<reservationInfo> ls_Reservation_Info(int iReservationId)
        {
            try
            {
                //using (SqlConnection con = new SqlConnection(sConn))
                //{
                //    SqlCommand cmd = new SqlCommand("sp_view_reservation_info", con);
                //    cmd.CommandType = CommandType.StoredProcedure;


                //    SqlParameter paramReservationId = new SqlParameter();
                //    paramReservationId.ParameterName = "@reservationId";
                //    paramReservationId.Value = iReservationId;
                //    cmd.Parameters.Add(paramReservationId);

                //    con.Open();
                //    SqlDataAdapter da = new SqlDataAdapter(cmd);

                //    DataTable dtRes_info = new DataTable();
                //    da.Fill(dtRes_info);
                //    da.Dispose();
                //    return dtRes_info;

                //}

                using (HBDataModel hbd = new HBDataModel())
                {
                    List<reservationInfo> res_info_ls = hbd.Database.SqlQuery<reservationInfo>
                                    ("EXEC [dbo].[sp_view_reservation_info]  {0}", iReservationId).ToList();

                    return res_info_ls;
                }

            }
            catch (Exception ex)
            {
                return null;
            }
        }


        /// <summary>
        /// approve booking
        /// </summary>
        /// <param name="iReservationId"></param>
        /// <returns></returns>
        public DataTable dtApprove_booking(int iReservationId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(sConn))
                {
                    SqlCommand cmd = new SqlCommand("sp_approve_booking", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter paramReserId = new SqlParameter();
                    paramReserId.ParameterName = "@reservationId";
                    paramReserId.Value = iReservationId;
                    cmd.Parameters.Add(paramReserId);

                    con.Open();

                    SqlDataAdapter da = new SqlDataAdapter(cmd);

                    DataTable dtApprove = new DataTable();
                    da.Fill(dtApprove);
                    da.Dispose();
                    return dtApprove;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public IEnumerable<login> lsLogin(string sUserName, string sPassword)
        {
            try
            {
                using (HBDataModel hbd = new HBDataModel())
                {
                    List<login> ls_login =
                        hbd.Database.SqlQuery<login>
                                 ("EXEC [dbo].[sp_login]  {0}, {1}", sUserName, sPassword).ToList();
                    return ls_login;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
