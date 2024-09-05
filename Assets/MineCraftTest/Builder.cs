using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Builder : MonoBehaviour
{
    [SerializeField] private float _distance;
    [SerializeField] private Transform _raycastPoint;
    [SerializeField] private Block _blockPrefab;
    [SerializeField] private BuildPreview _preview;

    private RaycastHit _hitInfo;

    private Vector3 BuildPosition => _hitInfo.transform.position + _hitInfo.normal;

    private void Update()
    {
        if (_hitInfo.transform == null)
            return;

        if (_hitInfo.transform.GetComponent<Block>() == null)
            return;

        if (Input.GetMouseButtonDown(0))
            Build();
    }

    private void FixedUpdate()
    {
        if (Physics.Raycast(_raycastPoint.position, _raycastPoint.forward, out _hitInfo ,_distance))
        {
            if (_preview.IsActive == false)
                _preview.Enable();

            _preview.SetPosition(BuildPosition);
        }
    }

    private void Build()
    {
        Vector3 position = BuildPosition;
        Instantiate(_blockPrefab, position, Quaternion.identity);
    }
}
