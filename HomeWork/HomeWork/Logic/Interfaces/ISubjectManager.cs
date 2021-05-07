using HomeWork.ViewModel;

namespace HomeWork.Logic.Interfaces
{
    interface ISubjectManager
    {
        void AddSubject(SubjectViewModel subject);
        void EditSubject(SubjectViewModel subject);
    }
}
