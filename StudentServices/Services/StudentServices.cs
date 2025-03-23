using Microsoft.VisualBasic;
using System.ComponentModel;
using System.Data;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Security;
using Models.Shared;
using StudentServices.Class;
using Models.Shared;




namespace StudentServices.Services
{
    public class StudentsServices
    {
        private readonly AppDb _constring;

        public StudentsServices(AppDb appDb)
        {
            _constring = appDb;
        }
        public async Task<List<Students>> StudentsList()
        {

            List<Students> lst = new();

            using (var con = new MySqlConnection(_constring.GetConnnection()))
            {


                try
                {
                    await con.OpenAsync().ConfigureAwait(false);

                    var com = new MySqlCommand("Sproc_StudentList", con)
                    {

                        CommandType = CommandType.StoredProcedure

                    };
                    com.Parameters.Clear();

                    var rdr = await com.ExecuteReaderAsync().ConfigureAwait(false);

                    while (await rdr.ReadAsync().ConfigureAwait(false))
                    {

                        lst.Add(new Students
                        {
                            ID = rdr["ID"].ToString(),
                            date = Convert.ToDateTime(rdr["date"]),
                            StudentID = rdr["StudentID"].ToString(),
                            category = rdr["category"].ToString(),
                            course = rdr["course"].ToString(),
                            lrn = rdr["lrn"].ToString(),
                            yearlevel = rdr["yearlevel"].ToString(),
                            Year = rdr["Year"].ToString(),
                            EnrolmentStatus = rdr["EnrolmentStatus"].ToString(),
                            Semester = rdr["Semester"].ToString(),
                            lname = rdr["lname"].ToString(),
                            fname = rdr["fname"].ToString(),
                            middlename = rdr["middlename"].ToString(),
                            ext = rdr["ext"].ToString(),
                            gender = rdr["gender"].ToString(),
                            bdate = Convert.ToDateTime(rdr["bdate"]),
                            email = rdr["email"].ToString(),
                            address = rdr["address"].ToString(),
                            contactNo = rdr["contactNo"].ToString(),
                            Guardian = rdr["Guardian"].ToString(),
                            Gaddress = rdr["Gaddress"].ToString(),
                            GConcactNo = rdr["GConcactNo"].ToString(),
                            preenrolled = Convert.ToBoolean(rdr["preenrolled"]),
                            note = rdr["note"].ToString(),
                   



                        });
                    }
                    await rdr.CloseAsync().ConfigureAwait(false);
                }
                catch (Exception ex)
                {

                }
                finally { await con.CloseAsync().ConfigureAwait(false); }
                return lst;
            }
        }



        public async Task<List<Students>> StudentsSearch(string data)
        {

            List<Students> lst = new();

            using (var con = new MySqlConnection(_constring.GetConnnection()))
            {


                try
                {
                    await con.OpenAsync().ConfigureAwait(false);

                    var com = new MySqlCommand("sproc_StudentsSearch", con)
                    {

                        CommandType = CommandType.StoredProcedure

                    };
                    com.Parameters.Clear();

                    com.Parameters.AddWithValue("P_DATA" , data);

                    var rdr = await com.ExecuteReaderAsync().ConfigureAwait(false);

                    while (await rdr.ReadAsync().ConfigureAwait(false))
                    {

                        lst.Add(new Students
                        {
                            ID = rdr["ID"].ToString(),
                            date = Convert.ToDateTime(rdr["date"]),
                            StudentID = rdr["StudentID"].ToString(),
                            category = rdr["category"].ToString(),
                            course = rdr["course"].ToString(),
                            lrn = rdr["lrn"].ToString(),
                            yearlevel = rdr["yearlevel"].ToString(),
                            Year = rdr["Year"].ToString(),
                            EnrolmentStatus = rdr["EnrolmentStatus"].ToString(),
                            Semester = rdr["Semester"].ToString(),
                            lname = rdr["lname"].ToString(),
                            fname = rdr["fname"].ToString(),
                            middlename = rdr["middlename"].ToString(),
                            ext = rdr["ext"].ToString(),
                            gender = rdr["gender"].ToString(),
                            bdate = Convert.ToDateTime(rdr["bdate"]),
                            email = rdr["email"].ToString(),
                            address = rdr["address"].ToString(),
                            contactNo = rdr["contactNo"].ToString(),
                            Guardian = rdr["Guardian"].ToString(),
                            Gaddress = rdr["Gaddress"].ToString(),
                            GConcactNo = rdr["GConcactNo"].ToString(),
                            preenrolled = Convert.ToBoolean(rdr["preenrolled"]),
                            note = rdr["note"].ToString(),
                         



                        });
                    }
                    await rdr.CloseAsync().ConfigureAwait(false);
                }
                catch (Exception ex)
                {

                }
                finally { await con.CloseAsync().ConfigureAwait(false); }
                return lst;
            }
        }


