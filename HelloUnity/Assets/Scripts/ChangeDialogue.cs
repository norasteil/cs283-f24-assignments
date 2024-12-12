using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChangeDialogue : MonoBehaviour
{
    public TextMeshProUGUI label;
    public float duration = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        duration += Time.deltaTime;

        if (duration >= 15.0f && duration < 20.0f) 
        {
        label.text = "Goat: My town had a bad harvest this season. Can you spare any strawberries for us?";
        }

        if (duration >= 20.0f && duration < 25.0f) 
        {
            label.text = "Sheep: We barely have enough strawberries to last the winter. We have nothing to give you.";
        }

        if (duration >= 25.0f && duration < 30.0f) 
        {
            label.text = "Goat: Would you really rather see my town starve than share some of your fruit?";
        }

        if (duration >= 30.0f && duration < 35.0f) 
        {
            label.text = "Sheep: If I give you any of our strawberries my town might also starve.";
        }

        if (duration >= 35.0f && duration < 45.0f) 
        {
            label.text = "Goat: Then you give me no choice.";
        }

        // he takes the kids and blows up the strawberries (create explosion particle system that leaves strawberries scattered around the world)
        
        // well guardian approaches main character
        if (duration >= 45.0f && duration < 50.0f) 
        {
            label.text = "Sheep: The goat took the children! How can I get them back?";
        }

        if (duration >= 50.0f && duration < 55.0f) 
        {
            label.text = "Elder Sheep: You must find 20 strawberries to give to the goat in exchange.";
        }

        if (duration >= 55.0f && duration < 60.0f) 
        {
            label.text = "Sheep: I'll leave tomorrow morning to search.";
        }

        if (duration > 60.0f)
        {
            label.text = "";
        }
    }
}
