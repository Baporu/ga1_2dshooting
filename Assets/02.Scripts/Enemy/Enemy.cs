using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float MoveSpeed;
    public float MinPositionY;

    private void Update()
    {
        Move();

        if (transform.position.y < MinPositionY)
            Destroy(gameObject);
    }

    private void Move()
    {
        Vector2 direction = Vector2.down; //  new Vector2(0, -1);
        transform.Translate(direction * MoveSpeed * Time.deltaTime);
    }
}