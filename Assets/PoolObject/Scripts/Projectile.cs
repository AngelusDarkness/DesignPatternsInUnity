using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Projectile : MonoBehaviour {
    
    private Rigidbody _rb;
    private Shooter _parent;
    private readonly WaitForSeconds _disableDelay = new WaitForSeconds(3);
    private Coroutine _disableCoroutine;

    private void Awake() {
        Debug.Log("Projectile Awake");
        _rb = GetComponent<Rigidbody>();
    }

    private void Disable() {
        Debug.Log($"Disabling Projectile {name}");
        transform.parent = _parent.transform;
        transform.position = _parent.transform.position;
        _rb.velocity = Vector3.zero;
        _parent.ReloadProjectile(this);
        gameObject.SetActive(false);
    }

    public void Load(Shooter parent) {
        _parent = parent;
        transform.parent = parent.transform;
        
        gameObject.SetActive(false);
    }
    
    public void Shoot(Vector3 direction) {
        gameObject.SetActive(true);
        transform.parent = null;
        _rb.velocity = direction * 20;

        if (_disableCoroutine == null) {
            StartCoroutine(DisableOverTime());    
        }
        
    }

    private IEnumerator DisableOverTime() {
        yield return _disableDelay;
        Disable();
    }
}
