using UnityEngine;

public class SpawnScript : MonoBehaviour
{
    [SerializeField] private GameObject _cube;
    [SerializeField] private int _numberOfCubes = 5;
   

	void Start()
    {
		for (int i = 0; i < _numberOfCubes; i++)
        {
            Vector3 randPos = new Vector3(Random.Range(-19f, 19f), 0.5f, Random.Range(-19f, 19f));
			SpawnCube(randPos);
		}
    }

	private void Update()
	{
		if (Input.GetMouseButtonDown(0))
        {
			Camera cameraComponent = GameObject.Find("Main Camera").GetComponent<Camera>();
			Ray ray = cameraComponent.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100))
            {
                SpawnCube(hit.point);
            }
        }
	}

	private void SpawnCube(Vector3 pos)
    {
        _cube.transform.position = pos;
		Instantiate(_cube);
	}

    
}
