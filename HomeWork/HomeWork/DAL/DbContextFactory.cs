using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeWork.DAL
{
    public class DbContextFactory
    {
        public SQLContext GetSQLContext()
        {
            return new SQLContext();
        }
    }
}
