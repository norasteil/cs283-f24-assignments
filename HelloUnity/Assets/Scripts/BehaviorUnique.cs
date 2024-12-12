using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehaviorUnique : MonoBehaviour
{
    public Animator animator;
    public string walkForwardAnimation = "walk_forward";
    public string idleAnimation = "idle";
    public Transform character;
    public GameObject npc;
    public Transform house;
    public Transform inside;
    public Transform outside;
    private bool isInside = false;
    private float duration = 4.0f;
    // public NPCDialogueChange changeDialogue;

    // Start is called before the first frame update
    void Start()
    {
        // Debug.Log("npc inside: " + isInside);
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // if (!isInside) 
        // {
        //     changeDialogue.Show();
        // }
        // else 
        // {
        //     changeDialogue.Hide();
        // }

        animator.Play(idleAnimation);
        // Debug.Log("npc vs char " + Vector3.Distance(house.position, character.position));
        if (Vector3.Distance(house.position, character.position) < 15f && isInside == true) 
        {
            // Debug.Log("npc moving outside");
            StartCoroutine(MoveOutside());
        }
        else if (Vector3.Distance(house.position, character.position) > 15f && isInside == false) {
            // Debug.Log("npc moving inside");
            StartCoroutine(MoveInside());
        }
    }

    IEnumerator MoveOutside()
    {
        animator.Play(walkForwardAnimation);
        Vector3 start = inside.position;
        Vector3 end = outside.position;

        Vector3 normalizedPos = (end - start).normalized;
        transform.rotation = Quaternion.LookRotation(normalizedPos);

        for (float timer = 0; timer < duration; timer += Time.deltaTime)
        {
            float u = timer / duration;
            transform.position = Vector3.Lerp(start, end, u);
            yield return null;
        }
        isInside = false;
        // Debug.Log("npc inside: " + isInside);
    }

    IEnumerator MoveInside()
    {
        animator.Play(walkForwardAnimation);
        Vector3 start = outside.position;
        Vector3 end = inside.position;

        Vector3 normalizedPos = (end - start).normalized;
        transform.rotation = Quaternion.LookRotation(normalizedPos);

        for (float timer = 0; timer < duration; timer += Time.deltaTime)
        {
            float u = timer / duration;
            transform.position = Vector3.Lerp(start, end, u);
            yield return null;
        }
        isInside = true;
        // Debug.Log("npc inside: " + isInside);
    }
}
