using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ItemSystem.Data.Restore
{
    [CreateAssetMenu(menuName = "Item/Restore/RestoreMPData")]
    public class RestoreMPData : RestoreData, IMPRestorerData
    {
        [Header("Restore MP")]

        [SerializeField] private float mp;

        public float MP { get => mp; }

        public void RestoreMP()
        {

        }
    }
}
