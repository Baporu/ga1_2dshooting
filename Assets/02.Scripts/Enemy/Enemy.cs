using UnityEngine;

public class Enemy : EnemyBase
{
    protected override void Move()
    {
        Vector2 direction = Vector2.down; //  new Vector2(0, -1);
        transform.Translate(direction * MoveSpeed * Time.deltaTime);
    }
}