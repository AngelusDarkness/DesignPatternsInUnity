using System.Collections.Generic;
using UnityEngine;

namespace Events{
    public class GameEvent  { }


    public class SpeedChangeEvent : GameEvent
    {
        public float speed = 0;
    }
    
    public class JumpEvent : GameEvent { }
    
}


