using EBZ.Mobile.Services;
using EBZ.Mobile.ServicesInterface;
using Xamarin.Forms;

namespace EBZ.Mobile.Models
{
    public class Constants
    {
        public const string BaseApiUrl = "https://adymealy-web.conveyor.cloud/api/v1";
        public const string MealQueues = "/mealqueues/";
        public const string MealTransactionsToday = "/mealtransactionstoday/";
        public const string MealTransactions = "/mealtransactions/";
        public const string LoginEndpoint = "/auth/login/";
        public const string CheckIn = "/checkin/";
        public const string CheckOut = "/checkout/";
        public const string User = "/user/";


        public const string GetCustomerCategories = "/customer/getcategories/";
        public const string Customers = "/customer/getcustomers";
        public const string Customer = "/customer/get/";
        public const string CustomersForMarketer = "/customer/getformarketer/";
        public const string CustomerBalance = "/customer/getbalance/";
        public const string CustomerPricing = "/customer/getpricings/";
        //public const string CustomerTransaction = "/customer/getmytransactions/";
        public const string CustomerRecentTransaction = "/customer/myrecenttransactions/";
        public const string CustomerRecentRecharges = "/customer/myrecentrecharges/";
        public const string CustomersDashboard = "/customer/mydashboard/";
        public const string Payment = "/sales/pay/";
        public const string ValidateCustomerPIN = "/customer/validatepin/";
        public const string ValidateSalesPersonPIN = "/salesperson/validatepin/";
        public const string MySales = "/salesperson/mysales/";
        public const string MyOtherSales = "/salesperson/myothersales/";
        public const string RegisterEndpoint = "/auth/register/";
        //public const string LoginEndpoint = "/auth/login/";
        public const string ResetPasswordEndpoint = "/auth/resetpassword/";
        public const string CreateCustomerByMarketer = "/customer/create/";
    }
}
