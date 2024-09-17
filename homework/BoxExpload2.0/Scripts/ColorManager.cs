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
        return _colors[Random.Range(0,_colors.Length)];
    }
}
