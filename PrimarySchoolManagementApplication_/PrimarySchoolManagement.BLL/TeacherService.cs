using PrimarySchoolManagement.BLL.Exceptions;
using PrimarySchoolManagement.BLL.Interfaces;
using PrimarySchoolManagement.DAL;
using PrimarySchoolManagement.DAL.Exceptions;
using PrimarySchoolManagement.DAL.Interfaces;
using PrimarySchoolManagement.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimarySchoolManagement.BLL
{
    public class TeacherService : ITeacherService
    {
        private readonly ITeacherRepository _teacherRepository;

        public TeacherService(ITeacherRepository teacherRepository)
        {
            _teacherRepository = teacherRepository;
        }

        /// <summary>
        /// add teacher
        /// </summary>
        /// <param name="teacher"></param>
        /// <returns></returns>
        public Task AddTeacherAsync(Teacher teacher)
        {
            return _teacherRepository.GetAllAsync();
        }

        /// <summary>
        /// delete teacher
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Task DeleteTeacherAsync(int id)
        {
           return _teacherRepository.DeleteAsync(id);
        }
        
        /// <summary>
        /// get the list of all teachers by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="NotFoundException"></exception>
        public async Task<Teacher> GetTeacherAsync(int id)
        {
            var teacher = await _teacherRepository.GetTeacherByIdAsync(id);

            if (teacher == null)

                throw new NotFoundException("Teacher not found.");

            return teacher;
        }

        /// <summary>
        /// get teachers
        /// </summary>
        /// <returns></returns>
        public Task<List<Teacher>> GetTeachersAsync()
        {
            return _teacherRepository.GetAllAsync();
        }

        //public async Task<Teacher> GetTeachersAsync(int id)
        //{
        //    var teacher = await _teacherRepository.GetTeacherByIdAsync(id);

        //    if (teacher == null)

        //        throw new TeacherNotFound("Teacher not found.");

        //    return teacher;
        //}

        /// <summary>
        /// update teacher
        /// </summary>
        /// <param name="teacher"></param>
        /// <returns></returns>
        public Task UpdateTeacherAsync(Teacher teacher)
        {
            return _teacherRepository.UpdateAsync(teacher);
        }

        public async Task<List<Teacher>> FilterTeacherAsyncByName(string name)
        { 
            var teacher = await _teacherRepository.GetAllAsync();
            return teacher.Where(s => s.Name.Contains(name, StringComparison.OrdinalIgnoreCase)).ToList();
        }
    }
}