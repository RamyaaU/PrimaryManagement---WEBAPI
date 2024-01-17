using PrimarySchoolManagement.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimarySchoolManagement.DAL.Interfaces
{
    public interface ISchoolRepository
    {
        Task<List<School>> GetAllAsync();

        Task<School?> GetByIdAsync(int id);

        Task AddAsync(School school);

        Task UpdateAsync(School school);

        Task DeleteAsync(int id);

        Task<List<School>> FilterSchoolByName (string name);

        //Task<List<School>> GetFilteredSchoolsAsync(Func<School, bool> filter);
    }
}
