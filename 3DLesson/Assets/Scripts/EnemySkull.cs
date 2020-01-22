using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySkull : MonoBehaviour
{
	private Transform _playerTransform;
	private void Start()
	{
		_playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
	}

	private void Update()
	{
		transform.LookAt(_playerTransform);
	}
}
