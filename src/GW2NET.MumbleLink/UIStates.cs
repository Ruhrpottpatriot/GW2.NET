using System;
using System.Diagnostics.CodeAnalysis;

namespace GW2NET.MumbleLink
{
    [CLSCompliant(false)]
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Not a public API.")]
    public class UiStates
    {
        public const uint None = 0x00;

        public const uint IsMapOpen = 0x01;

        public const uint IsCompassTopRight = 0x01 << 1;

        public const uint DoesCompassHaveRotationEnabled = 0x01 << 2;

        public const uint GameHasFocus = 0x01 << 3;

        public const uint IsInCompetitiveGameMode = 0x01 << 4;

        public const uint TextboxHasFocus = 0x01 << 5;

        public const uint IsInCombat = 0x01 << 6;
    }
}
