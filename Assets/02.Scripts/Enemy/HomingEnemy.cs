using UnityEngine;

public class HomingEnemy : Enemy
{
    // 캐싱: 자주 쓸법한 데이터(객체)를 가까운 곳에 저장해두고 쓰는거
    private GameObject _player;

    private void Start()
    {
        _player = GameObject.FindWithTag("Player");
    }

    protected override void Update()
    {
        base.Update();
        Rotate();
    }

    protected override void Move()
    {
        if (_player == null) return;

        transform.Translate(Vector2.down * _moveSpeed * Time.deltaTime);
    }

    private void Rotate()
    {
        if (_player == null) return;

        Vector2 direction = _player.transform.position - transform.position;

        float degree = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, degree + 90.0f);
    }
}