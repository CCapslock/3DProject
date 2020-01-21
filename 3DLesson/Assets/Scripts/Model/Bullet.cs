using UnityEngine;

namespace Geekbrains
{
    public sealed class Bullet : Ammunition
    {
        private void OnCollisionEnter(Collision collision)
        {
            DestroyAmmunition();
        }
    }
}
