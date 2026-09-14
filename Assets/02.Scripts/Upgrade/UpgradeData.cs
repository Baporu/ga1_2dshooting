using UnityEngine;

[System.Serializable]
public class UpgradeData
{
    [SerializeField] private UpgradeType _type;
    public UpgradeType Type => _type;
    [SerializeField] private float _defaultValue;
    public float DefaultValue => _defaultValue;
    [SerializeField] private float _increaseValue;
    public float IncreaseValue => _increaseValue;
    [SerializeField] private float _defaultCost;
    public float DefaultCost => _defaultCost;
    [SerializeField] private float _increaseCost;
    public float IncreaseCost => _increaseCost;
}