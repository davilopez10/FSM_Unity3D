using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FSM
{
    public class FSMAgent : MonoBehaviour
    {
        [SerializeField]
        protected FSMState initState;

        protected Stack<FSMState> currentStates = new Stack<FSMState>();

        protected FSMState currentState;

        protected bool canUpdate;

        public void ReplaceState(FSMState newState)
        {
            canUpdate = false;

            if (currentState != null)
            {
                currentState.OnExit();

                if (currentState.IsBasicState == false)
                    currentStates.Pop();
            }

            if (newState != null)
            {
                currentState = newState;
                currentStates.Push(currentState);
                currentState.OnEnter(this, () => canUpdate = true);
            }
            else
            {
                if (currentStates.Count > 0)
                {
                    currentState = currentStates.Peek();
                    currentState.OnEnter(this, () => canUpdate = true);
                }
                else
                    Debug.Log("States empty");
            }
        }

        protected virtual void Start()
        {
            ReplaceState(initState);

        }

        protected virtual void Update()
        {
            if (canUpdate)
            {
                currentState.OnUpdate();
            }
        }
    }
}

