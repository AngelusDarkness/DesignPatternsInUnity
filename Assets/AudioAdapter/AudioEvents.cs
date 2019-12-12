using System.Collections.Generic;
using Events;
using UnityEngine;

namespace AudioAdapter
{
    public class MuteBGMusicEvent : GameEvent {
        
    }
    
    public class MuteSFXEvent : GameEvent {
        
    }
    
    public class MuteEvent : GameEvent {
        
    }
    
    public class SetMasterVolumeEvent : GameEvent {
        public float volume;
    }
    
    public class FadeInMusicEvent : GameEvent {
        public float duration;
        public float volume;
    }
    

}


