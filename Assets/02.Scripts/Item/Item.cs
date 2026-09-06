using UnityEngine;

public abstract class Item : MonoBehaviour
{
    public float MoveSpeed = 2f;
    public float StopTime;
    private float _stopTimer;
    private GameObject _player;

    private void Start()
    {
        _stopTimer = StopTime;
        _player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        _stopTimer -= Time.deltaTime;

        if (_stopTimer < 0)
        {
            ChasePlayer();
        }
    }

    private void ChasePlayer()
    {
        Vector3 direction = _player.transform.position - this.transform.position;

        transform.Translate(direction * MoveSpeed * Time.deltaTime);
    }
}
