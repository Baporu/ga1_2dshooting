using UnityEngine;

[CreateAssetMenu(fileName = "EnemySpawnDataTableSO", menuName = "Scriptable Objects/EnemySpawnDataTableSO")]
public class EnemySpawnDataTableSO : ScriptableObject
{
    [SerializeField] private EnemySpawnData[] _datas;
    public EnemySpawnData[] Datas => _datas;
}