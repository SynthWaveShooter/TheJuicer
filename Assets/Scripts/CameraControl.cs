using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//https://www.youtube.com/watch?v=Ov9ekwAGhMA

public class CameraControl : MonoBehaviour
{
    public enum RotationAxis
	{
		MouseX = 1,
		MouseY = 2
	}

	public RotationAxis axes = RotationAxis.MouseX;

	public float minimumVert = -45.0f;
	public float maximumVert = 45.0f;

	public float sensHorizontal = 10.0f;
	public float sensVertical = 10.0f;

	public Camera FirstPersonCam, ThirdPersonCam;
	public GameObject Pistol, Automatic, cross1, cross2;
	public bool camSwitch = false;
	public bool gunSwitch = false;
	public bool crossSwitch = false;

	public float rotationX = 0;

    void Update()
    {
        Aim();
		if (Input.GetKeyDown("1"))
		{
			gunSwitch = !gunSwitch;
			Automatic.SetActive(gunSwitch);
			Pistol.SetActive(!gunSwitch);
			crossSwitch = !crossSwitch;
			cross2.SetActive(crossSwitch);
			cross1.SetActive(!crossSwitch);
		}
		if (Input.GetKeyDown("9"))
		{
			camSwitch = !camSwitch;
			FirstPersonCam.gameObject.SetActive(camSwitch);
			ThirdPersonCam.gameObject.SetActive(!camSwitch);
		}
	}

    void Aim()
    {
        if (axes == RotationAxis.MouseX)
        {
            transform.Rotate(0, Input.GetAxis("Mouse X") * sensHorizontal, 0);

        }
        else if (axes == RotationAxis.MouseY)
        {
            rotationX -= Input.GetAxis("Mouse Y") * sensVertical;
            rotationX = Mathf.Clamp(rotationX, minimumVert, maximumVert);

            float rotationY = transform.localEulerAngles.y;

            transform.localEulerAngles = new Vector3(rotationX, rotationY, 0);
        }
    }
}
