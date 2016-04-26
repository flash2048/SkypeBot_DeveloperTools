using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperToolsPack.Interfaces
{
    interface ITool
    {
        string Description { get; set; }
        string CommandName { get; set; }
        string Run(string str);
    }
}
