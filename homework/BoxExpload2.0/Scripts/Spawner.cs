using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Brick _prefab;

    public List<Rigidbody> Create(Transform transformExploded, float radius, float force, float separate)
    {
        List<Rigidbody> hits = new List<Rigidbody>();
        int indexSeparate = 2;
        int countRandomMin = 2;
        int countRandomMax = 7;
        int countNewObjects = Random.Range(countRandomMin, countRandomMax);

        for (int i = 0; i < countNewObjects; i++)
        {
            Brick prefab = Instantiate(_prefab, transform);
            prefab.transform.position = transformExploded.position;
            prefab.Init(radius * indexSeparate, force * indexSeparate, separate / indexSeparate, transformExploded.localScale / indexSeparate);
            hits.Add(prefab.GetComponent<Rigidbody>());
        }

        return hits;
    }
}
