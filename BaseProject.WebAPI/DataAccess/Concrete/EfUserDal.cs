using BaseProject.WebAPI.Core.DataAccess.EntityFramework;
using BaseProject.WebAPI.Core.Entities.Concrete;
using BaseProject.WebAPI.DataAccess.Abstract;
using BaseProject.WebAPI.DataAccess.Concrete.EntityFramework.Context;

namespace BaseProject.WebAPI.DataAccess.Concrete
{
    public class EfUserDal : EfEntityRepositoryBase<User, ApplicationDbContext>, IUserDal
    {
        public List<OperationClaim> GetClaims(User user)
        {
            using (var context = new ApplicationDbContext())
            {
                var result = from operationClaim in context.OperationClaims
                             join userOperationClaim in context.UserOperationClaims
                             on operationClaim.Id equals userOperationClaim.OperationClaimId
                             where userOperationClaim.UserId == user.Id
                             select new OperationClaim { Id = operationClaim.Id, Name = operationClaim.Name };

                Console.WriteLine(result);
                return result.ToList();

            }
        }
    }
}
