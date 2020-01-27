using System;
using UnityEngine;

namespace Geekbrains
{
	public class Aim : MonoBehaviour, ISetDamage
	{
		[SerializeField] private Renderer _renderer;
		[SerializeField] private EnemyHpUi _enemyHpUi;
		[SerializeField] private bool _isDead;

		public GameObject _deathParticleSystem;
		public float Hp = 100;
		public float TimeOfEnemyUi = (1.5f);



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
				Destroy(gameObject);
				_isDead = true;

			}
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
