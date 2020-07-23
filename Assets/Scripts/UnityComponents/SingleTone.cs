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
        public static float HealthOfCity;   
    }
}
