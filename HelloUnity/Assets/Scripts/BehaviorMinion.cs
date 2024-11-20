using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehaviorMinion : MonoBehaviour
{
    public Animator animator;
    public string walkForwardAnimation = "walk_forward";
    public float attackRange = 10.0f;
    private bool isFollowing = false;
    public bool isHome = false;
    public Transform character;
    public Transform enemy;
    private float duration = 10.0f;

    private float followHDist = 4.0f;
    private float velocity = 2.5f;
    private Vector3 actualPosition;

    // Start is called before the first frame update
    void Start()
    {
        actualPosition = enemy.position;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isHome && isFollowing) 
        {
            // character is home and being followed (stop following)
            isFollowing = false;
            isHome = true;
            StartCoroutine(DoLerp());
        }

        if (isFollowing && !isHome)
        {
            // character is being followed, not home (keep following)
            Follow();
        }

        if (!isHome && !isFollowing)
        {
            // character is not home and is not being followed (checking if character in follow range)
            if (Vector3.Distance(character.position, enemy.position) < 10.0f)
            {
                isFollowing = true;
                Follow();
            }
        }
    }

    void Follow()
    {
        animator.Play(walkForwardAnimation);
        enemy.LookAt(character);

        if (Vector3.Distance(character.position, enemy.position) > followHDist)
        {
            enemy.position += enemy.forward * velocity * Time.deltaTime;
        }
    }

    IEnumerator DoLerp()
    {
        animator.Play(walkForwardAnimation);
        Vector3 start = enemy.position;
        Vector3 end = actualPosition;

        Vector3 normalizedPos = (end - start).normalized;
        transform.rotation = Quaternion.LookRotation(normalizedPos);

        for (float timer = 0; timer < duration; timer += Time.deltaTime)
        {
            float u = timer / duration;
            transform.position = Vector3.Lerp(start, end, u);
            yield return null;
        }
    }
}
