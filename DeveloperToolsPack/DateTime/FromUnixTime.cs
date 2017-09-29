using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DeveloperToolsPack.Interfaces;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;

namespace DeveloperToolsPack.DateTime
{
    [Serializable]
    class FromUnixTime : ITool
    {
        public string Description { get; set; }
        public List<string> CommandNames { get; set; }
        public bool IsAdmin { get; set; }

        public FromUnixTime()
        {
            Description = "Сonvert date from Unix time to dd.MM.yyyy HH:mm:ss";
            CommandNames = new List<string>() { "/fromUnixTime" };
        }

        public virtual async Task Run(IDialogContext context, IAwaitable<IMessageActivity> result)
        {
            var activity = await result as Activity;
            if (activity?.Conversation != null)
            {
                if (!string.IsNullOrEmpty(activity.Text))
                {
                    long seconds;
                    Int64.TryParse(activity.Text, out seconds);
                    System.DateTime date = new System.DateTime(1970, 1, 1, 0, 0, 0, 0);
                    activity.Text = date.AddSeconds(seconds).ToString("dd.MM.yyyy HH:mm:ss");
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
