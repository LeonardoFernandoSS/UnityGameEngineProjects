using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ItemSystem.Data.Munition
{
    [CreateAssetMenu(menuName = "Item/Munition/FireMunitionData")]
    public class FireMunitionData : MunitionData, IMunitionData
    {
        public void ReloadWeapon()
        {
            throw new System.NotImplementedException();
        }
    }
}
