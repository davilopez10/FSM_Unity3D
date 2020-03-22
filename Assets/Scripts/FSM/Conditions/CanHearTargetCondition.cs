using FSM;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanHearTargetCondition : FSMCondition
{
    [SerializeField]
    private float detectionDistance = 3f;

    //[SerializeField]
    //private MoveToTargetState moveTargetState;

    public override bool CheckCondition()
    {
        return false;
        //return Vector3.Distance(moveTargetState.navmesh.transform.position, moveTargetState.target.position) < detectionDistance;
    }
}
