using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Expander : MonoBehaviour
{
    [SerializeField] private float _speedScale;

    private void Update()
    {
        transform.localScale *= _speedScale;
    }
}
