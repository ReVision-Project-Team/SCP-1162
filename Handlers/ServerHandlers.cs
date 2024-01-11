using Exiled.API.Enums;
using Exiled.API.Features;
using Exiled.API.Features.Pickups;
using Scp1162.API;
using UnityEngine;

namespace Scp1162.Handlers
{
    internal sealed class ServerHandlers
    {
        public void OnRoundStarted()
        {
            Extensions.Pickup = Pickup.CreateAndSpawn(ItemType.Coin, Vector3.zero, default);
            var obj = Extensions.Pickup.GameObject;
            var rigidbody = obj.GetComponent<Rigidbody>();

            rigidbody.useGravity = false;
            rigidbody.drag = 0;
            rigidbody.collisionDetectionMode = CollisionDetectionMode.Continuous;
            rigidbody.freezeRotation = true;
            rigidbody.detectCollisions = false;

            obj.transform.SetParent(Room.Get(RoomType.Lcz173).transform);
            obj.transform.localPosition = new Vector3(16.608f, 12.966f, 3.761f);
            obj.transform.localRotation = Quaternion.Euler(90, 0, 0);

            Extensions.Pickup.Scale = Vector3.one * 7;

            obj.SetActive(true);
        }
    }
}
