// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SkinService.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides the default implementation of the skins service.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.V1.Skins
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;
    using System.Globalization;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    using GW2NET.Common;
    using GW2NET.Entities.Items;
    using GW2NET.Entities.Skins;
    using GW2NET.V1.Skins.Json;

    /// <summary>Provides the default implementation of the skins service.</summary>
    public class SkinService : ISkinService
    {
        /// <summary>Infrastructure. Holds a reference to the service client.</summary>
        private readonly IServiceClient serviceClient;

        /// <summary>Initializes a new instance of the <see cref="SkinService"/> class.</summary>
        /// <param name="serviceClient">The service client.</param>
        public SkinService(IServiceClient serviceClient)
        {
            Contract.Requires(serviceClient != null);
            this.serviceClient = serviceClient;
        }

        /// <summary>Gets a skin and its localized details.</summary>
        /// <param name="skin">The skin identifier.</param>
        /// <returns>A skin and its localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/skin_details">wiki</a> for more information.</remarks>
        public Skin GetSkinDetails(int skin)
        {
            var culture = new CultureInfo("en");
            return this.GetSkinDetails(skin, culture);
        }

        /// <summary>Gets a skin and its localized details.</summary>
        /// <param name="skin">The skin identifier.</param>
        /// <param name="language">The language.</param>
        /// <returns>A skin and its localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/skin_details">wiki</a> for more information.</remarks>
        public Skin GetSkinDetails(int skin, CultureInfo language)
        {
            if (language == null)
            {
                throw new ArgumentNullException(paramName: "language", message: "Precondition failed: language != null");
            }

            Contract.EndContractBlock();

            var request = new SkinDetailsRequest { SkinId = skin, Culture = language };
            var response = this.serviceClient.Send<SkinDataContract>(request);
            if (response.Content == null)
            {
                return null;
            }

            var value = ConvertSkinContract(response.Content);
            value.Locale = response.Culture ?? language;
            return value;
        }

        /// <summary>Gets a skin and its localized details.</summary>
        /// <param name="skin">The skin identifier.</param>
        /// <returns>A skin and its localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/skin_details">wiki</a> for more information.</remarks>
        public Task<Skin> GetSkinDetailsAsync(int skin)
        {
            var culture = new CultureInfo("en");
            return this.GetSkinDetailsAsync(skin, culture, CancellationToken.None);
        }

        /// <summary>Gets a skin and its localized details.</summary>
        /// <param name="skin">The skin identifier.</param>
        /// <param name="language">The language.</param>
        /// <returns>A skin and its localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/skin_details">wiki</a> for more information.</remarks>
        public Task<Skin> GetSkinDetailsAsync(int skin, CultureInfo language)
        {
            return this.GetSkinDetailsAsync(skin, language, CancellationToken.None);
        }

        /// <summary>Gets a skin and its localized details.</summary>
        /// <param name="skin">The skin identifier.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A skin and its localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/skin_details">wiki</a> for more information.</remarks>
        public Task<Skin> GetSkinDetailsAsync(int skin, CancellationToken cancellationToken)
        {
            var culture = new CultureInfo("en");
            return this.GetSkinDetailsAsync(skin, culture, cancellationToken);
        }

        /// <summary>Gets a skin and its localized details.</summary>
        /// <param name="skin">The skin identifier.</param>
        /// <param name="language">The language.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A skin and its localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/skin_details">wiki</a> for more information.</remarks>
        public Task<Skin> GetSkinDetailsAsync(int skin, CultureInfo language, CancellationToken cancellationToken)
        {
            if (language == null)
            {
                throw new ArgumentNullException(paramName: "language", message: "Precondition failed: language != null");
            }

            Contract.EndContractBlock();

            var request = new SkinDetailsRequest { SkinId = skin, Culture = language };
            return this.serviceClient.SendAsync<SkinDataContract>(request, cancellationToken).ContinueWith(
                task =>
                    {
                        var response = task.Result;
                        if (response.Content == null)
                        {
                            return null;
                        }

                        var value = ConvertSkinContract(response.Content);
                        value.Locale = response.Culture ?? language;
                        return value;
                    }, 
                cancellationToken);
        }

        /// <summary>Gets a collection of skin identifiers.</summary>
        /// <returns>A collection of skin identifiers.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/skins">wiki</a> for more information.</remarks>
        public ICollection<int> GetSkins()
        {
            var request = new SkinDiscoveryRequest();
            var response = this.serviceClient.Send<SkinCollectionDataContract>(request);
            if (response.Content == null || response.Content.Skins == null)
            {
                return new int[0];
            }

            return response.Content.Skins;
        }

        /// <summary>Gets a collection of skin identifiers.</summary>
        /// <returns>A collection of skin identifiers.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/skins">wiki</a> for more information.</remarks>
        public Task<ICollection<int>> GetSkinsAsync()
        {
            return this.GetSkinsAsync(CancellationToken.None);
        }

        /// <summary>Gets a collection of skin identifiers.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of skin identifiers.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/skins">wiki</a> for more information.</remarks>
        public Task<ICollection<int>> GetSkinsAsync(CancellationToken cancellationToken)
        {
            var request = new SkinDiscoveryRequest();
            return this.serviceClient.SendAsync<SkinCollectionDataContract>(request, cancellationToken).ContinueWith(
                task =>
                    {
                        var response = task.Result;
                        if (response.Content == null)
                        {
                            return new int[0];
                        }

                        return response.Content.Skins;
                    }, 
                cancellationToken);
        }

        /// <summary>Infrastructure. Maps contracts to entities.</summary>
        /// <param name="skin">The entity.</param>
        /// <param name="content">The content.</param>
        private static void ConvertArmorSkinContract(ArmorSkin skin, ArmorSkinDataContract content)
        {
            Contract.Requires(skin != null);
            Contract.Requires(content != null);
            if (content.WeightClass != null)
            {
                skin.WeightClass = ConvertWeightClassContract(content.WeightClass);
            }
        }

        /// <summary>Infrastructure. Converts text to bit flags.</summary>
        /// <param name="content">The content.</param>
        /// <returns>The bit flags.</returns>
        private static WeightClass ConvertWeightClassContract(string content)
        {
            Contract.Requires(content != null);
            return (WeightClass)Enum.Parse(typeof(WeightClass), content, true);
        }

        /// <summary>Infrastructure. Converts text to bit flags.</summary>
        /// <param name="content">The content.</param>
        /// <returns>The bit flags.</returns>
        private static ItemRestrictions ConvertItemRestrictionsContract(string content)
        {
            Contract.Requires(content != null);
            return (ItemRestrictions)Enum.Parse(typeof(ItemRestrictions), content, true);
        }

        /// <summary>Infrastructure. Converts text to bit flags.</summary>
        /// <param name="content">The content.</param>
        /// <returns>The bit flags.</returns>
        private static ItemRestrictions ConvertItemRestrictionsContractCollection(IEnumerable<string> content)
        {
            Contract.Requires(content != null);
            return content.Aggregate(ItemRestrictions.None, (flags, flag) => flags | ConvertItemRestrictionsContract(flag));
        }

        /// <summary>Infrastructure. Maps contracts to entities.</summary>
        /// <param name="content">The content.</param>
        /// <returns>An entity.</returns>
        private static Skin ConvertSkinContract(SkinDataContract content)
        {
            Contract.Requires(content != null);
            Contract.Ensures(Contract.Result<Skin>() != null);

            // Create a new skin object
            var value = (Skin)Activator.CreateInstance(GetSkinType(content));

            // Set the skin identifier
            if (content.SkinId != null)
            {
                value.SkinId = int.Parse(content.SkinId);
            }

            // Set the name of the skin
            if (content.Name != null)
            {
                value.Name = content.Name;
            }

            // Set the skin flags
            if (content.Flags != null)
            {
                value.Flags = ConvertSkinFlagsContractCollection(content.Flags);
            }

            // Set the skin restrictions
            if (content.Restrictions != null)
            {
                value.Restrictions = ConvertItemRestrictionsContractCollection(content.Restrictions);
            }

            // Set the icon file identifier
            if (content.IconFileId != null)
            {
                value.FileId = int.Parse(content.IconFileId);
            }

            // Set the icon file signature
            if (content.IconFileSignature != null)
            {
                value.FileSignature = content.IconFileSignature;
            }

            // Set type-specific values (maximum 1 contract per type)
            if (content.Armor != null)
            {
                ConvertArmorSkinContract((ArmorSkin)value, content.Armor);
            }
            else if (content.Weapon != null)
            {
                ConvertWeaponSkinContract((WeaponSkin)value, content.Weapon);
            }

            // Set the description
            if (content.Description != null)
            {
                value.Description = content.Description;
            }

            // Return the skin object
            return value;
        }

        /// <summary>Infrastructure. Converts text to bit flags.</summary>
        /// <param name="content">The content.</param>
        /// <returns>The bit flags.</returns>
        private static SkinFlags ConvertSkinFlagsContract(string content)
        {
            Contract.Requires(content != null);
            return (SkinFlags)Enum.Parse(typeof(SkinFlags), content, true);
        }

        /// <summary>Infrastructure. Converts text to bit flags.</summary>
        /// <param name="content">The content.</param>
        /// <returns>The bit flags.</returns>
        private static SkinFlags ConvertSkinFlagsContractCollection(IEnumerable<string> content)
        {
            Contract.Requires(content != null);
            return content.Aggregate(SkinFlags.None, (flags, flag) => flags | ConvertSkinFlagsContract(flag));
        }

        /// <summary>Infrastructure. Converts text to bit flags.</summary>
        /// <param name="content">The content.</param>
        /// <returns>The bit flags.</returns>
        private static DamageType ConvertDamageTypeContract(string content)
        {
            Contract.Requires(content != null);
            return (DamageType)Enum.Parse(typeof(DamageType), content, true);
        }

        /// <summary>Infrastructure. Maps contracts to entities.</summary>
        /// <param name="skin">The entity.</param>
        /// <param name="content">The content.</param>
        private static void ConvertWeaponSkinContract(WeaponSkin skin, WeaponSkinDataContract content)
        {
            Contract.Requires(skin != null);
            Contract.Requires(content != null);

            // Set the damage type
            if (content.DamageType != null)
            {
                skin.DamageType = ConvertDamageTypeContract(content.DamageType);
            }
        }

        /// <summary>Infrastructure. Maps skin type discriminators to .NET types.</summary>
        /// <param name="content">The content.</param>
        /// <returns>The corresponding <see cref="System.Type"/>.</returns>
        private static Type GetArmorSkinType(ArmorSkinDataContract content)
        {
            Contract.Requires(content != null);
            Contract.Ensures(Contract.Result<Type>() != null);
            switch (content.Type)
            {
                case "Boots":
                    return typeof(BootsSkin);
                case "Coat":
                    return typeof(CoatSkin);
                case "Helm":
                    return typeof(HelmSkin);
                case "Shoulders":
                    return typeof(ShouldersSkin);
                case "Gloves":
                    return typeof(GlovesSkin);
                case "Leggings":
                    return typeof(LeggingsSkin);
                case "HelmAquatic":
                    return typeof(HelmAquaticSkin);
            }

            return typeof(UnknownArmorSkin);
        }

        /// <summary>Infrastructure. Maps skin type discriminators to .NET types.</summary>
        /// <param name="content">The content.</param>
        /// <returns>The corresponding <see cref="System.Type"/>.</returns>
        private static Type GetSkinType(SkinDataContract content)
        {
            Contract.Requires(content != null);
            Contract.Ensures(Contract.Result<Type>() != null);
            switch (content.Type)
            {
                case "Armor":
                    if (content.Armor == null)
                    {
                        return typeof(UnknownArmorSkin);
                    }

                    return GetArmorSkinType(content.Armor);
                case "Back":
                    return typeof(BackpackSkin);
                case "Weapon":
                    if (content.Weapon == null)
                    {
                        return typeof(UnknownArmorSkin);
                    }

                    return GetWeaponSkinType(content.Weapon);
            }

            return typeof(UnknownWeaponSkin);
        }

        /// <summary>Infrastructure. Maps skin type discriminators to .NET types.</summary>
        /// <param name="content">The content.</param>
        /// <returns>The corresponding <see cref="System.Type"/>.</returns>
        private static Type GetWeaponSkinType(WeaponSkinDataContract content)
        {
            Contract.Requires(content != null);
            Contract.Ensures(Contract.Result<Type>() != null);
            switch (content.Type)
            {
                case "Axe":
                    return typeof(AxeSkin);
                case "Dagger":
                    return typeof(DaggerSkin);
                case "Focus":
                    return typeof(FocusSkin);
                case "Greatsword":
                    return typeof(GreatSwordSkin);
                case "Hammer":
                    return typeof(HammerSkin);
                case "Harpoon":
                    return typeof(HarpoonSkin);
                case "LongBow":
                    return typeof(LongBowSkin);
                case "Mace":
                    return typeof(MaceSkin);
                case "Pistol":
                    return typeof(PistolSkin);
                case "Rifle":
                    return typeof(RifleSkin);
                case "Scepter":
                    return typeof(ScepterSkin);
                case "Shield":
                    return typeof(ShieldSkin);
                case "ShortBow":
                    return typeof(ShortBowSkin);
                case "Speargun":
                    return typeof(SpearGunSkin);
                case "Sword":
                    return typeof(SwordSkin);
                case "Staff":
                    return typeof(StaffSkin);
                case "Torch":
                    return typeof(TorchSkin);
                case "Trident":
                    return typeof(TridentSkin);
                case "Warhorn":
                    return typeof(WarHornSkin);
                case "Toy":
                    return typeof(ToyWeaponSkin);
                case "TwoHandedToy":
                    return typeof(TwoHandedToyWeaponSkin);
                case "SmallBundle":
                    return typeof(SmallBundleSkin);
                case "LargeBundle":
                    return typeof(LargeBundleSkin);
            }

            return typeof(UnknownWeaponSkin);
        }

        /// <summary>The invariant method for this class.</summary>
        [ContractInvariantMethod]
        private void ObjectInvariant()
        {
            Contract.Invariant(this.serviceClient != null);
        }
    }
}