using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimarySchoolManagement.DAL.Exceptions
{
    public class SchoolNotFound : Exception
    {
        public SchoolNotFound(string message) : base(message)
        {

        }
    }
}
