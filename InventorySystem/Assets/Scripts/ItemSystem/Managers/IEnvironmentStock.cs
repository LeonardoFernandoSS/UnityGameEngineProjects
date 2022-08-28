using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ItemSystem.Managers
{
    public interface IEnvironmentStock : ICollectionManager
    {
        static IEnvironmentStock Instance { get; set; }
    }
}

