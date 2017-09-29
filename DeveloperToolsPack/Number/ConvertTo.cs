using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DeveloperToolsPack.Interfaces;
using DeveloperToolsPack.WorkClasses;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;

namespace DeveloperToolsPack.Number
{
    [Serializable]
    class ConvertTo : ITool
    {
        public string Description { get; set; }
        public List<string> CommandNames { get; set; }
        public bool IsAdmin { get; set; }

        public ConvertTo()
        {
            Description = "Сonvert numbers to any number system (ConvertTo number from to)";
            CommandNames = new List<string>() { "/convertTo" };
        }

        public virtual async Task Run(IDialogContext context, IAwaitable<IMessageActivity> result)
        {
            var activity = await result as Activity;
            if (activity?.Conversation != null)
            {
                if (!string.IsNullOrEmpty(activity.Text))
                {
                    var a = activity.Text.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries).ToArray();
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
                    activity.Text = Converter.ConvertTo(a[0], to, from);
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
