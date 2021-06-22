using System.Collections;
using System.Collections.Generic;
using Events;
using UnityEngine;

public class SphereController : MonoBehaviour {

    [SerializeField] private float _damageAmount = 2;
    private readonly SaySomethingEvent _saySomethingEvent = new SaySomethingEvent();

    private readonly TakeDamageEvent _takeDamageEvent = new TakeDamageEvent();
    // Start is called before the first frame update
    private IEnumerator Start() 
    {
        _saySomethingEvent.somethingToSay = "Hello Observer Pattern World";
        yield return new WaitForSeconds(2);
        EventController.TriggerEvent(_saySomethingEvent);
        yield return new WaitForSeconds(4);
        _saySomethingEvent.somethingToSay = "How are you class??";
        EventController.TriggerEvent(_saySomethingEvent);
        yield return new WaitForSeconds(6);
        _saySomethingEvent.somethingToSay = "Did you understand me?";
        EventController.TriggerEvent(_saySomethingEvent);
        yield return new WaitForSeconds(6);
        _saySomethingEvent.somethingToSay = "Oooh you didnt? Take this!";
        EventController.TriggerEvent(_saySomethingEvent);
        yield return new WaitForSeconds(1);
        _takeDamageEvent.damage = _damageAmount;
        _takeDamageEvent.whoDidDamage = name;
        EventController.TriggerEvent(_takeDamageEvent);
        yield return new WaitForSeconds(2);
        _saySomethingEvent.somethingToSay = "Die now!!!!!";
        EventController.TriggerEvent(_saySomethingEvent);
        _takeDamageEvent.damage = _damageAmount * 4;
        EventController.TriggerEvent(_takeDamageEvent);
    }

}
