using BoneLib.BoneMenu;
using MelonLoader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace FingerPhysics
{
    public class Bone_Menu_Creator
    {
        private static MelonPreferences_Category category;

        private static MelonPreferences_Entry<bool> modEnabled;
        public static bool ModEnabled => modEnabled.Value;
        public static void OnInitialize()
        {
            category = MelonPreferences.CreateCategory("FingerPhysics");
            modEnabled = category.CreateEntry<bool>("Enabled", true);

            CreateBoneMenu();
        }

        public static void CreateBoneMenu()
        {
            Page page = Page.Root.CreatePage("Finger Physics", Color.white);

            page.CreateBool(
                "Physics Fingers Enabled",
                Color.white,
                modEnabled.Value,
                (b) => { modEnabled.Value = b; MelonPreferences.Save(); });

        }

    }
}
