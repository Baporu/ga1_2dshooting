using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    // 싱글톤 패턴
    // 1. 전역적으로 접근할 수 있다.
    // 2. 인스턴스(생성된 객체)가 하나임을 보장한다.
    private static ScoreManager _instance;
    public static ScoreManager Instance => _instance;

    // 관리: 특정 데이터에 대한 무결성과 생성, 읽기, 수정, 삭제 등과 관련된 게임 로직
    private int _bestScore;
    private int _currentScore = 0;

    // UI 책임 추가 (TMP 참조)
    [SerializeField] private TextMeshProUGUI _bestScoreTextUI;
    [SerializeField] private TextMeshProUGUI _currentScoreTextUI;


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

    public void AddScore(int score)
    {
        if (score < 0)
            return;

        _currentScore += score;
        if (_currentScore > _bestScore)
        {
            _bestScore = _currentScore;
        }

        Refresh();
    }

    private void Refresh()
    {
        _bestScoreTextUI.text = $"Best Score: {_bestScore}";
        _currentScoreTextUI.text = $"Score: {_currentScore}";
    }
}