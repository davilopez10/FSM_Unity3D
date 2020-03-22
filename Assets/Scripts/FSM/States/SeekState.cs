using System;
using UnityEngine;
using FSM;

public class SeekState : FSMState
{
    [SerializeField]
    private float seekTime = 5f;

    [SerializeField]
    private Vector3 rotationAxis;

    [SerializeField]
    private float rotationSpeed = 90;

    private float current;

    public override void OnEnter(FSMAgent agent, Action callback)
    {
        base.OnEnter(agent, callback);
    }

    public override void OnUpdate()
    {
        base.OnUpdate();

        current += Time.deltaTime;

        if(current> seekTime)
        {
            agent.ReplaceState(null);
            return;
        }

        agent.transform.Rotate(rotationAxis * rotationSpeed * Time.deltaTime);
    }

    public override void OnExit()
    {
        base.OnExit();
        current = 0;
    }
}
