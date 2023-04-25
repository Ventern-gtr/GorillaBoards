using System;
using BepInEx;
using GorillaNetworking;
using UnityEngine;
using UnityEngine.UI;
using Utilla;

namespace GorillaTagModTemplateProject
{
    /// <summary>
    /// This is your mod's main class.
    /// </summary>

    /* This attribute tells Utilla to look for [ModdedGameJoin] and [ModdedGameLeave] */
    [ModdedGamemode]
    [BepInPlugin(PluginInfo.GUID, PluginInfo.Name, PluginInfo.Version)]
    public class Plugin : BaseUnityPlugin
    {
        bool inRoom;
        bool enabled = true;
        private static Color color = UnityEngine.Random.ColorHSV(0f, 1f, 1f, 1f, 1f, 1f);
        private static float timer;
        bool bool1;
        bool bool2;
        bool bool3;
        bool bool4;
        bool bool5;
        bool bool6;

        void Start()
        {
            /* A lot of Gorilla Tag systems will not be set up when start is called /*
			/* Put code in OnGameInitialized to avoid null references */

            Utilla.Events.GameInitialized += OnGameInitialized;
        }

        void OnEnable()
        {
            bool enabled = true;
            HarmonyPatches.ApplyHarmonyPatches();
        }

        void OnDisable()
        {
            bool enabled = false;
            HarmonyPatches.RemoveHarmonyPatches();
        }

        void OnGameInitialized(object sender, EventArgs e)
        {
            /* Code here runs after the game initializes (i.e. GorillaLocomotion.Player.Instance != null) */
        }

        public void OnGUI()
        {
            if (enabled)
            {
                GUI.Box(new Rect(20f, 20f, 180f, 200f), " ");
                GUI.skin.toggle.fontSize = 15;
                GUI.skin.toggle.fontStyle = FontStyle.Bold;
                GUI.color = Color.grey;
                GUI.backgroundColor = Color.black;
                GUI.contentColor = Color.grey;
                if (bool1)
                {
                    GUI.color = Color.red;
                    GUI.contentColor = Color.red;
                    GUI.backgroundColor = Color.red;
                }
                bool1 = GUI.Toggle(new Rect(25f, 25f, 150f, 20f), bool1, "Black & Red");
                GUI.color = Color.grey;
                GUI.backgroundColor = Color.black;
                GUI.contentColor = Color.grey;
                if (bool2)
                {
                    GUI.color = Color.red;
                    GUI.contentColor = Color.red;
                    GUI.backgroundColor = Color.red;
                }
                bool2 = GUI.Toggle(new Rect(25f, 45f, 150f, 20f), bool2, "Black & Green");
                GUI.color = Color.grey;
                GUI.backgroundColor = Color.black;
                GUI.contentColor = Color.grey;
                if (bool3)
                {
                    GUI.color = Color.red;
                    GUI.contentColor = Color.red;
                    GUI.backgroundColor = Color.red;
                }
                bool3 = GUI.Toggle(new Rect(25f, 65f, 150f, 20f), bool3, "Black & White");
                GUI.color = Color.grey;
                GUI.backgroundColor = Color.black;
                GUI.contentColor = Color.grey;
                if (bool4)
                {
                    GUI.color = Color.red;
                    GUI.contentColor = Color.red;
                    GUI.backgroundColor = Color.red;
                }
                bool4 = GUI.Toggle(new Rect(25f, 85f, 150f, 20f), bool4, "White & Black");
                GUI.color = Color.grey;
                GUI.backgroundColor = Color.black;
                GUI.contentColor = Color.grey;
                if (bool5)
                {
                    GUI.color = Color.red;
                    GUI.contentColor = Color.red;
                    GUI.backgroundColor = Color.red;
                }
                bool5 = GUI.Toggle(new Rect(25f, 105f, 150f, 20f), bool5, "Magenta & Black");
                GUI.color = Color.grey;
                GUI.backgroundColor = Color.black;
                GUI.contentColor = Color.grey;
                if (bool6)
                {
                    GUI.color = Color.red;
                    GUI.contentColor = Color.red;
                    GUI.backgroundColor = Color.red;
                }
                bool6 = GUI.Toggle(new Rect(25f, 125f, 150f, 20f), bool6, "RGB Board [Test]");
            }
        }

