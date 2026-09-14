using UnityEngine;

[System.Serializable]
public class Upgrade
{
    // 기획자가 채우는 속성
    [SerializeField] private UpgradeType _type;
    public UpgradeType Type => _type;
    [SerializeField] private float _defaultValue;
    [SerializeField] private float _increaseValue;
    [SerializeField] private float _defaultCost;
    [SerializeField] private float _increaseCost;

    // 실행 중에 동적으로 바뀌는 속성
    private int _level;
    public int Level => _level;
    private float _currentValue;
    public float CurrentValue => _currentValue;
    private float _nextValue;
    public float NextValue => _nextValue;
    private int _cost;
    public int Cost => _cost;


    public Upgrade(UpgradeType type, int level, float defaultValue, float increaseValue, float defaultCost, float increaseCost)
    {
        _type = type;
        _level = level;
        _defaultValue = defaultValue;
        _increaseValue = increaseValue;
        _defaultCost = defaultCost;
        _increaseCost = increaseCost;

        Calculate();
    }

    public void LevelUp()
    {
        _level++;

        Calculate();
    }

    private void Calculate()
    {
        // Todo: 공식에 따라 변화
        // Value = 기본값 + 레벨 * 증가량
        // Cost = 기본 점수 * 증가량 점수 ^ 레벨
        _currentValue = _defaultValue + _level * _increaseValue;
        _nextValue = _defaultValue + (_level + 1) * _increaseValue;
        _cost = (int)(_defaultCost * Mathf.Pow(_increaseCost, _level));
    }
}