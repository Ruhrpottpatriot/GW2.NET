// <copyright file="AvatarContextConverter.cs" company="GW2.NET Coding Team">
// This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>

namespace GW2NET.MumbleLink.Converters
{
    using System;
    using System.Net;

    using GW2NET.Common;
    using GW2NET.MumbleLink.Interop;

    [CLSCompliant(false)]
    public sealed class AvatarContextConverter : IConverter<MumbleContext, AvatarContext>
    {
        private readonly IConverter<SockaddrIn, IPEndPoint> ipEndPointConverter;

        public AvatarContextConverter(IConverter<SockaddrIn, IPEndPoint> ipEndPointConverter)
        {
            if (ipEndPointConverter == null)
            {
                throw new ArgumentNullException("ipEndPointConverter");
            }

            this.ipEndPointConverter = ipEndPointConverter;
        }

        public AvatarContext Convert(MumbleContext value, object state)
        {
            return new AvatarContext
            {
                ServerAddress = this.ipEndPointConverter.Convert(value.serverAddress, state),
                MapId = (int)value.mapId,
                MapType = (int)value.mapType,
                ShardId = (int)value.shardId,
                Instance = (int)value.instance,
                BuildId = (int)value.buildId,
                UiState = value.uiState,
                IsMapOpen = (value.uiState & UiStates.IsMapOpen) != UiStates.None,
                IsCompassTopRight = (value.uiState & UiStates.IsCompassTopRight) != UiStates.None,
                DoesCompassHaveRotationEnabled = (value.uiState & UiStates.DoesCompassHaveRotationEnabled) != UiStates.None,
                GameHasFocus = (value.uiState & UiStates.GameHasFocus) != UiStates.None,
                IsInCompetitiveGameMode = (value.uiState & UiStates.IsInCompetitiveGameMode) != UiStates.None,
                TextboxHasFocus = (value.uiState & UiStates.TextboxHasFocus) != UiStates.None,
                IsInCombat = (value.uiState & UiStates.IsInCombat) != UiStates.None,
                CompassWidth = (int)value.compassWidth,
                CompassHeight = (int)value.compassHeight,
                CompassRotation = value.compassRotation,
                PlayerX = value.playerX,
                PlayerY = value.playerY,
                MapCenterX = value.mapCenterX,
                MapCenterY = value.mapCenterY,
                MapScale = value.mapScale,
                ProcessId = (int)value.processId,
                CurrentMount = (Mount)value.mountIndex
            };
        }
    }
}
