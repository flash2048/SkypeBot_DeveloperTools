using System;
using DeveloperToolsPack.Interfaces;

namespace DeveloperToolsPack.DateTime
{
    class FromUnixTime : ITool
    {
        public string Description { get; set; } = "Сonvert date from Unix time to dd.MM.yyyy HH:mm:ss";
        public string CommandName { get; set; } = "/fromUnixTime";
        public string Run(string str)
        {
            if (!System.String.IsNullOrEmpty(str))
            {
                long seconds;
                Int64.TryParse(str, out seconds);
                System.DateTime date = new System.DateTime(1970, 1, 1, 0, 0, 0, 0);
                return date.AddSeconds(seconds).ToString("dd.MM.yyyy HH:mm:ss");
            }
            return System.String.Empty;
        }
    }
}
