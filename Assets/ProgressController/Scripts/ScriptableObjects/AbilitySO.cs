using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AbilitySample", menuName = "Progress Controller/ Create AbilitySample", order = 1)]
public class AbilitySO : ScriptableObject
{
    //Attributes of ability
    //....
    [SerializeField] private int _maxLevel;
    [SerializeField] private int _abilityId;
    [SerializeField] private int _currentLevel;
    
    
    public void Load() {
        _currentLevel = SessionData.Data.abilitiesLevel[_abilityId];
        Debug.Log($"Ability ID: {_abilityId} | Level: {_currentLevel} of {_maxLevel}" );
    }
    
    public void Upgrade() {
        if (_currentLevel + 1 > _maxLevel)
            return;

        _currentLevel++;

        SessionData.Data.abilitiesLevel[_abilityId] = _currentLevel;
        SessionData.SaveData();
    }
}

[Serializable]
public class AbilitySerializable {
    public int currentLevel;
}
