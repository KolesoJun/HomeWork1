using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private Transform _place;
    [SerializeField] private float _speed;
   
    private Transform[] _placesPoints;
    private int _indexPoint;

    private void Start()
    {
        _placesPoints = _place.GetComponentsInChildren<Transform>();
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        if (transform.position == _placesPoints[_indexPoint].position) 
            ChangePoint();

        transform.position = Vector3.MoveTowards(transform.position, _placesPoints[_indexPoint].position, _speed * Time.deltaTime);
    }

    private void ChangePoint()
    {
        _indexPoint = (_indexPoint + 1) % _placesPoints.Length;
        var point = _placesPoints[_indexPoint].transform.position;
        transform.forward = point - transform.position;
    }
}
