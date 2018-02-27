using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StripeSDK;
using Stripe;
using Serialization;

namespace StripeConsoleApp
{
    class TestClass
    {
        public void Deserialize()
        {
            Serializer serializer = new Serializer();
            var stripeOptions = new StripeSubscriptionItemUpdateOptions();

            var JSON = serializer.Serialize<StripeSubscriptionItemUpdateOptions>(stripeOptions);

            Console.WriteLine(JSON);
        }

        public void Serialize()
        {
            var json = "{\"Amount\":4500,\"Currency\":\"usd\",\"ApplicationFee\":0,\"Capture\":true,\"Description\":\"\",\"Destination\":\"\",\"DestinationAmount\":\"\",\"ExchangeRate\":\"\",\"TransferGroup\":\"\",\"OnBehalfOf\":\"\",\"Metadata\":\"\",\"ReceiptEmail\":\"\",\"Shipping\":\"\",\"CustomerId\":\"\",\"SourceTokenOrExistingSourceId\":\"tok_1BbXAfDauvMb2JHj1bjzspsY\",\"SourceCard\":\"\",\"StatementDescriptor\":\"\"}";
            var jsondes = "{\"Amount\":4500,\"Currency\":\"usd\",\"ApplicationFee\":0,\"Capture\":true,\"Description\": null,\"Destination\": null,\"DestinationAmount\": null,\"ExchangeRate\": null,\"TransferGroup\": null,\"OnBehalfOf\": null,\"Metadata\": null,\"ReceiptEmail\": null,\"Shipping\": null,\"CustomerId\": null,\"SourceTokenOrExistingSourceId\":\"tok_1BbA8XDauvMb2JHj6QesXCB9\",\"SourceCard\": null,\"StatementDescriptor\": null}";

            //var jsonRep = json.Replace("\"\"", " null");

            Serializer serializer = new Serializer();

            var stripeChargeCreateOptions = serializer.Deserialize<StripeChargeCreateOptions>(json);

            return;

        }

        public void TestBalance()
        {
            StripeSDKMain stripe = new StripeSDKMain();

            string Response = "";
            string Errors = "";
            int ErrorCode = 0;

            var Api_Key = "g" + GetApiKey();

            stripe.Balance(Api_Key, ref Response, ref Errors, ref ErrorCode);
            if (ErrorCode == 0)
            {
                Console.WriteLine(Response);
            }
            else
            {
                Console.WriteLine(Errors);
            }
            
        }

        public void TestCharge()
        {
            StripeSDKMain stripe = new StripeSDKMain();
            StripeChargeCreateOptions stripeChargeCreateOptions = new StripeChargeCreateOptions();
            stripeChargeCreateOptions.Amount = 3000;
            stripeChargeCreateOptions.Currency = "usd";
            stripeChargeCreateOptions.SourceTokenOrExistingSourceId = "tok_amex";

            Serializer serializer = new Serializer();

            var stripeChargeCreateOptionsJSON = serializer.Serialize<StripeChargeCreateOptions>(stripeChargeCreateOptions);

            string Response = "";
            string Errors = "";
            int ErrorCode = 0;

            var Api_Key = GetApiKey();

            stripe.CreateCharge(Api_Key,stripeChargeCreateOptionsJSON,ref Response,ref Errors, ref ErrorCode);

            if (ErrorCode == 0)
            {
                Console.WriteLine(Response);
            }
            else
            {
                Console.WriteLine(Errors);
            }
        }        

        public void TestCreatePlan()
        {
            StripeSDKMain stripe = new StripeSDKMain();
            StripePlanCreateOptions stripePlanCreateOptions = new StripePlanCreateOptions()
            {
                Id = "Basic",
                Name = "Premium",
                Amount = 1000,
                Currency = "usd",
                Interval = "month",
            };

            Serializer serializer = new Serializer();

            var stripePlanCreateOptionsJSON = serializer.Serialize<StripePlanCreateOptions>(stripePlanCreateOptions);

            string Response = "";
            string Errors = "";
            int ErrorCode = 0;

            var Api_Key = GetApiKey();

            stripe.CreatePlan(Api_Key, stripePlanCreateOptionsJSON, ref Response, ref Errors, ref ErrorCode);

            if (ErrorCode == 0)
            {
                Console.WriteLine(Response);
            }
            else
            {
                Console.WriteLine(Errors);
            }
        }

