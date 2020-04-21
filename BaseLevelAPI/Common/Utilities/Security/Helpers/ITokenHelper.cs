using System.Collections.Generic;
using Common.Concrete.Entities;

namespace Common.Utilities.Security.Helpers
{
    public interface ITokenHelper
    {
        //AccessToken CreateToken(User user, List<OperationClaim> operationClaims);
        AccessToken.AccessToken CreateToken(User user, List<OperationClaim> operationClaims);
    }
}
