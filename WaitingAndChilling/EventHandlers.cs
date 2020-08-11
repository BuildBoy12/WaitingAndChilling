using Exiled.API.Features;
using Exiled.Events.EventArgs;
using MEC;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace WaitingAndChilling
{
    public class EventHandlers
    {
        public void OnWaitingForPlayers()
        {
            GameObject.Find("StartRound").transform.localScale = Vector3.zero;
        }

        public void OnPlayerJoined(JoinedEventArgs ev)
        {
            if (!Round.IsStarted)
                Timing.CallDelayed(1f, () => { ev.Player.SetRole(RoleType.Tutorial); ev.Player.ResetInventory(new List<ItemType>()); ev.Player.GameObject.AddComponent<TutComponent>(); });
        }
    }
}
