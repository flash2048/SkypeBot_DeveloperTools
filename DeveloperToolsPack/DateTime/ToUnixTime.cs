using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;
using DeveloperToolsPack.Interfaces;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;

namespace DeveloperToolsPack.DateTime
{
    [Serializable]
    class ToUnixTime : ITool
    {
        public string Description { get; set; }
        public List<string> CommandNames { get; set; }
        public bool IsAdmin { get; set; }

        public ToUnixTime()
        {
            Description = "Сonvert date in format dd.MM.yyyy HH:mm:ss to Unix time format";
            CommandNames = new List<string>() { "/toUnixTime" };
        }

        public virtual async Task Run(IDialogContext context, IAwaitable<IMessageActivity> result)
        {
            var activity = await result as Activity;
            if (activity?.Conversation != null)
            {
                if (!string.IsNullOrEmpty(activity.Text))
                {
                    System.DateTime date = new System.DateTime(1970, 1, 1, 0, 0, 0, 0);
                    System.DateTime date2;
                    System.DateTime.TryParse(activity.Text, out date2);
                    activity.Text = (date2 - date).TotalSeconds.ToString(CultureInfo.InvariantCulture);
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