        void Update()
        {
            if (bool1)
            {
                Plugin.blackred();
                return;
            }
            Plugin.Default();
            if (bool2)
            {
                Plugin.blackLime();
                return;
            }
            Plugin.Default();
            if (bool3)
            {
                Plugin.blackWhite();
                return;
            }
            Plugin.Default();
            if (bool4)
            {
                Plugin.whiteblack();
                return;
            }
            Plugin.Default();
            if (bool5)
            {
                Plugin.magentablack();
                return;
            }
            Plugin.Default();
            if (bool6)
            {
                Plugin.RGB();
                return;
            }
            Plugin.Default();
        }

        public static void Default()
        {
            {
                GameObject.Find("motdtext").GetComponent<Text>().color = Color.white;
                GameObject.Find("motd").GetComponent<Text>().color = Color.white;
                GameObject.Find("COC Text").GetComponent<Text>().color = Color.white;
                GameObject.Find("CodeOfConduct").GetComponent<Text>().color = Color.white;
                GameObject.Find("Current Mode Text").GetComponent<Text>().color = Color.white;
                GameObject.Find("WallScreenForest").GetComponent<Text>().color = Color.white;
                GameObject.Find("WallScreenCave").GetComponent<Text>().color = Color.white;
                GameObject.Find("WallScreenCity Front").GetComponent<Text>().color = Color.white;
                GameObject.Find("WallScreenCanyon").GetComponent<Text>().color = Color.white;
                GameObject.Find("Game Mode Title Text").GetComponent<Text>().color = Color.white;
                GameObject.Find("Game Mode List Text ENABLE FOR BETA").GetComponent<Text>().color = Color.white;
                Text[] componentsInChildren = GameObject.Find("Level/lower level/UI/PhysicalComputer/monitor").GetComponentsInChildren<Text>();
                for (int i = 0; i < componentsInChildren.Length; i++)
                {
                    componentsInChildren[i].color = Color.white;
                }
                GorillaScoreBoard[] array = UnityEngine.Object.FindObjectsOfType<GorillaScoreBoard>();
                for (int i = 0; i < array.Length; i++)
                {
                    Text boardText = array[i].boardText;
                    if (boardText.color != Color.white)
                    {
                        boardText.color = Color.white;
                    }
                }
            }
        }

