using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tour : MonoBehaviour
{
    public Transform[] points;
    public float speed = 0.5f;
    private int currIdx = 0;
    private bool inTransition = false;
    private Vector3 startPos;
    private Quaternion startRot;
    private float duration = 0.0f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.N) && !inTransition) {
            currIdx = (currIdx + 1) % points.Length;
            startPos = transform.position;
            startRot = transform.rotation;
            duration = 0.0f;
            inTransition = true;
        }

        if (inTransition) {
            duration += Time.deltaTime * speed;
            transform.position = Vector3.Lerp(startPos, points[currIdx].position, duration);
            transform.rotation = Quaternion.Slerp(startRot, points[currIdx].rotation, duration);
            if (duration >= 1.0f) {
                inTransition = false;
            }
        }
    }
}
