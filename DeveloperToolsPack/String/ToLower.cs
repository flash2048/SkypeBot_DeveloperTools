using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DeveloperToolsPack.Interfaces;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;

namespace DeveloperToolsPack.String
{
    [Serializable]
    class ToLower: ITool
    {
        public string Description { get; set; }
        public List<string> CommandNames { get; set; }
        public bool IsAdmin { get; set; }

        public ToLower()
        {
            Description = "String converted  to lowercase";
            CommandNames = new List<string>() { "/tolower" };
        }

        public virtual async Task Run(IDialogContext context, IAwaitable<IMessageActivity> result)
        {
            var activity = await result as Activity;
            if (activity?.Conversation != null)
            {
                if (!string.IsNullOrEmpty(activity.Text))
                {
                    activity.Text = activity.Text.ToLower();
                    context.Done(activity);
                }
                else
                {
                    await context.PostAsync("Enter text");
                    context.Wait(Run);
                }
            }
        }
        public async Task StartAsync(IDialogContext context)
        {
            context.Wait(this.Run);
        }
    }
}
