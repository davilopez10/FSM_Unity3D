using UnityEngine;
using System.Collections.Generic;
using System;

namespace FSM
{
    public class FSMState : MonoBehaviour
    {
        [Serializable]
        protected struct KeyValueStringFSMCondition
        {
            public FSMCondition condition;
            public FSMState toState;
        }

        [SerializeField]
        protected List<KeyValueStringFSMCondition> conditions;

        [SerializeField]
        private bool isBasicState;

        protected FSMAgent agent;

        public bool IsBasicState { get => isBasicState; }

        public virtual void OnEnter(FSMAgent agent, Action callback)
        {
            this.agent = agent;

            callback?.Invoke();
        }

        public virtual void OnUpdate()
        {
            for (int i = 0; i < conditions.Count; i++)
            {
                if (conditions[i].condition.CheckCondition())
                {
                    agent.ReplaceState(conditions[i].toState);
                    return;
                }
            }
        }

        public virtual void OnExit()
        {

        }

    }
}
