using System;
using System.Web.Security;
using DeveloperToolsPack.Interfaces;

namespace DeveloperToolsPack.String
{
    class Password : ITool
    {
        public string Description { get; set; } = "Generate new random password (password length)";
        public string CommandName { get; set; } = "/password";
        public string Run(string str)
        {
            var len = 8;

            if (!System.String.IsNullOrEmpty(str))
            {
                Int32.TryParse(str, out len);
            }
            return Membership.GeneratePassword(len, 1);
        }
    }
}
