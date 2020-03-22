using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FSM
{
    public abstract class FSMCondition: MonoBehaviour
    {
        public abstract bool CheckCondition();

    }
}