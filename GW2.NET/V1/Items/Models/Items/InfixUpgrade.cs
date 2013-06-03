using System.Collections.Generic;

namespace GW2DotNET.V1.Items.Models
{
    using Newtonsoft.Json;

    public struct InfixUpgrade
    {
        [JsonConstructor]
        public InfixUpgrade(IEnumerable<ItemAttribute> attributes, Dictionary<int, string> buff)
            : this()
        {
            this.Attributes = attributes;
            this.Buff = buff;
        }

        [JsonProperty("attributes")]
        public IEnumerable<ItemAttribute> Attributes
        {
            get;
            private set;
        }

        [JsonProperty("buff")]
        public Dictionary<int, string> Buff
        {
            get;
            private set;
        }

        public struct ItemAttribute
        {
            [JsonConstructor]
            public ItemAttribute(TargetAttribute targetAttribute, int modifier)
                : this()
            {
                this.Attribute = targetAttribute;
                this.Modifier = modifier;
            }

            [JsonProperty("attribute")]
            public TargetAttribute Attribute
            {
                get;
                private set;
            }

            [JsonProperty("modifier")]
            public int Modifier
            {
                get;
                private set;
            }

            public enum TargetAttribute
            {
                CritDamage,
                ConditionDamage,
                Healing,
                Vitality,
                Power,
                Toughness,
                Precision,
            }
        }
    }
}