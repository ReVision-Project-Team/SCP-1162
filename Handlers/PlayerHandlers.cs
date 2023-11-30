using Exiled.API.Enums;
using Exiled.Events.EventArgs.Player;
using SCP1162.API;

namespace SCP1162.Handlers
{
    internal sealed class PlayerHandlers
    {
        public void OnPickingUpItem(PickingUpItemEventArgs ev)
        {
            if (ev.Pickup.IsPickup())
            {
                ev.IsAllowed = false;
                if (ev.Player.CurrentItem.Type is ItemType.None || ev.Player.CurrentItem is null)
                {
                    ev.Player.EnableEffect(EffectType.Flashed, 1);
                    ev.Player.EnableEffect(EffectType.SeveredHands);
                    ev.Player.EnableEffect(EffectType.Traumatized);
                    ev.Player.DisableEffect(EffectType.SeveredHands);

                    ev.Player.Health = ev.Player.Health - 30;

                    ev.Player.ShowHint("Вы протинули руку и вытинули случайный предмет");
                    ev.Player.GiveRandomItem();
                }
                else
                {
                    ev.Player.CurrentItem.Destroy();
                    ev.Player.ShowHint("Вы протинули руку и вытинули случайный предмет");
                    ev.Player.GiveRandomItem();
                }
            }
        }
    }
}
