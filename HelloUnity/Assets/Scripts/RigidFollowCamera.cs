using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidFollowCamera : MonoBehaviour
{
    public Transform target;
    private float hDist = 5.5f;
    private float vDist = 1.75f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void LateUpdate() {
        Vector3 tPos = target.position;
        Vector3 tUp = target.up;
        Vector3 tForward = target.forward;

        // Camera position is offset from the target position
        Vector3 eye = tPos - tForward * hDist + tUp * vDist;

        // The direction the camera should point is from the target to the camera position
        Vector3 cameraForward = tPos - eye;

        // Set the camera's position and rotation with the new values
        transform.position = eye;
        transform.rotation = Quaternion.LookRotation(cameraForward);

    }
}
