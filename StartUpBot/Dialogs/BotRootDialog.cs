using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Luis;
using Microsoft.Bot.Builder.Luis.Models;
using Microsoft.Bot.Connector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace StartUpBot.Dialogs
{


    [LuisModel("113f64a8-2b2f-4613-81dc-fbce954a0c66", "16a81e8795df4f98bdd3083bd87c8711")]
    [Serializable]
    public class BotRootDialog : LuisDialog<object>
    {
        [LuisIntent("GetStarted")]//This handles the intention of the user when asking to know about the bot
        public async Task GetStarted(IDialogContext context, LuisResult result)
        {
            var reply = context.MakeMessage();
            string nm = reply.Recipient.Name;
            await context.PostAsync("Welcome Entrepreneur  \U0001F44F \U0001F44F \U0001F44F \U0001F601 \U0001F602 \U0001F603, glad to have you on board \U0001F386 \U0001F386 \U0001F386 \U00002728 .\n\n I am a startup bot,you can call me Santa\U0001F385 and if i guess right, you are " + nm + "\n\n Nice name by the way \U0001F609");
            await context.PostAsync("I can guide\U0001F482 you through building a successful company\U0001F3E2 by first building a good business model and having it tested.");
            PromptDialog.Confirm(context, quickR, "Would you like to get started?\U0001F616");
            
        }


        private async Task quickR(IDialogContext context, IAwaitable<bool> result)
        {
            if (await result)
            {
                IMessageActivity message = new Activity();
                await context.Forward(new BusinessModelDialog(), this.ok,message,CancellationToken.None);
                
            }
            else
            {
                Activity reply = context.MakeMessage() as Activity;
                reply.AttachmentLayout = AttachmentLayoutTypes.Carousel;
                reply.Attachments = new List<Attachment>();
                Dictionary<string, string> cardContentList = new Dictionary<string, string>();
                cardContentList.Add("https://themission.co/the-7-worst-lies-they-want-you-to-believe-about-creativity-c019bd0db0ff", "https://cdn-images-1.medium.com/max/2000/1*nPaaE0cdWTMvCf-kGxYvpw@2x.jpeg");
                cardContentList.Add("https://medium.com/personal-growth/6-very-good-reasons-to-quit-aa700d901605", "https://cdn-images-1.medium.com/max/1000/1*pq-UFjff8mbS4Ahuu4GlaQ.jpeg");
                cardContentList.Add("https://medium.com/@garyvee/business-is-my-vehicle-1baf5f47d76c", "https://cdn-images-1.medium.com/max/1000/1*XJJNbxKfobwCwmiQB6bu0A.jpeg");
                cardContentList.Add("https://medium.com/startup-grind/people-dont-buy-products-they-buy-better-versions-of-themselves-2ce85fdb5ff1", "https://cdn-images-1.medium.com/max/2000/1*mtvb06twTMVn4213KqmoyA.jpeg");

                int counter = 0;
                foreach(KeyValuePair<string, string> cardContent in cardContentList)
{
    List<CardImage> cardImages = new List<CardImage>();
    cardImages.Add(new CardImage(url:cardContent.Value ));

    List<CardAction> cardButtons = new List<CardAction>();

    CardAction plButton = new CardAction()
    {
        Value = cardContent.Key,
        Type = "openUrl",
        Title = "Read Article"
    };

    cardButtons.Add(plButton);

    if (counter == 0)
    {
        HeroCard plCard = new HeroCard()
        {
            Title = "The 7 worst lies they want you to believe about creativity",
            Subtitle = "Business Tips",
            Images = cardImages,
            Buttons = cardButtons
        };
        Attachment plAttachment = plCard.ToAttachment();
        reply.Attachments.Add(plAttachment);
        counter++;
    }
    else if (counter == 1)
    {
        HeroCard plCard = new HeroCard()
        {
            Title = "8 very good reasons to quit",
            Subtitle = "Business Tips",
            Images = cardImages,
            Buttons = cardButtons
        };
        Attachment plAttachment = plCard.ToAttachment();
        reply.Attachments.Add(plAttachment);
        counter++;
    }
    else if (counter == 2)
    {
        HeroCard plCard = new HeroCard()
        {
            Title = "Business is my vehicle",
            Subtitle = "Business Tips",
            Images = cardImages,
            Buttons = cardButtons
        };
        Attachment plAttachment = plCard.ToAttachment();
        reply.Attachments.Add(plAttachment);
        counter++;
    }
    else if (counter == 3)
    {
        HeroCard plCard = new HeroCard()
        {
            Title = "People don't buy products they buy a better version of themselves",
            Subtitle = "Business Tips",
            Images = cardImages,
            Buttons = cardButtons
        };
        Attachment plAttachment = plCard.ToAttachment();
        reply.Attachments.Add(plAttachment);
        counter++;
    }
    
}
              await context.PostAsync(reply);
              context.Wait(MessageReceived);
            }
            
        }

        private async Task ok(IDialogContext context, IAwaitable<object> result)
        {
            await context.PostAsync("Still studying in school ....\U0001F603 \n\nLearning to test business models. Check out this tips");
            Activity reply = context.MakeMessage() as Activity;
            reply.AttachmentLayout = AttachmentLayoutTypes.Carousel;
            reply.Attachments = new List<Attachment>();
            Dictionary<string, string> cardContentList = new Dictionary<string, string>();
            cardContentList.Add("https://themission.co/the-7-worst-lies-they-want-you-to-believe-about-creativity-c019bd0db0ff", "https://cdn-images-1.medium.com/max/2000/1*nPaaE0cdWTMvCf-kGxYvpw@2x.jpeg");
            cardContentList.Add("https://medium.com/personal-growth/6-very-good-reasons-to-quit-aa700d901605", "https://cdn-images-1.medium.com/max/1000/1*pq-UFjff8mbS4Ahuu4GlaQ.jpeg");
            cardContentList.Add("https://medium.com/@garyvee/business-is-my-vehicle-1baf5f47d76c", "https://cdn-images-1.medium.com/max/1000/1*XJJNbxKfobwCwmiQB6bu0A.jpeg");
            cardContentList.Add("https://medium.com/startup-grind/people-dont-buy-products-they-buy-better-versions-of-themselves-2ce85fdb5ff1", "https://cdn-images-1.medium.com/max/2000/1*mtvb06twTMVn4213KqmoyA.jpeg");

            int counter = 0;
            foreach (KeyValuePair<string, string> cardContent in cardContentList)
            {
                List<CardImage> cardImages = new List<CardImage>();
                cardImages.Add(new CardImage(url: cardContent.Value));

                List<CardAction> cardButtons = new List<CardAction>();

                CardAction plButton = new CardAction()
                {
                    Value = cardContent.Key,
                    Type = "openUrl",
                    Title = "Read Article"
                };

                cardButtons.Add(plButton);

                if (counter == 0)
                {
                    HeroCard plCard = new HeroCard()
                    {
                        Title = "The 7 worst lies they want you to believe about creativity",
                        Subtitle = "Business Tips",
                        Images = cardImages,
                        Buttons = cardButtons
                    };
                    Attachment plAttachment = plCard.ToAttachment();
                    reply.Attachments.Add(plAttachment);
                    counter++;
                }
                else if (counter == 1)
                {
                    HeroCard plCard = new HeroCard()
                    {
                        Title = "8 very good reasons to quit",
                        Subtitle = "Business Tips",
                        Images = cardImages,
                        Buttons = cardButtons
                    };
                    Attachment plAttachment = plCard.ToAttachment();
                    reply.Attachments.Add(plAttachment);
                    counter++;
                }
                else if (counter == 2)
                {
                    HeroCard plCard = new HeroCard()
                    {
                        Title = "Business is my vehicle",
                        Subtitle = "Business Tips",
                        Images = cardImages,
                        Buttons = cardButtons
                    };
                    Attachment plAttachment = plCard.ToAttachment();
                    reply.Attachments.Add(plAttachment);
                    counter++;
                }
                else if (counter == 3)
                {
                    HeroCard plCard = new HeroCard()
                    {
                        Title = "People don't buy products they buy a better version of themselves",
                        Subtitle = "Business Tips",
                        Images = cardImages,
                        Buttons = cardButtons
                    };
                    Attachment plAttachment = plCard.ToAttachment();
                    reply.Attachments.Add(plAttachment);
                    counter++;
                }

            }
            await context.PostAsync(reply);
            context.Wait(MessageReceived);
        }

        [LuisIntent("")]
        public async Task None(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("Currently studying business at Stanford.......\U0001F603 \n\nGotcha!!");
            context.Wait(MessageReceived);
        }

        [LuisIntent("Help")]//This handles the intention of the user when asking to know about the bot
        public async Task Help(IDialogContext context, LuisResult result)
        {
            var reply = context.MakeMessage();
            string nm = reply.Recipient.Name;
            await context.PostAsync("Hey Future Billionaire\U0001F603,");
            
            PromptDialog.Confirm(context, quickR, "Would you like to get started?\U0001F616");
            //context.Call(new BusinessModelDialog(), this.ok);
            
        }
    }
}