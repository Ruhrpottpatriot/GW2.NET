using System.Collections.Generic;
using System.Linq;

namespace GW2DotNET.V1.Items.Models
{
    public struct Item
    {
        private readonly int id;

        public int Id
        {
            get
            {
                return this.id;
            }
        }

        public string Name
        {
            get;
            private set;
        }

        public string Description
        {
            get;
            private set;
        }

        public ItemType Type
        {
            get;
            private set;
        }

        public int Level
        {
            get;
            private set;
        }

        public WeaponRarity Rarity
        {
            get;
            private set;
        }

        public int VendorValue
        {
            get;
            private set;
        }

        public IEnumerable<GameType> GameTypes
        {
            get;
            private set;
        }

        public IEnumerable<ItemFlags> Flags
        {
            get;
            private set;
        }

        public Restriction Restrictions
        {
            get;
            private set;
        }

        // Type uniqe structs
        public struct Weapon
        {
            public WeaponType Type
            {
                get;
                private set;
            }

            public int SuffixItemId { get; private set; }

            public int MinPower { get; private set; }

            public int MaxPower { get; private set; }


            public enum WeaponType
            {
                LongBow,
                Pistol,
                Warhorn,
                Sword,
                Staff,
                Hammer,
                Trident,
                Scepter,
                Speargun,
                Mace,
                Axe,
                Torch,
                Dagger,
                Shield,
                Harpoon,
                Greatsword,
                Rifle,
                Focus,
                ShortBow,
                Toy,
                TwoHandedToy
            }
        }
    }
}
