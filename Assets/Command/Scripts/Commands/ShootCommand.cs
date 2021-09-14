using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CommandPattern {
    
    public class ShootCommand : ICommand {
        public void Prepare(Transform transform) {
            Debug.Log("Prepare a projectile");
        }

        public void Execute() {
            Debug.Log("Shoot a projectile");
        }
    }
}