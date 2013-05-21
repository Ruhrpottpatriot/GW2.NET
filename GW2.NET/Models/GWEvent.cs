namespace GW2DotNET.Models
{
    public struct GwEvent
    {
        public GwEvent(int worldId, int mapId, string eventId, string state) : this()
        {
            this.WorldId = worldId;
            this.MapId = mapId;
            this.EventId = eventId;
            this.State = state;
        }

        public int WorldId { get; private set; }

        public int MapId { get; private set; }

        public string EventId { get; private set; }

        public string State { get; private set; }
    }
}
