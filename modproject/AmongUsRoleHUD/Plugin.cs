using BepInEx;
using BepInEx.Unity.IL2CPP;
using UnityEngine;
using AmongUs.GameOptions;
using System.Collections.Generic;
using Il2CppInterop.Runtime.Injection;

namespace AmongUsRoleHUD
{
    [BepInPlugin("com.yourname.amongusrolehud", "Role HUD", "1.0.0")]
    public class Plugin : BasePlugin
    {
        public override void Load()
        {
            Log.LogInfo("Role HUD plugin loaded!");

            // Inject our HUD MonoBehaviour into the game
            ClassInjector.RegisterTypeInIl2Cpp<RoleHudBehaviour>();
            var hudObject = new GameObject("RoleHudObject");
            hudObject.AddComponent<RoleHudBehaviour>();
            UnityEngine.Object.DontDestroyOnLoad(hudObject);
        }
    }

    public class RoleHudBehaviour : MonoBehaviour
    {
        public RoleHudBehaviour(System.IntPtr ptr) : base(ptr) { }

        private bool hudEnabled = true;

        private void Update()
        {
            // Toggle HUD with F3
            if (Input.GetKeyDown(KeyCode.F3))
            {
                hudEnabled = !hudEnabled;
            }
        }

        private void OnGUI()
        {
            if (!hudEnabled) return;
            if (PlayerControl.AllPlayerControls == null) return;

            var style = new GUIStyle();
            style.fontSize = 14;
            style.normal.textColor = Color.white;

            for (int i = 0; i < PlayerControl.AllPlayerControls.Count; i++)
            {
                var player = PlayerControl.AllPlayerControls[i];
                if (player == null || player.Data == null) continue;

                Vector3 screenPos = Camera.main.WorldToScreenPoint(player.transform.position);
                if (screenPos.z < 0) continue; // behind camera

                bool isImpostor = player.Data.RoleType == RoleTypes.Impostor;
                string status = player.Data.IsDead ? " (dead)" : "";
                string label = player.Data.PlayerName + (isImpostor ? " [IMPOSTOR]" : " [Crew]") + status;
                style.normal.textColor = isImpostor ? Color.red : Color.cyan;

                GUI.Label(new Rect(screenPos.x, Screen.height - screenPos.y, 200, 20), label, style);
            }
        }
    }
}