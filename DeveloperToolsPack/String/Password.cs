using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Security;
using DeveloperToolsPack.Interfaces;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;

namespace DeveloperToolsPack.String
{
    [Serializable]
    class Password : ITool
    {
        public string Description { get; set; }
        public List<string> CommandNames { get; set; }
        public bool IsAdmin { get; set; }

        public Password()
        {
            Description = "Generate new random password (password length)";
            CommandNames = new List<string>() { "/password" };
        }

        public virtual async Task Run(IDialogContext context, IAwaitable<IMessageActivity> result)
        {
            var activity = await result as Activity;
            if (activity?.Conversation != null)
            {
                var len = 8;

                if (!System.String.IsNullOrEmpty(activity.Text))
                {
                    Int32.TryParse(activity.Text, out len);
                }
                activity.Text = Membership.GeneratePassword(len, 1);
                context.Done(activity);
            }
        }

        public async Task StartAsync(IDialogContext context)
        {
            context.Wait(this.Run);
        }
    }
}
