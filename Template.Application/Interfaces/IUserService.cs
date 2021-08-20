using System;
using System.Collections.Generic;
using System.Text;
using Template.Application.ViewModels;

namespace Template.Application.Interfaces
{
    public interface IUserService
    {
        List<UserViewModel> Get(); 
    }
}


// esse metodo vai para a classe cliente (no caso o controller) a fim de que o cliente tenha acesso ao metodo, que ira executar o trabalho sem que o cliente saiba o que ele faz.