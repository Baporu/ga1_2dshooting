using System;
using UnityEngine;

public class EnemyToPlayer : EnemyBase
{
    private Vector3 _targetPosition;

    private void Start()
    {
        GameObject targetPlayer = GameObject.FindGameObjectWithTag("Player");
        _targetPosition = targetPlayer.transform.position;
    }

    protected override void Move()
    {
        Vector2 direction = _targetPosition - this.transform.position;
        direction.Normalize();
        transform.Translate(direction * MoveSpeed * Time.deltaTime);
    }
}