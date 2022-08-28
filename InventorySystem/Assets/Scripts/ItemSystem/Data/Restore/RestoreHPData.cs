using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ItemSystem.Data.Restore
{
    [CreateAssetMenu(menuName = "Item/Restore/RestoreHPData")]
    public class RestoreHPData : RestoreData, IHPRestorerData
    {
        [Header("Restore HP")]

        [SerializeField] private float hp;

        public float HP { get => hp; }

        public void RestoreHP()
        {

        }
    }
}
