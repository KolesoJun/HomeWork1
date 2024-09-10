using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody))]
public class Fuze : MonoBehaviour
{
    [SerializeField] private float _chanceSeparation = 100;
    [SerializeField] private float _radius;
    [SerializeField] private float _forceExpload;
    [SerializeField] private ParticleSystem _effect;
    [SerializeField] private Fuze _prefab;

    private float _divisionThreshold = 50;
    private int _indexSeparate = 2;
    private int _sizeDivision = 2;

    private void OnMouseUpAsButton()
    {
        Action();
    }

    private void Action()
    {
        Division();
        Instantiate(_effect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    private void Division()
    {
        if (_chanceSeparation >= _divisionThreshold)
        {
            int randomMin = 2;
            int randomMax = 6;
            int countNewObjects = Random.Range(randomMin, randomMax);

            for (int i = 0; i < countNewObjects; i++)
            {
                Fuze prefab = Instantiate(_prefab, transform.position, Quaternion.identity);
                prefab.GetComponent<Rigidbody>().AddExplosionForce(_forceExpload, transform.position, _radius);
                prefab.transform.localScale /= _sizeDivision;
                prefab.CalculateChanceSeparation();
            }
        }
    }

    public float CalculateChanceSeparation()
    {
        return _chanceSeparation /= _indexSeparate;
    }
}