        public static void RGB()
        {
            if (Time.time > Plugin.timer)
            {
                color = UnityEngine.Random.ColorHSV(0f, 1f, 1f, 1f, 1f, 1f);
                timer = Time.time + 0.3f;
                GameObject gameObject = GameObject.Find("screen");
                gameObject.GetComponent<MeshRenderer>().material = null;
                gameObject.GetComponent<MeshRenderer>().material.color = color;
                GameObject gameObject2 = GameObject.Find("REMOVE board");
                gameObject2.GetComponent<MeshRenderer>().material = null;
                gameObject2.GetComponent<MeshRenderer>().material.color = color;
                GameObject gameObject3 = GameObject.Find("motdscreen");
                gameObject3.GetComponent<MeshRenderer>().material = null;
                gameObject3.GetComponent<MeshRenderer>().material.color = color;
                GameObject gameObject4 = GameObject.Find("wallmonitorforest");
                gameObject4.GetComponent<MeshRenderer>().material = null;
                gameObject4.GetComponent<MeshRenderer>().material.color = color;
                GameObject gameObject5 = GameObject.Find("wallmonitorcave");
                gameObject5.GetComponent<MeshRenderer>().material = null;
                gameObject5.GetComponent<MeshRenderer>().material.color = color;
                GameObject gameObject6 = GameObject.Find("wallmonitorcosmetics");
                gameObject6.GetComponent<MeshRenderer>().material = null;
                gameObject6.GetComponent<MeshRenderer>().material.color = color;
                GameObject gameObject7 = GameObject.Find("wallmonitorcanyon");
                gameObject7.GetComponent<MeshRenderer>().material = null;
                gameObject7.GetComponent<MeshRenderer>().material.color = color;
                GameObject.Find("motdtext").GetComponent<Text>().color = Color.black;
                GameObject.Find("motd").GetComponent<Text>().color = Color.black;
                GameObject.Find("COC Text").GetComponent<Text>().color = Color.black;
                GameObject.Find("CodeOfConduct").GetComponent<Text>().color = Color.black;
                GameObject.Find("Current Mode Text").GetComponent<Text>().color = color;
                GameObject.Find("WallScreenForest").GetComponent<Text>().color = Color.black;
                GameObject.Find("WallScreenCave").GetComponent<Text>().color = Color.black;
                GameObject.Find("WallScreenCity Front").GetComponent<Text>().color = Color.black;
                GameObject.Find("WallScreenCanyon").GetComponent<Text>().color = Color.black;
                GameObject.Find("Game Mode Title Text").GetComponent<Text>().color = color; ;
                GameObject.Find("Game Mode List Text ENABLE FOR BETA").GetComponent<Text>().color = color;
                GorillaComputer instance = GorillaComputer.instance;
                instance.computerScreenRenderer.material = null;
                instance.computerScreenRenderer.material.color = color;
                Text[] componentsInChildren = GameObject.Find("Level/lower level/UI/PhysicalComputer/monitor").GetComponentsInChildren<Text>();
                for (int i = 0; i < componentsInChildren.Length; i++)
                {
                    componentsInChildren[i].color = Color.black;
                }
                GorillaScoreBoard[] array = UnityEngine.Object.FindObjectsOfType<GorillaScoreBoard>();
                for (int i = 0; i < array.Length; i++)
                {
                    Text boardText = array[i].boardText;
                    if (boardText.color != color)
                    {
                        boardText.color = color;
                    }
                }
            }
        }
        public static void blackred()
        {
            {
                GameObject gameObject = GameObject.Find("screen");
                gameObject.GetComponent<MeshRenderer>().material = null;
                gameObject.GetComponent<MeshRenderer>().material.color = Color.black;
                GameObject gameObject2 = GameObject.Find("REMOVE board");
                gameObject2.GetComponent<MeshRenderer>().material = null;
                gameObject2.GetComponent<MeshRenderer>().material.color = Color.black;
                GameObject gameObject3 = GameObject.Find("motdscreen");
                gameObject3.GetComponent<MeshRenderer>().material = null;
                gameObject3.GetComponent<MeshRenderer>().material.color = Color.black;
                GameObject gameObject4 = GameObject.Find("wallmonitorforest");
                gameObject4.GetComponent<MeshRenderer>().material = null;
                gameObject4.GetComponent<MeshRenderer>().material.color = Color.black;
                GameObject gameObject5 = GameObject.Find("wallmonitorcave");
                gameObject5.GetComponent<MeshRenderer>().material = null;
                gameObject5.GetComponent<MeshRenderer>().material.color = Color.black;
                GameObject gameObject6 = GameObject.Find("wallmonitorcosmetics");
                gameObject6.GetComponent<MeshRenderer>().material = null;
                gameObject6.GetComponent<MeshRenderer>().material.color = Color.black;
                GameObject gameObject7 = GameObject.Find("wallmonitorcanyon");
                gameObject7.GetComponent<MeshRenderer>().material = null;
                gameObject7.GetComponent<MeshRenderer>().material.color = Color.black;
                GameObject.Find("motdtext").GetComponent<Text>().color = Color.red;
                GameObject.Find("motd").GetComponent<Text>().color = Color.red;
                GameObject.Find("COC Text").GetComponent<Text>().color = Color.red;
                GameObject.Find("CodeOfConduct").GetComponent<Text>().color = Color.red;
                GameObject.Find("Current Mode Text").GetComponent<Text>().color = Color.red;
                GameObject.Find("WallScreenForest").GetComponent<Text>().color = Color.red;
                GameObject.Find("WallScreenCave").GetComponent<Text>().color = Color.red;
                GameObject.Find("WallScreenCity Front").GetComponent<Text>().color = Color.red;
                GameObject.Find("WallScreenCanyon").GetComponent<Text>().color = Color.red;
                GameObject.Find("Game Mode Title Text").GetComponent<Text>().color = Color.red;
                GameObject.Find("Game Mode List Text ENABLE FOR BETA").GetComponent<Text>().color = Color.red;
                GorillaComputer instance = GorillaComputer.instance;
                instance.computerScreenRenderer.material = null;
                instance.computerScreenRenderer.material.color = Color.black;
                Text[] componentsInChildren = GameObject.Find("Level/lower level/UI/PhysicalComputer/monitor").GetComponentsInChildren<Text>();
                for (int i = 0; i < componentsInChildren.Length; i++)
                {
                    componentsInChildren[i].color = Color.red;
                }
                GorillaScoreBoard[] array = UnityEngine.Object.FindObjectsOfType<GorillaScoreBoard>();
                for (int i = 0; i < array.Length; i++)
                {
                    Text boardText = array[i].boardText;
                    if (boardText.color != Color.red)
                    {
                        boardText.color = Color.red;
                    }
                }
            }
        }

