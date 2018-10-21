using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Quiz_Zone.Models;

namespace Quiz_Zone.Repository
{
    public class EFQuestionRepository : IQuestionRepository
    {
        private EFDbContext context = new EFDbContext();

        public IEnumerable<Question> Questions
        {
            get { return context.Questions; }
        }
    }
}