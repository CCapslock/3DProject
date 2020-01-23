using System;
using UnityEngine;

namespace Geekbrains
{
    public class Aim : MonoBehaviour, ISetDamage
    {
		public GameObject _deathParticleSystem;
		public float Hp = 100;
		public float TimeOfEnemyUi = (1.5f);
		private Renderer _renderer;
		private EnemyHpUi _enemyHpUi;
        private bool _isDead;

		private void Start()
		{
			_enemyHpUi = GetComponentInChildren<EnemyHpUi>();
			_enemyHpUi.SliderMaxValue = Hp;
			OffUi();
		}

		public void SetDamage(float info)
        {
            if (_isDead) return;
            if (Hp > 0)
            {
				OnUi();
				Hp -= info;
				_enemyHpUi.SliderCurrentValue = Hp;
				Invoke("OffUi", TimeOfEnemyUi);
                
            }

            if (Hp <= 0)
            {
				OffUi();
				Instantiate(_deathParticleSystem, transform.position, Quaternion.identity);
				_renderer = GetComponent<Renderer>();
				_renderer.enabled = false;
				Destroy(gameObject, 4);
                _isDead = true;
				
            }
			CustumDebug.Log(Hp);
        }
		 
		private void OnUi()
		{
			_enemyHpUi.SwitchUi(EnemyUiActiveType.On);
		}
		private void OffUi()
		{
			_enemyHpUi.SwitchUi(EnemyUiActiveType.Off);
		}

		public string GetMessage()
        {
            return gameObject.name;
        }
    }
}
