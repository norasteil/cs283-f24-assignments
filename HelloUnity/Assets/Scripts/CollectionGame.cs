using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectionGame : MonoBehaviour
{
    public ChangeText changeText;
    public GameObject strawberry;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnTriggerEnter(Collider other) 
    {
        if (other.CompareTag("Collectable")) 
        {
            Debug.Log("OnTrigger! " + other.name + " " + other.bounds.extents);

            CollectAnimation animation = other.GetComponent<CollectAnimation>();
            StartCoroutine(animation.Collect());

            changeText.Increment();
        }
    }
}
