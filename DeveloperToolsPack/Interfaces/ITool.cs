using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;

namespace DeveloperToolsPack.Interfaces
{
    public interface ITool: IDialog<object>
    {
        string Description { get; set; }
        List<string> CommandNames { get; set; }
        Task Run(IDialogContext context, IAwaitable<IMessageActivity> result);
    }
}
