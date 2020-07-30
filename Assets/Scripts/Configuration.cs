using System;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets
{
    [CreateAssetMenu(menuName = "Configs/Configuration")]
    public class Configuration : ScriptableObject
    {
        public Vector3Int worldStartPos = new Vector3Int(-100, -100, 0);
        public Vector3Int worldEndPos = new Vector3Int(100, 100, 0);
    }
}
