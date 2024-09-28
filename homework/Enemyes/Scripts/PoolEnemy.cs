using System.Collections.Generic;
using UnityEngine;

public class PoolEnemy : MonoBehaviour
{
    [SerializeField] private Enemy _prefab;
    [SerializeField] private int _countEnemyes = 10;

    private Stack<Enemy> _enemiesActive;

    private void Awake()
    {
        Init();
    }

    public Enemy Get()
    {
        if(_enemiesActive.Count > 0)
        {
            Enemy enemy = _enemiesActive.Pop();
            enemy.gameObject.SetActive(true);
            return enemy;
        }
        
        return null;
    }

    public void Release(Enemy enemy)
    {
        enemy.gameObject.SetActive(false);
        _enemiesActive.Push(enemy);
    }

    private void Init()
    {
        _enemiesActive = new Stack<Enemy>();

        for (int i = 0; i < _countEnemyes; i++)
            Create();
    }

    private void Create()
    {
        Enemy enemy = Instantiate(_prefab, transform);
        enemy.gameObject.SetActive(false);
        _enemiesActive.Push(enemy);
    }
}
