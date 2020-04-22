using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityController : MonoBehaviour {
    [SerializeField] private List<AbilitySO> _abilities;

    private void Start() {
        foreach (var ability in _abilities) {
            ability.Load();
        }
    }

    public void SimulateAbilityIncrease(int abilityId) {
        _abilities[abilityId].Upgrade();
    }

    
}
