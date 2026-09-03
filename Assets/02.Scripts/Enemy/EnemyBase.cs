using UnityEngine;

public abstract class EnemyBase : MonoBehaviour
{
    public float Health = 100;

    public float MoveSpeed;
    public float MinPositionY;

    private void Update()
    {
        Move();

        if (transform.position.y < MinPositionY)
            Destroy(gameObject);
    }

    protected abstract void Move();
}