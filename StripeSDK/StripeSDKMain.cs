using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stripe;
using Serialization;

namespace StripeSDK
{
    public class StripeSDKMain
    {
        private string SetApiKey(string Api_Key)
        {
            string result = "";
            try
            {
                StripeConfiguration.SetApiKey(Api_Key);
                result = "ok";
            }
            catch (StripeException e)
            {
                result = e.HttpStatusCode + ": " + e.Message;
            }
            return result;
        }

        public void Balance(string Api_Key, ref string Response, ref string Errors, ref int ErrorCode)
        {
            try
            {
                StripeConfiguration.SetApiKey(Api_Key);

                var balanceService = new StripeBalanceService();
                var balance = balanceService.Get();

                var response = balance.StripeResponse;
                Response = response.ResponseJson;
                ErrorCode = 0;

            }
            catch (StripeException e)
            {
                ErrorCode = 1;
                Serializer serializer = new Serializer();
                StripeError stripeError = e.StripeError;
                Errors = serializer.Serialize<StripeError>(stripeError);
            }
        }

        public void CreateCharge(string Api_Key, string stripeChargeCreateOptionsJSON, ref string Response, ref string Errors, ref int ErrorCode)
        {
            try
            {
                StripeConfiguration.SetApiKey(Api_Key);

                Serializer serializer = new Serializer();

                StripeChargeCreateOptions stripeChargeCreateOptions = serializer.Deserialize<StripeChargeCreateOptions>(stripeChargeCreateOptionsJSON);

                var stripeChargeService = new StripeChargeService();
                StripeCharge stripeCharge = stripeChargeService.Create(stripeChargeCreateOptions);
                Response = stripeCharge.StripeResponse.ResponseJson;
                ErrorCode = 0;
            }
            catch (StripeException e)
            {
                ErrorCode = 1;
                Serializer serializer = new Serializer();
                StripeError stripeError = e.StripeError;
                Errors = serializer.Serialize<StripeError>(stripeError);
            }
        }

        public void CreatePlan(string Api_Key, string stripePlanCreateOptionsJSON, ref string Response, ref string Errors, ref int ErrorCode)
        {
            try
            {
                StripeConfiguration.SetApiKey(Api_Key);

                Serializer serializer = new Serializer();
                StripePlanCreateOptions stripePlanCreateOptions = serializer.Deserialize<StripePlanCreateOptions>(stripePlanCreateOptionsJSON);


                var stripePlanService = new StripePlanService();
                StripePlan stripePlan = stripePlanService.Create(stripePlanCreateOptions);
                Response = stripePlan.StripeResponse.ResponseJson;
                ErrorCode = 0;
            }
            catch (StripeException e)
            {
                ErrorCode = 1;
                Serializer serializer = new Serializer();
                StripeError stripeError = e.StripeError;
                Errors = serializer.Serialize<StripeError>(stripeError);
            }
        }

        public void RetreivePlan(string Api_Key, string planId, ref string Response, ref string Errors, ref int ErrorCode)
        {
            try
            {
                StripeConfiguration.SetApiKey(Api_Key);

                var stripePlanService = new StripePlanService();
                StripePlan stripePlan = stripePlanService.Get(planId);
                Response = stripePlan.StripeResponse.ResponseJson;
                ErrorCode = 0;
            }
            catch (StripeException e)
            {
                ErrorCode = 1;
                Serializer serializer = new Serializer();
                StripeError stripeError = e.StripeError;
                Errors = serializer.Serialize<StripeError>(stripeError);
            }
        }

