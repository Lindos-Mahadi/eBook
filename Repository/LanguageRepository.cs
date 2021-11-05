using eBook.Data;
using eBook.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eBook.Repository
{
    public class LanguageRepository
    {
        private readonly ApplicationDbContext _context = null;

        public LanguageRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<LanguageModel>> GetLanguages()
        {
            return await _context.Language.Select(x => new LanguageModel()
            {
                LanguageId = x.LanguageId,
                Description = x.Description,
                Name = x.Name
            }).ToListAsync();
        }
    }
}
