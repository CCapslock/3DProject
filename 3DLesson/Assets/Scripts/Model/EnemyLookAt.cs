using UnityEngine;

namespace Geekbrains
{
	public class EnemyLookAt: BaseObjectScene
	{
		[SerializeField] private Transform _playerTransform;
		private void Start()
		{
			_playerTransform = GameObject.FindGameObjectWithTag(TagManager.PLAYER).transform;
		}

		private void Update()
		{
			transform.LookAt(_playerTransform);
		}
	}
}
