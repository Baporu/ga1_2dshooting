using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float Speed;
    public float MinPositionY;

    private void Start()
    {
    }

    private void Update()
    {
        Move();

        if (transform.position.y < MinPositionY)
            Destroy(gameObject);
    }

    private void Move()
    {
        Vector2 direction = Vector2.down; //  new Vector2(0, -1);
        transform.Translate(direction * Speed * Time.deltaTime);
    }
}