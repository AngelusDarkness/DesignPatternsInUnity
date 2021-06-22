using System.Collections.Generic;
using UnityEngine;

namespace Events{
    public class GameEvent  { }

    public class SaySomethingEvent : GameEvent 
    {
        public string somethingToSay;
    }

    public class TakeDamageEvent : GameEvent {
        public string whoDidDamage;
        public float damage;
    }
}


