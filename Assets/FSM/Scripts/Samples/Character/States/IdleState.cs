using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class IdleState : State
{
    public override void InitState() {
        Debug.Log("Init State: IdleState");
    }

    public override void UpdateState(float delta) {
        Debug.Log("Update State: IdleState");
    }

    public override void ExitState() {
        Debug.Log("Exit State: IdleState");
    }

    
}
