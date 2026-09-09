using System.Collections;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    [Header("Bomb")]
    [SerializeField] private int _damage = 99999;
    [SerializeField] private float _duration = 3f;

    [Header("Animation")]
    [SerializeField] private Vector2 _minMaxScale = new Vector2(4.8f, 5.2f);

    [SerializeField] private float _expandTime = 0.2f;
    [SerializeField] private float _shrinkTime = 0.2f;


    private void Start()
    {
        StartCoroutine(ExpandBomb());
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Enemy") == false)
            return;

        Enemy enemy = collider.GetComponent<Enemy>();
        enemy.TakeDamage(_damage);
    }

    private IEnumerator ExpandBomb()
    {
        float timer = 0f;

        while (timer < _expandTime)
        {
            float t = timer / _expandTime;

            float newScale = Mathf.SmoothStep(0, _minMaxScale.x, t);
            transform.localScale = new Vector3(newScale, newScale, newScale);

            timer += Time.deltaTime;
            yield return null;
        }

        StartCoroutine(AnimateBombIdle());
    }

    private IEnumerator AnimateBombIdle()
    {
        float timer = 0f;

        while (timer < _duration)
        {
            float newScale = Mathf.PingPong(timer, _minMaxScale.y - _minMaxScale.x) + _minMaxScale.x;
            transform.localScale = new Vector3(newScale, newScale, newScale);

            timer += Time.deltaTime;
            yield return null;
        }

        StartCoroutine(ShrinkBomb());
    }

    private IEnumerator ShrinkBomb()
    {
        float timer = 0f;
        float startScale = transform.localScale.x;

        while (timer < _shrinkTime)
        {
            float t = timer / _shrinkTime;

            float newScale = Mathf.Lerp(startScale, 0, t);
            transform.localScale = new Vector3(newScale, newScale, newScale);

            timer += Time.deltaTime;
            yield return null;
        }

        Destroy(gameObject);
    }
}