using System;
using UnityEngine;

public class AimedEnemy : EnemyBase
{
    private Vector3 _targetPosition;

    private void Start()
    {
        GameObject targetPlayer = GameObject.FindWithTag("Player");
        _targetPosition = targetPlayer.transform.position;
    }

    protected override void Move()
    {
        // 1. 방향을 구한다.
        Vector2 direction = _targetPosition - this.transform.position;
        direction.Normalize();

        // 2. 방향과 속도에 맞게 이동한다.
        transform.Translate(direction * _moveSpeed * Time.deltaTime);
    }
}