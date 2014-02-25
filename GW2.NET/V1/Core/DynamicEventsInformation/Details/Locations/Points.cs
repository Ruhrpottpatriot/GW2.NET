// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Points.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System.Drawing;
using GW2DotNET.V1.Core.Converters;
using Newtonsoft.Json;

namespace GW2DotNET.V1.Core.DynamicEventsInformation.Details.Locations
{
    /// <summary>
    /// Represents a collection of points.
    /// </summary>
    [JsonArray(ItemConverterType = typeof(PointFConverter))]
    public class Points : JsonList<PointF>
    {
    }
}