        public static void blackLime()
        {
            {
                GameObject gameObject = GameObject.Find("screen");
                gameObject.GetComponent<MeshRenderer>().material = null;
                gameObject.GetComponent<MeshRenderer>().material.color = Color.black;
                GameObject gameObject2 = GameObject.Find("REMOVE board");
                gameObject2.GetComponent<MeshRenderer>().material = null;
                gameObject2.GetComponent<MeshRenderer>().material.color = Color.black;
                GameObject gameObject3 = GameObject.Find("motdscreen");
                gameObject3.GetComponent<MeshRenderer>().material = null;
                gameObject3.GetComponent<MeshRenderer>().material.color = Color.black;
                GameObject gameObject4 = GameObject.Find("wallmonitorforest");
                gameObject4.GetComponent<MeshRenderer>().material = null;
                gameObject4.GetComponent<MeshRenderer>().material.color = Color.black;
                GameObject gameObject5 = GameObject.Find("wallmonitorcave");
                gameObject5.GetComponent<MeshRenderer>().material = null;
                gameObject5.GetComponent<MeshRenderer>().material.color = Color.black;
                GameObject gameObject6 = GameObject.Find("wallmonitorcosmetics");
                gameObject6.GetComponent<MeshRenderer>().material = null;
                gameObject6.GetComponent<MeshRenderer>().material.color = Color.black;
                GameObject gameObject7 = GameObject.Find("wallmonitorcanyon");
                gameObject7.GetComponent<MeshRenderer>().material = null;
                gameObject7.GetComponent<MeshRenderer>().material.color = Color.black;
                GameObject.Find("motdtext").GetComponent<Text>().color = Color.green;
                GameObject.Find("motd").GetComponent<Text>().color = Color.green;
                GameObject.Find("COC Text").GetComponent<Text>().color = Color.green;
                GameObject.Find("CodeOfConduct").GetComponent<Text>().color = Color.green;
                GameObject.Find("Current Mode Text").GetComponent<Text>().color = Color.green;
                GameObject.Find("WallScreenForest").GetComponent<Text>().color = Color.green;
                GameObject.Find("WallScreenCave").GetComponent<Text>().color = Color.green;
                GameObject.Find("WallScreenCity Front").GetComponent<Text>().color = Color.green;
                GameObject.Find("WallScreenCanyon").GetComponent<Text>().color = Color.green;
                GameObject.Find("Game Mode Title Text").GetComponent<Text>().color = Color.green;
                GameObject.Find("Game Mode List Text ENABLE FOR BETA").GetComponent<Text>().color = Color.green;
                GorillaComputer instance = GorillaComputer.instance;
                instance.computerScreenRenderer.material = null;
                instance.computerScreenRenderer.material.color = Color.black;
                Text[] componentsInChildren = GameObject.Find("Level/lower level/UI/PhysicalComputer/monitor").GetComponentsInChildren<Text>();
                for (int i = 0; i < componentsInChildren.Length; i++)
                {
                    componentsInChildren[i].color = Color.green;
                }
                GorillaScoreBoard[] array = UnityEngine.Object.FindObjectsOfType<GorillaScoreBoard>();
                for (int i = 0; i < array.Length; i++)
                {
                    Text boardText = array[i].boardText;
                    if (boardText.color != Color.green)
                    {
                        boardText.color = Color.green;
                    }
                }
            }
        }

