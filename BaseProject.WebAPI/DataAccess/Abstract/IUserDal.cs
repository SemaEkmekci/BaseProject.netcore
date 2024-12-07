using BaseProject.WebAPI.Core.DataAccess;
using BaseProject.WebAPI.Core.Entities.Concrete;

namespace BaseProject.WebAPI.DataAccess.Abstract
{
    public interface IUserDal : IEntityRepository<User>
    {
        List<OperationClaim> GetClaims(User user);
    }
}
