using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimarySchoolManagement.Data
{
    public class Class
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string GradeLevel { get; set; }

        public string ClassTeacher { get; set; }

        public bool IsDeleted { get; set; }
    }
}