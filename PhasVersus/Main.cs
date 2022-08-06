using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using MelonLoader;
using UnityEngine.InputSystem;
using O = PhasVersus.Objects;
using G = PhasVersus.Globals;
using System.Collections;
using Steamworks;

namespace PhasVersus
{
    public class BuildInfo
    {
        public const string ModName = "PhasVersus";
        public const string ModAuthor = "Seven7FootRat/waffleishis";
        public const string ModVersion = "1.2.5";
        public const string GameName = "Phasmophobia";
        public const string GameStudio = "Kinetic Games";
    }

    public class Main : MelonMod
    {
        public override void OnApplicationStart()
        {
            base.OnApplicationStart();

#if DEBUG
MelonLogger.Msg("Debuging/using test version");
#endif

            MelonLogger.Msg("You have launched the game with the PhasVersus Mod.\n" +
                "Make sure that you are the host as most features only work if you are the host.\n" +
                "The mod is most enjoyable with friends but can be used to troll public lobbies too.\n" +
                "Please do not abuse it. Enjoy! 8====D\n" +
                "Credits and special thanks to:\n" +
                "Cr4nkSt4r, your code helped out a lot in the production of this mod\n" +
                "The Phasmophobia Modding Community, for helpful advice and experience\n" +
                "Friends, for providing me with insperation and test subjects\n" +
                "Kinetic Games, for an awesome ghosty boi game :)");
        }

        public override void OnUpdate()
        {
            base.OnUpdate();

            Keyboard keyboard = Keyboard.current;

            if (!G.CoR)
            {
                MelonCoroutines.Start(G.SetGlobals());
            }
            if (!O.CoR)
            {
                MelonCoroutines.Start(O.SetObjects());
            }

            if (G.isInGame)
            {
                if (keyboard.kKey.wasPressedThisFrame) // Allow the player to kill self for a more desirable ghost experience
                {
                    if (O.localPlayer != null)
                    {
                        O.localPlayer.KillPlayer();
                    }
                }

                if (keyboard.hKey.wasPressedThisFrame)
                {
                    MelonCoroutines.Start(DoHunt());
                }

                if (keyboard.qKey.wasPressedThisFrame)
                {
                    MelonCoroutines.Start(DoAppear());
                }

                if (keyboard.rKey.wasPressedThisFrame)
                {
                    DoAbility();
                }

                if (keyboard.pKey.wasPressedThisFrame)
                {
                    DoDoorKnock();
                }
            }
        }

        public override void OnGUI()
        {
            base.OnGUI();

            GUI.Label(new Rect(0, 0, 100, 25), "PhasVersus");

            GUI.color = Color.magenta;

            if (O.ghost != null)
            {
                GUI.Label(new Rect(0, 50, 200, 25), "Name: " + O.ghost.field_Public_GhostInfo_0.field_Public_ValueTypePublicSealedObLiOb1InBoStObInBoUnique_0.field_Public_String_0);

                GUI.Label(new Rect(0, 75, 100, 25), "Age: " + O.ghost.field_Public_GhostInfo_0.field_Public_ValueTypePublicSealedObLiOb1InBoStObInBoUnique_0.field_Public_Int32_0.ToString());

                GUI.Label(new Rect(0, 100, 100, 25), "Type: " + O.ghost.field_Public_GhostInfo_0.field_Public_ValueTypePublicSealedObLiOb1InBoStObInBoUnique_0.field_Public_EnumNPublicSealedvaSpWrPhPoBaJiMaReShUnique_0.ToString());

                GUI.Label(new Rect(0, 125, 200, 25), "Difficulty: " + G.difficulty.ToString());
            }

            if (O.ghost != null && O.ghost.field_Public_EnumNPublicSealedvaidwahufalidothfuapUnique_0 == GhostAI.EnumNPublicSealedvaidwahufalidothfuapUnique.hunting)
            {
                if (UnityEngine.Screen.width != null && G.isStyleSet)
                {
                    // I love meth
                    var width = UnityEngine.Screen.width / 4;
                    var xpos = (UnityEngine.Screen.width / 2) - (width / 2);
                    var height = UnityEngine.Screen.height / 6.5f;
                    var ypos = height;

                    GUI.Label(new Rect(xpos, height, width, height), "<color=\"red\">HUNTING ()<\\color>", G.myStyle);
                }
            }

#if DEBUG
            if (G.curScene != null)
            {
                GUI.Label(new Rect(0, 150, 400, 25), "SceneName: " + G.curScene.name);
            }
            GUI.Label(new Rect(0, 175, 200, 25), "isInGame: " + G.isInGame.ToString());
#endif
        }

