using HomeWork.DAL;
using HomeWork.DAL.Model;
using HomeWork.Logic.Interfaces;
using HomeWork.ViewModel;
using System.Collections.Generic;
using System.Linq;

namespace HomeWork.Logic
{

    public sealed class SubjectManager : IManager, ISubjectManager
    {
        private readonly DbContextFactory _dbContextFactory;

        public SubjectManager()
        {
            _dbContextFactory = new DbContextFactory();
        }

        public void AddSubject(SubjectViewModel subject)
        {
            using var dbContext = _dbContextFactory.GetSQLContext();

            dbContext.Subjects.Add(subject.ToSubject());

            dbContext.SaveChanges();
        }

        public void EditSubject(SubjectViewModel subject)
        {
            using var dbContext = _dbContextFactory.GetSQLContext();

            var subjectDb = dbContext.Subjects.Find(subject.Id);

            if (subjectDb != null)
            {
                subjectDb.Name = subject.Name;                

                dbContext.Subjects.Update(subjectDb);
                dbContext.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using var dbContext = _dbContextFactory.GetSQLContext();

            var subjectDb = dbContext.Subjects.Find(id);

            if (subjectDb != null)
            {
                dbContext.Subjects.Remove(subjectDb);
                dbContext.SaveChanges();
            }
        }
        public List<SubjectViewModel> GetAllSubject()
        {
            using var dbContext = _dbContextFactory.GetSQLContext();

            var subjectDb = dbContext.Subjects.ToList();

            var subjectsViewModel = new List<SubjectViewModel>();

            foreach (var subject in subjectDb)
            {
                var item = ToSubjectViewModel(subject);
                subjectsViewModel.Add(item);
            }

            return subjectsViewModel;
        }

        private SubjectViewModel ToSubjectViewModel(Subject subject)
        {
            return new SubjectViewModel
            {
                Id = subject.Id,
                Name = subject.Name,
            };
        }
    }
}
