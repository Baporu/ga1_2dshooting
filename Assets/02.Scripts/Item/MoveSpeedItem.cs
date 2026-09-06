using UnityEngine;

public class MoveSpeedItem : Item
{
    [SerializeField] private float _buffDuration = 5f;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player") == false)
            return;

        PlayerMove playerMove = collider.gameObject.GetComponent<PlayerMove>();
        playerMove.BuffMove(_buffDuration);

        Destroy(gameObject);
    }
}
