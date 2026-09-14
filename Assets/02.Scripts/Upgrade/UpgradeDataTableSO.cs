using UnityEngine;

[CreateAssetMenu(fileName = "UpgradeDataTableSO", menuName = "Scriptable Objects/UpgradeDataTableSO")]
public class UpgradeDataTableSO : ScriptableObject
{
    [SerializeField] private UpgradeData[] _datas;
    public UpgradeData[] Datas => _datas;
}