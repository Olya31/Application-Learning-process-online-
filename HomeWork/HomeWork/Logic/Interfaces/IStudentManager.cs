using HomeWork.ViewModel;

namespace HomeWork.Logic.Interfaces
{
    interface IStudentManager
    {
        void EditStudent(StudentViewModel student);
        void AddStudent(StudentViewModel student);
    }
}
