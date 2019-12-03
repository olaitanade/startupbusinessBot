using Microsoft.Bot.Builder.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using Microsoft.Bot.Connector;

namespace StartUpBot.Dialogs
{
    [Serializable]
    public class BusinessModelDialog : IDialog<object>
    {
        string customervalue = "";
        string positioning = "";
        string pricelevel = "";
        string experiencecycle = "";
        public async Task StartAsync(IDialogContext context)
        {
            context.Wait(customervalueAsync);
        }

        private async Task customervalueAsync(IDialogContext context, IAwaitable<object> result)
        {
            await context.PostAsync("Session Started");
            await context.PostAsync("So to build a successful business model, we need to answer some very important questions that form the entire structure of the business.\n\n I will guide you through the questions after which the business structure is built. I also would kinda give you a success rate, so lets have some fun.\n\n If you get tired of the session just say 'Thank you for the session'.");
            
            var reply = context.MakeMessage();
            reply.Attachments = new List<Attachment>();

            List<CardAction> cardButtons = new List<CardAction>();

            CardAction plButton = new CardAction()
            {
                Value = "Reducing risk",
                Type = "imBack",
                Title = "Reducing risk"
            };
            CardAction plButton4 = new CardAction()
            {
                Value = "Saving money",
                Type = "imBack",
                Title = "Saving money"
            };
            CardAction plButton1 = new CardAction()
            {
                Value = "Building customer self image",
                Type = "imBack",
                Title = "Building customer self image"
            };
            CardAction plButton2 = new CardAction()
            {
                Value = "Improving customer productivity",
                Type = "imBack",
                Title = "Improving customer productivity"
            };
            CardAction plButton3 = new CardAction()
            {
                Value = "Simple to use",
                Type = "imBack",
                Title = "Simple to use"
            };

            cardButtons.Add(plButton);
            cardButtons.Add(plButton4);
            cardButtons.Add(plButton1);
            cardButtons.Add(plButton2);
            cardButtons.Add(plButton3);

            HeroCard plCard = new HeroCard()
            {
                Title = "Customer Value",
                Subtitle = "Why are your customers buying your solution ?",
                Buttons = cardButtons
            };
            Attachment plAttachment = plCard.ToAttachment();
            reply.Attachments.Add(plAttachment);
            await context.PostAsync(reply);

            context.Wait(positionAsync);
        }

        private async Task positionAsync(IDialogContext context, IAwaitable<object> result)
        {
            var activity = await result as Activity;
            if (activity.Text == "Reducing risk" || activity.Text == "Saving money" || activity.Text == "Building customer self image" || activity.Text == "Improving customer productivity" || activity.Text == "Simple to use")
            {
                customervalue = activity.Text;
                await context.PostAsync("7% of the model constructed. Great Job");
                var reply = activity.CreateReply();
                reply.Attachments = new List<Attachment>();

                List<CardAction> cardButtons = new List<CardAction>();

                CardAction plButton = new CardAction()
                {
                    Value = "Low cost",
                    Type = "imBack",
                    Title = "Low cost"
                };
                CardAction plButton1 = new CardAction()
                {
                    Value = "Luxury",
                    Type = "imBack",
                    Title = "Luxury"
                };
                CardAction plButton2 = new CardAction()
                {
                    Value = "Excellence",
                    Type = "imBack",
                    Title = "Excellence"
                };
                CardAction plButton3 = new CardAction()
                {
                    Value = "New market",
                    Type = "imBack",
                    Title = "New market"
                };

                cardButtons.Add(plButton);
                cardButtons.Add(plButton1);
                cardButtons.Add(plButton2);
                cardButtons.Add(plButton3);

                HeroCard plCard = new HeroCard()
                {
                    Title = "Positioning",
                    Subtitle = "How is your offer different from alternative solutions?",
                    Buttons = cardButtons
                };
                Attachment plAttachment = plCard.ToAttachment();
                reply.Attachments.Add(plAttachment);
                await context.PostAsync(reply);
                context.Wait(pricelevelAsync);
            }
            else if(activity.Text=="quit the session")
            {
                context.Done(true);
            }
            else
            {
                await context.PostAsync("Hmmm...");
                await context.PostAsync("Answer the Customer value question above or say 'quit the session' to quit");
                context.Wait(customervalueAsync);
            }
            
        }
        private async Task pricelevelAsync(IDialogContext context, IAwaitable<object> result)
        {
            var activity = await result as Activity;
            if (activity.Text == "Low cost" || activity.Text == "Luxury" || activity.Text == "Excelllence" || activity.Text == "New market")
            {
                customervalue = activity.Text;
                await context.PostAsync("15% of the model constructed. Great Job");
                var reply = activity.CreateReply();
                reply.Attachments = new List<Attachment>();
                List<CardAction> cardButtons = new List<CardAction>();
                CardAction plButton = new CardAction()
                {
                    Value = "Free",
                    Type = "imBack",
                    Title = "Free"
                };
                CardAction plButton1 = new CardAction()
                {
                    Value = "High end",
                    Type = "imBack",
                    Title = "High end"
                };
                CardAction plButton2 = new CardAction()
                {
                    Value = "Economy",
                    Type = "imBack",
                    Title = "Economy"
                };
                CardAction plButton3 = new CardAction()
                {
                    Value = "Market price",
                    Type = "imBack",
                    Title = "Market price"
                };

                cardButtons.Add(plButton);
                cardButtons.Add(plButton1);
                cardButtons.Add(plButton2);
                cardButtons.Add(plButton3);

                HeroCard plCard = new HeroCard()
                {
                    Title = "Price Level",
                    Subtitle = "At what price level should your product be sold?",
                    Buttons = cardButtons
                };
                Attachment plAttachment = plCard.ToAttachment();
                reply.Attachments.Add(plAttachment);
                await context.PostAsync(reply);
                context.Wait(experienceAsync);
            }
            else if (activity.Text == "quit the session")
            {
                context.Done(true);
            }
            else
            {
                await context.PostAsync("Hmmm...");
                await context.PostAsync("Answer the Customer value question above or say 'quit the session' to quit");
                context.Wait(positionAsync);
            }
            
        }

