using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScanerEnemy : MonoBehaviour
{
    public bool IsObstacle { get; private set; }
    public bool CanRotate { get; private set; }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponentInParent<EnemyController>() ||
            collision.gameObject.TryGetComponent<PlatformDestroyAgent>(out _))
            IsObstacle = true;

        if (collision.GetComponentInParent<Platform>())
            CanRotate = false;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponentInParent<EnemyController>() ||
            collision.gameObject.TryGetComponent<PlatformDestroyAgent>(out _))
            IsObstacle = false;

        if (collision.GetComponentInParent<Platform>())
            CanRotate = true;
    }
}
