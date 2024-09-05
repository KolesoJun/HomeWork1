using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TEst : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _speedMove;

    private Vector3 _offset;

    private void Start()
    {
        _offset = transform.position - _target.position;
    }

    private void Update()
    {
        //������ ����������� ����� ������3
        //transform.position = Vector3.MoveTowards(transform.position, _target.position, _speedMove * Time.deltaTime);

        //�������� ������������ - �� ��������� ����� (���������)
        transform.position = Vector3.Lerp(transform.position, _target.position, _speedMove);

        // ������ ����������� ����� Translate
        //var direction = (_target.position - transform.position).normalized;
        //transform.Translate(direction * _speedMove, Space.World);

        //������� ������ ��� y
        //transform.Rotate(0, 180, 0);

        //������� � ������� �������
        //transform.LookAt(direction);

        //������� �� ���������
        //transform.position = _target.position + _offset;
        //transform.RotateAround(_target.position, Vector3.up, _speedMove * Time.deltaTime);
        //transform.Rotate(Vector3.up * _speedMove * Time.deltaTime);
        //_offset = transform.position - _target.position;
        
        // ������� ����� ����������
        //transform.rotation *= Quaternion.Euler(0, 10, 0);

        //������� ������ �������� ���
        //transform.RotateAround(transform.position, _target.position, 5);
    }

}
