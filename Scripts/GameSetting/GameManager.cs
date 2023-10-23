using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private PlatformController _platformController;
    [SerializeField] private PlayerController _player;
    [SerializeField] private Spawner _spawner;

    private float _distance = 3f;

    void Update()
    {
        ProcedureBuild();
        ProcessGame();
    }

    private void ProcessGame()
    {
        if (_player == null)
            print("stop game");
    }

    private void ProcedureBuild()
    {
        float positionPlayer = _player.transform.position.x;
        float positionPlatformController = _platformController.transform.position.x;

        if (positionPlayer + _distance >= positionPlatformController)
        {
            StartCoroutine(_platformController.Build());
        }
        else
        {
            StopCoroutine(_platformController.Build());
        }
    }
}
