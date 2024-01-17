using PrimarySchoolManagement.BLL.Exceptions;
using PrimarySchoolManagement.BLL.Interfaces;
using PrimarySchoolManagement.DAL;
using PrimarySchoolManagement.DAL.Interfaces;
using PrimarySchoolManagement.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimarySchoolManagement.BLL
{
    public class ClassService : IClassService
    {
        private readonly IClassRepository _classRepository;

        public ClassService(IClassRepository classRepository)
        {
            _classRepository = classRepository;
        }

        public Task AddClassAsync(Class @class)
        {
            return _classRepository.GetAllAsync();
        }
               
        public async Task<Class> GetClassAsync(int id)
        {
            var c = await _classRepository.GetByIdAsync(id);

            if (c == null)

                throw new NotFoundException("Class not found.");
            return c;
        }

        public Task<List<Class>> GetClassesAsync()
        {
            return _classRepository.GetAllAsync();
        }

        public Task UpdateClassAsync(Class @class)
        {
            return _classRepository.UpdateAsync(@class);
        }

        public async Task<List<Class>> FilterClassAsyncByName(string name)
        {
            var clas = await _classRepository.GetAllAsync();
            return clas.Where(s => s.Name.Contains(name, StringComparison.OrdinalIgnoreCase)).ToList();
        }
    }
}
