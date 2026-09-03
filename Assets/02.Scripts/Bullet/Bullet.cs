using System;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // 목적: 총알을 위로 움직이고 싶다.
    public float MoveSpeed;

    public float Damage;

    private void Update()
    {
        Vector2 direction = Vector2.up; //  new Vector2(0, 1);
        transform.Translate(direction * MoveSpeed * Time.deltaTime);
    }

    // 충돌 관련 이벤트 (Enter -> Stay -> Exit)
    // 충돌이 시작되면 호출되는 이벤트 함수
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("충돌했다!");

        // 충돌한 친구가 Enemy일 때만 죽여보자!
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // GetComponent<타입>() -> 게임 오브젝트가 가지고 있는 컴포넌트를 참조
            EnemyBase enemy = collision.gameObject.GetComponent<EnemyBase>();

            enemy.Health -= Damage;

            if (enemy.Health <= 0)
            {
                Destroy(collision.gameObject);
            }

            Destroy(this.gameObject);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        //Debug.Log("충돌 중이다!");
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        //Debug.Log("충돌 끝났다!");
    }
}