using PrimarySchoolManagement.BLL.Exceptions;
using PrimarySchoolManagement.BLL.Interfaces;
using PrimarySchoolManagement.DAL.Interfaces;
using PrimarySchoolManagement.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimarySchoolManagement.BLL
{
    public class SchoolService : ISchoolService
    {
        private readonly ISchoolRepository _schoolRepository;

        public SchoolService(ISchoolRepository schoolRepository)
        {
            _schoolRepository = schoolRepository;
        }

        public Task<List<School>> GetSchoolsAsync()
        {
            return _schoolRepository.GetAllAsync();
        }

        public async Task<School> GetSchoolAsync(int id)
        {
            var school = await _schoolRepository.GetByIdAsync(id);

            if (school == null)

                throw new NotFoundException("School not found.");

            return school;
        }

        public Task AddSchoolAsync(School school)
        {
            return _schoolRepository.AddAsync(school);
        }

        public Task UpdateSchoolAsync(School school)
        {
            return _schoolRepository.UpdateAsync(school);
        }

        public Task DeleteSchoolAsync(int id)
        {
            return _schoolRepository.DeleteAsync(id);
        }

        //public Task<List<School>> GetFilteredSchoolsAsync(Func<School, bool> filter)
        //{
        //    return _schoolRepository.GetFilteredSchoolsAsync(filter);
        //}

        public async Task<List<School>> FilterSchoolAsyncByName(string name)
        {
            var s = await _schoolRepository.GetAllAsync();
            return s.Where(s=> s.Name.Contains(name, StringComparison.OrdinalIgnoreCase)).ToList();
        }
    }
}
