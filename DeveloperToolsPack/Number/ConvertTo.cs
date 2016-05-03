using System;
using System.Linq;
using DeveloperToolsPack.Interfaces;
using DeveloperToolsPack.WorkClasses;

namespace DeveloperToolsPack.Number
{
    class ConvertTo : ITool
    {
        public string Description { get; set; } = "Сonvert numbers to any number system (ConvertTo number from to)";
        public string CommandName { get; set; } = "/convertTo";
        public string Run(string str)
        {
            if (!System.String.IsNullOrEmpty(str))
            {
                var a = str.Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries).ToArray();
                var to = 2;
                var from = 10;
                if (a.Length > 1)
                {
                    Int32.TryParse(a[1], out from);
                    if (a.Length > 2)
                    {
                        Int32.TryParse(a[2], out to);
                    }
                }
                return Converter.ConvertTo(a[0], to, from);
            }
            return System.String.Empty;
        }
    }
}
