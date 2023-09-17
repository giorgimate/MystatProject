using MystatService.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mystat.Tests
{
    public class Teacher_Service_Should
    {
        private readonly IUnitOfWork _unitOfWork;
        public Teacher_Service_Should()
        {
            _unitOfWork = new UnitOfWork();
        }

        [Fact]
        public async void Return_All_Teachers_From_Database()
        {
            var actual = await _unitOfWork.Teacher.GetAllTeachersAsync();
        }
        [Fact]
        public async void Add_New_Teacher_In_Database()
        {
            Teacher actual = new()
            {
                FirstName = "გიორგი",
                LastName = "მათეშვილი",
                Pin = "40003004040",
                PhoneNumber = "555444444",
                Email = ".scds@mail.ru",
            };
            await _unitOfWork.Teacher.AddNewTeacherAsync(actual);
        }
        [Fact]
        public async void Delete_Teacher()
        {
            await _unitOfWork.Teacher.DeleteTeacherAsync(5);
        }
        [Fact]
        public async void Get_Single_Teacher()
        {
            var teacher = await _unitOfWork.Teacher.GetTeacherByIdAsync(6);
        }
        [Fact]
        public async void Update_Teacher()
        {
            var teacherToUpdte = await _unitOfWork.Teacher.GetTeacherByIdAsync(6);
            teacherToUpdte.FirstName = "ნუგზარი";
            await _unitOfWork.Teacher.UpdateTeacherAsync(teacherToUpdte);
        }
        [Fact]
        public async void Delete_Many_Teachers()
        {
            await _unitOfWork.Teacher.DeleteManyTeachersAsync(6,7);
        }
    }
}
