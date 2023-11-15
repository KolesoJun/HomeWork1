using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Button : MonoBehaviour
{
    [SerializeField] private float _value;
    [SerializeField] private bool _isDamage;
    [SerializeField] private TMP_Text _text;

    private Player _player;

    private void Awake()
    {
        _player = FindObjectOfType<Player>();

        if (_isDamage)
            _value *= -1;
    }

    private void Start()
    {
        _text.text = _value.ToString();
    }

    public void OnClick()
    {
        if (_player != null)
            _player.ChangeHealth(_value);
    }
}