        public static void blackWhite()
        {
            {
                GameObject gameObject = GameObject.Find("screen");
                gameObject.GetComponent<MeshRenderer>().material = null;
                gameObject.GetComponent<MeshRenderer>().material.color = Color.black;
                GameObject gameObject2 = GameObject.Find("REMOVE board");
                gameObject2.GetComponent<MeshRenderer>().material = null;
                gameObject2.GetComponent<MeshRenderer>().material.color = Color.black;
                GameObject gameObject3 = GameObject.Find("motdscreen");
                gameObject3.GetComponent<MeshRenderer>().material = null;
                gameObject3.GetComponent<MeshRenderer>().material.color = Color.black;
                GameObject gameObject4 = GameObject.Find("wallmonitorforest");
                gameObject4.GetComponent<MeshRenderer>().material = null;
                gameObject4.GetComponent<MeshRenderer>().material.color = Color.black;
                GameObject gameObject5 = GameObject.Find("wallmonitorcave");
                gameObject5.GetComponent<MeshRenderer>().material = null;
                gameObject5.GetComponent<MeshRenderer>().material.color = Color.black;
                GameObject gameObject6 = GameObject.Find("wallmonitorcosmetics");
                gameObject6.GetComponent<MeshRenderer>().material = null;
                gameObject6.GetComponent<MeshRenderer>().material.color = Color.black;
                GameObject gameObject7 = GameObject.Find("wallmonitorcanyon");
                gameObject7.GetComponent<MeshRenderer>().material = null;
                gameObject7.GetComponent<MeshRenderer>().material.color = Color.black;
                GameObject.Find("motdtext").GetComponent<Text>().color = Color.white;
                GameObject.Find("motd").GetComponent<Text>().color = Color.white;
                GameObject.Find("COC Text").GetComponent<Text>().color = Color.white;
                GameObject.Find("CodeOfConduct").GetComponent<Text>().color = Color.white;
                GameObject.Find("Current Mode Text").GetComponent<Text>().color = Color.white;
                GameObject.Find("WallScreenForest").GetComponent<Text>().color = Color.white;
                GameObject.Find("WallScreenCave").GetComponent<Text>().color = Color.white;
                GameObject.Find("WallScreenCity Front").GetComponent<Text>().color = Color.white;
                GameObject.Find("WallScreenCanyon").GetComponent<Text>().color = Color.white;
                GameObject.Find("Game Mode Title Text").GetComponent<Text>().color = Color.white;
                GameObject.Find("Game Mode List Text ENABLE FOR BETA").GetComponent<Text>().color = Color.white;
                GorillaComputer instance = GorillaComputer.instance;
                instance.computerScreenRenderer.material = null;
                instance.computerScreenRenderer.material.color = Color.black;
                Text[] componentsInChildren = GameObject.Find("Level/lower level/UI/PhysicalComputer/monitor").GetComponentsInChildren<Text>();
                for (int i = 0; i < componentsInChildren.Length; i++)
                {
                    componentsInChildren[i].color = Color.white;
                }
                GorillaScoreBoard[] array = UnityEngine.Object.FindObjectsOfType<GorillaScoreBoard>();
                for (int i = 0; i < array.Length; i++)
                {
                    Text boardText = array[i].boardText;
                    if (boardText.color != Color.white)
                    {
                        boardText.color = Color.white;
                    }
                }
            }
        }

