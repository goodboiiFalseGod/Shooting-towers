using Leopotam.Ecs;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System.Text;
using System.Threading.Tasks;

namespace Assets.UnityComponents
{
    public static class SingleTone
    {
        public static EcsWorld mainworld;
        public static int objectsCount;
        public static Vector3[] WalkingRoad0;
        public static Vector3[] FlyingRoad0;
        public static float HealthOfCity { get { return hoc; } set { hoc = value; ui.CityHealthVal = (int)value; } }
        public static int Wallet { get { return w; } set { w = value; ui.WalletVal = value; } }
        private static float hoc = 0;
        private static int w = 0;
        
        public static bool IsMouseOccupied = false;
        public static GameObject currentrlyHeld;
        public static UIinit ui;
    }
}
