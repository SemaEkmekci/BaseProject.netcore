using BaseProject.WebAPI.Core.Entities.Concrete;

namespace BaseProject.WebAPI.Business.Abstract
{
    public interface IUserService 
    {
        List<OperationClaim> GetClaims(User user);
        void Add(User user);
        User GetByMail(string email);
    }
}
