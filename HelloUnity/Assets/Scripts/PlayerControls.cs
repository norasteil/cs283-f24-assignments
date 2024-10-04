using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    public GameObject character;
    public float moveSpeed = 3.0f;
    public float turnSpeed = 100.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // while key is held, keep moving smoothly
        // if a key is down, change to running animation
        if (Input.GetKey(KeyCode.W)) {
            // forward
            Vector3 fwd = transform.forward;
            transform.position += fwd * moveSpeed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.A)) {
            // turn left
            // transform.position += left * speed * Time.deltaTime;
            transform.Rotate(Vector3.up, -turnSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.S)) {
            // backward
            Vector3 bwd = -transform.forward;
            transform.position += bwd * moveSpeed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.D)) {
            // turn right
            Vector3 right = transform.right;
            transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime);
        }
    }
}
