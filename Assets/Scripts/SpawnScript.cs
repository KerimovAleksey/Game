using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour
{
    [SerializeField] private GameObject _cube;
    [SerializeField] private int _numberOfCubes = 5;
    //InvokeRepeating("method", delay-time, time-repeating)
    //Instantiate(GameObject)
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < _numberOfCubes; i++)
        {
            Instantiate(_cube);

		}
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
