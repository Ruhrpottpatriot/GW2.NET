namespace GW2NET.Factories
{
    using System.Diagnostics.Contracts;

    using GW2NET.Local.DynamicEvents;

    public class FactoryForLocal
    {
        public IDynamicEventRotationService EventRotations
        {
            get
            {
                Contract.Ensures(Contract.Result<IDynamicEventRotationService>() != null);
                return new DynamicEventRotationService();
            }
        }
    }
}
