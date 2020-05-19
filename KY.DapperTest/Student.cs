using System;
using System.Collections.Generic;
using System.Text;
using Dapper;


namespace KY.DapperTest
{
    public class Student
    {
        public int Student_id { get; set; }
        public string  Name { get; set; }
     
        public bool Teacher_id { get; set; }
    }
}
