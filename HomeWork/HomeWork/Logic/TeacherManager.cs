using HomeWork.DAL;
using HomeWork.DAL.Model;
using HomeWork.Logic.Interfaces;
using HomeWork.ViewModel;
using System.Collections.Generic;
using System.Linq;

namespace HomeWork.Logic
{ 
    public sealed class TeacherManager : IManager, ITeacherManager
    {
        private readonly DbContextFactory _dbContextFactory;

        public TeacherManager()
        {
            _dbContextFactory = new DbContextFactory();
        }

        public void AddTeacher(TeacherViewModel teacher)
        {
            using var dbContext = _dbContextFactory.GetSQLContext();

            dbContext.Teachers.Add(teacher.ToTeacher());

            dbContext.SaveChanges();
        }

        public void EditTeacher(TeacherViewModel teacher)
        {
            using var dbContext = _dbContextFactory.GetSQLContext();

            var teacherDb = dbContext.Teachers.Find(teacher.Id);

            if (teacherDb != null)
            {
                teacherDb.FirstName = teacher.FirstName;
                teacherDb.LastName = teacher.LastName;
                teacherDb.SubjectId = teacher.SubjectId;
                

                dbContext.Teachers.Update(teacherDb);
                dbContext.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using var dbContext = _dbContextFactory.GetSQLContext();

            var teacherDb = dbContext.Teachers.Find(id);

            if (teacherDb != null)
            {
                dbContext.Teachers.Remove(teacherDb);
                dbContext.SaveChanges();
            }
        }
        public List<TeacherViewModel> GetAllTeacher()
        {
            using var dbContext = _dbContextFactory.GetSQLContext();

            var teacherDb = dbContext.Teachers.ToList();

            var teachersViewModel = new List<TeacherViewModel>();

            foreach (var teacher in teacherDb)
            {
                var item = ToTeacherViewModel(teacher);
                teachersViewModel.Add(item);
            }

            return teachersViewModel;
        }

        private TeacherViewModel ToTeacherViewModel(Teacher teacher)
        {
            return new TeacherViewModel
            {
                Id = teacher.Id,
                FirstName = teacher.FirstName,
                LastName = teacher.LastName,
                SubjectId = teacher.SubjectId,
            };
        }
    }
}
