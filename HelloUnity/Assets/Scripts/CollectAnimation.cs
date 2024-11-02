using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectAnimation : MonoBehaviour
{
    public float duration = 1.0f;
    public float spinSpeed = 700f;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void StartCollect() 
    {
        StartCoroutine(Collect());
    }

    public IEnumerator Collect() {
        float elapsedTime = 0f;
        Vector3 initScale = transform.localScale;

        while(elapsedTime < duration)
        {
            transform.Rotate(Vector3.up, spinSpeed * Time.deltaTime);
            transform.localScale = Vector3.Lerp(initScale, Vector3.zero, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        gameObject.SetActive(false);
    }
}