        public void TestRetreivePlan()
        {
            StripeSDKMain stripe = new StripeSDKMain();

            string Response = "";
            string Errors = "";
            int ErrorCode = 0;

            var Api_Key = GetApiKey();

            string planId = GetPlanId();

            stripe.RetreivePlan(Api_Key, planId, ref Response, ref Errors, ref ErrorCode);

            if (ErrorCode == 0)
            {
                Console.WriteLine(Response);
            }
            else
            {
                Console.WriteLine(Errors);
            }
        }

        public void TestUpdatePlan()
        {
            StripeSDKMain stripe = new StripeSDKMain();
            StripePlanUpdateOptions stripePlanUpdateOptions = new StripePlanUpdateOptions()
            {
                Name = "Full"
            };

            Serializer serializer = new Serializer();

            var stripePlanUpdateOptionsJSON = serializer.Serialize<StripePlanUpdateOptions>(stripePlanUpdateOptions);

            string Response = "";
            string Errors = "";
            int ErrorCode = 0;

            var Api_Key = GetApiKey();

            string planId = GetPlanId();

            stripe.UpdatePlan(Api_Key, planId, stripePlanUpdateOptionsJSON, ref Response, ref Errors, ref ErrorCode);

            if (ErrorCode == 0)
            {
                Console.WriteLine(Response);
            }
            else
            {
                Console.WriteLine(Errors);
            }
        }

        public void TestDeletePlan()
        {
            StripeSDKMain stripe = new StripeSDKMain();

            string Response = "";
            string Errors = "";
            int ErrorCode = 0;

            var Api_Key = GetApiKey();

            string planId = GetPlanId();

            stripe.DeletePlan(Api_Key, planId, ref Response, ref Errors, ref ErrorCode);

            if (ErrorCode == 0)
            {
                Console.WriteLine(Response);
            }
            else
            {
                Console.WriteLine(Errors);
            }
        }

        public void TestCreateCustomer()
        {
            StripeSDKMain stripe = new StripeSDKMain();

            StripeCustomerCreateOptions stripeCustomerCreateOptions = new StripeCustomerCreateOptions()
            {
                Description = "Maro",
                Email = "mmarotta@genexus.com",
                SourceToken = "tok_visa",
            };

            Serializer serializer = new Serializer();

            var stripeCustomerCreateOptionsJSON = serializer.Serialize<StripeCustomerCreateOptions>(stripeCustomerCreateOptions);

            string Response = "";
            string Errors = "";
            int ErrorCode = 0;

            var Api_Key = GetApiKey();

            stripe.CreateCustomer(Api_Key,stripeCustomerCreateOptionsJSON,ref Response,ref Errors,ref ErrorCode);
            if (ErrorCode == 0)
            {
                Console.WriteLine(Response);
            }
            else
            {
                Console.WriteLine(Errors);
            }
        }

        public void TestRetreiveCustomer()
        {
            StripeSDKMain stripe = new StripeSDKMain();

            string Response = "";
            string Errors = "";
            int ErrorCode = 0;

            var Api_Key = GetApiKey();

            string CustomerId = GetCustomerId();

            stripe.RetreiveCustomer(Api_Key, CustomerId, ref Response, ref Errors, ref ErrorCode);

            if (ErrorCode == 0)
            {
                Console.WriteLine(Response);
            }
            else
            {
                Console.WriteLine(Errors);
            }

        }

