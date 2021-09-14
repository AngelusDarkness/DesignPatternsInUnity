using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioServiceConsumer : MonoBehaviour
{
    private void Start() {
        AudioServiceLocator.Instance.GetProvider().Load(gameObject);
    }
    
    public void Play(bool loop) {
        AudioServiceLocator.Instance.GetProvider().Play(loop);
    }
        
    public void Stop() {
        AudioServiceLocator.Instance.GetProvider().Stop();
    }

    public void Seek(float position) {
        AudioServiceLocator.Instance.GetProvider().Seek(position);
    }

    public void SetVolume(float volume) {
        AudioServiceLocator.Instance.GetProvider().SetVolume(volume);
    }
        
    public void SetPitch(float pitch) {
        AudioServiceLocator.Instance.GetProvider().SetPitch(pitch);
    }
}
