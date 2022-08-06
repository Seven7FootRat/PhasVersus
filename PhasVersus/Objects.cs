using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using G = PhasVersus.Globals;

namespace PhasVersus
{
    public static class Objects
    {
        public static IEnumerator SetObjects()
        {
            CoR = true;

            ghost = UnityEngine.Object.FindObjectOfType<GhostAI>();

            playerList = UnityEngine.Object.FindObjectsOfType<Player>().ToList();
            yield return new WaitForSeconds(0.05f);

            levelValues = UnityEngine.Object.FindObjectOfType<LevelValues>();
            yield return new WaitForSeconds(0.05f);

            foreach (Player player in playerList)
            {
                if (playerList.Count > 0)
                {
                    if (player.field_Public_PhotonView_0.AmOwner)
                    {
                        localPlayer = player;
                    }
                }
            }
            yield return new WaitForSeconds(0.05f);

            CoR = false;
            yield break;
        }

        public static bool CoR = false;
        public static Player localPlayer;
        public static LevelValues levelValues;
        public static GhostAI ghost;
        public static List<Player> playerList;
    }
}
