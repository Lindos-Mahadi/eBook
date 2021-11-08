using eBook.Models;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace eBook.Repository
{
    public interface IAccountRepository
    {
        Task<IdentityResult> CreateUserAsync(SignUpUserModel userModel);
    }
}