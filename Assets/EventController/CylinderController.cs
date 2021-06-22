using System.Collections;
using System.Collections.Generic;
using Events;
using UnityEngine;

public class CylinderController : MonoBehaviour 
{
    [SerializeField] private bool _understood = false;
    [SerializeField] private float _health = 10;
    private void OnEnable() {
        EventController.AddListener<SaySomethingEvent>(OnSaySomethingEvent);
    }

    private void OnDisable() {
        EventController.RemoveListener<SaySomethingEvent>(OnSaySomethingEvent);
    }

    void OnSaySomethingEvent(SaySomethingEvent evt) 
    {
        Debug.Log($"Received Message: {evt.somethingToSay}");
        if (_understood) 
        {
            EventController.RemoveListener<SaySomethingEvent>(OnSaySomethingEvent);
        }
        else {
            EventController.AddListener<TakeDamageEvent>(OnTakeDamageEvent);
        }
        
    }
    
    void OnTakeDamageEvent(TakeDamageEvent evt) 
    {
        Debug.Log($"{name} Ouch!!!  {evt.whoDidDamage} hurt me with {evt.damage}");
        _health -= evt.damage;

        if (_health <= 0) {
            Debug.Log($"{name} Why god why!!!!!  I'm dead");
            EventController.RemoveListener<TakeDamageEvent>(OnTakeDamageEvent);
        }
    }
}
