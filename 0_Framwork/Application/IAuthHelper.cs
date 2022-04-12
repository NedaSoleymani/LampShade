

namespace _0_Framwork.Application
{
    public interface IAuthHelper
    {
        void SignOut();
        void Signin(AuthViewModel account);
        bool IsAuthenticated();
    }
}
