namespace GW2NET.ChatLinks.Interop
{
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Explicit)]
    public struct Recipe
    {
        [FieldOffset(0)]
        public int recipeId;
    }
}
