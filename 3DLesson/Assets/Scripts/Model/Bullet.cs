﻿using UnityEngine;

namespace Geekbrains
{
    public sealed class Bullet : Ammunition
    {
        private void OnCollisionEnter(Collision collision)
        {
			var tempObj = collision.gameObject.GetComponent<ISetDamage>();
			if(tempObj != null)
			{
				tempObj.SetDamage(_curDamage);
			}
			DestroyAmmunition();
        }
    }
}
