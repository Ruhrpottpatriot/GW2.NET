// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RepositoryFactoryBase.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides methods for creating repository objects.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2NET.Factories
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Globalization;

    /// <summary>Provides methods for creating repository objects.</summary>
    /// <typeparam name="TRepository">The type of repository to create.</typeparam>
    public abstract class RepositoryFactoryBase<TRepository>
    {
        /// <summary>Creates an instance for the given language.</summary>
        /// <param name="language">The two-letter language code.</param>
        /// <exception cref="ArgumentNullException">The value of <paramref name="language"/> is a null reference.</exception>
        /// <exception cref="ArgumentException">The length of <paramref name="language"/> is not 2.</exception>
        /// <returns>A repository.</returns>
        public virtual TRepository this[string language]
        {
            get
            {
                if (language == null)
                {
                    throw new ArgumentNullException(nameof(language));
                }

                return this.ForCulture(new CultureInfo(language));
            }
        }

        /// <summary>Creates an instance for the given language.</summary>
        /// <param name="culture">The culture.</param>
        /// <exception cref="ArgumentNullException">The value of <paramref name="culture"/> is a null reference.</exception>
        /// <returns>A repository.</returns>
        public virtual TRepository this[CultureInfo culture]
        {
            get
            {
                if (culture == null)
                {
                    throw new ArgumentNullException(nameof(culture));
                }

                return this.ForCulture(culture);
            }
        }

        /// <summary>Creates an instance for the default language.</summary>
        /// <returns>A repository.</returns>
        public abstract TRepository ForDefaultCulture();

        /// <summary>Creates an instance for the given language.</summary>
        /// <param name="culture">The culture.</param>
        /// <exception cref="ArgumentNullException">The value of <paramref name="culture"/> is a null reference.</exception>
        /// <returns>A repository.</returns>
        public abstract TRepository ForCulture(CultureInfo culture);

        /// <summary>Creates an instance for the current system language.</summary>
        /// <returns>A repository.</returns>
        public virtual TRepository ForCurrentCulture()
        {
            return this.ForCulture(CultureInfo.CurrentCulture);
        }

        /// <summary>Creates an instance for the current UI language.</summary>
        /// <returns>A repository.</returns>
        [SuppressMessage("ReSharper", "InconsistentNaming", Justification = "Consistent with the standard .NET naming.")]
        public virtual TRepository ForCurrentUICulture()
        {
            return this.ForCulture(CultureInfo.CurrentUICulture);
        }
    }
}