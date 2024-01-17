using PrimarySchoolManagement.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimarySchoolManagement.BLL.Interfaces
{
    public interface IClassService
    {
        Task<List<Class>> GetClassesAsync();
        Task<Class> GetClassAsync(int id);
        Task AddClassAsync(Class @class);
        Task UpdateClassAsync(Class @class);
        //Task DeleteClassAsync(int id);
        Task<List<Class>> FilterClassAsyncByName(string name);
    }
}
