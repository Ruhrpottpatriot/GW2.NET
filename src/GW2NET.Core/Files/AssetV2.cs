namespace GW2NET.Files
{
    using System;

    /// <summary>Represents information about a file that can be retrieved from the /v2 render service.</summary>
    public class AssetV2 : IEquatable<AssetV2>
    {
        /// <summary>Gets or sets the file id.</summary>
        public string FileId { get; set; }

        /// <summary>Gets or sets the icon url.</summary>
        public string IconUrl { get; set; }

        /// <summary>Indicates whether an object is equal to another object of the same type.</summary>
        /// <param name="left">The object on the left side.</param>
        /// <param name="right">The object on the right side.</param>
        /// <returns>true if the <paramref name="left" /> parameter is equal to the <paramref name="right" /> parameter; otherwise, false.</returns>
        public static bool operator ==(AssetV2 left, AssetV2 right)
        {
            return object.Equals(left, right);
        }

        /// <summary>Indicates whether an object differs from another object of the same type.</summary>
        /// <param name="left">The object on the left side.</param>
        /// <param name="right">The object on the right side.</param>
        /// <returns>true if the <paramref name="left" /> parameter differs from the <paramref name="right" /> parameter; otherwise, false.</returns>
        public static bool operator !=(AssetV2 left, AssetV2 right)
        {
            return !(left == right);
        }

        public bool Equals(AssetV2 other)
        {
            if (object.ReferenceEquals(null, other))
            {
                return false;
            }

            if (object.ReferenceEquals(this, other))
            {
                return true;
            }

            return this.FileId == other.FileId;
        }

        public override bool Equals(object obj)
        {
            if (object.ReferenceEquals(null, obj))
            {
                return false;
            }

            if (object.ReferenceEquals(this, obj))
            {
                return true;
            }

            if (obj.GetType() != this.GetType())
            {
                return false;
            }

            return this.Equals((AssetV2)obj);
        }

        public override int GetHashCode()
        {
            return this.FileId.GetHashCode();
        }

        public override string ToString()
        {
            return this.FileId;
        }
    }
}
