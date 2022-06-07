using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.JWT
{
   public  interface ITokenHelper //ilerde baska arac kullnamka isteyebilirim
    {
        AccessToken CreateAccessToken(User user, List<OperationClaim> operationClaims);
        // user tablosuna gider KULLANICININ CLIMLERINI BULUR WEB JSON URETIR VE BILGILERI ISTEMCIYE VERIR.
    }
}
