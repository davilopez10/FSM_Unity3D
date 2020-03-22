using FSM;
using System;
using UnityEngine;
using UnityEngine.AI;

public class PatrollerState : FSMState
{
    [SerializeField]
    private Transform[] patrollerPoints;

    [SerializeField]
    private NavMeshAgent navmesh;

    [SerializeField]
    private FSMState stateReachTarget;

    private Transform currentTransform;

    private int currentIndex;


    private int GetNearlyTarget()
    {
        float magnitude = 999;
        int transformIndex = -1;

        for (int i = 0; i < patrollerPoints.Length; i++)
        {
            float currentMagnitude = (patrollerPoints[i].position - agent.transform.position).sqrMagnitude;
            if (currentMagnitude < magnitude)
            {
                magnitude = currentMagnitude;
                transformIndex = i;
            }
        }

        return transformIndex;
    }

    private void NextTarget()
    {
        currentIndex++;

        if (currentIndex >= patrollerPoints.Length)
            currentIndex = 0;

        currentTransform = patrollerPoints[currentIndex];
        navmesh.SetDestination(currentTransform.position);
    }

    public override void OnEnter(FSMAgent agent, Action callback)
    {
        base.OnEnter(agent, callback);

        if (currentTransform == null)
        {
            currentIndex = GetNearlyTarget();
            currentTransform = patrollerPoints[currentIndex];
        }

        navmesh.isStopped = false;
        navmesh.SetDestination(currentTransform.position);
    }

    public override void OnUpdate()
    {
        base.OnUpdate();

        if (currentTransform != null)
        {
            if (navmesh.remainingDistance <= navmesh.stoppingDistance)
            {
                NextTarget();

                if (stateReachTarget != null)
                    agent.ReplaceState(stateReachTarget);
            }
        }
    }

    public override void OnExit()
    {
        base.OnExit();

        navmesh.isStopped=true;
    }
}
