using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private int _maxHealth = 100;
    private int _health;

    private void Start()
    {
        _health = _maxHealth;
    }

    public void TakeDamage(int damage)
    {
        _health -= damage;
        if (_health <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void HealWound(int healAmount)
    {
        _health += healAmount;
        if (_health > _maxHealth)
        {
            _health = _maxHealth;
        }
    }
}