        private async Task experienceAsync(IDialogContext context, IAwaitable<object> result)
        {
            var activity = await result as Activity;
            if (activity.Text == "Free" || activity.Text == "High end" || activity.Text == "Economy" || activity.Text == "Market price")
            {
                customervalue = activity.Text;
                await context.PostAsync("20% of the model constructed. Great Job");
                var reply = activity.CreateReply();
                reply.Attachments = new List<Attachment>();
                List<CardAction> cardButtons = new List<CardAction>();
                CardAction plButton = new CardAction()
                {
                    Value = "When they buy",
                    Type = "imBack",
                    Title = "When they buy"
                };
                CardAction plButton1 = new CardAction()
                {
                    Value = "After sales",
                    Type = "imBack",
                    Title = "After sales"
                };
                CardAction plButton2 = new CardAction()
                {
                    Value = "Disposal",
                    Type = "imBack",
                    Title = "Disposal"
                };
                CardAction plButton3 = new CardAction()
                {
                    Value = "Use of product",
                    Type = "imBack",
                    Title = "Use of product"
                };
                CardAction plButton4 = new CardAction()
                {
                    Value = "Creation",
                    Type = "imBack",
                    Title = "Creation"
                };
                CardAction plButton5 = new CardAction()
                {
                    Value = "Repurchase",
                    Type = "imBack",
                    Title = "Repurchase"
                };

                cardButtons.Add(plButton);
                cardButtons.Add(plButton1);
                cardButtons.Add(plButton2);
                cardButtons.Add(plButton3);
                cardButtons.Add(plButton4);
                cardButtons.Add(plButton5);

                HeroCard plCard = new HeroCard()
                {
                    Title = "Experience cycle",
                    Subtitle = "When in the buying and usages process do  you create a unique customer experience?",
                    Buttons = cardButtons
                };
                Attachment plAttachment = plCard.ToAttachment();
                reply.Attachments.Add(plAttachment);
                await context.PostAsync(reply);
                context.Wait(customersAsync);
                
            }
            else if (activity.Text == "quit the session")
            {
                context.Done(true);
            }
            else
            {
                await context.PostAsync("Hmmm...");
                await context.PostAsync("Answer the Customer value question above or say 'quit the session' to quit");
                context.Wait(experienceAsync);
            }
            
        }
        private async Task customersAsync(IDialogContext context, IAwaitable<object> result)
        {
            var activity = await result as Activity;
            if (activity.Text == "When they buy" || activity.Text == "After sales" || activity.Text == "Disposal" || activity.Text == "Creation" || activity.Text == "Repurchase" || activity.Text == "Use of product")
            {
                customervalue = activity.Text;
                await context.PostAsync("25% of the model constructed. Great Job");
                var reply = activity.CreateReply();
                reply.Attachments = new List<Attachment>();
                List<CardAction> cardButtons = new List<CardAction>();
                CardAction plButton = new CardAction()
                {
                    Value = "Multisided",
                    Type = "imBack",
                    Title = "Multisided"
                };
                CardAction plButton1 = new CardAction()
                {
                    Value = "Niche",
                    Type = "imBack",
                    Title = "Niche"
                };
                CardAction plButton2 = new CardAction()
                {
                    Value = "Diversified",
                    Type = "imBack",
                    Title = "Diversified"
                };
                CardAction plButton3 = new CardAction()
                {
                    Value = "Segmented",
                    Type = "imBack",
                    Title = "Segmented"
                };
                CardAction plButton4 = new CardAction()
                {
                    Value = "Mass market",
                    Type = "imBack",
                    Title = "Mass market"
                };
                

                cardButtons.Add(plButton);
                cardButtons.Add(plButton1);
                cardButtons.Add(plButton2);
                cardButtons.Add(plButton3);
                cardButtons.Add(plButton4);
                

                HeroCard plCard = new HeroCard()
                {
                    Title = "Customers",
                    Subtitle = "Who are your customer segments?",
                    Buttons = cardButtons
                };
                Attachment plAttachment = plCard.ToAttachment();
                reply.Attachments.Add(plAttachment);
                await context.PostAsync(reply);
                context.Wait(customerRelationshipAsync);

            }
            else if (activity.Text == "quit the session")
            {
                context.Done(true);
            }
            else
            {
                await context.PostAsync("Hmmm...");
                await context.PostAsync("Answer the Customer value question above or say 'quit the session' to quit");
                context.Wait(customersAsync);
            }
            
        }

