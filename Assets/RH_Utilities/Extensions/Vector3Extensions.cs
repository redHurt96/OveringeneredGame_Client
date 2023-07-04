using UnityEngine;
using static UnityEngine.Random;

namespace RH_Utilities.Extensions
{
    public static class Vector3Extensions
    {
        public static Vector3 AddRandomInBox(this Vector3 origin, Vector3 size) =>
            origin + new Vector3(
                Range(-size.x, size.x),
                Range(-size.y, size.y),
                Range(-size.z, size.z));

        public static System.Numerics.Vector3 ToNumerics(this Vector3 origin) => 
            new(origin.x, origin.y, origin.z);

        public static Vector3 ToUnity(this System.Numerics.Vector3 origin) => 
            new(origin.X, origin.Y, origin.Z);
    }
}