using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimarySchoolManagement.DAL.Exceptions
{
    public class DivisionNotFound : Exception
    {
        public DivisionNotFound(string message) : base(message) 
        {
                
        }
    }
}
