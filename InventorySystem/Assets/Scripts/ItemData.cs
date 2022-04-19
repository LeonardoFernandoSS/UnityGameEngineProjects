using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ItemSystem
{ 
    [CreateAssetMenu]
    public class ItemData : ScriptableObject
    {
        [SerializeField] public string Name { get; private set; }
        [SerializeField] public float MaxAmount { get; private set; }
    }
}
