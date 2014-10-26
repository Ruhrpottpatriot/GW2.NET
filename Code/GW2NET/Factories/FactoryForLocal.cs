namespace GW2NET.Factories
{
    using GW2NET.Local.DynamicEvents;

    public class FactoryForLocal
    {
        public IDynamicEventRotationService EventRotations
        {
            get
            {
                return new DynamicEventRotationService();
            }
        }
    }
}
