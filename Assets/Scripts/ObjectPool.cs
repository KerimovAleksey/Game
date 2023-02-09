using UnityEngine;

public class ObjectPool : MonoBehaviour
{
	/*
    public static ObjectPool instance;

	private List<GameObject> pooledObjects = new List<GameObject>();
	private int amountToPool;

	[SerializeField] private GameObject _cubePrefab;

	private void Awake()
	{
		amountToPool = GameObject.Find("Main Camera").GetComponent<SpawnScript>().NumberOfCubes;
		if (instance == null)
		{
			instance = this;
		}
	}

	private void Start()
	{
		for (int i = 0; i < amountToPool; i++)
		{
			GameObject obj = Instantiate(_cubePrefab);
			obj.SetActive(false);
			pooledObjects.Add(obj);
		}
	}

	public GameObject GetPooledObject()
	{
		for (int i = 0; i < pooledObjects.Count; i++)
		{
			if (!pooledObjects[i].activeInHierarchy)
			{
				return pooledObjects[i];
			}
		}
		return null;
	}
	*/// Попытка сделать pool объектов (см. текстовый файл - "Описание к проекту")
}
