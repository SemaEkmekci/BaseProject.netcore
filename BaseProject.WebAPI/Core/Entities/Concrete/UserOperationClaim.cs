using System.Security.Principal;

namespace BaseProject.WebAPI.Core.Entities.Concrete
{
    public class UserOperationClaim
    {
        public int Id { get; set; }
        public Guid UserId { get; set; }
        public int OperationClaimId { get; set; }

    }
}
