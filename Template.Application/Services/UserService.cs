using AutoMapper;
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
        private readonly IMapper mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            this.userRepository = userRepository;
            this.mapper = mapper;
        }

        
        public List<UserViewModel> Get()
        {
            List<UserViewModel> _userViewModel = new List<UserViewModel>();

            IEnumerable<User> _users = this.userRepository.GetAll();

            _userViewModel = mapper.Map<List<UserViewModel>>(_users);
            //foreach (var item in _users)
            //{
            //    _userViewModel.Add(mapper.Map<UserViewModel>(item));                                              >>poderia ser feita essa alteração(no lugar do codigo de baixo) a fim de utilizar o mapper, mas existe uma forma mais correta, que esta acima.
            
            //    _userViewModel.Add(new UserViewModel { Id = item.Id, Name = item.Name, Email = item.Email });
            //}

            return _userViewModel;
        }

        public bool Post(UserViewModel userViewModel)
        {
            //User _user = new User
            //{
            //    //Id = Guid.NewGuid(),
            //    //Name = userViewModel.Name,
            //    //Email = userViewModel.Email,
            //    //DateCreated = DateTime.Now,       >Desnecessários (datecriated, dateupdated e isdeleted), num primeiro momento,
            //                                        tendo em conta que realizamos a configuração ApplyGlobalConfigurations em Template.Data.Extensions.
            //    //DateUpdated = null,               >>Depois que configuramos o AutoMapper, toda essa parte é automatizada.
            //    //IsDeleted = false
            //};

            User _user = mapper.Map<User>(userViewModel);

            this.userRepository.Create(_user);

            return true;

        }

        public UserViewModel GetById(string id)
        {
            if (!Guid.TryParse(id, out Guid userId))
                throw new Exception("UserID is not valid!");
            

            User _user = this.userRepository.Find(x => x.Id == userId && !x.IsDeleted);

            if (_user == null)            
                throw new Exception("User not found!");
            

            return mapper.Map<UserViewModel>(_user);
        }

        public bool Put(UserViewModel userViewModel)
        {
            User _user = this.userRepository.Find(x => x.Id == userViewModel.Id && !x.IsDeleted);  //pegando o usuário pelo id e verificando que nao está deletado.

            if (_user == null)                                              // validando se não é um usuário nulo.
                throw new Exception("User not found!");

            _user = mapper.Map<User>(userViewModel);                        // convertendo as informações para o objeto (_user).
            this.userRepository.Update(_user);                              // salvando/atualizando o objeto.

            return true;
        }

        public bool Delete(string id)
        {
            if (!Guid.TryParse(id, out Guid userId))
                throw new Exception("UserID is not valid!");


            User _user = this.userRepository.Find(x => x.Id == userId && !x.IsDeleted);

            if (_user == null)
                throw new Exception("User not found!");

            

            return this.userRepository.Delete(_user);
        }
    }
}
