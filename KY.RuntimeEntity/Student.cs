using System;
using System.Collections.Generic;
using System.Text;

namespace KY.RuntimeEntity
{
    public class Student
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public IEnumerable<Teacher> teacher { get; set; } = new List<Teacher>();
    }
}
