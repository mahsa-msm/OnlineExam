using OnlineExam.Domain.Core.AppUsers;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineExam.Services.ApplicationService.UserAccount.Interface
{
    public interface IUserService
    {
        void Login(MyLoginModel loginModel);
        void SingUp(MyCreeateAppUser creeateAppUser);


    }
}
