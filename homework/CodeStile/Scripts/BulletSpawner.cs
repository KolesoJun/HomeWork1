using System.Collections;
using UnityEngine;

public class BulletSpawner: MonoBehaviour
{
    [SerializeField] private Bullet _prefab;
    [SerializeField] private Transform _target;
    [SerializeField] private float _timeWaitShooting;
    [SerializeField] private float _force;

    private void Start()
    {
        StartCoroutine(Shoot());
    }

    private IEnumerator Shoot()
    {
        WaitForSeconds wait = new WaitForSeconds(_timeWaitShooting);
        bool isWork = enabled;

        while (isWork)
        {
            var direction = (_target.position - transform.position).normalized;
            var bullet = Instantiate(_prefab, transform.position + direction, Quaternion.identity);
            bullet.transform.up = direction;
            bullet.Move(direction, _force);
            yield return wait;
        }
    }
}
