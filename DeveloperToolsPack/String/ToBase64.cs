using System;
using DeveloperToolsPack.Interfaces;

namespace DeveloperToolsPack.String
{
    class ToBase64 : ITool
    {
        public string Description { get; set; } = "Convert string to Base64";
        public string CommandName { get; set; } = "/toBase64";
        public string Run(string str)
        {
            if (!System.String.IsNullOrEmpty(str))
            {
                try
                {
                    var textBytes = System.Text.Encoding.UTF8.GetBytes(str);
                    return System.Convert.ToBase64String(textBytes);
                }
                catch (Exception)
                {
                    return System.String.Empty;
                }
               
            }
            return System.String.Empty;
        }
    }
}
