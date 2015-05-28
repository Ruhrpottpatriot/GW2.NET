namespace GW2NET.V2.Commerce.Exchange
{
    public class GemsExchangeRequest : ExchangeRequest
    {
        public override string Resource
        {
            get
            {
                return "/v2/commerce/exchange/gems";
            }
        }
    }
}
