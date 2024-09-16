using UnityEngine;

public class ColorManager : MonoBehaviour
{
    [SerializeField] private Color32[] _colors;

    private void Awake()
    {
        GetComponent<MeshRenderer>().material.color = ChangeRandom();
    }

    private Color32 ChangeRandom()
    {
        int randomMin = 0;
        int randomMax = _colors.Length;
        return _colors[Random.Range(randomMin, randomMax)];
    }
}
