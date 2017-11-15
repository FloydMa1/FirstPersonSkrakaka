
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour {

    private InputManager inputManager;
    [SerializeField] private float jumpPower = 250;
    private Rigidbody rigidbody;

    // Use this for initialization
    void Start () {
        rigidbody = GetComponent<Rigidbody>();
        if (!(inputManager = this.GetComponent<InputManager>()))
        {
            inputManager = this.gameObject.AddComponent<InputManager>();
        }
    }

    // Update is called once per frame
    void Update () {
        Vector3 down = transform.TransformDirection(Vector3.down);


        if (inputManager.Jump() && Physics.Raycast(transform.position, down, 2))
        {
            rigidbody.AddForce(transform.up * jumpPower);
            Debug.Log(jumpPower);
        }
    }
}
