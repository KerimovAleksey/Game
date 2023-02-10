using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class CubeHunterComponent : MonoBehaviour
{
	public static int CubeCount;
	public int CubeNumber;

	public static List<GameObject> CubeList = new List<GameObject>();
	private GameObject _currentTarget;
	private NavMeshAgent _agent;
	private FightComponent _thisFightComponent;

	private float _attackRate = 1f;

	
	private void OnEnable()
	{
		_agent = GetComponent<NavMeshAgent>();
		_thisFightComponent= GetComponent<FightComponent>();

		CubeCount++; 
		CubeNumber = CubeCount;
		CubeList.Add(gameObject);
	}

	private void Start()
	{
		GetNewTarget();
	}

	private void Update()
	{
		if (CubeList.Count <= CubeCount + 1)
		{

		}
		if (_currentTarget.activeSelf)
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
		if (CubeList.Count > 0)
		{
			_currentTarget = CubeList[Random.Range(0, CubeList.Count)];
			CancelInvoke();
		}
		else
		{
			return;
		}
		if (_currentTarget == gameObject) // Для повторного выбора цели, если объект выбрал сам себя
		{
			Invoke("GetNewTarget", 0.1f);
		}
	}

	
	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject == _currentTarget)
		{
			var enemyObj = _currentTarget;
			_thisFightComponent.GetEnemyObj(enemyObj); // Здесь начало!!!
			if (gameObject.activeSelf)
			{
				StartCoroutine(DealDamage(_thisFightComponent));
			}
		}
	}

	private IEnumerator DealDamage(FightComponent _component)
	{
		if (_component.isActiveAndEnabled)
		{
			_component.DealDamage();
			yield return new WaitForSeconds(_attackRate);
		}
	}


	public Dictionary<int, int> ReturnDictOfCubes()
	{
		
		Dictionary<int, int> dict = new Dictionary<int, int>();

		for (int i = 0; i < CubeList.Count; i++)
		{
			FightComponent objComponent;

			if (CubeList[i] != null && CubeList[i].activeSelf)
			{
				objComponent = CubeList[i].GetComponent<FightComponent>();
				if (!dict.ContainsKey(objComponent.Number))
				{
					dict.Add(objComponent.Number, objComponent.Score);
				} 
			}
		}
		return dict;
	}
}
