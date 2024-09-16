using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Brick _prefab;

    public void Create(Transform transformExploded, float radius, float force, float separate)
    {
        int indexSeparate = 2;
        int randomMin = 2;
        int randomMax = 6;
        int countNewObjects = Random.Range(randomMin, randomMax);

        for (int i = 0; i < countNewObjects; i++)
        {
            Brick prefab = Instantiate(_prefab, transform);
            prefab.transform.position = transformExploded.position;
            prefab.SetupNewParametrs(radius * indexSeparate, force * indexSeparate, separate / indexSeparate, transformExploded.localScale / indexSeparate);
        }
    }
}
