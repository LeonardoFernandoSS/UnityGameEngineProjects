using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ItemSystem.Data.Munition
{
    [CreateAssetMenu(menuName = "Item/Munition/ExplosiveMunitionData")]
    public class ExplosiveMunitionData : MunitionData, IMunitionData
    {
        public void ReloadWeapon()
        {
            throw new System.NotImplementedException();
        }
    }
}
