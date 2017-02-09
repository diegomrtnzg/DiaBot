using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Microsoft.Bot.Connector;
using Newtonsoft.Json;
using DiaBot.Dialog;

namespace DiaBot
{
    [BotAuthentication]
    public class MessagesController : ApiController
    {
        /// <summary>
        /// POST: api/Messages
        /// Receive a message from a user and reply to it
        /// </summary>
        public async Task<HttpResponseMessage> Post([FromBody]Activity activity)
        {
            if (activity.Type == ActivityTypes.Message)
            {
                await Microsoft.Bot.Builder.Dialogs.Conversation.SendAsync(activity, () => new DiabotDialog());
            }
            else
            {
                HandleSystemMessage(activity);
            }
            var response = Request.CreateResponse(HttpStatusCode.OK);
            return response;

        //    if (activity.Type == ActivityTypes.Message)
        //    {
        //        ConnectorClient connector = new ConnectorClient(new Uri(activity.ServiceUrl));
        //         //return our reply to the user
        //        Activity reply = new Activity();
        //        int level;
        //        bool isNumber = int.TryParse(activity.Text, out level);
        //        if (!isNumber)
        //        {
        //            switch (activity.Text)
        //            {
        //                case "Hello DiaBot":
        //                    reply = activity.CreateReply("Hi! Tell me your glucose blood level and I will guide you on what to do");
        //                    break;
        //                case "Thanks!":
        //                    reply = activity.CreateReply("You are welcome!");
        //                    break;
        //                default: 
        //                    reply = activity.CreateReply("Sorry I did not understand. Tell me your glucose blood level and I will guide you on what to do");
        //                    break;
        //            }
        //        }
        //        else
        //        {
        //            if (level >= 90 && level <= 120)
        //                reply = activity.CreateReply("You are OK!");
        //            else if (level > 120)
        //            {
        //                int difference = level - 120;
        //                int variant = 1700 * difference;
        //                reply = activity.CreateReply($"You have to descend {difference} units your glucose blood level. Each insulin doses, will lower your level [1700 / your daily doses] units");
        //            } 
                    //else
                    //   reply = activity.CreateReply("You need to take sugar right now");
            //        }

            //        await connector.Conversations.ReplyToActivityAsync(reply);
            //    }
            //    else
            //    {
            //        HandleSystemMessage(activity);
            //    }
            //    var response = Request.CreateResponse(HttpStatusCode.OK);
            //    return response;
        }

        private Activity HandleSystemMessage(Activity message)
        {
            if (message.Type == ActivityTypes.DeleteUserData)
            {
                // Implement user deletion here
                // If we handle user deletion, return a real message
            }
            else if (message.Type == ActivityTypes.ConversationUpdate)
            {
                // Handle conversation state changes, like members being added and removed
                // Use Activity.MembersAdded and Activity.MembersRemoved and Activity.Action for info
                // Not available in all channels
            }
            else if (message.Type == ActivityTypes.ContactRelationUpdate)
            {
                // Handle add/remove from contact lists
                // Activity.From + Activity.Action represent what happened
            }
            else if (message.Type == ActivityTypes.Typing)
            {
                // Handle knowing tha the user is typing
            }
            else if (message.Type == ActivityTypes.Ping)
            {
            }

            return null;
        }
    }
}