        public void TestUpdateCustomer()
        {
            StripeSDKMain stripe = new StripeSDKMain();
            StripeCustomerUpdateOptions stripeCustomerUpdateOptions = new StripeCustomerUpdateOptions()
            {
                Email = "massimarotta@gmail.com",
                SourceToken = "tok_amex"
            };

            Serializer serializer = new Serializer();

            var stripeCustomerUpdateOptionsJSON = serializer.Serialize<StripeCustomerUpdateOptions>(stripeCustomerUpdateOptions);

            string Response = "";
            string Errors = "";
            int ErrorCode = 0;

            var Api_Key = GetApiKey();

            string CustomerId = GetCustomerId();

            stripe.UpdateCustomer(Api_Key, CustomerId, stripeCustomerUpdateOptionsJSON, ref Response, ref Errors, ref ErrorCode);

            if (ErrorCode == 0)
            {
                Console.WriteLine(Response);
            }
            else
            {
                Console.WriteLine(Errors);
            }
        }

        public void TestDeleteCustomer()
        {
            StripeSDKMain stripe = new StripeSDKMain();

            string Response = "";
            string Errors = "";
            int ErrorCode = 0;

            var Api_Key = GetApiKey();
            string CustomerId = GetCustomerId();

            stripe.DeleteCustomer(Api_Key, CustomerId, ref Response, ref Errors, ref ErrorCode);

            if (ErrorCode == 0)
            {
                Console.WriteLine(Response);
            }
            else
            {
                Console.WriteLine(Errors);
            }
        }

        public void TestCreateSubscription()
        {
            StripeSDKMain stripe = new StripeSDKMain();

            StripeSubscriptionCreateOptions stripeSubscriptionCreateOptions = new StripeSubscriptionCreateOptions()
            {
                PlanId = GetPlanId()
            };

            Serializer serializer = new Serializer();

            var stripeSubscriptionCreateOptionsJSON = serializer.Serialize<StripeSubscriptionCreateOptions>(stripeSubscriptionCreateOptions);

            string Response = "";
            string Errors = "";
            int ErrorCode = 0;

            var Api_Key = GetApiKey();
            var CustomerId = GetCustomerId();

            stripe.CreateSubscription(Api_Key, CustomerId, stripeSubscriptionCreateOptionsJSON, ref Response, ref Errors, ref ErrorCode);
            if (ErrorCode == 0)
            {
                Console.WriteLine(Response);
            }
            else
            {
                Console.WriteLine(Errors);
            }
        }

        public void TestRetreiveSubscription()
        {
            StripeSDKMain stripe = new StripeSDKMain();

            string Response = "";
            string Errors = "";
            int ErrorCode = 0;

            var Api_Key = GetApiKey();
            var SubscriptionId = GetSubscriptionId();

            stripe.RetreiveSubscription(Api_Key, SubscriptionId, ref Response, ref Errors, ref ErrorCode);

            if(ErrorCode == 0)
            {
                Console.WriteLine(Response);
            }
            else
            {
                Console.WriteLine(Errors);
            }
        }

        public void TestUpdateSubscription()
        {
            StripeSDKMain stripe = new StripeSDKMain();

            string Response = "";
            string Errors = "";
            int ErrorCode = 0;

            var Api_Key = GetApiKey();
            var SubscriptionId = GetSubscriptionId();

            var stripeSubscriptionUpdateOptions = new StripeSubscriptionUpdateOptions()
            {
                Quantity = 3
            };

            Serializer serializer = new Serializer();
            var stripeSubscriptionUpdateOptionsJSON = serializer.Serialize<StripeSubscriptionUpdateOptions>(stripeSubscriptionUpdateOptions);

            stripe.UpdateSubscription(Api_Key, SubscriptionId, stripeSubscriptionUpdateOptionsJSON, ref Response, ref Errors, ref ErrorCode);

            if(ErrorCode == 0)
            {
                Console.WriteLine(Response);
            }
            else
            {
                Console.WriteLine(Errors);
            }
        }

        public void TestCancelSubscription()
        {
            StripeSDKMain stripe = new StripeSDKMain();

            string Response = "";
            string Errors = "";
            int ErrorCode = 0;

            var Api_Key = GetApiKey();
            var SubscriptionId = GetSubscriptionId();
            bool CancelAtPeriodEnd = false;

            stripe.CancelSubscription(Api_Key, SubscriptionId, CancelAtPeriodEnd, ref Response, ref Errors, ref ErrorCode);

            if(ErrorCode == 0)
            {
                Console.WriteLine(Response);
            }
            else
            {
                Console.WriteLine(Errors);
            }
        }

