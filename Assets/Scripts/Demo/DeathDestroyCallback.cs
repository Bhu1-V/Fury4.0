using UnityEngine;

namespace Fury.Guns.Demo
{
    public class DeathDestroyCallback : MonoBehaviour
    {
        public void DeathEnd()
        {
            Destroy(gameObject);
        }
    }
}