using Microsoft.EntityFrameworkCore;
using OneMits.Data;
using OneMits.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OneMits.InterfaceImplementation
{
    public class AnswerImplementation : IAnswer
    {
        private readonly ApplicationDbContext _context;

        public AnswerImplementation(ApplicationDbContext context)
        {
            _context = context;
        }


        public Answer GetById(string id)
        {
            throw new NotImplementedException();
        }

        public async Task  Delete(int AnswerId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Answer> GetAll()
        {
            return _context.Answers;


        }
    }
}
