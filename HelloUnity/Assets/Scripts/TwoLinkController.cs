using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwoLinkController : MonoBehaviour
{
    public Transform target;
    public Transform endEffector;
    public Transform middleJoint;
    public Transform baseJoint;

    void Update()
    {
        if (target != null && endEffector != null && middleJoint != null && baseJoint != null)
        {
            float upperLimbLength = Vector3.Distance(baseJoint.position, middleJoint.position);
            float lowerLimbLength = Vector3.Distance(middleJoint.position, endEffector.position);
            float targetDistance = Vector3.Distance(baseJoint.position, target.position);

            float totalLimbLength = upperLimbLength + lowerLimbLength;
            if (targetDistance > totalLimbLength)
            {
                Vector3 direction = (target.position - baseJoint.position).normalized;
                target.position = baseJoint.position + direction * totalLimbLength;
            }

            Vector3 baseToTarget = (target.position - baseJoint.position).normalized;
            baseJoint.rotation = Quaternion.LookRotation(baseToTarget);

            float a = upperLimbLength;
            float b = lowerLimbLength;
            float c = targetDistance;

            float cosAngleMiddle = Mathf.Clamp((a * a + b * b - c * c) / (2 * a * b), -1f, 1f);
            float angleMiddle = Mathf.Acos(cosAngleMiddle) * Mathf.Rad2Deg;

            if (!float.IsNaN(angleMiddle))
            {
                middleJoint.localRotation = Quaternion.Euler(angleMiddle - 90f, 0, 0);
            }
            else
            {
                Debug.LogWarning("Invalid rotation angle detected.");
            }

            Debug.DrawLine(baseJoint.position, middleJoint.position, Color.red);
            Debug.DrawLine(middleJoint.position, endEffector.position, Color.blue);
            Debug.DrawLine(endEffector.position, target.position, Color.green);
        }
    }
}
