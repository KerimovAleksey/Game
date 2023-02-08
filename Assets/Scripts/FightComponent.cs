using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightComponent : MonoBehaviour
{
	[SerializeField] private int _health;
	[SerializeField] private int _damage;
	[SerializeField] private CubeData cubeStats;

	public int Score = 0;

	private FightComponent _enemyFightComponent;
	private int maxGetDamageValue = 50;

	private void Awake()
	{
		_health = cubeStats.Health;
		_damage = cubeStats.Damage;
	}

	public void DealDamage()
	{
		if (_enemyFightComponent)
		{
			bool killed = _enemyFightComponent.GetDamage(_damage);
			if (killed == true)
			{
				TakeOneScore();
			}
		}
	}

	public bool GetDamage(int damageValue)
	{
		if (damageValue <= maxGetDamageValue)
		{
			_health -= damageValue;
		}
		else
		{
			_health -= maxGetDamageValue;
		}

		if (_health <= 0)
		{
			Destroy(gameObject);
			return true;
		}
		return false;
	}

	public void GetEnemyFightComponent(FightComponent _enemyComponent)
	{
		_enemyFightComponent = _enemyComponent;
	}

	private void TakeOneScore()
	{
		Score++;
		_damage += 2;
		Debug.Log(_damage);
	}
}
