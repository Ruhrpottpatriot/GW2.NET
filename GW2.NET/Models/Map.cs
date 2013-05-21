namespace GW2DotNET.Models
{
    public struct Map
    {
        public Map(int id, string name)
            : this()
        {
            this.Id = id;
            this.Name = name;
        }

        public int Id
        {
            get;
            private set;
        }

        public string Name
        {
            get;
            private set;
        }
    }
}
