using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringFollowCamera : MonoBehaviour
{
    public Transform target;
    public float hDist = 5.5f;
    public float vDist = 1.75f;
    public float dampConstant = 1.0f;
    public float springConstant = 1.5f;
    private Vector3 velocity;
    private Vector3 actualPosition;

    // Start is called before the first frame update
    void Start()
    {
        velocity = Vector3.zero;
        actualPosition = transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 tPos = target.position;
        Vector3 tUp = target.up;
        Vector3 tForward = target.forward;

        // Camera position is offset from the target position
        Vector3 idealEye = tPos - tForward * hDist + tUp * vDist;

        // The direction the camera should point is from the target to the camera position
        Vector3 cameraForward = tPos - actualPosition;

        // Compute the acceleration of the spring, and then integrate
        Vector3 displacement = actualPosition - idealEye;
        Vector3 springAccel = (-springConstant * displacement) - (dampConstant * velocity);

        // Update the camera's velocity based on the spring acceleration
        velocity += springAccel * Time.deltaTime;
        actualPosition += velocity * Time.deltaTime;

        // Set the camera's position and rotation with the new values
        transform.position = actualPosition;
        transform.rotation = Quaternion.LookRotation(cameraForward);
    }
}
