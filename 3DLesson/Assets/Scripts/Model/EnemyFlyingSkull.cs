using UnityEngine;
using UnityEngine.AI;

namespace Geekbrains
{
	public sealed class EnemyFlyingSkull : BaseObjectScene
	{
		[SerializeField] private AICharacterControl _enemyAi;
		[SerializeField] private NavMeshAgent _agent;
		[SerializeField] private Transform _playerTransform;
		[SerializeField] private float _calculatedDistance;

		public float KeepDistanceOfPlayer;

		private void Start()
		{
			_playerTransform = GameObject.FindGameObjectWithTag(TagManager.PLAYER).transform;
			_agent = GetComponentInChildren<UnityEngine.AI.NavMeshAgent>();
			_enemyAi = GetComponent<AICharacterControl>();
		}
		private void Update()
		{
			CalculateDistance();
			if (_calculatedDistance <= KeepDistanceOfPlayer)
			{
				_enemyAi.enabled = false;
				_agent.enabled = false;
			}
			else
			{
				_enemyAi.enabled = true;
				_agent.enabled = true;

			}
		}
		private void CalculateDistance()
		{
			_calculatedDistance = Vector3.Distance(transform.position, _playerTransform.position);
		}
	}
}

