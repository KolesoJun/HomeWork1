using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scaner : MonoBehaviour
{
    [SerializeField] private float _sizeMin;
    [SerializeField] private float _sizeMax;
    [SerializeField] private float _growth;

    public Transform Target { get; private set; }
    public Transform Player { get; private set; }

    private bool _canSwap;

    private void Update()
    {
        if (_canSwap == false)
        {
            transform.localScale = new Vector3(Mathf.MoveTowards(transform.localScale.x, _sizeMax, _growth * Time.deltaTime), transform.localScale.y, Mathf.MoveTowards(transform.localScale.z, _sizeMax, _growth * Time.deltaTime));

            if (transform.localScale.x >= _sizeMax)
                _canSwap = true;
        }
        else
        {
            transform.localScale = new Vector3(Mathf.MoveTowards(transform.localScale.x, _sizeMin, _growth * Time.deltaTime), transform.localScale.y, Mathf.MoveTowards(transform.localScale.z, _sizeMin, _growth * Time.deltaTime));

            if (transform.localScale.x <= _sizeMin)
                _canSwap = false;
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PathEnemy")
            Target = other.transform;

        if (other.gameObject.TryGetComponent<PlayerController>(out PlayerController player))
            Player = player.transform;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.TryGetComponent<PlayerController>(out PlayerController player))
        {
            Player = null;
        }
    }
}
