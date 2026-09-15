using UnityEngine;

[System.Serializable]
public class Upgrade
{
    // Todo: (완료) SO로 따로 빼기
    // 기획자가 채우는 속성 -> SO로 빼기도 함
    private UpgradeData _data;
    public UpgradeData Data => _data;

    // 실행 중에 동적으로 바뀌는 속성
    private int _level = 1;
    public int Level => _level;
    private float _currentValue;
    public float CurrentValue => _currentValue;
    private float _nextValue;
    public float NextValue => _nextValue;
    private int _cost;
    public int Cost => _cost;


    public Upgrade(UpgradeData data, int level)
    {
        _data = data;
        _level = level;

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
        _currentValue = _data.DefaultValue + (_level - 1) * _data.IncreaseValue;
        _nextValue = _data.DefaultValue + _level * _data.IncreaseValue;
        _cost = (int)(_data.DefaultCost * Mathf.Pow(_data.IncreaseCost, _level - 1));
    }
}