using Exiled.API.Features;
using MEC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace WaitingAndChilling
{
    public class TutComponent : MonoBehaviour
    {
        private Player player;
        private List<CoroutineHandle> Coroutines = new List<CoroutineHandle>();

        private void Awake()
        {
            player = Player.Get(gameObject);
            Coroutines.Add(Timing.RunCoroutine(DataHints()));
        }

        private void Update()
        {
            if (player == null || Round.IsStarted)
            {
                Destroy();
            }
        }

        private IEnumerator<float> DataHints()
        {
            while (true)
            {
                player.Broadcast(1, $"{(Round.IsLobbyLocked ? "<color=yellow>Lobby Lock Enabled</color>" : (Player.List.Count() > 1 ? "<color=yellow>The game will start soon.</color>" : "<color=yellow>Waiting for more players.</color>"))}" +
                                               $"\nPlayers Connected: {Player.List.Count()}", Broadcast.BroadcastFlags.Normal);
                yield return Timing.WaitForSeconds(1f);
            }
        }

        private void Destroy()
        {
            try
            {
                foreach (CoroutineHandle coroutine in Coroutines)
                    Timing.KillCoroutines(coroutine);

                Destroy(this);
            }
            catch (Exception e)
            {
                Log.Error("Cannot destroy tutComponent: " + e);
            }
        }
    }
}
