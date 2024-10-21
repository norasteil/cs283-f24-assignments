using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public Transform[] points;
    public float duration = 3.0F;
    float timer = 0;

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
        int curr = 0;
        while (curr < points.Length - 1) {
            Transform start = points[curr];
            Transform end = points[curr + 1];

            Vector3 normalizedPos = end.position - start.position;
            transform.rotation = Quaternion.LookRotation(normalizedPos);

            for (float timer = 0; timer < duration; timer += Time.deltaTime)
            {
                float u = timer / duration;
                transform.position = Vector3.Lerp(start.position, end.position, u);
                yield return null;
            }
            curr++;
        }
    }
}
