using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DeveloperToolsPack.Interfaces;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;

namespace DeveloperToolsPack.String
{
    [Serializable]
    class ToBase64 : ITool
    {

        public string Description { get; set; }
        public List<string> CommandNames { get; set; }
        public bool IsAdmin { get; set; }

        public ToBase64()
        {
            Description = "Convert string to Base64";
            CommandNames = new List<string>() { "/toBase64" };
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
                        var textBytes = System.Text.Encoding.UTF8.GetBytes(activity.Text);
                        activity.Text = System.Convert.ToBase64String(textBytes);
                    }
                    catch (Exception)
                    {
                        activity.Text = System.String.Empty;
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
