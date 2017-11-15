using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour {

    private GameObject cameraObject;
    private InputManager inputManager;

    [SerializeField] private float cameraSpeed = 5;
	[SerializeField] private float viewDegree = 90;

    private float cameraRotation = 0;

    /*
     * Initialize the required components components
     */
    void Start(){
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        cameraObject = Camera.main.gameObject;
        //check if the inputmanager is present. If it's not, add it.
        if(!(inputManager = this.GetComponent<InputManager>())){
            inputManager = this.gameObject.AddComponent<InputManager>();
        }
    }

	void Update () {
        //rotate the entire gameobject
        transform.Rotate(0, inputManager.GetXRot()* cameraSpeed, 0);
        //rotate the camera only. 
	    cameraRotation = Mathf.Clamp(cameraRotation + inputManager.GetYRot() * cameraSpeed,
			-viewDegree, viewDegree);
		cameraObject.transform.localEulerAngles =
			new Vector3(cameraRotation, 0, 0);
	}
}