        // This function is unnessesarily big as shit...           Too bad!!!
        public IEnumerator DoHunt()
        {
            if (O.ghost != null)
            {
                MelonLogger.Msg("DoHunt called");
                switch (G.difficulty)
                {
                    case EnumPublicSealedvaAmInPrNiCu6vUnique.Amateur:
                        {
                            O.ghost.ChangeState(GhostAI.EnumNPublicSealedvaidwahufalidothfuapUnique.hunting);
                            G.remainingHuntTime = 5;
                            yield return new WaitForSeconds(1);
                            G.remainingHuntTime = 4;
                            yield return new WaitForSeconds(1);
                            G.remainingHuntTime = 3;
                            yield return new WaitForSeconds(1);
                            G.remainingHuntTime = 2;
                            yield return new WaitForSeconds(1);
                            G.remainingHuntTime = 1;
                            yield return new WaitForSeconds(1);
                            G.remainingHuntTime = 0;
                            O.ghost.ChangeState(GhostAI.EnumNPublicSealedvaidwahufalidothfuapUnique.idle);
                        }
                        break;
                    case EnumPublicSealedvaAmInPrNiCu6vUnique.Intermediate:
                        {
                            O.ghost.ChangeState(GhostAI.EnumNPublicSealedvaidwahufalidothfuapUnique.hunting);
                            G.remainingHuntTime = 10;
                            yield return new WaitForSeconds(1);
                            G.remainingHuntTime = 9;
                            yield return new WaitForSeconds(1);
                            G.remainingHuntTime = 8;
                            yield return new WaitForSeconds(1);
                            G.remainingHuntTime = 7;
                            yield return new WaitForSeconds(1);
                            G.remainingHuntTime = 6;
                            yield return new WaitForSeconds(1);
                            G.remainingHuntTime = 5;
                            yield return new WaitForSeconds(1);
                            G.remainingHuntTime = 4;
                            yield return new WaitForSeconds(1);
                            G.remainingHuntTime = 3;
                            yield return new WaitForSeconds(1);
                            G.remainingHuntTime = 2;
                            yield return new WaitForSeconds(1);
                            G.remainingHuntTime = 1;
                            yield return new WaitForSeconds(1);
                            G.remainingHuntTime = 0;
                            O.ghost.ChangeState(GhostAI.EnumNPublicSealedvaidwahufalidothfuapUnique.idle);
                        }
                        break;
                    case EnumPublicSealedvaAmInPrNiCu6vUnique.Professional:
                        {
                            O.ghost.ChangeState(GhostAI.EnumNPublicSealedvaidwahufalidothfuapUnique.hunting);
                            G.remainingHuntTime = 15;
                            yield return new WaitForSeconds(1);
                            G.remainingHuntTime = 14;
                            yield return new WaitForSeconds(1);
                            G.remainingHuntTime = 13;
                            yield return new WaitForSeconds(1);
                            G.remainingHuntTime = 12;
                            yield return new WaitForSeconds(1);
                            G.remainingHuntTime = 11;
                            yield return new WaitForSeconds(1);
                            G.remainingHuntTime = 10;
                            yield return new WaitForSeconds(1);
                            G.remainingHuntTime = 9;
                            yield return new WaitForSeconds(1);
                            G.remainingHuntTime = 8;
                            yield return new WaitForSeconds(1);
                            G.remainingHuntTime = 7;
                            yield return new WaitForSeconds(1);
                            G.remainingHuntTime = 6;
                            yield return new WaitForSeconds(1);
                            G.remainingHuntTime = 5;
                            yield return new WaitForSeconds(1);
                            G.remainingHuntTime = 4;
                            yield return new WaitForSeconds(1);
                            G.remainingHuntTime = 3;
                            yield return new WaitForSeconds(1);
                            G.remainingHuntTime = 2;
                            yield return new WaitForSeconds(1);
                            G.remainingHuntTime = 1;
                            yield return new WaitForSeconds(1);
                            G.remainingHuntTime = 0;
                            O.ghost.ChangeState(GhostAI.EnumNPublicSealedvaidwahufalidothfuapUnique.idle);
                        }
                        break;
                    case EnumPublicSealedvaAmInPrNiCu6vUnique.Nightmare:
                        {
                            O.ghost.ChangeState(GhostAI.EnumNPublicSealedvaidwahufalidothfuapUnique.hunting);
                            G.remainingHuntTime = 20;
                            yield return new WaitForSeconds(1);
                            G.remainingHuntTime = 19;
                            yield return new WaitForSeconds(1);
                            G.remainingHuntTime = 18;
                            yield return new WaitForSeconds(1);
                            G.remainingHuntTime = 17;
                            yield return new WaitForSeconds(1);
                            G.remainingHuntTime = 16;
                            yield return new WaitForSeconds(1);
                            G.remainingHuntTime = 15;
                            yield return new WaitForSeconds(1);
                            G.remainingHuntTime = 14;
                            yield return new WaitForSeconds(1);
                            G.remainingHuntTime = 13;
                            yield return new WaitForSeconds(1);
                            G.remainingHuntTime = 12;
                            yield return new WaitForSeconds(1);
                            G.remainingHuntTime = 11;
                            yield return new WaitForSeconds(1);
                            G.remainingHuntTime = 10;
                            yield return new WaitForSeconds(1);
                            G.remainingHuntTime = 9;
                            yield return new WaitForSeconds(1);
                            G.remainingHuntTime = 8;
                            yield return new WaitForSeconds(1);
                            G.remainingHuntTime = 7;
                            yield return new WaitForSeconds(1);
                            G.remainingHuntTime = 6;
                            yield return new WaitForSeconds(1);
                            G.remainingHuntTime = 5;
                            yield return new WaitForSeconds(1);
                            G.remainingHuntTime = 4;
                            yield return new WaitForSeconds(1);
                            G.remainingHuntTime = 3;
                            yield return new WaitForSeconds(1);
                            G.remainingHuntTime = 2;
                            yield return new WaitForSeconds(1);
                            G.remainingHuntTime = 1;
                            yield return new WaitForSeconds(1);
                            G.remainingHuntTime = 0;
                            O.ghost.ChangeState(GhostAI.EnumNPublicSealedvaidwahufalidothfuapUnique.idle);
                        }
                        break;
                    default:
                        {
                            O.ghost.ChangeState(GhostAI.EnumNPublicSealedvaidwahufalidothfuapUnique.hunting);
                            G.remainingHuntTime = 15;
                            yield return new WaitForSeconds(1);
                            G.remainingHuntTime = 14;
                            yield return new WaitForSeconds(1);
                            G.remainingHuntTime = 13;
                            yield return new WaitForSeconds(1);
                            G.remainingHuntTime = 12;
                            yield return new WaitForSeconds(1);
                            G.remainingHuntTime = 11;
                            yield return new WaitForSeconds(1);
                            G.remainingHuntTime = 10;
                            yield return new WaitForSeconds(1);
                            G.remainingHuntTime = 9;
                            yield return new WaitForSeconds(1);
                            G.remainingHuntTime = 8;
                            yield return new WaitForSeconds(1);
                            G.remainingHuntTime = 7;
                            yield return new WaitForSeconds(1);
                            G.remainingHuntTime = 6;
                            yield return new WaitForSeconds(1);
                            G.remainingHuntTime = 5;
                            yield return new WaitForSeconds(1);
                            G.remainingHuntTime = 4;
                            yield return new WaitForSeconds(1);
                            G.remainingHuntTime = 3;
                            yield return new WaitForSeconds(1);
                            G.remainingHuntTime = 2;
                            yield return new WaitForSeconds(1);
                            G.remainingHuntTime = 1;
                            yield return new WaitForSeconds(1);
                            G.remainingHuntTime = 0;
                            O.ghost.ChangeState(GhostAI.EnumNPublicSealedvaidwahufalidothfuapUnique.idle);
                        }
                        break;
                }
                yield break;
            }
        }

