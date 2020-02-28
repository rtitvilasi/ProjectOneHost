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
    public class CategoryImplementation : ICategory
    {
        private readonly ApplicationDbContext _context;

        public CategoryImplementation(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Create(Category category)
        {
            _context.Add(category);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int categoryid)
        {
            var forum = GetById(categoryid);
            _context.RemoveRange(forum.Questions);
            _context.Remove(forum);
            await _context.SaveChangesAsync();
        }
        


        public IEnumerable<Category> GetAll()
        {
            return _context.Categories
                .Include(category => category.Questions);
        }


        public IEnumerable<ApplicationUser> GetAllActiveUsers()
        {
            throw new NotImplementedException();
        }

        public Category GetById(int id)
        {
            var category = _context.Categories.Where(c => c.CategoryId == id)
                .Include(f => f.Questions)
                .ThenInclude(p => p.User)
                .Include(f => f.Questions)
                .ThenInclude(p => p.LikeQuestions)
                .Include(f => f.Questions)
                .ThenInclude(p => p.Answers)
                .ThenInclude(l => l.LikeAnswers)
                .ThenInclude(r => r.User)
                .FirstOrDefault();
            return category;
        }



        public Task UpdateCategoryDescription(int categoryid, string newCategoryDescription)
        {
            throw new NotImplementedException();
        }

        public Task UpdateCategoryTitle(int categoryid, string newCategoryTitle)
        {
            throw new NotImplementedException();
        }

    }
}
