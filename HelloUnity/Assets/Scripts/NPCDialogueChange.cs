using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NPCDialogueChange : MonoBehaviour
{
    public TextMeshProUGUI label;
    public GameObject dialogue;
    // private bool visible = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    
    public void Show() 
    {
        dialogue.SetActive(true);
        label.text = "Villager: Hello!\n(Y): Greet Villager (N): Ignore Villager";
    }

    public void Hide() 
    {
        dialogue.SetActive(false);
    }
}