        public IEnumerator DoAppear()
        {
            if (O.ghost != null)
            {
                MelonLogger.Msg("DoAppear called");
                O.ghost.Appear();
                yield return new WaitForSeconds(3f);
                O.ghost.UnAppear();
                yield break;
            }
        }

        public void DoAbility()
        {
            if (O.ghost != null)
            {
                MelonLogger.Msg("DoAbility called");
                O.ghost.ChangeState(GhostAI.EnumNPublicSealedvaidwahufalidothfuapUnique.GhostAbility);
            }
        }

        public void DoDoorKnock()
        {
            if (O.ghost != null)
            {
                MelonLogger.Msg("DoDoorKnock called");
                O.ghost.ChangeState(GhostAI.EnumNPublicSealedvaidwahufalidothfuapUnique.doorKnock);
            }
        }
    }

    /*
    [HarmonyLib.HarmonyPatch(typeof(GhostAI), "Start")]
    public static class GhostAI_Start_Patch
    {
        public static void Postfix(ref GhostAI __instance)
        {
            foreach (Renderer renderer in __instance.GetComponentsInChildren<Renderer>())
            {
                renderer.material.SetColor("_Color", Color.green);
                renderer.material.shader = Shader.Find("Hidden/Internal-Colored");
                renderer.material.SetInt("_ZTest", 8);
            }
        }
    }
    */

