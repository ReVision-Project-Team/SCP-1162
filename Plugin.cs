using Exiled.Events.Handlers;
using System;
using SCP1162.Handlers;

namespace SCP1162
{
    public sealed class Plugin : Exiled.API.Features.Plugin<Config>
    {
        private ServerHandlers _server;
        private PlayerHandlers _player;

        public override string Prefix => "SCP-1162";
        public override string Name => "SCP 1162";
        public override string Author => "Timersky";

        public Plugin singleton;

        public override Version Version { get; } = new Version(1, 0, 0);
        public override Version RequiredExiledVersion { get; } = new Version(8, 4, 0);

        public override void OnEnabled()
        {
            singleton = this;

            _server = new ServerHandlers();
            _player = new PlayerHandlers();

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

            singleton = null;

            base.OnDisabled();
        }

        public override void OnReloaded() { }
        public override void OnRegisteringCommands() { }
        public override void OnUnregisteringCommands() { }
    }
}
