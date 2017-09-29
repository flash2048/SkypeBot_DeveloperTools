using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DeveloperToolsPack.Interfaces;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;

namespace DeveloperToolsPack.String
{
    [Serializable]
    class FromBase64 : ITool
    {

        public string Description { get; set; }
        public List<string> CommandNames { get; set; }
        public bool IsAdmin { get; set; }

        public FromBase64()
        {
            Description = "Convert Base64 string to normal state";
            CommandNames = new List<string>() { "/fromBase64" };
        }

        public virtual async Task Run(IDialogContext context, IAwaitable<IMessageActivity> result)
        {
            var activity = await result as Activity;
            if (activity?.Conversation != null)
            {
                if (!string.IsNullOrEmpty(activity.Text))
                {
                    try
                    {
                        var base64EncodedBytes = Convert.FromBase64String(activity.Text);
                        activity.Text =  System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
                    }
                    catch (Exception)
                    {
                        activity.Text = "It's not base64 string";
                    }
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
