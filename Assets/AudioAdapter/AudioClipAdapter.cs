using UnityEngine;

namespace AudioAdapter {
    public abstract class AudioClipAdapter : ScriptableObject {
        public abstract void Load(GameObject owner);
        public abstract void Play(bool isLoop = false);
        public abstract void Pause();
        public abstract void Stop();
        public abstract void Seek(float position);
        public abstract void SetVolume(float volume);
        public abstract void SetPitch(float pitch);
    
    }
}
