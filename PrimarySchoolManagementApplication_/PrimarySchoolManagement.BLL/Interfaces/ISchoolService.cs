using PrimarySchoolManagement.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimarySchoolManagement.BLL.Interfaces
{
    public interface ISchoolService
    {
        Task<List<School>> GetSchoolsAsync();
        Task<School> GetSchoolAsync(int id);
        Task AddSchoolAsync(School school);
        Task UpdateSchoolAsync(School school);
        Task DeleteSchoolAsync(int id);
        //Task<List<School>> GetFilteredSchoolsAsync(Func<School, bool> filter);

        Task<List<School>> FilterSchoolAsyncByName(string name);
    }
}