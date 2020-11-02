using OnlineExam.Domain.Core.AppUsers;

namespace OnlineExam.Services.ApplicationService.UserAccount.Interface
{
    public interface IUserService
    {
        void Login(MyLoginModel loginModel);
        void SingUp(MyCreeateAppUser creeateAppUser);


    }
}
