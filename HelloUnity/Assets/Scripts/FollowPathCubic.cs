using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPathCubic : MonoBehaviour
{
    public bool DeCasteljau = false;
    public Transform[] positions;
    public float moveSpeed = 20.0f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DoLerp());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            StartCoroutine(DoLerp());
        }
    }

    IEnumerator DoLerp()
    {
        for (int i = 1; i < positions.Length; i++)
        {
            Vector3 b0 = positions[i - 1].position;
            Vector3 b3 = positions[i].position;
            Vector3 b1;
            Vector3 b2;

            if (i == 1)
            {
                b1 = b0 + (1 / 6f) * (b3 - b0);
            }
            else 
            {
                b1 = b0 + (1 / 6f) * (positions[i].position - positions[i - 2].position);
            } 

            if (i == positions.Length - 1)
            {
                b2 = b3 - (1 / 6f) * (b3 - b0);
            }
            else 
            {
                b2 = b3 - (1 / 6f) * (positions[i + 1].position - positions[i - 1].position);
            } 

            float duration = Vector3.Distance(b0, b3) / moveSpeed;
            for (float t = 0; t < 1; t += Time.deltaTime / duration)
            {
                Vector3 position;
                if (DeCasteljau)
                {
                    position = useDeCasteljau(b0, b1, b2, b3, t);
                }
                else
                {
                    position = usePolynomial(b0, b1, b2, b3, t);
                }

                transform.position = position;
                transform.forward = getTangent(b0, b1, b2, b3, t).normalized;

                yield return null;
            }
        }
    }

    private Vector3 usePolynomial(Vector3 b0, Vector3 b1, Vector3 b2, Vector3 b3, float t)
    {
        float u = 1 - t;
        return u * u * u * b0 + 3 * u * u * t * b1 + 3 * u * t * t * b2 + t * t * t * b3;
    }

    private Vector3 useDeCasteljau(Vector3 b0, Vector3 b1, Vector3 b2, Vector3 b3, float t)
    {
        Vector3 p0 = Vector3.Lerp(b0, b1, t);
        Vector3 p1 = Vector3.Lerp(b1, b2, t);
        Vector3 p2 = Vector3.Lerp(b2, b3, t);
        Vector3 p3 = Vector3.Lerp(p0, p1, t);
        Vector3 p4 = Vector3.Lerp(p1, p2, t);

        return Vector3.Lerp(p3, p4, t);
    }

    private Vector3 getTangent(Vector3 b0, Vector3 b1, Vector3 b2, Vector3 b3, float t)
    {
        return -3 * Mathf.Pow(1 - t, 2) * b0 + (3 * Mathf.Pow(1 - t, 2) - 6 * (1 - t) * t) * b1 + (6 * (1 - t) * t - 3 * t * t) * b2 + 3 * t * t * b3;
    }
}
