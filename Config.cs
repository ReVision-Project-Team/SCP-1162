using Exiled.API.Interfaces;
using System.Collections.Generic;

namespace Scp1162
{
    public sealed class Config : IConfig
    {
        public bool IsEnabled { get; set; } = true;

        public bool Debug { get; set; } = false;

        public List<ItemType> BannedItems { get; set; } = new List<ItemType>()
        {
            ItemType.None,
            ItemType.KeycardO5,
            ItemType.Jailbird,
            ItemType.Ammo12gauge,
            ItemType.Ammo44cal,
            ItemType.Ammo556x45,
            ItemType.Ammo762x39,
            ItemType.Ammo9x19,
            ItemType.ArmorHeavy,
            ItemType.ArmorLight,
            ItemType.ArmorCombat,
            ItemType.GunA7,
            ItemType.GunE11SR,
            ItemType.GunAK,
            ItemType.GunCom45,
            ItemType.GunLogicer,
            ItemType.GunRevolver,
            ItemType.GunCrossvec,
            ItemType.GunFRMG0,
            ItemType.GunShotgun,
            ItemType.ParticleDisruptor,
            ItemType.MicroHID,
            ItemType.SCP330,
            ItemType.SCP244b,
            ItemType.SCP244a
        };
    }
}
