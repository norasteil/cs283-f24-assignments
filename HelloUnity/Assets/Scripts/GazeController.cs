using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GazeController : MonoBehaviour
{
    public Transform target;
    public Transform head;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 r = -(target.position - head.position);  
        Vector3 e = head.forward;                    

        Vector3 cross = Vector3.Cross(r, e);
        float dot = Vector3.Dot(r, e);

        float phi = Mathf.Atan2(cross.magnitude, Vector3.Dot(r, r) + dot) * Mathf.Rad2Deg;

        Vector3 axis = cross.normalized;
        Quaternion computedRot = Quaternion.AngleAxis(phi, axis);

        head.parent.rotation = computedRot * head.parent.rotation;

        Debug.DrawLine(head.position, target.position, Color.red);
    }
}
