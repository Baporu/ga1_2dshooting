using UnityEngine;

public class PlayerAutoMove : MonoBehaviour
{
    /* Find든 트리거든 적 찾아서 저장
     * 관건은 휴리스틱 어떻게 설정할지
     * 평소에 내 판단 근거
     *
     * 가까운 적을 피하면서 체력이 적은 애
     */

    [SerializeField] private float _speed = 2f;
    [SerializeField] private float _stopTrackingY = -2f;
    private GameObject _target;


    private void Update()
    {
        if (_target == null || _target.transform.position.y < _stopTrackingY)
        {
            FindNearestTarget();
        }

        Move();
    }

    private void FindNearestTarget()
    {
        // 1. 타겟을 구한다.
        GameObject[] targets = GameObject.FindGameObjectsWithTag("Enemy");
        if (targets.Length == 0)
            return;

        _target = targets[0];
        float minDistance = float.MaxValue;

        foreach (var enemy in targets)
        {
            if (enemy.transform.position.y < _stopTrackingY)
                continue;

            float distance = Vector2.Distance(transform.position, enemy.transform.position);
            if (distance < minDistance)
            {
                minDistance = distance;
                _target = enemy;
            }
        }
    }

    private void Move()
    {
        if (_target == null)
            return;

        // 2. 방향을 구한다.
        Vector3 diff = _target.transform.position - transform.position;
        Vector3 direction = diff;

        if (diff.y >= 3)
        {
            direction.y = 1;
        }
        else
        {
            direction.y = -1;
        }

        direction.Normalize();

        // 3. 속도에 맞게 이동한다.
        transform.Translate(direction * _speed * Time.deltaTime);
    }
}