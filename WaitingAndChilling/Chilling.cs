using Exiled.API.Features;
using System;
using Player = Exiled.Events.Handlers.Player;
using Server = Exiled.Events.Handlers.Server;

namespace WaitingAndChilling
{
    public class Chilling : Plugin<Config>
    {
        private EventHandlers EventHandlers;
        public override void OnEnabled()
        {
            base.OnEnabled();
            EventHandlers = new EventHandlers();
            Server.WaitingForPlayers += EventHandlers.OnWaitingForPlayers;
            Player.Joined += EventHandlers.OnPlayerJoined;
        }

        public override void OnDisabled()
        {
            base.OnDisabled();
            Server.WaitingForPlayers -= EventHandlers.OnWaitingForPlayers;
            Player.Joined -= EventHandlers.OnPlayerJoined;
        }

        public override Version Version => new Version(1, 0, 0);
        public override string Author => "Build";
    }
}
