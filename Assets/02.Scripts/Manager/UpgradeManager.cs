using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    // 업그레이드 관리자: 업그레이드에 대한 무결성과 생성, 조회, 수정, 삭제 등과 관련된 게임 로직
    private static UpgradeManager _instance;
    public static UpgradeManager Instance => _instance;

    [SerializeField] private UpgradeDataTableSO _dataTable;

    // 업그레이드 도메인 클래스들
    private Upgrade[] _upgrades;
    public Upgrade[] Upgrades => _upgrades;

    // 업그레이드 UI들
    [SerializeField] private UI_Upgrade[] _uiUpgrades;


    private void Awake()
    {
        if (_instance != null)
        {
            Destroy(gameObject);
            return;
        }

        _instance = this;
        DontDestroyOnLoad(gameObject);

        _upgrades = new Upgrade[_dataTable.Datas.Length];

        for (int i = 0; i < _dataTable.Datas.Length; i++)
        {
            _upgrades[i] = new Upgrade(_dataTable.Datas[i], 1);
        }
    }

    private void Start()
    {
        RefreshUI();
    }

    public void LevelUp(int index)
    {
        Upgrade upgrade = Upgrades[index];

        if (ScoreManager.Instance.Score < upgrade.Cost)
            return;

        ScoreManager.Instance.Spend(upgrade.Cost);
        upgrade.LevelUp();

        RefreshUI();
    }

    // UI 갱신
    private void RefreshUI()
    {
        foreach (UI_Upgrade uiUpgrade in _uiUpgrades)
        {
            uiUpgrade.Refresh();
        }
    }
}