using System.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using MelonLoader;
using O = PhasVersus.Objects;
using System.IO;
using System.Windows;

namespace PhasVersus
{
    public static class Globals
    {
        public static bool CoR = false;
        public static bool isInGame = false;
        public static Scene curScene;
        public static string bundlePath;
        public static Shader chamShader;
        public static EnumPublicSealedvaAmInPrNiCu6vUnique difficulty;
        public static string playerName;
        public static float remainingHuntTime;
        public static GUIStyle myStyle;
        public static bool isStyleSet = false;

        public static IEnumerator SetGlobals()
        {
            CoR = true;

            if (!isStyleSet)
            {
                myStyle = new GUIStyle();

                myStyle.fontSize = 35;
                myStyle.alignment = TextAnchor.MiddleCenter;
                myStyle.richText = true;

                isStyleSet = true;

                yield return new WaitForSeconds(0.05f);
            }

            curScene = SceneManager.GetActiveScene();
            yield return new WaitForSeconds(0.05f);

            if (curScene != null)
            {
                if (curScene.name != "Menu_New" && curScene.name != "SplashScreen_Headphones")
                {
                    isInGame = true;
                    yield return new WaitForSeconds(0.05f);
                }
                else
                {
                    isInGame = false;
                    yield return new WaitForSeconds(0.05f);
                }
            }
            else
            {
                isInGame = false;
            }

            try
            {
                difficulty = O.levelValues.field_Public_EnumPublicSealedvaAmInPrNiCu6vUnique_0;
            }
            catch (Exception ex)
            {
                MelonLogger.Msg("Exception in Difficulty set(Globals.SetGlobals) EX: " + ex);
            }
            yield return new WaitForSeconds(0.05f);

            CoR = false;
            yield break;
        }
    }
}
