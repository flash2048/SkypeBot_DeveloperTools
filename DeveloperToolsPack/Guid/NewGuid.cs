using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DeveloperToolsPack.Interfaces;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;

namespace DeveloperToolsPack.Guid
{
    [Serializable]
    class NewGuid : ITool
    {
        public string Description { get; set; }
        public List<string> CommandNames { get; set; }
        public bool IsAdmin { get; set; }

        public NewGuid()
        {
            Description = "Get new Guid value";
            CommandNames = new List<string>() { "/newGuid" };
        }

        public virtual async Task Run(IDialogContext context, IAwaitable<IMessageActivity> result)
        {
            var activity = await result as Activity;
            if (activity?.Conversation != null)
            {
                activity.Text = System.Guid.NewGuid().ToString(); ;
                context.Done(activity);
            }
        }

        public async Task StartAsync(IDialogContext context)
        {
            context.Wait(this.Run);
        }
    }
}
