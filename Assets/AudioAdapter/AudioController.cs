using System;
using System.Collections;
using System.Collections.Generic;
using Events;
using UnityEngine;

namespace AudioAdapter {
    public class AudioController : MonoBehaviour {
        [SerializeField] private AudioClipAdapter _audioClipAdapter;
        
        private void Start() {
            _audioClipAdapter.Load(gameObject);
        }

        private void OnEnable() {
//            EventController.AddListener<PlayBGMusicEvent>(OnPlayBGMusicEvent);
        }

        private void OnDisable() {
//            EventController.RemoveListener<PlayBGMusicEvent>(OnPlayBGMusicEvent);
        }

        
        
        public void Play(bool loop) {
            _audioClipAdapter.Play(loop);
        }
        
        public void Stop() {
            _audioClipAdapter.Stop();
        }

        public void Seek(float position) {
            _audioClipAdapter.Seek(position);
        }

        public void SetVolume(float volume) {
            _audioClipAdapter.SetVolume(volume);
        }
        
        public void SetPitch(float pitch) {
            _audioClipAdapter.SetPitch(pitch);
        }
        
    } 

}

