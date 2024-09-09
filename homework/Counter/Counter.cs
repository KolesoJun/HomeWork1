using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{
    private const int IndexMouseButton = 0;

    [SerializeField] private float _delay;

    private Coroutine _coroutine;
    private Text _text;
    private int _score;
    private bool _isWork;

    private void Awake()
    {
        _text = GetComponent<Text>();
    }

    private void Start()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(IndexMouseButton)) 
        {
            if (_isWork)
            {
                StopCoroutine(_coroutine);
                _isWork = false;
            }
            else
            {
                _coroutine = StartCoroutine(StartedScore());
                _isWork = true;
            }
        }
    }

    private IEnumerator StartedScore()
    {
        var wait = new WaitForSeconds(_delay);

        while (true)
        {
            _score++;
            _text.text = _score.ToString();
            yield return wait;
        }
    }
}
