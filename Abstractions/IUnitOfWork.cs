using System.Threading.Tasks;
using Abstractions.Entities;
using Abstractions.Repositories;
using Microsoft.AspNetCore.Identity;

namespace Abstractions
{
    public interface IUnitOfWork
    {
        IBookRepository BookRepository { get; }

        ISageRepository SageRepository { get; }

        IOrderRepository OrderRepository { get; }

        UserManager<User> UserManager { get; }

        RoleManager<IdentityRole> RoleManager { get; }

        SignInManager<User> SignInManager { get; }

        Task<int> SaveAsync();
    }
}