        private async Task customerRelationshipAsync(IDialogContext context, IAwaitable<object> result)
        {
            var activity = await result as Activity;
            if (activity.Text == "Multisided" || activity.Text == "Niche" || activity.Text == "Diversified" || activity.Text == "Segmented" || activity.Text == "Mass market")
            {
                customervalue = activity.Text;
                await context.PostAsync("30% of the model constructed. Great Job");
                var reply = activity.CreateReply();
                reply.Attachments = new List<Attachment>();
                List<CardAction> cardButtons = new List<CardAction>();
                CardAction plButton = new CardAction()
                {
                    Value = "0",
                    Type = "imBack",
                    Title = "0"
                };
                CardAction plButton1 = new CardAction()
                {
                    Value = "1",
                    Type = "imBack",
                    Title = "1"
                };
                CardAction plButton2 = new CardAction()
                {
                    Value = "2",
                    Type = "imBack",
                    Title = "3"
                };
                CardAction plButton3 = new CardAction()
                {
                    Value = "3",
                    Type = "imBack",
                    Title = "3"
                };

                cardButtons.Add(plButton);
                cardButtons.Add(plButton1);
                cardButtons.Add(plButton2);
                cardButtons.Add(plButton3);

                HeroCard plCard = new HeroCard()
                {
                    Title = "Customer relationship",
                    Subtitle = "How do we serve our customers?",
                    Buttons = cardButtons
                };
                Attachment plAttachment = plCard.ToAttachment();
                reply.Attachments.Add(plAttachment);
                await context.PostAsync(reply);
                context.Wait(channelsAsync);

            }
            else if (activity.Text == "quit the session")
            {
                context.Done(true);
            }
            else
            {
                await context.PostAsync("Hmmm...");
                await context.PostAsync("Answer the Customer value question above or say 'quit the session' to quit");
                context.Wait(customersAsync);
            }
            
        }
        private async Task channelsAsync(IDialogContext context, IAwaitable<object> result)
        {
            var activity = await result as Activity;
            if (activity.Text == "0" || activity.Text == "1" || activity.Text == "2" || activity.Text == "3")
            {
                customervalue = activity.Text;
                await context.PostAsync("40% of the model constructed. Great Job");
                var reply = activity.CreateReply();
                reply.Attachments = new List<Attachment>();
                List<CardAction> cardButtons = new List<CardAction>();
                CardAction plButton = new CardAction()
                {
                    Value = "Vas",
                    Type = "imBack",
                    Title = "Value-added reseller"
                };
                CardAction plButton1 = new CardAction()
                {
                    Value = "Dealers",
                    Type = "imBack",
                    Title = "Dealers"
                };
                CardAction plButton2 = new CardAction()
                {
                    Value = "Oem",
                    Type = "imBack",
                    Title = "OEM manufacturers"
                };
                CardAction plButton3 = new CardAction()
                {
                    Value = "System integrators",
                    Type = "imBack",
                    Title = "System integrators"
                };
                CardAction plButton4 = new CardAction()
                {
                    Value = "Partner shops",
                    Type = "imBack",
                    Title = "Partner shops"
                };
                CardAction plButton5 = new CardAction()
                {
                    Value = "Temporary outlets",
                    Type = "imBack",
                    Title = "Temporary outlets"
                };
                CardAction plButton6 = new CardAction()
                {
                    Value = "Own retail stores",
                    Type = "imBack",
                    Title = "Own retail stores"
                };
                CardAction plButton7 = new CardAction()
                {
                    Value = "Online sales-own platform",
                    Type = "imBack",
                    Title = "Online sales-own platform"
                };
                CardAction plButton8 = new CardAction()
                {
                    Value = "Online sales-other platforms",
                    Type = "imBack",
                    Title = "Online sales-other platforms"
                };
                CardAction plButton9 = new CardAction()
                {
                    Value = "Distributors",
                    Type = "imBack",
                    Title = "Distributors"
                };
                CardAction plButton10 = new CardAction()
                {
                    Value = "Direct sales force",
                    Type = "imBack",
                    Title = "Direct sales force"
                };
                cardButtons.Add(plButton);
                cardButtons.Add(plButton1);
                cardButtons.Add(plButton2);
                cardButtons.Add(plButton3);
                cardButtons.Add(plButton4);
                cardButtons.Add(plButton5);
                cardButtons.Add(plButton6);
                cardButtons.Add(plButton7);
                cardButtons.Add(plButton8);
                cardButtons.Add(plButton9);
                cardButtons.Add(plButton10);

                HeroCard plCard = new HeroCard()
                {
                    Title = "Channels",
                    Subtitle = "How do you reach your customers?",
                    Buttons = cardButtons
                };
                Attachment plAttachment = plCard.ToAttachment();
                reply.Attachments.Add(plAttachment);
                await context.PostAsync(reply);
                context.Wait(physicalAsync);

            }
            else if (activity.Text == "quit the session")
            {
                context.Done(true);
            }
            else
            {
                await context.PostAsync("Hmmm...");
                await context.PostAsync("Answer the Customer value question above or say 'quit the session' to quit");
                context.Wait(customersAsync);
            }
        }

        private async Task resourcesAsync(IDialogContext context, IAwaitable<object> result)
        {
            var activity = await result as Activity;
            if (activity.Text == "Low cost" || activity.Text == "Luxury" || activity.Text == "Excelllence" || activity.Text == "New market")
            {
                customervalue = activity.Text;
                await context.PostAsync("10% of the model constructed. Great Job");
                var reply = activity.CreateReply();
                reply.Attachments = new List<Attachment>();
                List<CardAction> cardButtons = new List<CardAction>();
                CardAction plButton = new CardAction()
                {
                    Value = "Free",
                    Type = "imBack",
                    Title = "Free"
                };
                CardAction plButton1 = new CardAction()
                {
                    Value = "High end",
                    Type = "imBack",
                    Title = "High end"
                };
                CardAction plButton2 = new CardAction()
                {
                    Value = "Economy",
                    Type = "imBack",
                    Title = "Economy"
                };
                CardAction plButton3 = new CardAction()
                {
                    Value = "Market price",
                    Type = "imBack",
                    Title = "Market price"
                };

                cardButtons.Add(plButton);
                cardButtons.Add(plButton1);
                cardButtons.Add(plButton2);
                cardButtons.Add(plButton3);

                HeroCard plCard = new HeroCard()
                {
                    Title = "Price Level",
                    Subtitle = "At what price level should your product be sold?",
                    Buttons = cardButtons
                };
                Attachment plAttachment = plCard.ToAttachment();
                reply.Attachments.Add(plAttachment);
                await context.PostAsync(reply);
                context.Wait(customersAsync);

            }
            else if (activity.Text == "quit the session")
            {
                context.Done(true);
            }
            else
            {
                await context.PostAsync("Hmmm...");
                await context.PostAsync("Answer the Customer value question above or say 'quit the session' to quit");
                context.Wait(experienceAsync);
            }
            context.Wait(physicalAsync);
        }
        private async Task physicalAsync(IDialogContext context, IAwaitable<object> result)
        {
            var activity = await result as Activity;
            if (activity.Text == "Vas" || activity.Text == "Oem" || activity.Text == "Dealers" || activity.Text == "Distributors" || activity.Text == "System integrators" || activity.Text == "Partner Shops" || activity.Text == "Temporary outlets" || activity.Text == "Own retail stores" || activity.Text == "Direct sales force" || activity.Text == "Online sales-own platform" || activity.Text == "Online sales-other platforms")
            {
                customervalue = activity.Text;
                await context.PostAsync("45% of the model constructed. Great Job");
                var reply = activity.CreateReply();
                reply.Attachments = new List<Attachment>();
                List<CardAction> cardButtons = new List<CardAction>();
                CardAction plButton = new CardAction()
                {
                    Value = "Location and site",
                    Type = "imBack",
                    Title = "Location and site"
                };
                CardAction plButton1 = new CardAction()
                {
                    Value = "Premises",
                    Type = "imBack",
                    Title = "Premises"
                };
                CardAction plButton2 = new CardAction()
                {
                    Value = "Machines and equipment",
                    Type = "imBack",
                    Title = "Machines and equipment"
                };
                CardAction plButton3 = new CardAction()
                {
                    Value = "Premises + Machines and equipment",
                    Type = "imBack",
                    Title = "Premises + Machines and equipment"
                };

                cardButtons.Add(plButton);
                cardButtons.Add(plButton1);
                cardButtons.Add(plButton2);
                cardButtons.Add(plButton3);

                HeroCard plCard = new HeroCard()
                {
                    Title = "Physical resources",
                    Subtitle = "What are the key physical resources you need in your business?",
                    Buttons = cardButtons
                };
                Attachment plAttachment = plCard.ToAttachment();
                reply.Attachments.Add(plAttachment);
                await context.PostAsync(reply);
                context.Wait(financialAsync);

            }
            else if (activity.Text == "quit the session")
            {
                context.Done(true);
            }
            else
            {
                await context.PostAsync("Hmmm...");
                await context.PostAsync("Answer the Customer value question above or say 'quit the session' to quit");
                context.Wait(customersAsync);
            }
            
        }

