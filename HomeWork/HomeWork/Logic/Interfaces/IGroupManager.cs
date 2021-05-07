using HomeWork.ViewModel;

namespace HomeWork.Logic.Interfaces
{
    public interface IGroupManager
    {
        void AddGroup(GroupViewModel group);
        void EditGroup(GroupViewModel group);
    }
}
