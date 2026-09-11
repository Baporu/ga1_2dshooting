using UnityEngine;

// 데이터 클래스: 순수하게 데이터(값)를 보관하고 전달할 목적으로 만든 클래스
// = 로직이 들어있으면 안 됨
[System.Serializable]
public class EnemySpawnData
{
    [SerializeField] private GameObject _enemyPrefab;
    public GameObject EnemyPrefab => _enemyPrefab;

    [SerializeField] private int _weight;
    public int Weight => _weight;
}