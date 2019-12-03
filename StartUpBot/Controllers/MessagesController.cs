using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;
using System;

namespace StartUpBot
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
                await Conversation.SendAsync(activity, () => new Dialogs.BotRootDialog());
            }
            else
            {
                HandleSystemMessage(activity);
            }
            var response = Request.CreateResponse(HttpStatusCode.OK);
            return response;
        }

        private async Task<Activity> HandleSystemMessage(Activity message)
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
                IConversationUpdateActivity update = message;
                var client = new ConnectorClient(new Uri(message.ServiceUrl), new MicrosoftAppCredentials());
                if (update.MembersAdded != null && update.MembersAdded.Count>0)
                {
                    foreach (var newMember in update.MembersAdded)
                    {
                        if (newMember.Id != message.Recipient.Id)
                        {
                            var reply = message.CreateReply();
                            reply.Text = "Hey Future Billionaire\U0001F603, glad to see you again \U0001F386 \U0001F386 \U00002728 .\n\n I am a startup bot,you can call me Santa\U0001F385 for short. \n\n I can guide\U0001F482 you through building a successful company\U0001F3E2 by first building a good business model and having it tested.";
                            await client.Conversations.ReplyToActivityAsync(reply);
                        }
                    }
                }
                
            }
            else if (message.Type == ActivityTypes.ContactRelationUpdate)
            {
                // Handle add/remove from contact lists
                // Activity.From + Activity.Action represent what happened
                IContactRelationUpdateActivity update = message;
                var client = new ConnectorClient(new Uri(message.ServiceUrl), new MicrosoftAppCredentials());
            
                 
                if (update.Action.ToLower() == "add")
                {
                    var reply = message.CreateReply();
                    reply.Text = "Welcome Entrepreneur  \U0001F44F \U0001F44F \U0001F44F \U0001F601 \U0001F602 \U0001F603, glad to have you on board \U0001F386 \U0001F386 \U0001F386 \U00002728 .\n\n I am a startup bot,you can call me Santa\U0001F385 and if i guess right, you are " + reply.Recipient.Name + "\n\n Nice name by the way \U0001F609 \n\n I can guide\U0001F482 you through building a successful company\U0001F3E2 by first building a good business model and having it tested.";
                    await client.Conversations.ReplyToActivityAsync(reply);
                }
            
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