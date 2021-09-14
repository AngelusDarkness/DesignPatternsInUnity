using System.Collections;
using System.Collections.Generic;
using AudioAdapter;
using UnityEngine;

namespace AudioAdapter {


    [CreateAssetMenu(fileName = "WwiseAudioClip", menuName = "AudioAdapter/ Create WWise Clip", order = 2)]
    public class WwiseAudioClip : AudioClipAdapter {
        public override void Load(GameObject owner) {
            Debug.Log("Wwise Load Audio");
        }

        public override void Play(bool isLoop = false) {
            Debug.Log($"Wwise Play Audio {isLoop}");
        }

        public override void Pause() {
            Debug.Log("Wwise Pause Audio");
        }

        public override void Stop() {
            Debug.Log("Wwise Stop Audio");
        }

        public override void Seek(float position) {
            Debug.Log("Wwise Seek Audio");
        }

        public override void SetVolume(float volume) {
            Debug.Log($"Wwise Volume {volume} Audio");
        }

        public override void SetPitch(float pitch) {
            Debug.Log($"Wwise Pitch {pitch} Audio");
        }
    }
}