        public async Task<int> StudentsSave(Students s)
        {
           

            int i = 0;

            using (var con = new MySqlConnection(_constring.GetConnnection()))
            {
         

                try
                {
                    await con.OpenAsync().ConfigureAwait(false);

                    var com = new MySqlCommand("sproc_StudentSave", con)
                    {

                        CommandType = CommandType.StoredProcedure

                    };
                    com.Parameters.Clear();

                    com.Parameters.AddWithValue("pID", s.ID);
                    com.Parameters.AddWithValue("pdate", s.date);
                    com.Parameters.AddWithValue("pStudentID", s.StudentID);
                    com.Parameters.AddWithValue("pcategory", s.category);
                    com.Parameters.AddWithValue("pcourse", s.course);

                    com.Parameters.AddWithValue("plrn", s.lrn);
                    com.Parameters.AddWithValue("pyearlevel", s.yearlevel);
                    com.Parameters.AddWithValue("pYear", s.Year);
                    com.Parameters.AddWithValue("pEnrolmentStatus", s.EnrolmentStatus);
                    com.Parameters.AddWithValue("pSemester", s.Semester);

                    com.Parameters.AddWithValue("plname", s.lname);
                    com.Parameters.AddWithValue("pfname", s.fname);
                    com.Parameters.AddWithValue("pmiddlename", s.middlename);
                    com.Parameters.AddWithValue("pext", s.ext);
                    com.Parameters.AddWithValue("pgender", s.gender);

                    com.Parameters.AddWithValue("pbdate", s.bdate);
                    com.Parameters.AddWithValue("pemail", s.email);
                    com.Parameters.AddWithValue("paddress", s.address);
                    com.Parameters.AddWithValue("pcontactNo", s.contactNo);
                    com.Parameters.AddWithValue("pGuardian", s.Guardian);

                    com.Parameters.AddWithValue("pGaddress", s.address);
                    com.Parameters.AddWithValue("pGConcactNo", s.GConcactNo);
                    com.Parameters.AddWithValue("ppreenrolled", s.preenrolled);
                    com.Parameters.AddWithValue("pnote", s.note);


                   i = com.ExecuteNonQuery();
                }
                catch (Exception ex)
                {

                }
                finally { await con.CloseAsync().ConfigureAwait(false); }
                return i;
            }
        }



        public async Task<int> StudentsDelete(string s)
        {
            int i = 0;

            using (var con = new MySqlConnection(_constring.GetConnnection()))
            {
                try
                {
                    await con.OpenAsync().ConfigureAwait(false);

                    var com = new MySqlCommand("Stored_Delete", con)
                    {

                        CommandType = CommandType.StoredProcedure

                    };
                    com.Parameters.Clear();

                    com.Parameters.AddWithValue("PID", s);
                


                    i = com.ExecuteNonQuery();
                }
                catch (Exception ex)
                {

                }
                finally { await con.CloseAsync().ConfigureAwait(false); }
                return i;
            }
        }
    }


}




