using PrimarySchoolManagement.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimarySchoolManagement.DAL.Interfaces
{
    public interface ITeacherRepository
    {
        Task<List<Teacher>> GetAllAsync();

        Task<Teacher?> GetTeacherByIdAsync(int id);

        Task AddAsync(Teacher school);

        Task UpdateAsync(Teacher school);

        Task DeleteAsync(int id);

        //Task<List<Teacher>> GetFilterTeacherAsync(Func<Teacher, bool> filter);

        Task<List<Teacher>> FilterTeacherByName(string name);
    }
}
