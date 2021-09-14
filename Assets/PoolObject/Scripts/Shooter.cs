using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour {
    [SerializeField] private int _projectilesAmount = 10;
    [SerializeField] private GameObject _projectilePrefab;
    
    private readonly Queue<Projectile> _projectiles = new Queue<Projectile>();
    
    private void Start() {
        //Initialize pool of objects.
        for (var i = 0; i < _projectilesAmount; i++) {
            var projectile = InstantiateProjectile();
            _projectiles.Enqueue(projectile);
        }
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            Shoot();
        }
    }

    private void Shoot() {
        Debug.Log($"Shoot at position {transform.position}");

        var projectile = _projectiles.Count > 0 ? _projectiles.Dequeue() : InstantiateProjectile();
        projectile.Shoot(transform.forward);
    }

    public void ReloadProjectile(Projectile projectile) {
        _projectiles.Enqueue(projectile);
    }

    private Projectile InstantiateProjectile() {
        var projectile = Instantiate(_projectilePrefab, transform.position, transform.rotation).GetComponent<Projectile>();
        projectile.Load(this);
        return projectile;
    }
}
