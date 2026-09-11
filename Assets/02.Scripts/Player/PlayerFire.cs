using System;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    // 목표: 스페이스바를 누를 때마다 총알을 생성해서 발사하고 싶다.
    // 필요 속성
    // - 총알 프리팹
    public GameObject BulletPrefab;

    // - 생성 위치(총구)
    public Transform LeftFirePoint;
    public Transform RightFirePoint;
    public Transform SubLeftFirePoint;
    public Transform SubRightFirePoint;

    // - 쿨타이머
    private const float MinCoolTime = 0.06f;
    public float CoolTime = 0.5f;
    private float _fireRate = 0.5f;
    public float FireRate => _fireRate;
    private float _coolTimer = 0;

    private bool _isBuffed = false;
    private float _buffTimer = 0;

    // - 오토 모드
    public bool AutoFireMode = false;

    private void Start()
    {
        _fireRate = CoolTime;
        _coolTimer = _fireRate;
    }


    private void Update()
    {
        // 오토 공격 모드 토글
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            AutoFireMode = !AutoFireMode;
        }

        if (_isBuffed)
        {
            _buffTimer -= Time.deltaTime;
            if (_buffTimer <= 0)
            {
                _isBuffed = false;
                _fireRate = CoolTime;
            }
        }

        // 0. 쿨타이머 감소
        _coolTimer -= Time.deltaTime;

        // 1. 쿨타이머가 0초 이하이고 && (스페이스바를 누르거나 || 오토 모드라면)
        if (_coolTimer <= 0 && (Input.GetKeyDown(KeyCode.Space) || AutoFireMode))
        {
            // 2. 발사
            Fire();

            // 3. 쿨타이머 초기화
            _coolTimer = _fireRate;
        }
    }

    public void BuffFire(float amount, float duration)
    {
        if (_isBuffed)
            return;

        _isBuffed = true;
        _buffTimer = duration;
        _fireRate /= 1 + amount;
    }

    private void Fire()
    {
        // 2. 총알 프리팹을 생성한다.
        // Instantiate는 프리팹을 복사해서 (Monobehaviour를 상속받는)게임 오브젝트를 생성하고 씬에 넣어주는 기능
        Bullet leftBullet = BulletPool.Instance.GetBullet(BulletType.Main);
        leftBullet.transform.position = LeftFirePoint.position; // 생성한 총알의 위치를 총구의 위치로

        Bullet rightBullet = BulletPool.Instance.GetBullet(BulletType.Main);
        rightBullet.transform.position = RightFirePoint.position; // 생성한 총알의 위치를 총구의 위치로

        Bullet subLeftBullet = BulletPool.Instance.GetBullet(BulletType.Sub);
        subLeftBullet.transform.position = SubLeftFirePoint.position; // 생성한 총알의 위치를 총구의 위치로

        Bullet subRightBullet = BulletPool.Instance.GetBullet(BulletType.Sub);
        subRightBullet.transform.position = SubRightFirePoint.position; // 생성한 총알의 위치를 총구의 위치로

        AudioManager.Instance.PlaySFX(AudioType.BULLET);
    }

    public void FireRateUp(float upValue)
    {
        if (upValue < 0)
        {
            Debug.LogWarning("공격 속도 증가량은 0보다 작을 수 없습니다.");
            return;
        }

        // 최고 속도 제한
        CoolTime = Math.Max(CoolTime - upValue, MinCoolTime);
    }
}