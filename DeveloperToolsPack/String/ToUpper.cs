using DeveloperToolsPack.Interfaces;

namespace DeveloperToolsPack.String
{
    class ToUpper: ITool
    {
        public string Description { get; set; } = "**ToUpper** \t String converted  to uppercase";
        public string CommandName { get; set; } = "ToUpper";
        public string Run(string str)
        {
            if (!System.String.IsNullOrEmpty(str))
            {
                return str.ToUpper();
            }
            return System.String.Empty;
        }
    }
}
