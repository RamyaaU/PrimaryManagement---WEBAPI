using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimarySchoolManagement.DAL.Exceptions
{
    public  class ClassNotFound : Exception
    {
        public ClassNotFound(string message) : base(message)
        {

        }
    }
}
