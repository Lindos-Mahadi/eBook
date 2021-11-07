using eBook.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eBook.Repository
{
    public interface ILanguageRepository
    {
        Task<List<LanguageModel>> GetLanguages();
    }
}