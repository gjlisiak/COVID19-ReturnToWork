﻿using System;
using System.Data;
using System.Threading.Tasks;
using BackToWorkFunctions.Model;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace BackToWorkFunctions.Helper
{
    public class DbHelper
    {
        //for data insertion write condition to check if data for that user exist or not
        public static async Task<bool> PostDataAsync<T>(T model, string ops)
        {
            string sqlStr = null;
            switch (ops)
            {
                case Constants.postUserInfo:
                    var conStr = Environment.GetEnvironmentVariable("SqlConnectionString", EnvironmentVariableTarget.Process);
                    try
                    {
                        using (var conn = new SqlConnection(conStr))
                        {
                            string spName = @"dbo.[PostUserInfo]";
                            SqlCommand cmd = new SqlCommand(spName, conn);
                            cmd.CommandType = CommandType.StoredProcedure;

                            cmd.Parameters.Add("@UserId", SqlDbType.VarChar).Value = typeof(T).GetProperty("UserId").GetValue(model);
                            cmd.Parameters.Add("@UserGUID", SqlDbType.VarChar).Value = typeof(T).GetProperty("UserGUID").GetValue(model);
                            cmd.Parameters.Add("@Password", SqlDbType.VarChar).Value = typeof(T).GetProperty("Password").GetValue(model);
                            cmd.Parameters.Add("@FirstName", SqlDbType.VarChar).Value = typeof(T).GetProperty("FirstName").GetValue(model);
                            cmd.Parameters.Add("@LastName", SqlDbType.VarChar).Value = typeof(T).GetProperty("LastName").GetValue(model);
                            cmd.Parameters.Add("@FullName", SqlDbType.VarChar).Value = typeof(T).GetProperty("FullName").GetValue(model);
                            cmd.Parameters.Add("@Role", SqlDbType.VarChar).Value = typeof(T).GetProperty("Role").GetValue(model);
                            cmd.Parameters.Add("@YearOfBirth", SqlDbType.VarChar).Value = typeof(T).GetProperty("YearOfBirth").GetValue(model);
                            cmd.Parameters.Add("@MobileNumber", SqlDbType.VarChar).Value = typeof(T).GetProperty("MobileNumber").GetValue(model);
                            cmd.Parameters.Add("@EmailAddress", SqlDbType.VarChar).Value = typeof(T).GetProperty("EmailAddress").GetValue(model);
                            cmd.Parameters.Add("@StreetAddress1", SqlDbType.VarChar).Value = typeof(T).GetProperty("StreetAddress1").GetValue(model);
                            cmd.Parameters.Add("@StreetAddress2", SqlDbType.VarChar).Value = typeof(T).GetProperty("StreetAddress2").GetValue(model);
                            cmd.Parameters.Add("@City", SqlDbType.VarChar).Value = typeof(T).GetProperty("City").GetValue(model);
                            cmd.Parameters.Add("@State", SqlDbType.VarChar).Value = typeof(T).GetProperty("State").GetValue(model);
                            cmd.Parameters.Add("@Country", SqlDbType.VarChar).Value = typeof(T).GetProperty("Country").GetValue(model);
                            cmd.Parameters.Add("@ZipCode", SqlDbType.VarChar).Value = typeof(T).GetProperty("ZipCode").GetValue(model);
                            cmd.Parameters.Add("@TeamsAddress", SqlDbType.VarChar).Value = typeof(T).GetProperty("TeamsAddress").GetValue(model);
                            cmd.Parameters.Add("@TwilioAddress", SqlDbType.VarChar).Value = typeof(T).GetProperty("TwilioAddress").GetValue(model);
                            cmd.Parameters.Add("@RequestBTWEmail", SqlDbType.VarChar).Value = typeof(T).GetProperty("RequestBTWEmail").GetValue(model);
                            cmd.Parameters.Add("@RequestBTWMobile", SqlDbType.VarChar).Value = typeof(T).GetProperty("RequestBTWMobile").GetValue(model);

                            conn.Open();
                            cmd.ExecuteNonQuery();
                            conn.Close();                            
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        return false;
                    }
                    break;

                case Constants.postLabTestInfo:
                    sqlStr = "Insert into [dbo].[LabTestInfo]" +
                        "([UserId], " +
                        "[DateOfEntry], " +
                        "[TestType], " +
                        "[TestDate], " +
                        "[TestResult]) " +
                        "values" +
                        "('" + typeof(T).GetProperty("UserId").GetValue(model) + "'," +
                        "'" + typeof(T).GetProperty("DateOfEntry").GetValue(model) + "'," +
                        "'" + typeof(T).GetProperty("TestType").GetValue(model) + "', " +
                        "'" + typeof(T).GetProperty("TestDate").GetValue(model) + "', " +
                        "'" + typeof(T).GetProperty("TestResult").GetValue(model) + "')";
                    break;

                case Constants.postRequestStatus:
                    sqlStr = "Insert into [dbo].[RequestStatus] " +
                        "([UserId], " +
                        "[DateOfEntry], " +
                        "[  ]) " +
                        "values" +
                        "('" + typeof(T).GetProperty("UserId").GetValue(model) + "'," +
                        "'" + typeof(T).GetProperty("DateOfEntry").GetValue(model) + "', " +
                        "'" + typeof(T).GetProperty("ReturnRequestStatus").GetValue(model) + "')";
                    break;

                case Constants.postSymptomsInfo:
                    sqlStr = "Insert into[dbo].[SymptomsInfo] " +
                        "([UserId], " +
                        "[DateOfEntry], " +
                        "[UserIsExposed], " +
                        "[ExposureDate], " +
                        "[IsSymptomatic], " +
                        "[SymptomFever], " +
                        "[SymptomCough], " +
                        "[SymptomShortnessOfBreath], " +
                        "[SymptomChills], " +
                        "[SymptomMusclePain], " +
                        "[SymptomSoreThroat], " +
                        "[SymptomLossOfSmellTaste], " +
                        "[SymptomVomiting], " +
                        "[SymptomDiarrhea], " +
                        "[Temperature], " +
                        "[UserIsSymptomatic], " +
                        "[ClearToWorkToday], " +
                        "[GUID]) " +
                        "values" +
                        "('" + typeof(T).GetProperty("UserId").GetValue(model) + "', " +
                        "'" + typeof(T).GetProperty("DateOfEntry").GetValue(model) + "', " +
                        "'" + typeof(T).GetProperty("UserIsExposed").GetValue(model) + "', " +
                        "'" + typeof(T).GetProperty("ExposureDate").GetValue(model) + "', " +
                        "'" + typeof(T).GetProperty("IsSymptomatic").GetValue(model) + "', " +
                        "'" + typeof(T).GetProperty("SymptomFever").GetValue(model) + "', " +
                        "'" + typeof(T).GetProperty("SymptomCough").GetValue(model) + "', " +
                        "'" + typeof(T).GetProperty("SymptomShortnessOfBreath").GetValue(model) + "', " +
                        "'" + typeof(T).GetProperty("SymptomChills").GetValue(model) + "', " +
                        "'" + typeof(T).GetProperty("SymptomMusclePain").GetValue(model) + "', " +
                        "'" + typeof(T).GetProperty("SymptomSoreThroat").GetValue(model) + "', " +
                        "'" + typeof(T).GetProperty("SymptomLossOfSmellTaste").GetValue(model) + "', " +
                        "'" + typeof(T).GetProperty("SymptomVomiting").GetValue(model) + "', " +
                        "'" + typeof(T).GetProperty("SymptomDiarrhea").GetValue(model) + "', " +
                        "'" + typeof(T).GetProperty("Temperature").GetValue(model) + "', " +
                        "'" + typeof(T).GetProperty("UserIsSymptomatic").GetValue(model) + "', " +
                        "'" + typeof(T).GetProperty("ClearToWorkToday").GetValue(model) + "', " +
                        "'" + typeof(T).GetProperty("GUID").GetValue(model) + "')";
                    break;
            }            
            return true;
        }        

        public static async Task<T> GetDataAsync<T>(string ops, string paramString)
        {
            var conStr = Environment.GetEnvironmentVariable("SqlConnectionString", EnvironmentVariableTarget.Process);

            switch (ops)
            {
                case Constants.getUserInfo:                    
                    UserInfo userInfo = new UserInfo();
                    using (SqlConnection conn = new SqlConnection(conStr))
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand("GetUserInfo", conn);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@UserId", paramString));
                        SqlDataReader reader = cmd.ExecuteReader();

                        if (reader != null)
                        {
                            while (reader.Read())
                            {
                                userInfo.UserId = reader["UserId"].ToString();
                                userInfo.UserGUID = reader["UserGUID"].ToString();
                                userInfo.Password = reader["Password"].ToString();
                                userInfo.FirstName = reader["FirstName"].ToString();
                                userInfo.LastName = reader["LastName"].ToString();
                                userInfo.FullName = reader["FullName"].ToString();
                                userInfo.Role = reader["Role"].ToString();
                                userInfo.YearOfBirth = (int)reader["YearOfBirth"];
                                userInfo.MobileNumber = reader["MobileNumber"].ToString();
                                userInfo.EmailAddress = reader["EmailAddress"].ToString();
                                userInfo.StreetAddress1 = reader["StreetAddress1"].ToString();
                                userInfo.StreetAddress2 = reader["StreetAddress2"].ToString();
                                userInfo.City = reader["City"].ToString();
                                userInfo.State = reader["State"].ToString();
                                userInfo.Country = reader["Country"].ToString();
                                userInfo.ZipCode = reader["ZipCode"].ToString();
                                userInfo.TeamsAddress = reader["TeamsAddress"].ToString();
                                userInfo.TwilioAddress = reader["TwilioAddress"].ToString();
                                userInfo.RequestBTWEmail = reader["RequestBTWEmail"].ToString();
                                userInfo.RequestBTWMobile = reader["RequestBTWMobile"].ToString();
                            }
                        }
                        reader.Close();
                        conn.Close();
                        return (T)Convert.ChangeType(userInfo, typeof(T));
                    }                    

                case Constants.getLabTestInfo:
                    List<LabTestInfo> lstlabTestInfo = new List<LabTestInfo>();
                    using (SqlConnection conn = new SqlConnection(conStr))
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand("GetLabTestInfo", conn);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@UserId", paramString));
                        SqlDataReader reader = cmd.ExecuteReader();

                        if (reader != null)
                        {
                            while (reader.Read())
                            {
                                LabTestInfo labTestInfo = new LabTestInfo();
                                labTestInfo.UserId = reader["UserId"].ToString();
                                labTestInfo.DateOfEntry = reader["DateOfEntry"].ToString();
                                labTestInfo.TestType = reader["TestType"].ToString();
                                labTestInfo.TestDate = reader["TestDate"].ToString();
                                labTestInfo.TestResult = reader["TestResult"].ToString();
                                lstlabTestInfo.Add(labTestInfo);
                            }
                        }
                        return (T)Convert.ChangeType(lstlabTestInfo, typeof(T));
                    }

                case Constants.getRequestStatus:
                    List<RequestStatus> lstrequestStatus = new List<RequestStatus>();
                    using (SqlConnection conn = new SqlConnection(conStr))
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand("GetRequestStatus", conn);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@UserId", paramString));
                        SqlDataReader reader = cmd.ExecuteReader();

                        if (reader != null)
                        {
                            while (reader.Read())
                            {
                                RequestStatus requestStatus = new RequestStatus();
                                requestStatus.UserId = reader["UserId"].ToString();
                                requestStatus.DateOfEntry = reader["DateOfEntry"].ToString();
                                requestStatus.ReturnRequestStatus = reader["ReturnRequestStatus"].ToString();
                                lstrequestStatus.Add(requestStatus);
                            }
                        }
                        return (T)Convert.ChangeType(lstrequestStatus, typeof(T));
                    }

                default:
                    List<SymptomsInfo> lstsymptomsInfo = new List<SymptomsInfo>();

                    using (SqlConnection conn = new SqlConnection(conStr))
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand("GetSymptomsInfo", conn);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@UserId", paramString));
                        SqlDataReader reader = cmd.ExecuteReader();

                        if (reader != null)
                        {
                            while (reader.Read())
                            {
                                SymptomsInfo symptomsInfo = new SymptomsInfo();
                                symptomsInfo.UserId = reader["UserId"].ToString();
                                symptomsInfo.DateOfEntry = reader["DateOfEntry"].ToString();
                                symptomsInfo.UserIsExposed = DBNull.Value.Equals(reader["UserIsExposed"]) ? false : (bool)reader["UserIsExposed"];
                                symptomsInfo.ExposureDate = reader["ExposureDate"].ToString();
                                symptomsInfo.IsSymptomatic = DBNull.Value.Equals(reader["IsSymptomatic"]) ? false : (bool)reader["IsSymptomatic"];
                                symptomsInfo.SymptomFever = DBNull.Value.Equals(reader["SymptomFever"]) ? false : (bool)reader["SymptomFever"];
                                symptomsInfo.SymptomCough = DBNull.Value.Equals(reader["SymptomCough"]) ? false : (bool)reader["SymptomCough"];
                                symptomsInfo.SymptomShortnessOfBreath = DBNull.Value.Equals(reader["SymptomShortnessOfBreath"]) ? false : (bool)reader["SymptomShortnessOfBreath"];
                                symptomsInfo.SymptomChills = DBNull.Value.Equals(reader["SymptomChills"]) ? false : (bool)reader["SymptomChills"];
                                symptomsInfo.SymptomMusclePain = DBNull.Value.Equals(reader["SymptomMusclePain"]) ? false : (bool)reader["SymptomMusclePain"];
                                symptomsInfo.SymptomSoreThroat = DBNull.Value.Equals(reader["SymptomSoreThroat"]) ? false : (bool)reader["SymptomSoreThroat"];
                                symptomsInfo.SymptomLossOfSmellTaste = DBNull.Value.Equals(reader["SymptomLossOfSmellTaste"]) ? false : (bool)reader["SymptomLossOfSmellTaste"];
                                symptomsInfo.SymptomVomiting = DBNull.Value.Equals(reader["SymptomVomiting"]) ? false : (bool)reader["SymptomVomiting"];
                                symptomsInfo.SymptomDiarrhea = DBNull.Value.Equals(reader["SymptomDiarrhea"]) ? false : (bool)reader["SymptomDiarrhea"];
                                symptomsInfo.Temperature = DBNull.Value.Equals(reader["Temperature"]) ? 0 : (decimal)reader["Temperature"];
                                symptomsInfo.UserIsSymptomatic = DBNull.Value.Equals(reader["UserIsSymptomatic"]) ? false : (bool)reader["UserIsSymptomatic"];
                                symptomsInfo.ClearToWorkToday = DBNull.Value.Equals(reader["ClearToWorkToday"]) ? false : (bool)reader["ClearToWorkToday"];
                                symptomsInfo.GUID = reader["GUID"].ToString();
                                lstsymptomsInfo.Add(symptomsInfo);
                            }
                        }
                        return (T)Convert.ChangeType(lstsymptomsInfo, typeof(T));
                    }
            }
        }

        public static async Task<bool> GetTeamsAddress(List<TeamsAddressQuarantineInfo> teamsAddressQuarantineInfoCollector)
        {
            var conStr = Environment.GetEnvironmentVariable("SqlConnectionString", EnvironmentVariableTarget.Process);

            using (SqlConnection conn = new SqlConnection(conStr))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("GetAllTeamsAddress", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader != null)
                {
                    while (reader.Read())
                    {
                        TeamsAddressQuarantineInfo teamsAddressQuarantineInfo = new TeamsAddressQuarantineInfo();
                        teamsAddressQuarantineInfo.UserId = reader["UserId"].ToString();
                        teamsAddressQuarantineInfo.TeamsAddress = reader["TeamsAddress"].ToString();
                        teamsAddressQuarantineInfoCollector.Add(teamsAddressQuarantineInfo);
                    }
                    return true;
                }
                return false;
            }
        }

        public static async Task<bool> GetUserContactInfo(List<UserContactInfo> userContactInfoCollector)
        {
            var conStr = Environment.GetEnvironmentVariable("SqlConnectionString", EnvironmentVariableTarget.Process);

            using (SqlConnection conn = new SqlConnection(conStr))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("GetAllUsersContactInfo", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader != null)
                {
                    while (reader.Read())
                    {
                        UserContactInfo userContactInfo = new UserContactInfo();
                        userContactInfo.UserId = reader["UserId"].ToString();
                        userContactInfo.FullName = reader["FullName"].ToString();
                        userContactInfo.EmailAddress = reader["EmailAddress"].ToString();
                        userContactInfo.MobilePhone = reader["MobileNumber"].ToString();
                        userContactInfoCollector.Add(userContactInfo);
                    }
                    return true;
                }
                return false;
            }
        }
    }
}
