using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeHunterComponent : MonoBehaviour
{
	static int CubeCount = 0;
	public int CubeNumber;

	private void Start()
	{
		transform.position = new Vector3(Random.Range(-19f,19f), 0.5f, Random.Range(-19f, 19f));
		CubeCount++;
		CubeNumber = CubeCount;
	}
	private void DealDamage()
	{

	}
}
