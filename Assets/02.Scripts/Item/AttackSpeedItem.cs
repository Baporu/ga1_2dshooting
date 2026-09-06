using UnityEngine;

public class AttackSpeedItem : Item
{
    [SerializeField] private float _buffPercent;
    [SerializeField] private float _buffDuration;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player") == false)
            return;

        PlayerFire playerFire = collider.gameObject.GetComponent<PlayerFire>();
        playerFire.BuffFire(_buffPercent / 100, _buffDuration);

        Destroy(gameObject);
    }
}
