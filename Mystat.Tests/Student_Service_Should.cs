using MystatService.Interfaces;

namespace MystatService
{
    public class Student_Service_Should
    {
        private readonly IUnitOfWork _unitOfWork;
        public Student_Service_Should()
        {
            _unitOfWork = new UnitOfWork();
        }

        [Fact]
        public async void Return_All_Students_From_Database()
        {
            var actual = await _unitOfWork.Student.GetAllStudentsAsync();
        }

        [Fact]
        public async void Add_New_Student_In_Database()
        {
            Student actual = new()
            {
                FirstName = "გიორგი",
                LastName = "მათეშვილი",
                Attends = true,
                AttendsOnline = false,
                Brilliants = 33,
                Comment = string.Empty
            };
            await _unitOfWork.Student.AddNewStudentAsync(actual);
        }
        [Fact]
        public async void Get_Single_Student()
        {
            var student = await _unitOfWork.Student.GetStudentByIdAsync(4);
        }
        [Fact]
        public async void Update_Student()
        {
            var studentToUpdte = await _unitOfWork.Student.GetStudentByIdAsync(7);
            studentToUpdte.FirstName = "ნუგზარი";
            await _unitOfWork.Student.UpdateStudentAsync(studentToUpdte);
        }
        [Fact]
        public async void Delete_student()
        {
            await _unitOfWork.Student.DeleteStudentAsync(1);
        }
        [Fact]
        public async void Delete_Many_Students()
        {
            await _unitOfWork.Student.DeleteManyStudentsAsync();
        }
    }
}
