using System;
using UnityEngine;

[Serializable]
public class CubeData : ScriptableObject
{
	[SerializeField] private int _health = 100;
	[SerializeField] private int _damage = UnityEngine.Random.Range(5, 50);
}
