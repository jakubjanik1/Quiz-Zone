﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Quiz_Zone.DAL;
using Quiz_Zone.Models;

namespace Quiz_Zone.Repository
{
    public class DbQuizRepository : IQuizRepository
    {
        private QuizDbContext context = new QuizDbContext();

        public IEnumerable<Question> Questions
        {
            get { return context.Questions; }
        }

        public IEnumerable<Category> Categories
        {
            get { return context.Categories; }
        }
    }
}