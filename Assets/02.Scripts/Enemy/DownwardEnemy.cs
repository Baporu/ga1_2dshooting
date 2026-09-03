using UnityEngine;

public class DownwardEnemy : EnemyBase
{
    protected override void Move()
    {
        Vector2 direction = Vector2.down; //  new Vector2(0, -1);
        transform.Translate(direction * _moveSpeed * Time.deltaTime);
    }
}