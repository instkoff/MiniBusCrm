using System.Collections.Generic;

namespace MiniBusCrm.DataAccess.Contracts.Settings
{
    public static class UserRoles
    {
        public const string Admin = "Admin";
        public const string Operator = "Operator";

        public static IEnumerable<string> GetRoles()
        {
            yield return Admin;
            yield return Operator;
        }
    }
}