using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed;

    private bool _canMove;
    private PoolEnemy _poolEnemy;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Border>())
        {
            _canMove = false;
            _poolEnemy.Release(this);
        }
    }

    private void Update()
    {
        if(_canMove)
            transform.Translate(Vector3.forward * _speed * Time.deltaTime);
    }

    public void Init(PoolEnemy pool, Vector3 startPosition, Vector3 rotate)
    {
        _poolEnemy = pool;
        transform.position = startPosition;
        transform.rotation = Quaternion.Euler(rotate);
        _canMove = true;
    }
}
