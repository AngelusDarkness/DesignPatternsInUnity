using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AudioAdapter {
    [CreateAssetMenu(fileName = "UnityAudioClip", menuName = "AudioAdapter/ Create UnityAudioClip", order = 1)]
    public class UnityAudioClip : AudioClipAdapter {
        [SerializeField] private AudioClip _audioClip;
        
        private AudioSource _audioSource;

        public override void Load(GameObject owner) {
            _audioSource = owner.AddComponent<AudioSource>();
            _audioSource.clip = _audioClip;
        }
        
        public override void Play(bool isLoop = false) {
            _audioSource.loop = isLoop;
            _audioSource.Play();
        }

        public override void Pause() {
            if (_audioSource.isPlaying) {
                _audioSource.Pause();
            }
        }

        public override void Stop() {
            if (_audioSource.isPlaying) {
                _audioSource.Stop();
            }
        }

        public override void Seek(float position) {
            _audioSource.time = position;
        }

        public override void SetVolume(float volume) {
            _audioSource.volume = volume;
        }

        public override void SetPitch(float pitch) {
            _audioSource.pitch = pitch;
        }
    }
}
