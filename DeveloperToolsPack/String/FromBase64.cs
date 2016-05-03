using System;
using DeveloperToolsPack.Interfaces;

namespace DeveloperToolsPack.String
{
    class FromBase64 : ITool
    {
        public string Description { get; set; } = "Convert Base64 string to normal state";
        public string CommandName { get; set; } = "/fromBase64";
        public string Run(string str)
        {
            if (!System.String.IsNullOrEmpty(str))
            {
                try
                {
                    var base64EncodedBytes = Convert.FromBase64String(str);
                    return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
                }
                catch (Exception)
                {
                    return "It's not base64 string";
                }
               
            }
            return System.String.Empty;
        }
    }
}
