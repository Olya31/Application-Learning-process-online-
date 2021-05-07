using HomeWork.ViewModel;

namespace HomeWork.Logic.Interfaces
{
    interface IMarkManager
    {
        void AddMark(MarkViewModel mark);
        void EditMark(MarkViewModel mark);
    }
}
