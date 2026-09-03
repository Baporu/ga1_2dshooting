using UnityEngine;

public class EnemyChasingPlayer : EnemyBase
{
    private GameObject _targetPlayer;

    private void Start()
    {
        _targetPlayer = GameObject.FindGameObjectWithTag("Player");
    }

    protected override void Move()
    {
        Vector2 direction = _targetPlayer.transform.position - this.transform.position;
        direction.Normalize();
        transform.Translate(direction * MoveSpeed * Time.deltaTime);
    }
}