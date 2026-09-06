using UnityEngine;

public class HealthItem : Item
{
    [SerializeField] private int _healthAmount;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player") == false)
            return;

        Player player = collider.gameObject.GetComponent<Player>();
        player.HealWound(_healthAmount);

        Destroy(gameObject);
    }
}
