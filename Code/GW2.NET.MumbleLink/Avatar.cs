namespace GW2DotNET.MumbleLink
{
    using GW2DotNET.Entities.Maps;

    public class Avatar
    {
        public long uiTick { get; set; }

        public int uiVersion { get; set; }

        public Identity Identity { get; set; }

        public AvatarContext Context { get; set; }

        public Vector3D AvatarFront { get; set; }

        public Vector3D AvatarTop { get; set; }

        public Vector3D AvatarPosition { get; set; }

        public Vector3D CameraPosition { get; set; }

        public Vector3D CameraFront { get; set; }

        public Vector3D CameraTop { get; set; }
    }
}
