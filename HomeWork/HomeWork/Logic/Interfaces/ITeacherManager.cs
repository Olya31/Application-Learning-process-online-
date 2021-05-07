using HomeWork.ViewModel;

namespace HomeWork.Logic.Interfaces
{
    interface ITeacherManager
    {
        void AddTeacher(TeacherViewModel teacher);
        void EditTeacher(TeacherViewModel teacher);
    }
}
