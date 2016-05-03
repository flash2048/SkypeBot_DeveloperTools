using System.Globalization;
using DeveloperToolsPack.Interfaces;

namespace DeveloperToolsPack.DateTime
{
    class ToUnixTime : ITool
    {
        public string Description { get; set; } = "Сonvert date in format dd.MM.yyyy HH:mm:ss to Unix time format";
        public string CommandName { get; set; } = "/toUnixTime";
        public string Run(string str)
        {
            if (!System.String.IsNullOrEmpty(str))
            {
                
                System.DateTime date = new System.DateTime(1970, 1, 1, 0, 0, 0, 0);
                System.DateTime date2;
                System.DateTime.TryParse(str, out date2);
                return (date2-date).TotalSeconds.ToString(CultureInfo.InvariantCulture);
            }
            return System.String.Empty;
        }
    }
}
