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

    // 트리거 관련 이벤트
    private void OnTriggerEnter2D(Collider2D collider)
    {
        // 충돌한 친구가 Enemy일 때만 죽여보자!
        if (collider.gameObject.CompareTag("Enemy"))
        {
            // GetComponent<타입>() -> 게임 오브젝트가 가지고 있는 컴포넌트를 참조
            EnemyBase enemy = collider.gameObject.GetComponent<EnemyBase>();

            // 디미터의 법칙 적용 (= 최소 지식 원칙 -> 다른 객체의 자료 참조를 줄이고 함수를 이용해 공개 -> 결합도를 낮춤)
            // EnemyBase에 대한 과한 결합을 줄이고 TakeDamage() 함수만 실행시키기 (묻지 말고 시켜라 = Tell, Don't Ask)
            // 이제는 적을 수정할 때 적만 수정하면 깔끔하게 끝남
            enemy.TakeDamage(Damage);

            Destroy(this.gameObject);
        }
    }

    // 충돌 관련 이벤트 (Enter -> Stay -> Exit)
    // 충돌이 시작되면 호출되는 이벤트 함수
    private void OnCollisionEnter2D(Collision2D collision)
    {
        /*
        // 충돌한 친구가 Enemy일 때만 죽여보자!
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // GetComponent<타입>() -> 게임 오브젝트가 가지고 있는 컴포넌트를 참조
            EnemyBase enemy = collision.gameObject.GetComponent<EnemyBase>();


            // 응집도는 높이고, 결합도는 낮춰라
            // 응집도: 데이터(필드)와 그 데이터를 다루는 로직(메서드)은 같은 클래스에
            // 결합도: 다른 클래스에게 계속 묻는 것
            // 나중에 무적 모드가 추가되면? 방어력이 추가되면?
            // -> 적이 수정되면 총알까지 변경해주어야 함
            enemy.Health -= Damage;

            if (enemy.Health <= 0)
            {
                Destroy(enemy.gameObject);
            }


            // 디미터의 법칙 적용 (= 최소 지식 원칙 -> 다른 객체의 자료 참조를 줄이고 함수를 이용해 공개 -> 결합도를 낮춤)
            // EnemyBase에 대한 과한 결합을 줄이고 TakeDamage() 함수만 실행시키기 (묻지 말고 시켜라 = Tell, Don't Ask)
            // 이제는 적을 수정할 때 적만 수정하면 깔끔하게 끝남
            enemy.TakeDamage(Damage);

            Destroy(this.gameObject);
        }
        */
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