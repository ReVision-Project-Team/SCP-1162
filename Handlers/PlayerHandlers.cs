using Exiled.API.Enums;
using Exiled.API.Extensions;
using Exiled.Events.EventArgs.Player;
using Scp1162.API;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Scp1162.Handlers
{
    internal sealed class PlayerHandlers
    {
        private HashSet<ItemType> _bannedItems;

        internal PlayerHandlers(IEnumerable<ItemType> banned) => _bannedItems = banned.ToHashSet();

        public void OnPickingUpItem(PickingUpItemEventArgs ev)
        {
            if (!ev.IsAllowed || ev.Player == null || ev.Pickup == null || ev.Player.IsHost || !ev.Pickup.IsScp1162())
            {
                return;
            }

            ev.IsAllowed = false;

            if ((ev.Player?.CurrentItem?.Type ?? ItemType.None) == ItemType.None)
            {
                ev.Player.EnableEffect(EffectType.Flashed, 1, 1);
                ev.Player.EnableEffect(EffectType.SeveredHands);
                ev.Player.EnableEffect(EffectType.Traumatized);

                ev.Player.Health -= 30;

                ev.Player.ShowHint("Вы протянули руку но не смогли её вытянуть");
            }
            else
            {
                ev.Player.RemoveHeldItem();

                ev.Player.ShowHint("Вы протянули руку и вытянули случайный предмет");

                ev.Player.CurrentItem = ev.Player.AddItem(SelectRandomItem());
            }
        }

        private ItemType SelectRandomItem()
        {
            var array = Enum.GetValues(typeof(ItemType)).ToArray<ItemType>().ToList();

            ItemType item;

            do
            {
                item = array.GetRandomValue();
            } while (item == ItemType.None || _bannedItems.Contains(item));

            return item;
        }
    }
}