    [HarmonyLib.HarmonyPatch(typeof(GhostAI), "Start")]
    public static class GhostAI_Start_Patch
    {
        public static void Postfix(ref GhostAI __instance)
        {
            __instance.field_Public_GhostInfo_0.field_Public_ValueTypePublicSealedObLiOb1InBoStObInBoUnique_0.field_Public_String_0 = G.playerName;
        }
    }

    [HarmonyLib.HarmonyPatch(typeof(GhostAI), "Update")]
    public static class GhostAI_Update_Patch
    {
        public static void Prefix(ref GhostAI __instance)
        {
            var newPos = O.localPlayer.transform.position;
            newPos.y = newPos.y - 0.7f;

            __instance.transform.position = newPos;
            __instance.transform.rotation = O.localPlayer.transform.rotation;
        }
    }

    [HarmonyLib.HarmonyPatch(typeof(Player), "Start")]
    public static class Player_Start_Patch
    {
        public static void Postfix(ref Player __instance)
        {
            if (__instance.field_Public_PhotonView_0.AmOwner)
            {
                if (G.isInGame)
                {
                    var pa = __instance.field_Public_Animator_0;
                    var bones = pa.GetBoneTransform(HumanBodyBones.Head);
                    UnityEngine.Object.Destroy(bones.GetComponent<Light>());
                    var light = bones.gameObject.AddComponent<Light>();
                    light.color = Color.white;
                    light.type = LightType.Spot;
                    light.shadows = LightShadows.None;
                    light.range = 99f;
                    light.spotAngle = 9999f;
                    light.intensity = 0.3f;
                }
            }
            else
            {
                if (G.isInGame)
                {
                    foreach (Renderer renderer in __instance.GetComponentsInChildren<Renderer>())
                    {
                        renderer.material.SetColor("_Color", Color.green);
                        renderer.material.shader = Shader.Find("Hidden/Internal-Colored");
                        renderer.material.SetInt("_ZTest", 8);
                    }
                }
            }
        }
    }

    [HarmonyLib.HarmonyPatch(typeof(GameController), "Awake")]
    public static class GameController_Patch
    {
        public static void Postfix(ref GameController __instance)
        {
            var playerDataList = __instance.field_Public_List_1_ObjectPublicPlStPlUnique_0;
            
            foreach (ObjectPublicPlStPlUnique playerData in playerDataList)
            {
                if (playerData.field_Public_Player_0 == O.localPlayer)
                {
                    G.playerName = playerData.field_Public_String_0;

                    break;
                }
                else
                    continue;
            }
        }
    }
}
