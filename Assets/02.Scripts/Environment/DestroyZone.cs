using UnityEngine;

public class DestroyZone : MonoBehaviour
{
    // 나와 충돌한 다른 게임 오브젝트는 누구든 파괴해버리겠다.
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Bullet")
        {
            Bullet bullet = other.gameObject.GetComponent<Bullet>();
            bullet.gameObject.SetActive(false);

            return;
        }

        Destroy(other.gameObject);
    }
}