using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State {
    public abstract void InitState();

    public abstract void UpdateState(float delta);

    public abstract void ExitState();

    
}
