using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;
using BTAI;

public class WanderBehavior : MonoBehaviour
{
    public Transform wanderRange;  // Set to a sphere
    private float radius = 40.0f;
    private Root m_btRoot = BT.Root();
    private UnityEngine.AI.NavMeshAgent navMesh;

    void Start()
    {
        BTNode moveTo = BT.RunCoroutine(MoveToRandom);

        Sequence sequence = BT.Sequence();
        sequence.OpenBranch(moveTo);

        m_btRoot.OpenBranch(sequence);
    }

    void Update()
    {
        m_btRoot.Tick();
    }

    IEnumerator<BTState> MoveToRandom()
    {
       NavMeshAgent agent = GetComponent<NavMeshAgent>();

    //    Vector3 target;
    //    Utils.RandomPointOnTerrain(
    //       wanderRange.position, wanderRange.localScale.x, out target);
       Vector3 newDest = newPoint();
       agent.SetDestination(newDest);

       // wait for agent to reach destination
       while (agent.remainingDistance > 0.1f)
       {
          yield return BTState.Continue;
       }

       yield return BTState.Success;
    }

    public Vector3 newPoint() 
    {
        Vector3 sourcePos = (Random.insideUnitSphere * radius) + transform.position;
        UnityEngine.AI.NavMeshHit hit;

        if (UnityEngine.AI.NavMesh.SamplePosition(sourcePos, out hit, radius, UnityEngine.AI.NavMesh.AllAreas)) {
            return hit.position;
        }

        return transform.position;
    }
}