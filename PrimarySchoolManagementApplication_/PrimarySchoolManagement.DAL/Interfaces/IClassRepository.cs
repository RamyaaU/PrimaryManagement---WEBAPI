using PrimarySchoolManagement.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimarySchoolManagement.DAL.Interfaces
{
    public interface IClassRepository
    {
        Task<List<Class>> GetAllAsync();

        Task<Class?> GetByIdAsync(int id);

        Task AddAsync(Class @class);

        Task UpdateAsync(Class @class);

        //Task DeleteAsync(int id);

        Task<List<Class>> FilterClassByName(string name);
    }
}
