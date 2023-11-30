using Exiled.API.Features;
using Exiled.API.Features.Pickups;
using Exiled.API.Features.Items;
using SCP1162;
using System.Linq;
using Exiled.API.Extensions;

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

        public static void GiveRandomItem(this Player player)
        {
            Config _config = new Config();
            Item _item = Item.List.ToList().GetRandomValue();
            if (_item is null || player is null) return;
            if (_config.UnauthorizedItems.Contains(_item.Type)) GiveRandomItem(player);
            player.AddItem(_item);
            player.CurrentItem = _item;
        }
    }
}
