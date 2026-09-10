using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    // 싱글톤 패턴
    // 1. 전역적으로 접근할 수 있다.
    // 2. 인스턴스(생성된 객체)가 하나임을 보장한다.
    private static ScoreManager _instance;
    public static ScoreManager Instance => _instance;

    // UI 책임 추가 (TMP 참조)
    [SerializeField] private TextMeshProUGUI _bestScoreTextUI;
    [SerializeField] private TextMeshProUGUI _currentScoreTextUI;

    // 관리: 특정 데이터에 대한 무결성과 생성, 읽기, 수정, 삭제 등과 관련된 게임 로직
    private int _bestScore;
    private int _currentScore = 0;

    private const string SaveKey = "BestScore";


    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        _instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        // 입력: Input
        // 저장, 불러오기: PlayerPrefs
        _bestScore = PlayerPrefs.GetInt(SaveKey, 0);

        Refresh();
    }

    public void AddScore(int score)
    {
        if (score < 0)
            return;

        _currentScore += score;

        if (_currentScore > _bestScore)
        {
            _bestScore = _currentScore;

            // 저장: PlayerPrefs.Set~ 시리즈를 이용해서 int/float/string을 저장 가능하다.
            // 컴퓨터는 레지스트리, 모바일은 로컬 저장소에 저장된다.
            PlayerPrefs.SetInt(SaveKey, _bestScore);
            PlayerPrefs.Save();
        }

        Refresh();
    }

    private void Refresh()
    {
        _bestScoreTextUI.text = $"Best Score: {_bestScore}";
        _currentScoreTextUI.text = $"Score: {_currentScore}";
    }
}