using System;

namespace MiniBusCrm.Domain.Contracts.Exceptions
{
    public class UniqueUsernameException :  Exception
    {
        public UniqueUsernameException(string message) : base(message)
        {
            
        }
    }
}
