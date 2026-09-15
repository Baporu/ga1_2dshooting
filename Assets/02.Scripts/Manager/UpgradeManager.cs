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

    private const string UpgradeSaveDataKey = "UpgradeSaveData";


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
        UpgradeSaveData saveData = Load();

        for (int i = 0; i < _dataTable.Datas.Length; i++)
        {
            _upgrades[i] = new Upgrade(_dataTable.Datas[i], saveData.Level[i]);
        }
    }

    private void Start()
    {
        RefreshUI();
    }

    public void LevelUp(int index)
    {
        // Todo: 묻지 말고 시켜라!
        // 골드 매니저에게 돈이 있는지 물어보고 돈이 있다면 차감 후 업그레이드 호출
        Upgrade upgrade = Upgrades[index];

        if (ScoreManager.Instance.Score < upgrade.Cost)
            return;

        ScoreManager.Instance.Spend(upgrade.Cost);
        upgrade.LevelUp();

        Save();

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

    private void Save()
    {
        // 데이터 저장은 유의미한 정보만 저장한다.
        // Upgrade의 속성 중 기획자가 채우는 속성은 고정적이고,
        // 다른 값들은 레벨로 역산이 가능하다.
        // 그러므로 레벨만 저장한다.

        UpgradeSaveData saveData = new UpgradeSaveData(_upgrades.Length);

        for (int i = 0; i < _upgrades.Length; i++)
        {
            saveData.Type[i] = _upgrades[i].Data.Type;
            saveData.Level[i] = _upgrades[i].Level;
        }

        // Todo: 암호화해서 저장하기
        // JSON 포맷으로 문자열 변환
        // Key와 Value 형태로 저장
        string text = JsonUtility.ToJson(saveData);
        PlayerPrefs.SetString(UpgradeSaveDataKey, text);

        PlayerPrefs.Save();
    }

    private UpgradeSaveData Load()
    {
        UpgradeSaveData saveData;

        if (!PlayerPrefs.HasKey(UpgradeSaveDataKey))
        {
            saveData = new UpgradeSaveData(_upgrades.Length);

            for (int i = 0; i < _upgrades.Length; i++)
            {
                saveData.Level[i] = 1;
            }

            return saveData;
        }

        // Todo: 복호화해서 저장하기
        string json = PlayerPrefs.GetString(UpgradeSaveDataKey, string.Empty);
        saveData = JsonUtility.FromJson<UpgradeSaveData>(json);

        return saveData;
    }
}