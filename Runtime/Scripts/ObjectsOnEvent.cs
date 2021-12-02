using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Korrel.ObjectOnEventCreator
{
    [System.Serializable]
    public class ObjectsOnEvent
    {
        public string eventIdentifier;
        public List<GameObject> objectsToCreate;
        
    }
}