        public static void whiteblack()
        {
            {
                GameObject gameObject = GameObject.Find("screen");
                gameObject.GetComponent<MeshRenderer>().material = null;
                gameObject.GetComponent<MeshRenderer>().material.color = Color.white;
                GameObject gameObject2 = GameObject.Find("REMOVE board");
                gameObject2.GetComponent<MeshRenderer>().material = null;
                gameObject2.GetComponent<MeshRenderer>().material.color = Color.white;
                GameObject gameObject3 = GameObject.Find("motdscreen");
                gameObject3.GetComponent<MeshRenderer>().material = null;
                gameObject3.GetComponent<MeshRenderer>().material.color = Color.white;
                GameObject gameObject4 = GameObject.Find("wallmonitorforest");
                gameObject4.GetComponent<MeshRenderer>().material = null;
                gameObject4.GetComponent<MeshRenderer>().material.color = Color.white;
                GameObject gameObject5 = GameObject.Find("wallmonitorcave");
                gameObject5.GetComponent<MeshRenderer>().material = null;
                gameObject5.GetComponent<MeshRenderer>().material.color = Color.white;
                GameObject gameObject6 = GameObject.Find("wallmonitorcosmetics");
                gameObject6.GetComponent<MeshRenderer>().material = null;
                gameObject6.GetComponent<MeshRenderer>().material.color = Color.white;
                GameObject gameObject7 = GameObject.Find("wallmonitorcanyon");
                gameObject7.GetComponent<MeshRenderer>().material = null;
                gameObject7.GetComponent<MeshRenderer>().material.color = Color.white;
                GameObject.Find("motdtext").GetComponent<Text>().color = Color.black;
                GameObject.Find("motd").GetComponent<Text>().color = Color.black;
                GameObject.Find("COC Text").GetComponent<Text>().color = Color.black;
                GameObject.Find("CodeOfConduct").GetComponent<Text>().color = Color.black;
                GameObject.Find("Current Mode Text").GetComponent<Text>().color = Color.white;
                GameObject.Find("WallScreenForest").GetComponent<Text>().color = Color.black;
                GameObject.Find("WallScreenCave").GetComponent<Text>().color = Color.black;
                GameObject.Find("WallScreenCity Front").GetComponent<Text>().color = Color.black;
                GameObject.Find("WallScreenCanyon").GetComponent<Text>().color = Color.black;
                GameObject.Find("Game Mode Title Text").GetComponent<Text>().color = Color.white;
                GameObject.Find("Game Mode List Text ENABLE FOR BETA").GetComponent<Text>().color = Color.white;
                GorillaComputer instance = GorillaComputer.instance;
                instance.computerScreenRenderer.material = null;
                instance.computerScreenRenderer.material.color = Color.white;
                Text[] componentsInChildren = GameObject.Find("Level/lower level/UI/PhysicalComputer/monitor").GetComponentsInChildren<Text>();
                for (int i = 0; i < componentsInChildren.Length; i++)
                {
                    componentsInChildren[i].color = Color.black;
                }
                GorillaScoreBoard[] array = UnityEngine.Object.FindObjectsOfType<GorillaScoreBoard>();
                for (int i = 0; i < array.Length; i++)
                {
                    Text boardText = array[i].boardText;
                    if (boardText.color != Color.black)
                    {
                        boardText.color = Color.black;
                    }
                }
            }
        }

