using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody))]
public class Fuze : MonoBehaviour
{
    [SerializeField] private float _chanceSeparation = 100;
    [SerializeField] private ParticleSystem _effect;
    [SerializeField] private Fuze _prefab;
    [SerializeField] private float _radiusDefault;
    [SerializeField] private float _forceDefault;

    [SerializeField] private float _forceExplode;//[SerializeField] - ��� ��� �������, �� ������ �����
    [SerializeField] private float _radiusExplode;//[SerializeField] - ��� ��� �������, �� ������ �����
    private bool _isWork;
    private float _divisionThreshold = 50;
    private int _indexSeparate = 2;
    private int _sizeDivision = 2;
    private int _multiplierForSize; // [SerializeField] ���� ��� ���� ������������, �� ������-�� �� ������� ����� ��������� (������: ��������� = 1, ����� 2, ����� 4; ���� �� ������������, �� 1, ����� 2, � ��� ����������� 2 - ������?)

    private void OnMouseUpAsButton()
    {
        Action();
    }

    private void Start()
    {
        _forceExplode = _multiplierForSize * _forceDefault + _forceDefault;//��� �� ������� ���� ������: ������ ����� ������ ������ ����������� ���� �� �������� ����� ��������. ��� ���������������� ���� �� ������� ������ 100 - 60???? �� �������
        _radiusExplode = _multiplierForSize * _radiusDefault;
    }

    private void FixedUpdate()
    {
        if (_isWork)
            _forceExplode = Mathf.MoveTowards(_forceExplode, 0, _forceExplode + 1);
    }

    private void Action()
    {
        if (_chanceSeparation >= _divisionThreshold)
            CreateSubsidiariesObjects();

        Explode();
        Instantiate(_effect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    private void CreateSubsidiariesObjects()
    {
        int randomMin = 2;
        int randomMax = 6;
        int countNewObjects = Random.Range(randomMin, randomMax);

        for (int i = 0; i < countNewObjects; i++)
        {
            Fuze prefab = Instantiate(_prefab, transform.position, Quaternion.identity);
            prefab.transform.localScale /= _sizeDivision;
            prefab.CalculateChanceSeparation();
            prefab.IncreaseMultiplier();
        }
    }

    private void Explode()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, _radiusExplode);
        gameObject.GetComponent<Fuze>()._isWork = true;

        foreach (var hit in hits)
        {
            if (hit.attachedRigidbody != null)
                hit.attachedRigidbody.AddForce((hit.transform.position - transform.position) * _forceExplode, ForceMode.Impulse);
        }
    }

    public void CalculateChanceSeparation()
    {
        _chanceSeparation /= _indexSeparate;
    }

    public void IncreaseMultiplier()
    {
        _multiplierForSize *= _sizeDivision;
    }
}
