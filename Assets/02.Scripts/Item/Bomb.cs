using System;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    [SerializeField] private int _damage = 99999;
    [SerializeField] private float _duration = 3f;
    private float _timer;

    private void Start()
    {
        _timer = _duration;
    }

    private void Update()
    {
        _timer -= Time.deltaTime;

        if (_timer > 0)
            return;

        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Enemy") == false)
            return;

        Enemy enemy = collider.GetComponent<Enemy>();
        enemy.TakeDamage(_damage);
    }
}