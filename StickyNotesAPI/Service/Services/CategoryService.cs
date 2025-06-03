using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Model.Context;
using Model.DTO;
using Model.Model;
using Service.IServices;

namespace Service.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly AppDBContext _context;

        public CategoryService(AppDBContext dbContext)
        {
            _context = dbContext;
        }

        public List<CategoryDTO> GetCategory(int id)
        {
            return _context
                .Categories.Where(c => c.UserId == id)
                .Select(c => new CategoryDTO
                {
                    Id = c.Id,
                    Name = c.Name,
                    Color = c.Color,
                })
                .Take(16)
                .ToList();
        }

        public ResponseDTO CreateCategory(CategoryDTO newcat)
        {
            int categoryCount = _context.Categories.Count(c => c.UserId == newcat.UserId);
            if (categoryCount >= 16)
            {
                return new ResponseDTO { Success = false, Message = "Category limit reached" };
            }

            Category? alreadyexist = _context.Categories.FirstOrDefault(x => x.Name == newcat.Name);
            if (alreadyexist != null)
            {
                return new ResponseDTO { Success = false, Message = "Already in Use" };
            }
            _context.Categories.Add(
                new Category
                {
                    Name = newcat.Name,
                    Color = newcat.Color,
                    UserId = newcat.UserId,
                }
            );

            _context.SaveChanges();

            return new ResponseDTO { Success = true, Message = "Created" };
        }

        public ResponseDTO EditCategory(CategoryDTO editcat)
        {
            Category? category = _context.Categories.FirstOrDefault(x => x.Id == editcat.Id);
            if (category == null)
            {
                return new ResponseDTO { Success = false, Message = "Category not found" };
            }

            category.Name = editcat.Name;
            category.Color = editcat.Color;

            _context.SaveChanges();

            return new ResponseDTO { Success = true, Message = "Category updated successfully" };
        }

        public ResponseDTO DeleteCategory(int id)
        {
            Category? category = _context.Categories.FirstOrDefault(x => x.Id == id);
            if (category == null)
            {
                return new ResponseDTO { Success = false, Message = "Category not found" };
            }

            var notes = _context.Notes.Where(n => n.CategoryId == id).ToList();
            _context.Notes.RemoveRange(notes);

            _context.Categories.Remove(category);
            _context.SaveChanges();

            return new ResponseDTO
            {
                Success = true,
                Message = "Category and associated notes deleted successfully",
            };
        }
    }
}