        public void UpdatePlan(string Api_Key, string planId, string stripePlanUpdateOptionsJSON, ref string Response, ref string Errors, ref int ErrorCode)
        {
            try
            {
                StripeConfiguration.SetApiKey(Api_Key);

                Serializer serializer = new Serializer();
                StripePlanUpdateOptions stripePlanUpdateOptions = serializer.Deserialize<StripePlanUpdateOptions>(stripePlanUpdateOptionsJSON);


                var stripePlanService = new StripePlanService();
                StripePlan stripePlan = stripePlanService.Update(planId, stripePlanUpdateOptions);
                Response = stripePlan.StripeResponse.ResponseJson;
                ErrorCode = 0;
            }
            catch (StripeException e)
            {
                ErrorCode = 1;
                Serializer serializer = new Serializer();
                StripeError stripeError = e.StripeError;
                Errors = serializer.Serialize<StripeError>(stripeError);
            }
        }

        public void DeletePlan(string Api_Key, string planId, ref string Response, ref string Errors, ref int ErrorCode)
        {
            try
            {
                StripeConfiguration.SetApiKey(Api_Key);

                var planService = new StripePlanService();
                StripeDeleted deletedPlan = planService.Delete(planId);
                Response = deletedPlan.StripeResponse.ResponseJson;
                ErrorCode = 0;
            }
            catch (StripeException e)
            {
                ErrorCode = 1;
                Serializer serializer = new Serializer();
                StripeError stripeError = e.StripeError;
                Errors = serializer.Serialize<StripeError>(stripeError);
            }
        }

        public void CreateCustomer(string Api_Key, string stripeCustomerCreateOptionsJSON, ref string Response, ref string Errors, ref int ErrorCode)
        {
            try
            {
                StripeConfiguration.SetApiKey(Api_Key);

                Serializer serializer = new Serializer();

                var stripeCustomerCreateOptions = serializer.Deserialize<StripeCustomerCreateOptions>(stripeCustomerCreateOptionsJSON);

                var stripeCustomerService = new StripeCustomerService();
                StripeCustomer stripeCustomer = stripeCustomerService.Create(stripeCustomerCreateOptions);
                Response = stripeCustomer.StripeResponse.ResponseJson;
                ErrorCode = 0;
            }
            catch (StripeException e)
            {
                ErrorCode = 1;
                Serializer serializer = new Serializer();
                StripeError stripeError = e.StripeError;
                Errors = serializer.Serialize<StripeError>(stripeError);
            }
        }

        public void RetreiveCustomer(string Api_Key, string customerId, ref string Response, ref string Errors, ref int ErrorCode)
        {
            try
            {
                StripeConfiguration.SetApiKey(Api_Key);

                var stripeCustomerService = new StripeCustomerService();
                StripeCustomer stripeCustomer = stripeCustomerService.Get(customerId);
                Response = stripeCustomer.StripeResponse.ResponseJson;
                ErrorCode = 0;
            }
            catch (StripeException e)
            {
                ErrorCode = 1;
                Serializer serializer = new Serializer();
                StripeError stripeError = e.StripeError;
                Errors = serializer.Serialize<StripeError>(stripeError);
            }
        }

        public void UpdateCustomer(string Api_Key, string customerId, string stripeCustomerUpdateOptionsJSON, ref string Response, ref string Errors, ref int ErrorCode)
        {
            try
            {
                StripeConfiguration.SetApiKey(Api_Key);

                Serializer serializer = new Serializer();
                StripeCustomerUpdateOptions stripeCustomerUpdateOptions = serializer.Deserialize<StripeCustomerUpdateOptions>(stripeCustomerUpdateOptionsJSON);


                var stripeCustomerService = new StripeCustomerService();
                StripeCustomer stripeCustomer = stripeCustomerService.Update(customerId, stripeCustomerUpdateOptions);
                Response = stripeCustomer.StripeResponse.ResponseJson;
                ErrorCode = 0;
            }
            catch (StripeException e)
            {
                ErrorCode = 1;
                Serializer serializer = new Serializer();
                StripeError stripeError = e.StripeError;
                Errors = serializer.Serialize<StripeError>(stripeError);
            }
        }

