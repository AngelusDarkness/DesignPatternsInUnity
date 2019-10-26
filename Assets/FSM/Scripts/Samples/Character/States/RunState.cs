using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FSM
{
    public class RunState : State
    {
        public override void InitState()
        {
            Debug.Log("Init State: RunState");
        }

        public override void UpdateState(float delta)
        {
            Debug.Log("Update State: RunState");
        }

        public override void ExitState()
        {
            Debug.Log("Exit State: RunState");
        }
    }
}