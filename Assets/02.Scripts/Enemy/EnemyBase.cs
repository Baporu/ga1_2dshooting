using System;
using UnityEngine;

public abstract class EnemyBase : MonoBehaviour
{
    public float Health = 100;

    public float MoveSpeed;
    public float MinPositionY;

    private void Update()
    {
        Move();

        if (transform.position.y < MinPositionY)
            Destroy(gameObject);
    }

    protected abstract void Move();

    public void TakeDamage(float damage)
    {
        Health -= damage;

        if (Health <= 0)
        {
            Destroy(gameObject);
        }
    }
}