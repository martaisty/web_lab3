using System;
using System.Threading.Tasks;
using Abstractions;
using Abstractions.Entities;
using Abstractions.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace DAL
{
    internal class UnitOfWork : IUnitOfWork
    {
        private readonly DatabaseContext _context;
        private readonly IServiceProvider _serviceProvider;
        private IBookRepository _bookRepository;
        private IOrderRepository _orderRepository;
        private ISageRepository _sageRepository;

        private UserManager<User> _userManager;
        private RoleManager<IdentityRole> _roleManager;
        private SignInManager<User> _signInManager;

        public UnitOfWork(DatabaseContext context, IServiceProvider serviceProvider)
        {
            _context = context;
            _serviceProvider = serviceProvider;
        }

        public IBookRepository BookRepository =>
            _bookRepository ??= _serviceProvider.GetService<IBookRepository>();

        public ISageRepository SageRepository =>
            _sageRepository ??= _serviceProvider.GetService<ISageRepository>();

        public IOrderRepository OrderRepository =>
            _orderRepository ??= _serviceProvider.GetService<IOrderRepository>();

        public UserManager<User> UserManager =>
            _userManager ??= _serviceProvider.GetService<UserManager<User>>();

        public RoleManager<IdentityRole> RoleManager =>
            _roleManager ??= _serviceProvider.GetService<RoleManager<IdentityRole>>();

        public SignInManager<User> SignInManager =>
            _signInManager ??= _serviceProvider.GetService<SignInManager<User>>();

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}