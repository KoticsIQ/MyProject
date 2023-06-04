using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
	public float SentivityMouse;
	private float MouseX;
	private float MouseY;
	public Transform Player;
    // Start is called before the first frame update
    void Start()
    {
		Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
		MouseX = Input.GetAxis("Mouse X") * SentivityMouse * Time.deltaTime;
		MouseY = Input.GetAxis("Mouse Y") * SentivityMouse * Time.deltaTime;
		Player.Rotate(MouseX * new Vector3(0,1,0));
		transform.Rotate(-MouseY * new Vector3(1,0,0));
    }
}
