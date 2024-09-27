using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyCamera : MonoBehaviour
{
    public float lookSensitivity = 2.0f;
    public float moveSpeed = 3.0f;
    public float fwdFactor = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        // wasd mvmt
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        move = transform.TransformDirection(move) * moveSpeed * Time.deltaTime;
        transform.position += move;

        // mouse scroll
        Vector3 fwd = Camera.main.transform.forward;
        Camera.main.transform.position += fwd * Input.mouseScrollDelta.y * fwdFactor;

        // mouse rotation
        Vector2 mouseDelta = lookSensitivity * new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        Quaternion rotation = transform.rotation;
        Quaternion horiz = Quaternion.AngleAxis(mouseDelta.x, Vector3.up);
        Quaternion vert = Quaternion.AngleAxis(mouseDelta.y, Vector3.right);
        transform.rotation = vert * rotation * horiz;
    }
}