        public void DeleteCustomer(string Api_Key, string customerId, ref string Response, ref string Errors, ref int ErrorCode)
        {
            try
            {
                StripeConfiguration.SetApiKey(Api_Key);

                var customerService = new StripeCustomerService();
                StripeDeleted deletedCustomer = customerService.Delete(customerId);
                Response = deletedCustomer.StripeResponse.ResponseJson;
                ErrorCode = 0;
            }
            catch (StripeException e)
            {
                ErrorCode = 1;
                Serializer serializer = new Serializer();
                StripeError stripeError = e.StripeError;
                Errors = serializer.Serialize<StripeError>(stripeError);
            }
        }

        public void CreateSubscription(string Api_Key, string customerId, string stripeSubscriptionCreateOptionsJSON, ref string Response, ref string Errors, ref int ErrorCode)
        {
            try
            {
                StripeConfiguration.SetApiKey(Api_Key);

                Serializer serializer = new Serializer();
                var stripeSubscriptionCreateOptions = serializer.Deserialize<StripeSubscriptionCreateOptions>(stripeSubscriptionCreateOptionsJSON);

                var stripeSubscriptionService = new StripeSubscriptionService();
                StripeSubscription stripeSubscription = stripeSubscriptionService.Create(customerId, stripeSubscriptionCreateOptions);

                Response = stripeSubscription.StripeResponse.ResponseJson;
                ErrorCode = 0;
            }
            catch (StripeException e)
            {
                ErrorCode = 1;
                Serializer serializer = new Serializer();
                StripeError stripeError = e.StripeError;
                Errors = serializer.Serialize<StripeError>(stripeError);
            }
        }

        public void RetreiveSubscription(string Api_Key, string SubscriptionId, ref string Response, ref string Errors, ref int ErrorCode)
        {
            try
            {
                StripeConfiguration.SetApiKey(Api_Key);

                var stripeSubscriptionService = new StripeSubscriptionService();
                StripeSubscription stripeSubscription = stripeSubscriptionService.Get(SubscriptionId);

                Response = stripeSubscription.StripeResponse.ResponseJson;
                ErrorCode = 0;
            }
            catch (StripeException e)
            {
                ErrorCode = 1;
                Serializer serializer = new Serializer();
                StripeError stripeError = e.StripeError;
                Errors = serializer.Serialize<StripeError>(stripeError);
            }
        }

        public void UpdateSubscription(string Api_Key, string SubscriptionId, string stripeSubscriptionUpdateOptionsJSON, ref string Response, ref string Errors, ref int ErrorCode)
        {
            try
            {
                StripeConfiguration.SetApiKey(Api_Key);

                Serializer serializer = new Serializer();
                var stripeSubscriptionUpdateOptions = serializer.Deserialize<StripeSubscriptionUpdateOptions>(stripeSubscriptionUpdateOptionsJSON);
                var stripeSubscriptionService = new StripeSubscriptionService();

                var stripeSubscription = stripeSubscriptionService.Update(SubscriptionId, stripeSubscriptionUpdateOptions);

                Response = stripeSubscription.StripeResponse.ResponseJson;
                ErrorCode = 0;
            }
            catch (StripeException e)
            {
                ErrorCode = 1;
                Serializer serializer = new Serializer();
                StripeError stripeError = e.StripeError;
                Errors = serializer.Serialize<StripeError>(stripeError);
            }
        }

        public void CancelSubscription(string Api_Key, string SubscriptionId, bool CancelAtPeriodEnd, ref string Response, ref string Errors, ref int ErrorCode)
        {
            try
            {
                StripeConfiguration.SetApiKey(Api_Key);

                var stripeSubscriptionService = new StripeSubscriptionService();

                var stripeSubscription = stripeSubscriptionService.Cancel(SubscriptionId, CancelAtPeriodEnd);
                Response = stripeSubscription.StripeResponse.ResponseJson;
                ErrorCode = 0;
            }
            catch (StripeException e)
            {
                ErrorCode = 1;
                Serializer serializer = new Serializer();
                StripeError stripeError = e.StripeError;
                Errors = serializer.Serialize<StripeError>(stripeError);
            }
        }

