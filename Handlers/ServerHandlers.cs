using Exiled.API.Features.Pickups;
using SCP1162.API;
using System.Linq;
using UnityEngine;

namespace SCP1162.Handlers
{
    internal sealed class ServerHandlers
    {
        public void OnRoundStarted()
        {
            Exiled.API.Features.Room _room = Exiled.API.Features.Room.List.FirstOrDefault(x => x.Type == Exiled.API.Enums.RoomType.Lcz173);
            GameObject scp1162 = Exiled.API.Features.Items.Item.Create(ItemType.SCP500).CreatePickup(Vector3.zero).GameObject;

            scp1162.GetComponent<Rigidbody>().useGravity = false;
            scp1162.GetComponent<Rigidbody>().drag = 0f;
            scp1162.GetComponent<Rigidbody>().collisionDetectionMode = CollisionDetectionMode.Continuous;
            scp1162.GetComponent<Rigidbody>().freezeRotation = true;
            scp1162.GetComponent<Rigidbody>().detectCollisions = false;

            scp1162.transform.parent = _room.transform;
            scp1162.transform.localPosition = new Vector3(16.608f, 12.966f, 3.761f);
            scp1162.transform.localRotation = Quaternion.Euler(90, 0, 0);
            scp1162.transform.localScale = new Vector3(5, 5, 5);

            scp1162.SetActive(true);

            scp1162.GetComponent<Pickup>().SetPickup();
        }
    }
}
