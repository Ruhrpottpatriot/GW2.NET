// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ChatLinks.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Contains static methods to get the chat link for a specific in game object.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;

namespace GW2DotNET.V1.Infrastructure
{
    /// <summary>
    /// Contains static methods to get the chat link for a specific ingame object.
    /// </summary>
    public static class ChatLinks
    {
        /// <summary>
        /// Converts a amount of money in a chat link.
        /// </summary>
        /// <param name="valueInCopper">
        /// The value of the money.
        /// </param>
        /// <returns>
        /// A chat link usable ingame.
        /// </returns>
        /// <remarks>The value to this method has to be supplied in copper. 
        /// One gold is 100 silver and one silver is 100 copper, making one gold 10000 copper.
        /// </remarks>
        public static string CoinChatLink(int valueInCopper)
        {
            byte[] bytes = BitConverter.GetBytes(valueInCopper);

            var finalArray = new List<byte> { 1 };

            finalArray.AddRange(bytes);

            string base64String = Convert.ToBase64String(finalArray.ToArray());

            return string.Format("[&{0}]", base64String);
        }

        /// <summary>
        /// Converts an item into a chat link.
        /// </summary>
        /// <param name="quantity">
        /// The item quantity.
        /// </param>
        /// <param name="itemId">
        /// The item id.
        /// </param>
        /// <returns>
        /// A chat link representing the item, which is usable ingame.
        /// </returns>
        /// <remarks>
        /// The item quantity is the amount of items which the user wants to link
        /// (e.g. 10 Copper Ore), while the item id is the id gained from the api
        /// or another location.
        /// </remarks>
        public static string ItemChatLink(short quantity, int itemId)
        {
            var byteList = new List<byte> { 2 };

            byte[] quantityBytes = BitConverter.GetBytes(quantity);
            byte[] itemIdBytes = BitConverter.GetBytes(itemId);

            byteList.Add(quantityBytes[0]);
            byteList.AddRange(itemIdBytes);

            string base64String = Convert.ToBase64String(byteList.ToArray());

            return string.Format("[&{0}]", base64String);
        }

        /// <summary>
        /// The text chat link.
        /// </summary>
        /// <param name="textIdentifier">
        /// The text identifier.
        /// </param>
        /// <returns>
        /// A chat link representing certain phrases used ingame.
        /// </returns>
        public static string TextChatLink(int textIdentifier)
        {
            var byteList = new List<byte> { 3 };

            byte[] textBytes = BitConverter.GetBytes(textIdentifier);

            byteList.AddRange(textBytes);

            string base64String = Convert.ToBase64String(byteList.ToArray());

            return string.Format("[&{0}]", base64String);
        }

        /// <summary>
        /// The map chat link.
        /// </summary>
        /// <param name="mapPointId">
        /// The location id.
        /// </param>
        /// <returns>
        /// A chat link representing either a waypoint or a point of interest on the game map.
        /// </returns>
        public static string MapChatLink(int mapPointId)
        {
            var byteList = new List<byte> { 4 };

            byte[] textBytes = BitConverter.GetBytes(mapPointId);

            byteList.AddRange(textBytes);

            string base64String = Convert.ToBase64String(byteList.ToArray());

            return string.Format("[&{0}]", base64String);
        }

        /// <summary>
        /// The skill chat link.
        /// </summary>
        /// <param name="skillId">
        /// The skill id.
        /// </param>
        /// <returns>
        /// A chat link representing a skill.
        /// </returns>
        public static string SkillChatLink(int skillId)
        {
            var byteList = new List<byte> { 6 };

            byte[] textBytes = BitConverter.GetBytes(skillId);

            byteList.AddRange(textBytes);

            string base64String = Convert.ToBase64String(byteList.ToArray());

            return string.Format("[&{0}]", base64String);
        }

        /// <summary>
        /// The trait chat link.
        /// </summary>
        /// <param name="traitId">
        /// The trait id.
        /// </param>
        /// <returns>
        /// A chat link representing a trait.
        /// </returns>
        public static string TraitChatLink(int traitId)
        {
            var byteList = new List<byte> { 7 };

            byte[] textBytes = BitConverter.GetBytes(traitId);

            byteList.AddRange(textBytes);

            string base64String = Convert.ToBase64String(byteList.ToArray());

            return string.Format("[&{0}]", base64String);
        }

        /// <summary>
        /// The recipe chat link.
        /// </summary>
        /// <param name="recipeId">
        /// The recipe id.
        /// </param>
        /// <returns>
        /// A chat link representing a recipe.
        /// </returns>
        public static string RecipeChatLink(int recipeId)
        {
            var byteList = new List<byte> { 9 };

            byte[] textBytes = BitConverter.GetBytes(recipeId);

            byteList.AddRange(textBytes);

            string base64String = Convert.ToBase64String(byteList.ToArray());

            return string.Format("[&{0}]", base64String);
        }

        /* static public string DecodeFrom64(string encodedData)
        {
            byte[] encodedDataAsBytes = Convert.FromBase64String(encodedData);

            var returnString = BitConverter.ToInt32(encodedDataAsBytes, 1).ToString();

            return returnString;
        }*/
    }
}
