using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ItemSystem.Managers
{
    public interface IPlayerStock : ICollectionManager
    {
        static IPlayerStock  Instance { get; set; }
    }
}
