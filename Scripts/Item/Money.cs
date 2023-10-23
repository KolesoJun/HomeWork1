using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Money : Item
{
    private const string Name = "Money";

    private bool _isPicked;

    private void Update()
    {
        if(_isPicked)
            Destroy(this.gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.TryGetComponent<PlayerController>(out PlayerController player))
        {
            player.TakeItem(Name);
            _isPicked = true;
        }
    }
}
