using System;
using UnityEngine;

public class PlayerBomb : MonoBehaviour
{
    // 폭탄 프리팹
    [SerializeField] private GameObject _bombPrefab;
    [SerializeField] private float _coolTime = 10f;
    private float _coolTimer;

    private void Start()
    {
        _coolTimer = 0f;
    }

    private void Update()
    {
        if (_coolTimer > 0)
        {
            _coolTimer -= Time.deltaTime;
            return;
        }

        if (Input.GetKeyDown(KeyCode.B) == false)
            return;

        SpawnBomb();
    }

    private void SpawnBomb()
    {
        Instantiate(_bombPrefab, transform.position, transform.rotation);
        _coolTimer = _coolTime;
    }
}