using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class CubeHunterComponent : MonoBehaviour
{
	
	static int CubeCount = 0;

	public static List<GameObject> CubeList = new List<GameObject>();
	
	public int CubeNumber;

	private GameObject _currentTarget;
	private NavMeshAgent _agent;
	private FightComponent _thisFightComponent;

	private float _delayAttack = 0.1f;
	private float _timeRepeatAttack = 2f;
	

	private void Awake()
	{
		_agent = GetComponent<NavMeshAgent>();
		_thisFightComponent= GetComponent<FightComponent>();

		CubeList.Add(gameObject);
		CubeCount++;
		CubeNumber = CubeCount;
	}

	private void Start()
	{
		GetNewTarget();
	}

	private void Update()
	{
		if (_currentTarget)
		{
			_agent.SetDestination(_currentTarget.transform.position);
		}
		else
		{
			GetNewTarget();
		}
		
	}



	private void GetNewTarget()
	{
		_currentTarget = CubeList[Random.Range(0, CubeList.Count)];
		if (_currentTarget == gameObject) // Для повторного выбора цели, если объект выбрал сам себя
		{
			Invoke("GetNewTarget", 0.1f);
		}
	}

	
	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject == _currentTarget)
		{
			var objStats = _currentTarget.GetComponent<FightComponent>();
			_thisFightComponent.GetEnemyFightComponent(objStats);

			_thisFightComponent.InvokeRepeating("DealDamage", _delayAttack, _timeRepeatAttack);
		}
	}
	private void OnCollisionExit(Collision collision)
	{
		if (collision.gameObject == _currentTarget)
		{
			CancelInvoke();
		}
	}

	public Dictionary<int, int> ReturnDictOfCubes()
	{
		
		Dictionary<int, int> dict = new Dictionary<int, int>();

		for (int i = 0; i < CubeList.Count; i++)
		{
			FightComponent objComponent;

			if (CubeList[i] != null)
			{
				objComponent = CubeList[i].GetComponent<FightComponent>();
				dict.Add(objComponent.Number, objComponent.Score);
			}
		}
		return dict;
	}

}
