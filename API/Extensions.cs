using Exiled.API.Features;
using Exiled.API.Features.Items;
using System.Linq;
using Exiled.API.Extensions;
using UnityEngine;

namespace SCP1162.API
{
    public static class Extensions
    {
        private static GameObject _pickup;

        public static bool IsPickup(this GameObject pickup) 
        {
            if (pickup != _pickup)
                return false;
            return true;
        }
        public static GameObject GetPickup() => _pickup;
        public static void SetPickup(this GameObject value) => _pickup = value;

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
