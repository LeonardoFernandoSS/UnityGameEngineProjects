using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ItemSystem.Data.Restore
{
    [CreateAssetMenu(menuName = "Item/Restore/RestoreStatusData")]
    public class RestoreStatusData : RestoreData, IStatusRestorerData
    {
        [Header("Restore Status")]

        [SerializeField] private List<string> status;

        public List<string> Status { get => Status; }

        public void RestoreStatus()
        {

        }
    }
}
