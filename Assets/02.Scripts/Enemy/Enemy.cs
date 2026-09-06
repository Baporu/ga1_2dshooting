using Unity.Mathematics;
using UnityEngine;


public abstract class Enemy : MonoBehaviour
{
    [SerializeField] private int _health = 100;
    [SerializeField] protected float _moveSpeed;
    [SerializeField] protected int _damage;

    [SerializeField] private Item[] _itemPrefabs;

    private void Update()
    {
        Move();
    }

    protected abstract void Move();


    public void TakeDamage(int damage)
    {
        _health -= damage;
        if (_health <= 0)
        {
            DropItem();
            Destroy(gameObject);
        }
    }

    private void DropItem()
    {
        int randomValue = UnityEngine.Random.Range(0, 100);

        if (randomValue < 30)
        {
            Instantiate(_itemPrefabs[randomValue / 10], transform.position, quaternion.identity);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;

        Player player = other.GetComponent<Player>();
        if (player == null)
        {
            Debug.LogWarning("플레이어가 null입니다.");
            return;
        }

        player.TakeDamage(_damage);

        Destroy(gameObject);
    }
}