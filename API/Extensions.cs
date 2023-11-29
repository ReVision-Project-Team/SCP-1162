using Exiled.API.Features;
using Exiled.API.Features.Pickups;
using Exiled.API.Features.Items;
using SCP1162;

namespace SCP1162.API
{
    public static class Extensions
    {
        private static Pickup _pickup;

        public static bool IsPickup(this Pickup pickup) 
        {
            if (pickup != _pickup)
                return false;
            return true;
        }
        public static Pickup GetPickup() => _pickup;
        public static void SetPickup(this Pickup value) => _pickup = value;

        public static void AddItems(this Player player)
        {
            Item.List.
            player.CurrentItem = player.AddItem();
        }
    }
}
