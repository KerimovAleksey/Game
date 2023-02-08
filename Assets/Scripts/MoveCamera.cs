using UnityEngine;

public class MoveCamera : MonoBehaviour
{
	public Vector3 MapOrigin = new Vector3(0,0,0);
	public float ZoomSpeed = 0.25F;
	private float ScrollWheelValue = 0;
	void Update()
	{
		if (Input.GetKey(KeyCode.LeftArrow))
		{
			transform.RotateAround(MapOrigin, Vector3.up, 0.5F);
		}
		if (Input.GetKey(KeyCode.RightArrow))
		{
			transform.RotateAround(MapOrigin, Vector3.down, 0.5F);
		}
		if (Input.GetKey(KeyCode.UpArrow))
		{
			transform.RotateAround(MapOrigin, Vector3.right, 0.5F);
		}
		if (Input.GetKey(KeyCode.DownArrow))
		{
			transform.RotateAround(MapOrigin, Vector3.left, 0.5F);
		}
		ScrollWheelValue = -(Input.GetAxis("Mouse ScrollWheel"));
		if (ScrollWheelValue != 0)
		{
			transform.position *= (1F + ScrollWheelValue * ZoomSpeed);

		}
		transform.LookAt(MapOrigin);

	}
}
