using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FSM
{
    public class WalkState : State
    {
        public override void InitState()
        {
            Debug.Log("Init State: Walk  State");
        }

        public override void UpdateState(float delta)
        {

            Debug.Log("Update State: WalkState");
        }

        public override void ExitState()
        {
            Debug.Log("Exit State: WalkState");
        }
    }
}
