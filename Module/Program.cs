using System;
using System.Linq;
using System.Reflection;
using EFT.UI;
using Aki.Common.Utils.Patching;
using UnityEngine;

namespace Spaceman.PrettyUI
{
    public class Program
    {
        static void Main(string[] args)
        {
            Debug.LogError("Spaceman.PrettyUI: Making the screen pretty");
            PatcherUtil.Patch<MenuScreenPatch>();
            Debug.LogError("Spaceman.PrettyUI: Done!");
        }
    }


    public class MenuScreenPatch : GenericPatch<MenuScreenPatch>
    {
        public MenuScreenPatch() : base(postfix: nameof(PatchPostfix))
        {
        }

        protected override MethodBase GetTargetMethod()
        {
            return typeof(MenuScreen).GetMethod("Show", BindingFlags.NonPublic | BindingFlags.Instance);
        }

        public static void PatchPostfix(GameObject ____alphaWarningGameObject)
        {
            ____alphaWarningGameObject.SetActive(false);
        }
    }
}
