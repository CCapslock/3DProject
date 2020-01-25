using UnityEngine;

namespace Geekbrains
{
	public class EnemyFlyingSkull : BaseObjectScene
	{
		[SerializeField] private NavMeshAgent _enemyAi;
		[SerializeField] private Transform _playerTransform;
		[SerializeField] private float _calculatedDistance;

		public float KeepDistanceOfPlayer;

		private void Start()
		{
			_playerTransform = GameObject.FindGameObjectWithTag(TagManager.PLAYER).transform;
			_enemyAi = GetComponentInChildren<UnityEngine.AI.NavMeshAgent>();
		}
		private void Update()
		{
			CalculateDistance();
			if (_calculatedDistance <= KeepDistanceOfPlayer)
			{
				_enemyAi.enabled = false;
			}
			else
			{
				_enemyAi.enabled = true;
			}
		}
		private void CalculateDistance()
		{
			_calculatedDistance = Vector3.Distance(transform.position, _playerTransform.position);
		}
	}
}

