using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Luis;
using Microsoft.Bot.Builder.Luis.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace DiaBot.Dialog
{
    // Dialogs
    // http://docs.botframework.com/sdkreference/csharp/dialogs.html

    // https://api.projectoxford.ai/luis/v1/application?id=b7cfffee-5554-446f-b4e9-92123a8db3c9&subscription-key=a1f9f6093899474090870b59cc362b7c
    [LuisModel("XXXX",
               "XXXX")]

    [Serializable]
    public class DiabotDialog : LuisDialog<object>
    {
        // We don't recognize the intention of the user
        [LuisIntent("")]
        public async Task Unknown(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("Sorry I did not understand. Tell me your glucose blood level and I will guide you on what to do");
            context.Wait(MessageReceived);            
        }

        // User is saying hi
        [LuisIntent("Greetings")]
        public async Task Salutation(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("Hi! Tell me your glucose blood level and I will guide you on what to do");
            context.Wait(MessageReceived);
        }

        [LuisIntent("Goodbye")]
        public async Task Thankful(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("You are welcome!");
            context.Wait(MessageReceived);
        }

        [LuisIntent("GlucoseLevel")]
        public async Task GlucoseLevel(IDialogContext context, LuisResult result)
        {
            int level;
            bool hasLevel = int.TryParse(result.Entities.FirstOrDefault(l => l.Type == "builtin.number").Entity, out level);
            string response;

            if (hasLevel)
            {
                if (level >= 90 && level <= 120)
                    response = "You are OK!";
                else if (level > 120)
                {
                    int difference = level - 120;
                    int variant = 1700 * difference;
                    response = $"You have to descend {difference} units your glucose blood level. Each insulin doses, will lower your level [1700 / your daily doses] units";
                }
                else
                    response = "You need to take sugar right now";
            }
            else
            {
                response = "Sorry I did not understand. Tell me your glucose blood level and I will guide you on what to do";
            }

            await context.PostAsync(response);
            context.Wait(MessageReceived);
        }
    }
}