        private async Task financialAsync(IDialogContext context, IAwaitable<object> result)
        {
            var activity = await result as Activity;
            if (activity.Text == "Location and site" || activity.Text == "Premises" || activity.Text == "Machines and equipment" || activity.Text == "Premises + Machines and equipment")
            {
                customervalue = activity.Text;
                await context.PostAsync("55% of the model constructed. Great Job");
                var reply = activity.CreateReply();
                reply.Attachments = new List<Attachment>();
                List<CardAction> cardButtons = new List<CardAction>();
                CardAction plButton = new CardAction()
                {
                    Value = "Crowd funding",
                    Type = "imBack",
                    Title = "Crowd funding"
                };
                CardAction plButton1 = new CardAction()
                {
                    Value = "Customer funding",
                    Type = "imBack",
                    Title = "Customer funding"
                };
                CardAction plButton2 = new CardAction()
                {
                    Value = "Venture capital",
                    Type = "imBack",
                    Title = "Venture capital"
                };
                CardAction plButton3 = new CardAction()
                {
                    Value = "Supplier credit",
                    Type = "imBack",
                    Title = "Supplier credit"
                };
                CardAction plButton4 = new CardAction()
                {
                    Value = "Donations",
                    Type = "imBack",
                    Title = "Donations"
                };
                CardAction plButton5 = new CardAction()
                {
                    Value = "Loan and credits",
                    Type = "imBack",
                    Title = "Loan and credits"
                };
                CardAction plButton6 = new CardAction()
                {
                    Value = "Grants and subsidies",
                    Type = "imBack",
                    Title = "Grants and subsidies"
                };
                CardAction plButton7 = new CardAction()
                {
                    Value = "Equity",
                    Type = "imBack",
                    Title = "Equity"
                };
                cardButtons.Add(plButton);
                cardButtons.Add(plButton1);
                cardButtons.Add(plButton2);
                cardButtons.Add(plButton3);
                cardButtons.Add(plButton4);
                cardButtons.Add(plButton5);
                cardButtons.Add(plButton6);
                cardButtons.Add(plButton7);

                HeroCard plCard = new HeroCard()
                {
                    Title = "Financial resources",
                    Subtitle = "Where can you raise money for your investments and for daily operations?",
                    Buttons = cardButtons
                };
                Attachment plAttachment = plCard.ToAttachment();
                reply.Attachments.Add(plAttachment);
                await context.PostAsync(reply);
                context.Wait(humanAsync);

            }
            else if (activity.Text == "quit the session")
            {
                context.Done(true);
            }
            else
            {
                await context.PostAsync("Hmmm...");
                await context.PostAsync("Answer the Customer value question above or say 'quit the session' to quit");
                context.Wait(experienceAsync);
            }
            
        }
        private async Task humanAsync(IDialogContext context, IAwaitable<object> result)
        {
            var activity = await result as Activity;
            if (activity.Text == "Crowd funding" || activity.Text == "Customer funding" || activity.Text == "Venture capital" || activity.Text == "Supplier credit" || activity.Text == "Donations" || activity.Text == "Loan and credits" || activity.Text == "Grants and subsidies" || activity.Text == "Equity")
            {
                customervalue = activity.Text;
                await context.PostAsync("60% of the model constructed. Great Job");
                var reply = activity.CreateReply();
                reply.Attachments = new List<Attachment>();
                List<CardAction> cardButtons = new List<CardAction>();
                CardAction plButton = new CardAction()
                {
                    Value = "Specialist",
                    Type = "imBack",
                    Title = "Specialist"
                };
                CardAction plButton1 = new CardAction()
                {
                    Value = "Crowd sourcing",
                    Type = "imBack",
                    Title = "Crowd sourcing"
                };
                CardAction plButton2 = new CardAction()
                {
                    Value = "Labour",
                    Type = "imBack",
                    Title = "Labour"
                };
                CardAction plButton3 = new CardAction()
                {
                    Value = "Advisors",
                    Type = "imBack",
                    Title = "Advisors"
                };
                CardAction plButton4 = new CardAction()
                {
                    Value = "Management team",
                    Type = "imBack",
                    Title = "Management team"
                };
                
                CardAction plButton5 = new CardAction()
                {
                    Value = "Board,Coach or mentor",
                    Type = "imBack",
                    Title = "Board,Coach or mentor"
                };

                cardButtons.Add(plButton);
                cardButtons.Add(plButton1);
                cardButtons.Add(plButton2);
                cardButtons.Add(plButton3);
                cardButtons.Add(plButton4);
                cardButtons.Add(plButton5);
                

                HeroCard plCard = new HeroCard()
                {
                    Title = "Human resources",
                    Subtitle = "What kind of people are involved in the project and who do you need to get involved?",
                    Buttons = cardButtons
                };
                Attachment plAttachment = plCard.ToAttachment();
                reply.Attachments.Add(plAttachment);
                await context.PostAsync(reply);
                context.Wait(intelluctualAsync);

            }
            else if (activity.Text == "quit the session")
            {
                context.Done(true);
            }
            else
            {
                await context.PostAsync("Hmmm...");
                await context.PostAsync("Answer the Customer value question above or say 'quit the session' to quit");
                context.Wait(intelluctualAsync);
            }
            
        }

