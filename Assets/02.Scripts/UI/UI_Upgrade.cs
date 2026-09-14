using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_Upgrade : MonoBehaviour
{
    [SerializeField] private int _index;

    [SerializeField] private Button _button;
    [SerializeField] private TextMeshProUGUI _titleText;
    [SerializeField] private TextMeshProUGUI _descriptionText;
    [SerializeField] private TextMeshProUGUI _scoreCostText;


    public void OnClick()
    {
        // 버튼이 클릭되면 매니저에게 업그레이드 해달라고 요청한다.
        UpgradeManager.Instance.LevelUp(_index);
    }

    public void Refresh()
    {
        Upgrade upgrade = UpgradeManager.Instance.Upgrades[_index];

        _titleText.text = $"{upgrade.Type} Lv.{upgrade.Level}";
        _descriptionText.text = $"+{upgrade.CurrentValue} -> +{upgrade.NextValue}";
        _scoreCostText.text = $"{upgrade.Cost:N0} Score";
    }
}