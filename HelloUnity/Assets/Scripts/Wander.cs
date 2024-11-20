using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wander : MonoBehaviour
{
    public float radius = 20.0f;
    public float moveSpeed = 3.0f;
    private UnityEngine.AI.NavMeshAgent navMesh;

    // Start is called before the first frame update
    void Start()
    {
        navMesh = GetComponent<UnityEngine.AI.NavMeshAgent>();
        navMesh.speed = moveSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if (navMesh.remainingDistance < 0.4f) 
        {
            Vector3 newDest = newPoint();
            navMesh.SetDestination(newDest);
        }
    }

    public Vector3 newPoint() 
    {
        // get a random point
        Vector3 sourcePos = (Random.insideUnitSphere * radius) + transform.position;
        UnityEngine.AI.NavMeshHit hit;

        // find the closest point to the random point that is inside the navMesh and wander radius
        if (UnityEngine.AI.NavMesh.SamplePosition(sourcePos, out hit, radius, UnityEngine.AI.NavMesh.AllAreas)) 
        {
            return hit.position;
        }

        return transform.position;
    }
}
