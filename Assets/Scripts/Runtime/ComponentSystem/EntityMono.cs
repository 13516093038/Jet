using System;
using Core.ComponentSystem;
using UnityEngine;

namespace Runtime.ComponentSystem
{
    public class EntityMono : MonoBehaviour
    {
        /// <summary>
        /// 实体
        /// </summary>
        public Entity Entity { get; protected set; }

        protected void OnDestroy()
        {
            if (Entity != null)
            {
                Entity.Recycle();
            }
        }
    }
}