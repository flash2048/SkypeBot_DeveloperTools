using DeveloperToolsPack.Interfaces;

namespace DeveloperToolsPack.Guid
{
    class NewGuid : ITool
    {
        public string Description { get; set; } = "**NewGuid** \t Get new Guid value";
        public string CommandName { get; set; } = "NewGuid";
        public string Run(string str)
        {
            return System.Guid.NewGuid().ToString();
        }
    }
}
