using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChangeText : MonoBehaviour
{
    public TextMeshProUGUI label;
    public int count = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        label.text = count.ToString();

        if (count >= 20) 
        {
            label.text = "You defeated the goat!";
        }
    }

    public void Increment() 
    {
        count++;
    }

    public void Decrement() 
    {
        count--;
    }
}
