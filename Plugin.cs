using Exiled.Events.Handlers;
using Scp1162.Handlers;
using System;

namespace Scp1162
{
    public class Plugin : Exiled.API.Features.Plugin<Config>
    {
        private ServerHandlers _server;
        private PlayerHandlers _player;

        public override string Prefix => "Scp1162";
        public override string Name => "SCP-1162";
        public override string Author => "Timersky & NotAloneAgain";

        public override Version Version { get; } = new Version(1, 0, 0);
        public override Version RequiredExiledVersion { get; } = new Version(8, 4, 0);

        public override void OnEnabled()
        {
            _server = new ServerHandlers();
            _player = new PlayerHandlers(Config.BannedItems);

            Server.RoundStarted += _server.OnRoundStarted;
            Player.PickingUpItem += _player.OnPickingUpItem;

            base.OnEnabled();
        }
        public override void OnDisabled()
        {
            Player.PickingUpItem -= _player.OnPickingUpItem;
            Server.RoundStarted -= _server.OnRoundStarted;

            _player = null;
            _server = null;

            base.OnDisabled();
        }

        public override void OnReloaded() { }

        public override void OnRegisteringCommands() { }

        public override void OnUnregisteringCommands() { }
    }
}
