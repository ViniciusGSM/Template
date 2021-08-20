using System;
using System.Collections.Generic;
using System.Text;
using Template.Application.Interfaces;
using Template.Application.ViewModels;
using Template.Domain.Entities;
using Template.Domain.Interfaces;

namespace Template.Application.Services
{
    public class UserService: IUserService
    {
        private readonly IUserRepository userRepository;
        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        
        public List<UserViewModel> Get()
        {
            List<UserViewModel> _userViewModel = new List<UserViewModel>();

            IEnumerable<User> _users = this.userRepository.GetAll();

            foreach (var item in _users)
            {
                _userViewModel.Add(new UserViewModel { Id = item.Id, Name = item.Name, Email = item.Email });
            }

            return _userViewModel;
        }
    }
}
