using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Exploder _prefab;

    public void CreatePrefabs(Transform transformExploded, float radius, float force)
    {
        if (CanSpawn(transformExploded.localScale))
        {
            int indexSeparate = 2;
            int randomMin = 2;
            int randomMax = 6;
            int countNewObjects = Random.Range(randomMin, randomMax);

            for (int i = 0; i < countNewObjects; i++)
            {
                Exploder prefab = Instantiate(_prefab, transform);
                prefab.transform.position = transformExploded.position;
                prefab.SetupNewParametrs(radius* indexSeparate, force* indexSeparate);
            }
        }
    }

    private bool CanSpawn(Vector3 scale)
    {
        Vector3 scaleMin = new Vector3(0.25f, 0.25f, 0.25f);

        if (scale.x >= scaleMin.x && scale.y >= scaleMin.y && scale.z >= scaleMin.z)
            return true;

        return false;
    }
}
