using System;
using UnityEngine;

public abstract class EnemyBase : MonoBehaviour
{
    [SerializeField] private float _health = 100;
    [SerializeField] protected float _moveSpeed = 2;
    [SerializeField] private float _minPositionY = -6;

    private void Update()
    {
        Move();

        if (transform.position.y < _minPositionY)
            Destroy(gameObject);
    }

    protected abstract void Move();

    public void TakeDamage(float damage)
    {
        _health -= damage;

        if (_health <= 0)
        {
            Destroy(gameObject);
        }
    }
}