using System.Numerics;
using UnityEngine;
using UnityEngine.UIElements;
using Quaternion = UnityEngine.Quaternion;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

public class AimedEnemy : Enemy
{
    private GameObject _player;
    private Vector2 _direction;

    private void Start()
    {
        _player = GameObject.FindWithTag("Player");
        if (_player == null)
        {
            Debug.Log("플레이어 태그를 가진 게임 오브젝트를 찾지 못했습니다.");
            return;
        }

        _direction = _player.transform.position - transform.position;
        _direction.Normalize();

        float dx = _direction.x;
        float dy = _direction.y;
        // tanθ = dy / dx
        // tan^ * tanθ = tan^ * dy / dx
        // θ = tan^ * dy / dx
        float seta = Mathf.Atan2(dy, dx);
        float angle = seta * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, angle);

        Rotate();
    }

    protected override void Move()
    {
        // 방향과 속도에 맞게 이동한다.
        //transform.Translate(Vector2.down * _moveSpeed * Time.deltaTime);
        transform.position += (Vector3)_direction * _moveSpeed * Time.deltaTime;
    }

    private void Rotate()
    {
        if (_player == null) return;

        Vector2 direction = _player.transform.position - transform.position;

        float degree = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, degree + 90.0f);
    }
}