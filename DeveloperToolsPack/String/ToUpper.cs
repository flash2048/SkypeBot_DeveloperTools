using DeveloperToolsPack.Interfaces;

namespace DeveloperToolsPack.String
{
    class ToUpper: ITool
    {
        public string Description { get; set; } = "String converted  to uppercase";
        public string CommandName { get; set; } = "/toUpper";
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