        private async Task intelluctualAsync(IDialogContext context, IAwaitable<object> result)
        {
            var activity = await result as Activity;
            if (activity.Text == "Specialist" || activity.Text == "Crowd sourcing" || activity.Text == "Labour" || activity.Text == "Advisors" || activity.Text == "Management team" || activity.Text == "Board,Coach or mentor")
            {
                customervalue = activity.Text;
                await context.PostAsync("65% of the model constructed. Great Job");
                var reply = activity.CreateReply();
                reply.Attachments = new List<Attachment>();
                List<CardAction> cardButtons = new List<CardAction>();
                CardAction plButton = new CardAction()
                {
                    Value = "Experience + tacit knowledge",
                    Type = "imBack",
                    Title = "Experience + tacit knowledge"
                };
                CardAction plButton1 = new CardAction()
                {
                    Value = "Copyright",
                    Type = "imBack",
                    Title = "Copyright"
                };
                CardAction plButton2 = new CardAction()
                {
                    Value = "Information databases",
                    Type = "imBack",
                    Title = "Information databases"
                };
                CardAction plButton3 = new CardAction()
                {
                    Value = "Trade secrets",
                    Type = "imBack",
                    Title = "Trade secrets"
                };
                CardAction plButton4 = new CardAction()
                {
                    Value = "Industrial design",
                    Type = "imBack",
                    Title = "Industrial design"
                };
                CardAction plButton5 = new CardAction()
                {
                    Value = "Trademark",
                    Type = "imBack",
                    Title = "Trademark"
                };
                CardAction plButton6 = new CardAction()
                {
                    Value = "Patent",
                    Type = "imBack",
                    Title = "Patent"
                };
                cardButtons.Add(plButton);
                cardButtons.Add(plButton1);
                cardButtons.Add(plButton2);
                cardButtons.Add(plButton3);
                cardButtons.Add(plButton4);
                cardButtons.Add(plButton5);
                cardButtons.Add(plButton6);
                

                HeroCard plCard = new HeroCard()
                {
                    Title = "Intelluctual resources",
                    Subtitle = "Is there any kind of intellectual property rights, trade secrets or know how in general,that can give you a sustaining competitive advantage ?",
                    Buttons = cardButtons
                };
                Attachment plAttachment = plCard.ToAttachment();
                reply.Attachments.Add(plAttachment);
                await context.PostAsync(reply);
                context.Wait(valuechainAsync);
                //context.Done(true);
            }
            else if (activity.Text == "quit the session")
            {
                context.Done(true);
            }
            else
            {
                await context.PostAsync("Hmmm...");
                await context.PostAsync("Answer the Customer value question above or say 'quit the session' to quit");
                context.Wait(intelluctualAsync);
            }
            
        }
       
