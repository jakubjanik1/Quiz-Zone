using Quiz_Zone.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Quiz_Zone.DAL
{
    public class QuizDbContext : DbContext
    {
        public DbSet<Question> Questions { get; set; }

        public DbSet<Category> Categories { get; set; }

        public QuizDbContext()
            : base("QuizZoneDB")
        {

        }
    }
}