        public void TestCreateSubscriptionItem()
        {
            StripeSDKMain stripe = new StripeSDKMain();

            var Plan_Id = GetPlanId();
            var Subscription_Id = GetSubscriptionId();

            var stripeSubscriptionItemCreateOptions = new StripeSubscriptionItemCreateOptions()
            {
                PlanId = Plan_Id,
                SubscriptionId = Subscription_Id
            };


            
            Serializer serializer = new Serializer();
            var stripeSubscriptionItemCreateOptionsJSON = serializer.Serialize<StripeSubscriptionItemCreateOptions>(stripeSubscriptionItemCreateOptions);

            string Response = "";
            string Errors = "";
            int ErrorCode = 0;

            var Api_Key = GetApiKey();

            stripe.CreateSubscriptionItem(Api_Key, stripeSubscriptionItemCreateOptionsJSON, ref Response, ref Errors, ref ErrorCode);

            if(ErrorCode == 0)
            {
                Console.WriteLine(Response);
            }
            else
            {
                Console.WriteLine(Errors);
            }
        }

        public void TestRetreiveSubscriptionItem()
        {
            StripeSDKMain stripe = new StripeSDKMain();

            string Subscription_Item_Id = GetSubscriptionItemId();
            string Response = "";
            string Errors = "";
            int ErrorCode = 0;

            var Api_Key = GetApiKey();

            stripe.RetreiveSubscriptionItem(Api_Key, Subscription_Item_Id, ref Response, ref Errors, ref ErrorCode);

            if(ErrorCode == 0)
            {
                Console.WriteLine(Response);
            }
            else
            {
                Console.WriteLine(Errors);
            }
        }

        public void TestUpdateSubscriptionItem()
        {
            StripeSDKMain stripe = new StripeSDKMain();

            string Response = "";
            string Errors = "";
            int ErrorCode = 0;

            var Api_Key = GetApiKey();
            var Subscription_Item_Id = GetSubscriptionItemId();

            var stripeSubscriptionItemUpdateOptions = new StripeSubscriptionItemUpdateOptions()
            {
                PlanId = "Premium-Test",
                Quantity = 2
            };

            Serializer serializer = new Serializer();
            var stripeSubscriptionItemUpdateOptionsJSON = serializer.Serialize<StripeSubscriptionItemUpdateOptions>(stripeSubscriptionItemUpdateOptions);

            stripe.UpdateSubscriptionItem(Api_Key, Subscription_Item_Id, stripeSubscriptionItemUpdateOptionsJSON, ref Response, ref Errors, ref ErrorCode);

            if (ErrorCode == 0)
            {
                Console.WriteLine(Response);
            }
            else
            {
                Console.WriteLine(Errors);
            }
        }

        public void TestDeleteSubscriptionItem()
        {
            StripeSDKMain stripe = new StripeSDKMain();

            string Response = "";
            string Errors = "";
            int ErrorCode = 0;

            var Api_Key = GetApiKey();
            var Subscription_Item_Id = GetSubscriptionItemId();

            stripe.DeleteSubscriptionItem(Api_Key, Subscription_Item_Id, ref Response, ref Errors, ref ErrorCode);

            if(ErrorCode == 0)
            {
                Console.WriteLine(Response);
            }
            else
            {
                Console.WriteLine(Errors);
            }
        }

        private string GetApiKey()
        {
            //string Api_Key = "sk_test_BQokikJOvBiI2HlWgH4olfQ2"; //Test Default
            string Api_Key = "sk_test_q2hads5uY8O74T5rwLMIewId"; //mmarotta@genexus.com
            return Api_Key;
        }

        private string GetCustomerId()
        {
            return "cus_CEsRTqV9Rkz6Yf";
        }

        private string GetPlanId()
        {
            return "Basic";
        }

        private string GetSubscriptionId()
        {
            return "sub_CFDFdsO97JV3fw";
        }

        private string GetSubscriptionItemId()
        {
            return "si_CFDH4jytlIZaER";
        }
    }
}
