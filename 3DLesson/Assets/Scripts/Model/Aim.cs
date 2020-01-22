using System;
using UnityEngine;

namespace Geekbrains
{
    public sealed class Aim : MonoBehaviour, ISetDamage
    {
        public event Action OnPointChange;
		
        public float Hp = 100;
        private bool _isDead;
        //todo дописать поглащение урона
        public void SetDamage(float info)
        {
            if (_isDead) return;
            if (Hp > 0)
            {
                Hp -= info;
            }

            if (Hp <= 0)
            {
                Destroy(gameObject);

                OnPointChange?.Invoke();
                _isDead = true;
            }
			CustumDebug.Log(Hp);
        }

        public string GetMessage()
        {
            return gameObject.name;
        }
    }
}
