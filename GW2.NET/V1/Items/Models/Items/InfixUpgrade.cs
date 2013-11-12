// --------------------------------------------------------------------------------------------------------------------
// <copyright file="InfixUpgrade.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the InfixUpgrade type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;

using Newtonsoft.Json;

namespace GW2DotNET.V1.Items.Models.Items
{
    /// <summary>
    /// The infix upgrade.
    /// </summary>
    [Serializable]
    public class InfixUpgrade
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InfixUpgrade"/> class.
        /// </summary>
        /// <param name="attributes">
        /// The attributes.
        /// </param>
        /// <param name="buff">
        /// The buff.
        /// </param>
        [JsonConstructor]
        public InfixUpgrade(IEnumerable<ItemAttribute> attributes, Dictionary<string, string> buff)
        {
            this.Attributes = attributes;
            this.Buff = buff;
        }

        /// <summary>
        /// Gets the attributes.
        /// </summary>
        [JsonProperty("attributes")]
        public IEnumerable<ItemAttribute> Attributes
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the buff.
        /// </summary>
        [JsonProperty("buff")]
        public Dictionary<string, string> Buff
        {
            get;
            private set;
        }

        /// <summary>
        /// The item attribute.
        /// </summary>
        [Serializable]
        public class ItemAttribute
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="ItemAttribute"/> class.
            /// </summary>
            /// <param name="targetAttribute">
            /// The target attribute.
            /// </param>
            /// <param name="modifier">
            /// The modifier.
            /// </param>
            [JsonConstructor]
            public ItemAttribute(TargetAttribute targetAttribute, int modifier)
            {
                this.Attribute = targetAttribute;
                this.Modifier = modifier;
            }

            /// <summary>
            /// Enumerates the possible attribute the modifier targets.
            /// </summary>
            public enum TargetAttribute
            {
                /// <summary>
                /// Critical damage is modified.
                /// </summary>
                CritDamage,

                /// <summary>
                /// Condition damage is modified.
                /// </summary>
                ConditionDamage,

                /// <summary>
                /// Healing is modified.
                /// </summary>
                Healing,

                /// <summary>
                /// Vitality is modified.
                /// </summary>
                Vitality,

                /// <summary>
                /// Power is modified.
                /// </summary>
                Power,

                /// <summary>
                /// Toughness is modified.
                /// </summary>
                Toughness,

                /// <summary>
                /// Precision is modified.
                /// </summary>
                Precision,
            }

            /// <summary>
            /// Gets the attribute.
            /// </summary>
            [JsonProperty("attribute")]
            public TargetAttribute Attribute
            {
                get;
                private set;
            }

            /// <summary>
            /// Gets the modifier.
            /// </summary>
            [JsonProperty("modifier")]
            public int Modifier
            {
                get;
                private set;
            }
        }
    }
}