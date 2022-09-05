using Stripe;

namespace Payment.Processing.Implementations
{
    public class MakePayment
    {
        public static async Task<bool> PayAsync(string cardNumber, int month, double year, string cvc, long value)
        {
            try
            {
                StripeConfiguration.ApiKey = "sk_test_51LQ4hXDzxcS8IaX52tqmoJJNm7P4oQUCZ9m20X3CfXN7uHhOt41MtD92DntVHNuqTB8iGlQTGO75FRIwRNzMHI4H00IRL0iBfn";

                var optionsToken = new TokenCreateOptions()
                {
                    Card = new TokenCardOptions()
                    {
                        Number = cardNumber,
                        ExpMonth = month,
                        ExpYear = (int)year, 
                        Cvc = cvc
                    }
                };

                var serviceToken = new TokenService();
                Token stripeToken = await serviceToken.CreateAsync(optionsToken);

                var options = new ChargeCreateOptions()
                {
                    Amount = value,
                    Currency = "usd",
                    Description = "test",
                    Source = stripeToken.Id
                };

                var service = new ChargeService();
                Charge charge = await service.CreateAsync(options);

                return charge.Paid;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
