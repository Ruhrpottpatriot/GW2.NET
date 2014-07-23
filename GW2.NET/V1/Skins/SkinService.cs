// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SkinService.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides the default implementation of the skins service.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Skins
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Threading;
    using System.Threading.Tasks;

    using GW2DotNET.Common;
    using GW2DotNET.Common.Serializers;
    using GW2DotNET.Items;
    using GW2DotNET.Skins;
    using GW2DotNET.Utilities;
    using GW2DotNET.V1.Skins.Contracts;

    /// <summary>Provides the default implementation of the skins service.</summary>
    public class SkinService : ISkinService
    {
        /// <summary>Infrastructure. Holds a reference to the service client.</summary>
        private readonly IServiceClient serviceClient;

        /// <summary>Initializes a new instance of the <see cref="SkinService"/> class.</summary>
        /// <param name="serviceClient">The service client.</param>
        public SkinService(IServiceClient serviceClient)
        {
            this.serviceClient = serviceClient;
        }

        /// <summary>Gets a skin and its localized details.</summary>
        /// <param name="skin">The skin identifier.</param>
        /// <returns>A skin and its localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/skin_details">wiki</a> for more information.</remarks>
        public Skin GetSkinDetails(int skin)
        {
            return this.GetSkinDetails(skin, CultureInfo.GetCultureInfo("en"));
        }

        /// <summary>Gets a skin and its localized details.</summary>
        /// <param name="skin">The skin identifier.</param>
        /// <param name="language">The language.</param>
        /// <returns>A skin and its localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/skin_details">wiki</a> for more information.</remarks>
        public Skin GetSkinDetails(int skin, CultureInfo language)
        {
            Preconditions.EnsureNotNull(paramName: "language", value: language);
            var request = new SkinDetailsRequest { SkinId = skin, Culture = language };
            var response = this.serviceClient.Send(request, new JsonSerializer<SkinContract>());
            var value = MapSkinContract(response.Content);
            value.Language = language.TwoLetterISOLanguageName;
            return value;
        }

        /// <summary>Gets a skin and its localized details.</summary>
        /// <param name="skin">The skin identifier.</param>
        /// <returns>A skin and its localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/skin_details">wiki</a> for more information.</remarks>
        public Task<Skin> GetSkinDetailsAsync(int skin)
        {
            return this.GetSkinDetailsAsync(skin, CultureInfo.GetCultureInfo("en"), CancellationToken.None);
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
            return this.GetSkinDetailsAsync(skin, CultureInfo.GetCultureInfo("en"), cancellationToken);
        }

        /// <summary>Gets a skin and its localized details.</summary>
        /// <param name="skin">The skin identifier.</param>
        /// <param name="language">The language.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A skin and its localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/skin_details">wiki</a> for more information.</remarks>
        public Task<Skin> GetSkinDetailsAsync(int skin, CultureInfo language, CancellationToken cancellationToken)
        {
            Preconditions.EnsureNotNull(paramName: "language", value: language);
            var request = new SkinDetailsRequest { SkinId = skin, Culture = language };
            return this.serviceClient.SendAsync(request, new JsonSerializer<SkinContract>(), cancellationToken).ContinueWith(
                task =>
                    {
                        var response = task.Result;
                        var value = MapSkinContract(response.Content);
                        value.Language = language.TwoLetterISOLanguageName;
                        return value;
                    }, 
                cancellationToken);
        }

        /// <summary>Gets a collection of skin identifiers.</summary>
        /// <returns>A collection of skin identifiers.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/skins">wiki</a> for more information.</remarks>
        public ICollection<int> GetSkins()
        {
            var request = new SkinRequest();
            var response = this.serviceClient.Send(request, new JsonSerializer<SkinCollectionContract>());
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
            var request = new SkinRequest();
            return this.serviceClient.SendAsync(request, new JsonSerializer<SkinCollectionContract>(), cancellationToken).ContinueWith(
                task =>
                    {
                        var response = task.Result;
                        return response.Content.Skins;
                    }, 
                cancellationToken);
        }

        /// <summary>Infrastructure. Maps skin type discriminators to .NET types.</summary>
        /// <param name="content">The content.</param>
        /// <returns>The corresponding <see cref="System.Type"/>.</returns>
        private static Type GetArmorSkinType(ArmorSkinContract content)
        {
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
                default:
                    return typeof(UnknownArmorSkin);
            }
        }

        /// <summary>Infrastructure. Maps skin type discriminators to .NET types.</summary>
        /// <param name="content">The content.</param>
        /// <returns>The corresponding <see cref="System.Type"/>.</returns>
        private static Type GetSkinType(SkinContract content)
        {
            switch (content.Type)
            {
                case "Armor":
                    return GetArmorSkinType(content.Armor);
                case "Back":
                    return typeof(BackpackSkin);
                case "Weapon":
                    return GetWeaponSkinType(content.Weapon);
                default:
                    return typeof(UnknownWeaponSkin);
            }
        }

        /// <summary>Infrastructure. Maps skin type discriminators to .NET types.</summary>
        /// <param name="content">The content.</param>
        /// <returns>The corresponding <see cref="System.Type"/>.</returns>
        private static Type GetWeaponSkinType(WeaponSkinContract content)
        {
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
                default:
                    return typeof(UnknownWeaponSkin);
            }
        }

        /// <summary>Infrastructure. Maps contracts to entities.</summary>
        /// <param name="skin">The entity.</param>
        /// <param name="content">The content.</param>
        private static void MapArmorSkinContract(ArmorSkin skin, ArmorSkinContract content)
        {
            skin.WeightClass = (ArmorWeightClass)Enum.Parse(typeof(ArmorWeightClass), content.WeightClass, true);
        }

        /// <summary>Infrastructure. Maps contracts to entities.</summary>
        /// <param name="content">The content.</param>
        /// <returns>An entity.</returns>
        private static Skin MapSkinContract(SkinContract content)
        {
            // Map type discriminators to .NET types
            var value = (Skin)Activator.CreateInstance(GetSkinType(content));

            // Map skin identifier
            value.SkinId = int.Parse(content.SkinId);

            // Map skin name
            value.Name = content.Name;

            // Map skin flags
            foreach (var flag in content.Flags)
            {
                value.Flags |= (SkinFlags)Enum.Parse(typeof(SkinFlags), flag, true);
            }

            // Map skin restrictions
            foreach (var restriction in content.Restrictions)
            {
                value.Restrictions |= (ItemRestrictions)Enum.Parse(typeof(ItemRestrictions), restriction, true);
            }

            // Map icon file identifier
            value.FileId = int.Parse(content.IconFileId);

            // Map icon file signature
            value.FileSignature = content.IconFileSignature;

            // Map type-specific skin contracts (maximum 1 contract per type)
            if (content.Armor != null)
            {
                MapArmorSkinContract((ArmorSkin)value, content.Armor);
            }
            else if (content.Weapon != null)
            {
                MapWeaponSkinContract((WeaponSkin)value, content.Weapon);
            }

            // Map skin description
            value.Description = string.IsNullOrEmpty(content.Description) ? null : content.Description;

            return value;
        }

        /// <summary>Infrastructure. Maps contracts to entities.</summary>
        /// <param name="skin">The entity.</param>
        /// <param name="content">The content.</param>
        private static void MapWeaponSkinContract(WeaponSkin skin, WeaponSkinContract content)
        {
            skin.DamageType = (WeaponDamageType)Enum.Parse(typeof(WeaponDamageType), content.DamageType, true);
        }
    }
}