        private async Task partnershipAsync(IDialogContext context, IAwaitable<object> result)
        {
            var activity = await result as Activity;
            if (activity.Text == "Open innovation platform" || activity.Text == "Media platform" || activity.Text == "Service platform" || activity.Text == "Software platform" || activity.Text == "Marketplace platform" || activity.Text == "Product platform" || activity.Text == "Event platform" || activity.Text == "Community platform")
            {
                customervalue = activity.Text;
                await context.PostAsync("60% of the model constructed. Great Job");
                var reply = activity.CreateReply();
                reply.Attachments = new List<Attachment>();
                List<CardAction> cardButtons = new List<CardAction>();
                CardAction plButton = new CardAction()
                {
                    Value = "Joint venture",
                    Type = "imBack",
                    Title = "Joint venture"
                };
                CardAction plButton1 = new CardAction()
                {
                    Value = "Sourcing partner",
                    Type = "imBack",
                    Title = "Sourcing partner"
                };
                CardAction plButton2 = new CardAction()
                {
                    Value = "Consortium",
                    Type = "imBack",
                    Title = "Consortium"
                };
                CardAction plButton3 = new CardAction()
                {
                    Value = "Marketing partners",
                    Type = "imBack",
                    Title = "Marketing partners"
                };
                CardAction plButton4 = new CardAction()
                {
                    Value = "Open innovation",
                    Type = "imBack",
                    Title = "Open innovation"
                };
                CardAction plButton5 = new CardAction()
                {
                    Value = "Strategic alliance",
                    Type = "imBack",
                    Title = "Strategic alliance"
                };
                CardAction plButton6 = new CardAction()
                {
                    Value = "Resource sharing",
                    Type = "imBack",
                    Title = "Resource sharing"
                };
                CardAction plButton7 = new CardAction()
                {
                    Value = "Purchasing partnership",
                    Type = "imBack",
                    Title = "Purchasing partnership"
                };

                cardButtons.Add(plButton);
                cardButtons.Add(plButton1);
                cardButtons.Add(plButton2);
                cardButtons.Add(plButton3);
                cardButtons.Add(plButton4);
                cardButtons.Add(plButton5);
                cardButtons.Add(plButton6);
                cardButtons.Add(plButton7);

                HeroCard plCard = new HeroCard()
                {
                    Title = "Partnerships",
                    Subtitle = "How do you cooperate with partners?",
                    Buttons = cardButtons
                };
                Attachment plAttachment = plCard.ToAttachment();
                reply.Attachments.Add(plAttachment);
                await context.PostAsync(reply);
                context.Wait(revenueAsync);

            }
            else if (activity.Text == "quit the session")
            {
                context.Done(true);
            }
            else
            {
                await context.PostAsync("Hmmm...");
                await context.PostAsync("Answer the Customer value question above or say 'quit the session' to quit");
                context.Wait(intelluctualAsync);
            }

        }
        private async Task valuechainAsync(IDialogContext context, IAwaitable<object> result)
        {
            var activity = await result as Activity;
            if (activity.Text == "Experience + tacit knowledge" || activity.Text == "Copyright" || activity.Text == "Information databases" || activity.Text == "Trade secrets" || activity.Text == "Industrial design" || activity.Text == "Trademark" || activity.Text == "Patent")
            {
                customervalue = activity.Text;
                await context.PostAsync("60% of the model constructed. Great Job");
                var reply = activity.CreateReply();
                reply.Attachments = new List<Attachment>();
                List<CardAction> cardButtons = new List<CardAction>();
                CardAction plButton = new CardAction()
                {
                    Value = "Content Production",
                    Type = "imBack",
                    Title = "Content Production"
                };
                CardAction plButton1 = new CardAction()
                {
                    Value = "Production",
                    Type = "imBack",
                    Title = "Production"
                };
                CardAction plButton2 = new CardAction()
                {
                    Value = "Training and education",
                    Type = "imBack",
                    Title = "Training and education"
                };
                CardAction plButton3 = new CardAction()
                {
                    Value = "Logistics and infrastructure",
                    Type = "imBack",
                    Title = "Logistics and infrastructure"
                };
                CardAction plButton4 = new CardAction()
                {
                    Value = "Trade",
                    Type = "imBack",
                    Title = "Trade"
                };
                CardAction plButton5 = new CardAction()
                {
                    Value = "Service",
                    Type = "imBack",
                    Title = "Service"
                };

                cardButtons.Add(plButton);
                cardButtons.Add(plButton1);
                cardButtons.Add(plButton2);
                cardButtons.Add(plButton3);
                cardButtons.Add(plButton4);
                cardButtons.Add(plButton5);
                

                HeroCard plCard = new HeroCard()
                {
                    Title = "Value Chain",
                    Subtitle = "Is your business based on repeated and standardized processes performed by low-skilled labour leading to mass produced and standardized products or services?",
                    Buttons = cardButtons
                };
                Attachment plAttachment = plCard.ToAttachment();
                reply.Attachments.Add(plAttachment);
                await context.PostAsync(reply);
                context.Wait(workshopAsync);

            }
            else if (activity.Text == "quit the session")
            {
                context.Done(true);
            }
            else
            {
                await context.PostAsync("Hmmm...");
                await context.PostAsync("Answer the Customer value question above or say 'quit the session' to quit");
                context.Wait(intelluctualAsync);
            }

        }
        private async Task workshopAsync(IDialogContext context, IAwaitable<object> result)
        {
            var activity = await result as Activity;
            if (activity.Text == "Content Production" || activity.Text == "Production" || activity.Text == "Training and education" || activity.Text == "Logistics and infrastructure" || activity.Text == "Trade" || activity.Text == "Service")
            {
                customervalue = activity.Text;
                await context.PostAsync("60% of the model constructed. Great Job");
                var reply = activity.CreateReply();
                reply.Attachments = new List<Attachment>();
                List<CardAction> cardButtons = new List<CardAction>();
                CardAction plButton = new CardAction()
                {
                    Value = "Art and Craft",
                    Type = "imBack",
                    Title = "Art and Craft"
                };
                CardAction plButton1 = new CardAction()
                {
                    Value = "Knowledge service",
                    Type = "imBack",
                    Title = "Knowledge service"
                };
                CardAction plButton2 = new CardAction()
                {
                    Value = "Research and Development",
                    Type = "imBack",
                    Title = "Research and Development"
                };
                CardAction plButton3 = new CardAction()
                {
                    Value = "Projects",
                    Type = "imBack",
                    Title = "Projects"
                };
                CardAction plButton4 = new CardAction()
                {
                    Value = "Events",
                    Type = "imBack",
                    Title = "Events"
                };

                cardButtons.Add(plButton);
                cardButtons.Add(plButton1);
                cardButtons.Add(plButton2);
                cardButtons.Add(plButton3);
                cardButtons.Add(plButton4);

                HeroCard plCard = new HeroCard()
                {
                    Title = "Workshop",
                    Subtitle = "Is your business based on more problem or project specific processes performed by specialized labour and leading to individualised products or services.",
                    Buttons = cardButtons
                };
                Attachment plAttachment = plCard.ToAttachment();
                reply.Attachments.Add(plAttachment);
                await context.PostAsync(reply);
                context.Wait(platformAsync);

            }
            else if (activity.Text == "quit the session")
            {
                context.Done(true);
            }
            else
            {
                await context.PostAsync("Hmmm...");
                await context.PostAsync("Answer the Customer value question above or say 'quit the session' to quit");
                context.Wait(intelluctualAsync);
            }

        }
        private async Task platformAsync(IDialogContext context, IAwaitable<object> result)
        {
            var activity = await result as Activity;
            if (activity.Text == "Art and Craft" || activity.Text == "Knowledge service" || activity.Text == "Research and Development" || activity.Text == "Projects" || activity.Text == "Events" )
            {
                customervalue = activity.Text;
                await context.PostAsync("60% of the model constructed. Great Job");
                var reply = activity.CreateReply();
                reply.Attachments = new List<Attachment>();
                List<CardAction> cardButtons = new List<CardAction>();
                CardAction plButton = new CardAction()
                {
                    Value = "Open innovation platform",
                    Type = "imBack",
                    Title = "Open innovation platform"
                };
                CardAction plButton1 = new CardAction()
                {
                    Value = "Media platform",
                    Type = "imBack",
                    Title = "Media platform"
                };
                CardAction plButton2 = new CardAction()
                {
                    Value = "Service platform",
                    Type = "imBack",
                    Title = "Service platform"
                };
                CardAction plButton3 = new CardAction()
                {
                    Value = "Software platform",
                    Type = "imBack",
                    Title = "Software platform"
                };
                CardAction plButton4 = new CardAction()
                {
                    Value = "Marketplace platform",
                    Type = "imBack",
                    Title = "Marketplace platform"
                };
                CardAction plButton5 = new CardAction()
                {
                    Value = "Product platform",
                    Type = "imBack",
                    Title = "Product platform"
                };
                CardAction plButton6 = new CardAction()
                {
                    Value = "Event platform",
                    Type = "imBack",
                    Title = "Event platform"
                };
                CardAction plButton7 = new CardAction()
                {
                    Value = "Community platform",
                    Type = "imBack",
                    Title = "Community platform"
                };

                cardButtons.Add(plButton);
                cardButtons.Add(plButton1);
                cardButtons.Add(plButton2);
                cardButtons.Add(plButton3);
                cardButtons.Add(plButton4);
                cardButtons.Add(plButton5);
                cardButtons.Add(plButton6);
                cardButtons.Add(plButton7);

                HeroCard plCard = new HeroCard()
                {
                    Title = "Platform",
                    Subtitle = "Is your business offering a facility or platform, where different segments of organisations and/or people and meet to communicate or exchange products or services",
                    Buttons = cardButtons
                };
                Attachment plAttachment = plCard.ToAttachment();
                reply.Attachments.Add(plAttachment);
                await context.PostAsync(reply);
                context.Wait(intelluctualAsync);

            }
            else if (activity.Text == "quit the session")
            {
                context.Done(true);
            }
            else
            {
                await context.PostAsync("Hmmm...");
                await context.PostAsync("Answer the Customer value question above or say 'quit the session' to quit");
                context.Wait(partnershipAsync);
            }

        }
        private async Task revenueAsync(IDialogContext context, IAwaitable<object> result)
        {
            var activity = await result as Activity;
            if (activity.Text == "Joint venture" || activity.Text == "Sourcing partner" || activity.Text == "Consortium" || activity.Text == "Marketing partners" || activity.Text == "Open innovation" || activity.Text == "Strategic alliance" || activity.Text == "Resource sharing" || activity.Text == "Purchasing partnership")
            {
                customervalue = activity.Text;
                await context.PostAsync("60% of the model constructed. Great Job");
                var reply = activity.CreateReply();
                reply.Attachments = new List<Attachment>();
                List<CardAction> cardButtons = new List<CardAction>();
                CardAction plButton = new CardAction()
                {
                    Value = "Transaction fee",
                    Type = "imBack",
                    Title = "Transaction fee"
                };
                CardAction plButton1 = new CardAction()
                {
                    Value = "Selling hours",
                    Type = "imBack",
                    Title = "Selling hours"
                };
                CardAction plButton2 = new CardAction()
                {
                    Value = "Commission",
                    Type = "imBack",
                    Title = "Commission"
                };
                CardAction plButton3 = new CardAction()
                {
                    Value = "Advertising",
                    Type = "imBack",
                    Title = "Advertising"
                };
                CardAction plButton4 = new CardAction()
                {
                    Value = "Membership",
                    Type = "imBack",
                    Title = "Membership"
                };
                CardAction plButton5 = new CardAction()
                {
                    Value = "Subscription",
                    Type = "imBack",
                    Title = "Subscription"
                };
                CardAction plButton6 = new CardAction()
                {
                    Value = "Product sales",
                    Type = "imBack",
                    Title = "Product sales"
                };
                CardAction plButton7 = new CardAction()
                {
                    Value = "Sponsorship",
                    Type = "imBack",
                    Title = "Sponsorship"
                };
                CardAction plButton8 = new CardAction()
                {
                    Value = "Project sales",
                    Type = "imBack",
                    Title = "Project sales"
                };
                CardAction plButton9 = new CardAction()
                {
                    Value = "License fee",
                    Type = "imBack",
                    Title = "License fee"
                };
                CardAction plButton10 = new CardAction()
                {
                    Value = "Rent and leasing",
                    Type = "imBack",
                    Title = "Rent and leasing"
                };

                cardButtons.Add(plButton);
                cardButtons.Add(plButton1);
                cardButtons.Add(plButton2);
                cardButtons.Add(plButton3);
                cardButtons.Add(plButton4);
                cardButtons.Add(plButton5);
                cardButtons.Add(plButton6);
                cardButtons.Add(plButton7);
                cardButtons.Add(plButton8);
                cardButtons.Add(plButton9);
                cardButtons.Add(plButton10);

                HeroCard plCard = new HeroCard()
                {
                    Title = "Revenue",
                    Subtitle = "How do you make money?",
                    Buttons = cardButtons
                };
                Attachment plAttachment = plCard.ToAttachment();
                reply.Attachments.Add(plAttachment);
                await context.PostAsync(reply);
                context.Wait(pricemodelAsync);

            }
            else if (activity.Text == "quit the session")
            {
                context.Done(true);
            }
            else
            {
                await context.PostAsync("Hmmm...");
                await context.PostAsync("Answer the Customer value question above or say 'quit the session' to quit");
                context.Wait(intelluctualAsync);
            }

        }
        private async Task pricemodelAsync(IDialogContext context, IAwaitable<object> result)
        {
            var activity = await result as Activity;
            if (activity.Text == "Transaction fee" || activity.Text == "Selling hours" || activity.Text == "Commission" || activity.Text == "Advertising" || activity.Text == "Membership" || activity.Text == "Subscription" || activity.Text == "Product sales" || activity.Text == "Sponsorship" || activity.Text == "Project sales" || activity.Text == "License fee" || activity.Text == "Rent and leasing")
            {
                customervalue = activity.Text;
                await context.PostAsync("60% of the model constructed. Great Job");
                var reply = activity.CreateReply();
                reply.Attachments = new List<Attachment>();
                List<CardAction> cardButtons = new List<CardAction>();
                CardAction plButton = new CardAction()
                {
                    Value = "Customer dependent",
                    Type = "imBack",
                    Title = "Customer dependent"
                };
                CardAction plButton1 = new CardAction()
                {
                    Value = "Dynamic market",
                    Type = "imBack",
                    Title = "Dynamic market"
                };
                CardAction plButton2 = new CardAction()
                {
                    Value = "Seasonal",
                    Type = "imBack",
                    Title = "Seasonal"
                };
                CardAction plButton3 = new CardAction()
                {
                    Value = "Tender",
                    Type = "imBack",
                    Title = "Tender"
                };
                CardAction plButton4 = new CardAction()
                {
                    Value = "Value dependent",
                    Type = "imBack",
                    Title = "Value dependent"
                };
                CardAction plButton5 = new CardAction()
                {
                    Value = "Pay per use",
                    Type = "imBack",
                    Title = "Pay per use"
                };
                CardAction plButton6 = new CardAction()
                {
                    Value = "Auction",
                    Type = "imBack",
                    Title = "Auction"
                };
                CardAction plButton7 = new CardAction()
                {
                    Value = "Negotiation",
                    Type = "imBack",
                    Title = "Negotiation"
                };
                CardAction plButton8 = new CardAction()
                {
                    Value = "Feature dependent",
                    Type = "imBack",
                    Title = "Feature dependent"
                };
                CardAction plButton9 = new CardAction()
                {
                    Value = "Volume dependent",
                    Type = "imBack",
                    Title = "Volume dependent"
                };
                CardAction plButton10 = new CardAction()
                {
                    Value = "List prices",
                    Type = "imBack",
                    Title = "List prices"
                };
                CardAction plButton11 = new CardAction()
                {
                    Value = "Subscription",
                    Type = "imBack",
                    Title = "Subscription"
                };
                cardButtons.Add(plButton);
                cardButtons.Add(plButton1);
                cardButtons.Add(plButton2);
                cardButtons.Add(plButton3);
                cardButtons.Add(plButton4);
                cardButtons.Add(plButton5);
                cardButtons.Add(plButton6);
                cardButtons.Add(plButton7);
                cardButtons.Add(plButton8);
                cardButtons.Add(plButton9);
                cardButtons.Add(plButton10);
                cardButtons.Add(plButton11);

                HeroCard plCard = new HeroCard()
                {
                    Title = "Price model",
                    Subtitle = "How do you set the price?",
                    Buttons = cardButtons
                };
                Attachment plAttachment = plCard.ToAttachment();
                reply.Attachments.Add(plAttachment);
                await context.PostAsync(reply);
                context.Wait(costAsync);

            }
            else if (activity.Text == "quit the session")
            {
                context.Done(true);
            }
            else
            {
                await context.PostAsync("Hmmm...");
                await context.PostAsync("Answer the Customer value question above or say 'quit the session' to quit");
                context.Wait(intelluctualAsync);
            }

        }
        private async Task costAsync(IDialogContext context, IAwaitable<object> result)
        {
            var activity = await result as Activity;
            if (activity.Text == "Crowd funding" || activity.Text == "Customer funding" || activity.Text == "Venture capital" || activity.Text == "Supplier credit" || activity.Text == "Donations" || activity.Text == "Loan and credits" || activity.Text == "Grants and subsidies" || activity.Text == "Equity")
            {
                customervalue = activity.Text;
                await context.PostAsync("60% of the model constructed. Great Job");
                var reply = activity.CreateReply();
                reply.Attachments = new List<Attachment>();
                List<CardAction> cardButtons = new List<CardAction>();
                CardAction plButton = new CardAction()
                {
                    Value = "Specialist",
                    Type = "imBack",
                    Title = "Specialist"
                };
                CardAction plButton1 = new CardAction()
                {
                    Value = "Crowd sourcing",
                    Type = "imBack",
                    Title = "Crowd sourcing"
                };
                CardAction plButton2 = new CardAction()
                {
                    Value = "Labour",
                    Type = "imBack",
                    Title = "Labour"
                };
                CardAction plButton3 = new CardAction()
                {
                    Value = "Advisors",
                    Type = "imBack",
                    Title = "Advisors"
                };
                CardAction plButton4 = new CardAction()
                {
                    Value = "Management team",
                    Type = "imBack",
                    Title = "Management team"
                };
                CardAction plButton5 = new CardAction()
                {
                    Value = "Board",
                    Type = "imBack",
                    Title = "Board"
                };
                CardAction plButton6 = new CardAction()
                {
                    Value = "Coach or mentor",
                    Type = "imBack",
                    Title = "Coach or mentor"
                };

                cardButtons.Add(plButton);
                cardButtons.Add(plButton1);
                cardButtons.Add(plButton2);
                cardButtons.Add(plButton3);
                cardButtons.Add(plButton4);
                cardButtons.Add(plButton5);
                cardButtons.Add(plButton6);

                HeroCard plCard = new HeroCard()
                {
                    Title = "Human resources",
                    Subtitle = "What kind of people are involved in the project and who do you need to get involved?",
                    Buttons = cardButtons
                };
                Attachment plAttachment = plCard.ToAttachment();
                reply.Attachments.Add(plAttachment);
                await context.PostAsync(reply);
                context.Wait(intelluctualAsync);

            }
            else if (activity.Text == "quit the session")
            {
                context.Done(true);
            }
            else
            {
                await context.PostAsync("Hmmm...");
                await context.PostAsync("Answer the Customer value question above or say 'quit the session' to quit");
                context.Wait(intelluctualAsync);
            }

        }
    }
}