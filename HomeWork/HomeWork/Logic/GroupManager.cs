using HomeWork.DAL;
using HomeWork.DAL.Model;
using HomeWork.Logic.Interfaces;
using HomeWork.ViewModel;
using System.Collections.Generic;
using System.Linq;

namespace HomeWork.Logic
{
    public sealed class GroupManager : IManager, IGroupManager
    {
        private readonly DbContextFactory _dbContextFactory;

        public GroupManager()
        {
            _dbContextFactory = new DbContextFactory();
        }

        public void AddGroup(GroupViewModel group)
        {
            using var dbContext = _dbContextFactory.GetSQLContext();

            dbContext.Groups.Add(group.ToGroup());

            dbContext.SaveChanges();
        }

        public void EditGroup(GroupViewModel group)
        {
            using var dbContext = _dbContextFactory.GetSQLContext();

            var groupDb = dbContext.Groups.Find(group.Id);

            if (groupDb != null)
            {
                groupDb.Name = group.Name;
                dbContext.Groups.Update(groupDb);
                dbContext.SaveChanges();
            }            
        }

        public void Delete(int id)
        {
            using var dbContext = _dbContextFactory.GetSQLContext();

            var groupDb = dbContext.Groups.Find(id);

            if (groupDb != null)
            {
                dbContext.Groups.Remove(groupDb);
                dbContext.SaveChanges();
            }
        }

        public List<GroupViewModel> GetAllGroup()
        {
            using var dbContext = _dbContextFactory.GetSQLContext();

            var groupDb = dbContext.Groups.ToList();

            var groupsViewModel = new List<GroupViewModel>();
            
            foreach(var group in groupDb)
            {
                var item = ToGroupViewModel(group);
                groupsViewModel.Add(item);
            }
            
            return groupsViewModel;
        }

        private GroupViewModel ToGroupViewModel(Group group)
        {
            return new GroupViewModel
            {
                Id = group.Id,
                Name = group.Name,
            };
        }

        
    }
}
