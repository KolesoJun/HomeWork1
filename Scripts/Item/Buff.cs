using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buff : Item
{
    private bool _isAllow;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.TryGetComponent<PlayerController>(out PlayerController player))
        {
            _isAllow = true;
            player.Upgrade(ref _isAllow);
            Destroy(gameObject);
        }
    }
}