        public static void magentablack()
        {
            {
                GameObject gameObject = GameObject.Find("screen");
                gameObject.GetComponent<MeshRenderer>().material = null;
                gameObject.GetComponent<MeshRenderer>().material.color = Color.magenta;
                GameObject gameObject2 = GameObject.Find("REMOVE board");
                gameObject2.GetComponent<MeshRenderer>().material = null;
                gameObject2.GetComponent<MeshRenderer>().material.color = Color.magenta;
                GameObject gameObject3 = GameObject.Find("motdscreen");
                gameObject3.GetComponent<MeshRenderer>().material = null;
                gameObject3.GetComponent<MeshRenderer>().material.color = Color.magenta;
                GameObject gameObject4 = GameObject.Find("wallmonitorforest");
                gameObject4.GetComponent<MeshRenderer>().material = null;
                gameObject4.GetComponent<MeshRenderer>().material.color = Color.magenta;
                GameObject gameObject5 = GameObject.Find("wallmonitorcave");
                gameObject5.GetComponent<MeshRenderer>().material = null;
                gameObject5.GetComponent<MeshRenderer>().material.color = Color.magenta;
                GameObject gameObject6 = GameObject.Find("wallmonitorcosmetics");
                gameObject6.GetComponent<MeshRenderer>().material = null;
                gameObject6.GetComponent<MeshRenderer>().material.color = Color.magenta;
                GameObject gameObject7 = GameObject.Find("wallmonitorcanyon");
                gameObject7.GetComponent<MeshRenderer>().material = null;
                gameObject7.GetComponent<MeshRenderer>().material.color = Color.magenta;
                GameObject.Find("motdtext").GetComponent<Text>().color = Color.black;
                GameObject.Find("motd").GetComponent<Text>().color = Color.black;
                GameObject.Find("COC Text").GetComponent<Text>().color = Color.black;
                GameObject.Find("CodeOfConduct").GetComponent<Text>().color = Color.black;
                GameObject.Find("Current Mode Text").GetComponent<Text>().color = Color.magenta;
                GameObject.Find("WallScreenForest").GetComponent<Text>().color = Color.black;
                GameObject.Find("WallScreenCave").GetComponent<Text>().color = Color.black;
                GameObject.Find("WallScreenCity Front").GetComponent<Text>().color = Color.black;
                GameObject.Find("WallScreenCanyon").GetComponent<Text>().color = Color.black;
                GameObject.Find("Game Mode Title Text").GetComponent<Text>().color = Color.magenta;
                GameObject.Find("Game Mode List Text ENABLE FOR BETA").GetComponent<Text>().color = Color.magenta;
                GorillaComputer instance = GorillaComputer.instance;
                instance.computerScreenRenderer.material = null;
                instance.computerScreenRenderer.material.color = Color.magenta;
                Text[] componentsInChildren = GameObject.Find("Level/lower level/UI/PhysicalComputer/monitor").GetComponentsInChildren<Text>();
                for (int i = 0; i < componentsInChildren.Length; i++)
                {
                    componentsInChildren[i].color = Color.black;
                }
                GorillaScoreBoard[] array = UnityEngine.Object.FindObjectsOfType<GorillaScoreBoard>();
                for (int i = 0; i < array.Length; i++)
                {
                    Text boardText = array[i].boardText;
                    if (boardText.color != Color.magenta)
                    {
                        boardText.color = Color.magenta;
                    }
                }
            }
        }

        /* This attribute tells Utilla to call this method when a modded room is joined */
        [ModdedGamemodeJoin]
        public void OnJoin(string gamemode)
        {
            /* Activate your mod here */
            /* This code will run regardless of if the mod is enabled*/

            inRoom = true;
        }

        /* This attribute tells Utilla to call this method when a modded room is left */
        [ModdedGamemodeLeave]
        public void OnLeave(string gamemode)
        {
            /* Deactivate your mod here */
            /* This code will run regardless of if the mod is enabled*/

            inRoom = false;
        }
    }
}