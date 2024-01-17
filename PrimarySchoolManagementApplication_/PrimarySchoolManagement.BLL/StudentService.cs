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
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;

        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public Task AddStudentAsync(Student student)
        {
            return _studentRepository.GetAllStudentsAsync();
        }

        public Task DeleteStudentAsync(int id)
        {
            return _studentRepository.DeleteStudentAsync(id);
        }

        public async Task<Student> GetStudentAsync(int id)
        {
            var student = await _studentRepository.GetStudentByIdAsync(id);

            if (student == null)

                throw new NotFoundException("Student not found.");

            return student;
        }

        public Task<List<Student>> GetStudentsAsync()
        {
            return _studentRepository.GetAllStudentsAsync();
        }

        public Task UpdateStudentAsync(Student student)
        {
            return _studentRepository.UpdateStudentAsync(student);
        }

        public async Task<List<Student>> FilterStudentAsyncByName(string name)
        {
            var student = await _studentRepository.GetAllStudentsAsync();
            return student.Where(s => s.Name.Contains(name, StringComparison.OrdinalIgnoreCase)).ToList();
        }
    }
}
