using DeveloperToolsPack.Interfaces;

namespace DeveloperToolsPack.String
{
    class ToLower: ITool
    {
        public string Description { get; set; } = "String converted  to lowercase";
        public string CommandName { get; set; } = "/toLower";
        public string Run(string str)
        {
            if (!System.String.IsNullOrEmpty(str))
            {
                return str.ToLower();
            }
            return System.String.Empty;
        }
    }
}
