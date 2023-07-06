using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scaner : MonoBehaviour
{
    [SerializeField] private float _sizeMax;
    [SerializeField] private float _growth;

    public Transform PathPoint { get; private set; }
    public Transform Player { get; private set; }

    private void Update()
    {
        transform.localScale = new Vector3
            (Mathf.MoveTowards(transform.localScale.x, _sizeMax, _growth * Time.deltaTime),
            transform.localScale.y, 
            Mathf.MoveTowards(transform.localScale.z, _sizeMax, _growth * Time.deltaTime));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<EnemyPathPoint>(out EnemyPathPoint pathPoint))
            PathPoint = pathPoint.transform;

        if (other.gameObject.TryGetComponent<PlayerController>(out PlayerController player))
            Player = player.transform;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.TryGetComponent<PlayerController>(out PlayerController player))
            Player = null;
    }
}
