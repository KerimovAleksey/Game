using UnityEngine;

public class SpawnScript : MonoBehaviour
{
    [SerializeField] private GameObject _cube;
    [SerializeField] private int _numberOfCubes = 5;

    void Start()
    {
        for (int i = 0; i < _numberOfCubes; i++)
        {
            SpawnCube();
		}
    }

    private void SpawnCube()
    {
		Instantiate(_cube);
	}
}