        public void CreateSubscriptionItem(string Api_Key, string stripeSubscriptionItemCreateOptionsJSON, ref string Response, ref string Errors, ref int ErrorCode)
        {
            try
            {
                StripeConfiguration.SetApiKey(Api_Key);

                Serializer serializer = new Serializer();
                var stripeSubscriptionItemCreateOptions = serializer.Deserialize<StripeSubscriptionItemCreateOptions>(stripeSubscriptionItemCreateOptionsJSON);

                var stripeSubscriptionItemService = new StripeSubscriptionItemService();
                var stripeSubscriptionItem = stripeSubscriptionItemService.Create(stripeSubscriptionItemCreateOptions);

                Response = stripeSubscriptionItem.StripeResponse.ResponseJson;
                ErrorCode = 0;
            }
            catch (StripeException e)
            {
                ErrorCode = 1;
                Serializer serializer = new Serializer();
                StripeError stripeError = e.StripeError;
                Errors = serializer.Serialize<StripeError>(stripeError);
            }
        }

        public void RetreiveSubscriptionItem(string Api_key, string Subscription_Item_Id, ref string Response, ref string Errors, ref int ErrorCode)
        {
            try
            {
                StripeConfiguration.SetApiKey(Api_key);

                var stripeSubscriptionItemService = new StripeSubscriptionItemService();
                var stripeSubscriptionItem = stripeSubscriptionItemService.Get(Subscription_Item_Id);
                Response = stripeSubscriptionItem.StripeResponse.ResponseJson;
                ErrorCode = 0;
            }
            catch (StripeException e)
            {
                ErrorCode = 1;
                Serializer serializer = new Serializer();
                StripeError stripeError = e.StripeError;
                Errors = serializer.Serialize<StripeError>(stripeError);
            }
        }

        public void UpdateSubscriptionItem(string Api_Key, string Subscription_Item_Id, string stripeSubscriptionItemUpdateOptionsJSON, ref string Response, ref string Errors, ref int ErrorCode)
        {
            try
            {
                StripeConfiguration.SetApiKey(Api_Key);

                Serializer serializer = new Serializer();
                var stripeSubscriptionItemUpdateOptions = serializer.Deserialize<StripeSubscriptionItemUpdateOptions>(stripeSubscriptionItemUpdateOptionsJSON);

                var stripeSubscriptionItemService = new StripeSubscriptionItemService();
                var stripeSubscriptionItem = stripeSubscriptionItemService.Update(Subscription_Item_Id, stripeSubscriptionItemUpdateOptions);

                Response = stripeSubscriptionItem.StripeResponse.ResponseJson;
                ErrorCode = 0;
            }
            catch (StripeException e)
            {
                ErrorCode = 1;
                Serializer serializer = new Serializer();
                StripeError stripeError = e.StripeError;
                Errors = serializer.Serialize<StripeError>(stripeError);
            }
        }

        public void DeleteSubscriptionItem(string Api_Key, string Subscription_Item_Id, ref string Response, ref string Errors, ref int ErrorCode)
        {
            try
            {
                StripeConfiguration.SetApiKey(Api_Key);

                var stripeSubscriptionItemService = new StripeSubscriptionItemService();
                var stripeSubscriptionItem = stripeSubscriptionItemService.Delete(Subscription_Item_Id);

                Response = stripeSubscriptionItem.StripeResponse.ResponseJson;
                ErrorCode = 0;
            }
            catch (StripeException e)
            {
                ErrorCode = 1;
                Serializer serializer = new Serializer();
                StripeError stripeError = e.StripeError;
                Errors = serializer.Serialize<StripeError>(stripeError);
            }
        }
    }
}