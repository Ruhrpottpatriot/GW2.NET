namespace GW2NET.V2.Commerce.Exchange
{
    public class CoinsExchangeRequest : ExchangeRequest
    {
        public override string Resource
        {
            get
            {
                return "/v2/commerce/exchange/coins";
            }
        }
    }
}
