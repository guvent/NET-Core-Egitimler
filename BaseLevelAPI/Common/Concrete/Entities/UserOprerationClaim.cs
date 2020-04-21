using Common.Abstract.Entities;

namespace Common.Concrete.Entities
{
    public class UserOprerationClaim:IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int OperationClaimId { get; set; }
    }
}
