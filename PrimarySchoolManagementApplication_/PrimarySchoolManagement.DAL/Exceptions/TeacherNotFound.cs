using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimarySchoolManagement.DAL.Exceptions
{
    public class TeacherNotFound : Exception
    {
        public TeacherNotFound(string message) : base(message)
        {

        }
    }
}
