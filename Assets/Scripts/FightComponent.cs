using System.Collections.Generic;
using UnityEngine;

public class FightComponent : MonoBehaviour
{
	[SerializeField] private CubeData cubeStats;
	[SerializeField] private CanvasInfoComponent _labelInfo;
	[SerializeField] private CubeHunterComponent _cubeNumber;


	private FightComponent _enemyFightComponent;
	private Renderer _matColor;

	public int Number;

	private int _health;
	private int _damage;
	private int maxGetDamageValue = 50;

	public int Score = 0;

	private void Awake()
	{
		
		_matColor= GetComponent<Renderer>();
		_health = cubeStats.Health;
		_damage = cubeStats.Damage;
		_labelInfo.UpdateScore(Score, _damage);
	}
	private void Start()
	{
		Number = _cubeNumber.CubeNumber;
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

		_labelInfo.UpdateHealthBar(_health);
		_matColor.material.color = new Color(0, _health / 100f, 0);

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
		if (_damage <= 48)
		{
			_damage += 2;
		}
		_labelInfo.UpdateScore(Score, _damage);
		
	}

}
