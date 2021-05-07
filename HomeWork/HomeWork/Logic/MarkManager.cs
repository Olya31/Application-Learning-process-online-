using HomeWork.DAL;
using HomeWork.Logic.Interfaces;
using HomeWork.ViewModel;


namespace HomeWork.Logic
{
  
    public sealed class MarkManager : IManager, IMarkManager
    {
        private readonly DbContextFactory _dbContextFactory;

        public MarkManager()
        {
            _dbContextFactory = new DbContextFactory();
        }

        public void AddMark(MarkViewModel mark)
        {
            using var dbContext = _dbContextFactory.GetSQLContext();

            dbContext.Marks.Add(mark.ToMark());

            dbContext.SaveChanges();
        }

        public void EditMark(MarkViewModel mark)
        {
            using var dbContext = _dbContextFactory.GetSQLContext();

            var markDb = dbContext.Marks.Find(mark.Id);

            if (markDb != null)
            {
                markDb.Score = mark.Score;                
                markDb.SubjectId = mark.SubjectId;
               
                dbContext.Marks.Update(markDb);
                dbContext.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using var dbContext = _dbContextFactory.GetSQLContext();

            var markDb = dbContext.Marks.Find(id);

            if (markDb != null)
            {
                dbContext.Marks.Remove(markDb);
                dbContext.SaveChanges();
            }
        }
    }
}
