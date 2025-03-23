using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Shared
{
    public class Students
    {
        public string ID { get; set; }

        public DateTime date { get; set; }

        public string StudentID { get; set; }

        public string category { get; set; } = "";

        public string course { get; set; } = "";

        public string lrn { get; set; } = "";

        public string yearlevel { get; set; } = "";

        public string Year { get; set; } = "";

        public string EnrolmentStatus { get; set; }

        public string Semester { get; set; } = "";

        public string lname { get; set; } = "";

        public string fname { get; set; } = "";

        public string middlename { get; set; } = "";

        public string ext { get; set; } = "";

        public string gender { get; set; } = "";

        public DateTime bdate { get; set; }

        public string email { get; set; } = "";

        public string address { get; set; } = "";

        public string contactNo { get; set; } = "";

        public string Guardian { get; set; } = "";

        public string Gaddress { get; set; } = "";

        public string GConcactNo { get; set; } = "";

        public bool preenrolled { get; set; } = true;

        public string note { get; set; } = "";



        string fllname;

        public string fullname
        {
            get 
            {
                if (middlename != " ")
                {
                    fllname = $"{lname},{fname}  {middlename.Substring(0, 1)}. {ext}";
                }
                else
                {
                    fllname = $"{lname},{fname}";
                }

               
                return fllname;
             
            }
            set 
            
            {
                fllname = value; 
            }
        }
    }
}
