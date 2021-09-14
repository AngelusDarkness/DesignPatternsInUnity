using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace CommandPattern {

    
    public class PlayerController : MonoBehaviour {
        
        private ICommand _currentCommand;

        private Dictionary<KeyCode, ICommand> _commands = new Dictionary<KeyCode, ICommand>();

        private KeyCode[] _keys;
        // Start is called before the first frame update
        void Start() {
            _commands.Add(KeyCode.A, new JumpCommand());
            _commands.Add(KeyCode.Space, new JumpCommand());
            
            _commands.Add(KeyCode.S, new ShootCommand());
            _commands.Add(KeyCode.L, new ShootCommand());

            _keys = _commands.Keys.ToArray();
        }

        // Update is called once per frame
        void Update() {
            if (Input.anyKeyDown) {
                foreach (var key in _keys) {
                    
                    if (!Input.GetKeyDown(key)) continue;
                    
                    var command = _commands[key];
                    command.Prepare(transform);
                    _currentCommand = command;
                    break;
                }
            }
            
            _currentCommand?.Execute();
        }
        
        
    }
}