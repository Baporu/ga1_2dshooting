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
        _coolTimer = _coolTime;
    }

    private void Update()
    {
        _coolTimer += Time.deltaTime;

        if (_coolTimer >= _coolTime && SimpleInput.GetButton("Bomb"))
        {
            _coolTimer = 0f;
            SpawnBomb();
        }
    }

    private void SpawnBomb()
    {
        Instantiate(_bombPrefab, transform.position, transform.rotation);
    }
}