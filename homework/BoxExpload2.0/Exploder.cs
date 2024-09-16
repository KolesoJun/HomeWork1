using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Fuze))]
[RequireComponent(typeof(SphereCollider))]
public class Exploder : MonoBehaviour
{
    
    private SphereCollider _collider;
    private Fuze _fuze;

    private void Awake()
    {
        _fuze = GetComponent<Fuze>();
        _collider = GetComponent<SphereCollider>();
        _collider.isTrigger = true;
    }


}
