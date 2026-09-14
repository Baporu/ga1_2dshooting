using UnityEngine;
using UnityEngine.UI;

public class UI_AutoButton : MonoBehaviour
{
    // 버튼을 클릭하면 토글하고 싶다.
    // - 플레이어의 자동 이동
    // - 플레이어의 자동 공격
    [Header("on/off스프라이트")]
    [SerializeField] private Sprite _onSprite;

    [SerializeField] private Sprite _offSprite;

    private Image _myImage;
    private AudioSource _audioSource;

    private bool _autoMode = false;
    private Player _player;

    [Header("클릭시 애니메이션")]
    [SerializeField] private AnimationCurve _bumpCurve;

    private float _scale = 1.0f;
    private bool _isBumping = false;
    private float _elapsedTime = 0; // 경과 시간
    private const float BumpDuration = 0.3f;
    private const float BumpScale = 1.1f;


    private void Start()
    {
        _myImage = GetComponent<Image>();
        _audioSource = GetComponent<AudioSource>();
        _player = FindAnyObjectByType<Player>();

        AutoToggle();
    }

    public void AutoToggle()
    {
        _autoMode = !_autoMode;

        _player.GetComponent<PlayerFire>().SetAuto(_autoMode);
        _player.GetComponent<PlayerMove>().enabled = !_autoMode;
        _player.GetComponent<PlayerAutoMove>().enabled = _autoMode;


        // 오토 모드에 따라 보여지는 이미지 스프라이트 교체
        // 변수 = 조건 ? true일때의 값  : false일때의 값 
        _myImage.sprite = _autoMode ? _onSprite : _offSprite;
    }

    // todo: 버튼 클릭할 때 애니메이션 주기 + 사운드 주기
    // 애니메이션: 코드로 구현 약간 커졌따가 원래대로..

    public void PlayAnimation()
    {
        _isBumping = true;
        _elapsedTime = 0;
    }

    private void Update()
    {
        if (!_isBumping) return;

        // 1. 경과 시간 누적
        _elapsedTime += Time.deltaTime;
        if (_elapsedTime > BumpDuration) // 시간이 다 지났다면..
        {
            transform.localScale = Vector3.one; // 스케일 초기화
            _isBumping = false;
            return;
        }

        // 2. 누적 시간과 애니메이션 커브에 따른 스케일 변경
        float time = _elapsedTime / BumpDuration; // 얼마나 지났는지 퍼센트 (0 ~ 1)
        float curveValue = _bumpCurve.Evaluate(time); // 퍼센트에 따라 커브 애니메이션 값 추출
        transform.localScale = Vector3.Lerp(transform.localScale, Vector3.one * BumpScale, curveValue);
    }


    // 사운드: 일레븐랩스에서 버튼 클릭 공용 사운드 만들어서 적용
    public void PlaySound()
    {
        _audioSource.Play();
    }
}