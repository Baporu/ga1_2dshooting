using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AudioType
{
    BULLET,
    PLAYER_HIT,
    ENEMY_HIT,
    ITEM,
    PLAYER_DEATH,
    ENEMY_DEATH,
}

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [SerializeField] private AudioClip[] _audioClips;
    [SerializeField] private int _initPoolSize = 10;

    private Queue<AudioSource> _audioSourcePool;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        Init();
    }

    private void Init()
    {
        _audioSourcePool = new Queue<AudioSource>();

        for (int i = 0; i < _initPoolSize; i++)
        {
            AudioSource audioSource = gameObject.AddComponent<AudioSource>();
            audioSource.playOnAwake = false;
            audioSource.enabled = false;

            _audioSourcePool.Enqueue(audioSource);
        }
    }

    // SFX 실행 (배경 음악은 별도로 재생 중)
    public void PlaySFX(AudioType audioType)
    {
        AudioClip audioClip = _audioClips[(int)audioType];

        if (_audioSourcePool.Count > 0)
        {
            AudioSource audioSource = _audioSourcePool.Dequeue();
            audioSource.clip = audioClip;
            audioSource.pitch = UnityEngine.Random.Range(0.8f, 1.2f);
            audioSource.enabled = true;
            audioSource.Play();

            StartCoroutine(WaitAndReturnToPool(audioSource, audioClip.length));
        }

        else
        {
            AudioSource audioSource = gameObject.AddComponent<AudioSource>();
            audioSource.clip = audioClip;
            audioSource.playOnAwake = false;
            audioSource.pitch = UnityEngine.Random.Range(0.8f, 1.2f);
            audioSource.Play();

            StartCoroutine(WaitAndReturnToPool(audioSource, audioClip.length));
        }
    }

    // 실행 시간 기다렸다가 다시 풀에 넣기
    private IEnumerator WaitAndReturnToPool(AudioSource audioSource, float time)
    {
        yield return new WaitForSeconds(time);

        audioSource.enabled = false;
        _audioSourcePool.Enqueue(audioSource);
    }
}