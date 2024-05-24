using System;
using System.Runtime.Serialization;
using UnityEngine;

namespace RockVoyage
{
    [Serializable, DataContract]
    public abstract class HouseInfo
    {
        [field: SerializeField]
        public string Name { get; protected set; }

        [field: SerializeField]
        public MapInfo MapInfo { get; protected set; }

        [field: SerializeField]
        public string SceneName { get; protected set; }

        public virtual void Awake()
        {
            MapInfo.Houses.Add(Name, this);
        }

        public virtual void OnDestroy()
        {
            MapInfo.Houses.Remove(Name);
        }
    }
}