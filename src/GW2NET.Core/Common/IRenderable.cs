// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IRenderable.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides the interface for objects for which a graphical representation exists.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.Common
{
    /// <summary>Provides the interface for objects for which a graphical representation exists.</summary>
    public interface IRenderable
    {
        /// <summary>Gets the file identifier.</summary>
        int FileId { get; }

        /// <summary>Gets the file signature.</summary>
        string FileSignature { get; }
    }
}
