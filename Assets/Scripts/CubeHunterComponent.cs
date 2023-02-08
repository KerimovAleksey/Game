using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CubeHunterComponent : MonoBehaviour
{
	static int CubeCount = 0;
	static List<GameObject> CubeList = new List<GameObject>();

	public int CubeNumber;

	private GameObject _currentTarget;
	private NavMeshAgent _agent;

	private float _delayAttack = 0.1f;
	private float _timeRepeatAttack = 2f;
	

	private void Awake()
	{
		_agent = GetComponent<NavMeshAgent>();
	}

	private void Start()
	{
		CubeList.Add(gameObject);
		transform.position = new Vector3(Random.Range(-19f,19f), 0.5f, Random.Range(-19f, 19f)); // Задаём случайную позицию появления куба-охотника
		CubeCount++;
		CubeNumber = CubeCount;

		GetNewTarget();
	}

	private void Update()
	{
		_agent.SetDestination(_currentTarget.transform.position);
	}


	private void DealDamage()
	{
		Debug.Log("Attack!");

	}

	private void GetNewTarget()
	{
		_currentTarget = CubeList[Random.Range(0, CubeCount - 1)];
		
	}



	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject == _currentTarget)
		{
			InvokeRepeating("DealDamage", _delayAttack, _timeRepeatAttack);
		}
	}
	private void OnCollisionExit(Collision collision)
	{
		if (collision.gameObject == _currentTarget)
		{
			CancelInvoke("DealDamage");
		}
	}
}
