using Exiled.API.Features.Pickups;

namespace Scp1162.API
{
    public static class Extensions
    {
        public static Pickup Pickup { get; internal set; }

        public static bool IsScp1162(this Pickup pickup) => pickup == Pickup;
    }
}
