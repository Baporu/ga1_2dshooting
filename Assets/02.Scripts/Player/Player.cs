using UnityEngine;

public class Player : MonoBehaviour
{
    // 캡슐화
    // - 데이터 은닉
    // - 메서드를 통한 상태 변경
    [SerializeField] private int _health = 100;
    public int Health => _health;

    [SerializeField] private GameObject _deathEffectPrefab;

    // 잘 설계된 클래스는
    // - 필드 (인스턴스 변수)
    // - 필드에 잘못된 값이 할당되지 않게 막고, 정상적으로 동작하는 메서드

    // Getter/Setter: 특정 데이터를 get/set 해주는 메서드
    /*public void SetHealth(int value)
    {
        _health = value;
    }
    public int GetHealth()
    {
        return _health;
    }*/

    public void TakeDamage(int damage)
    {
        if (damage < 0)
        {
            Debug.LogWarning("대미지는 음수일 수 없습니다.");
            return;
        }

        _health -= damage;
        
        if (_health <= 0)
        {
            Instantiate(_deathEffectPrefab, transform.position, Quaternion.identity);
            AudioManager.Instance.PlaySFX(AudioType.PLAYER_DEATH);

            Destroy(gameObject);
        }

        else
        {
            AudioManager.Instance.PlaySFX(AudioType.PLAYER_HIT);
        }
    }

    public void Heal(int healAmount)
    {
        if (healAmount < 0)
        {
            Debug.LogWarning("힐량은 음수일 수 없습니다.");
            return;
        }

        _health += healAmount;
    }
}