using UnityEngine;
using UnityEngine.Events;
using System;


public class Entity : MonoBehaviour, IAlive
{
    [SerializeField] private float _hp;
    [SerializeField] private float _maxHP;

    public float HP => _hp;
    public float MaxHP => _maxHP;

    public event UnityAction<IAlive> HPChanged;

    public float Heal(float addedHp)
    {       
        _hp += addedHp;
        if (_hp > _maxHP)
        {
            float difference = _maxHP - _hp;
            _hp = _maxHP;
            return difference;
        }
        return 0;
    }

    public bool IsDead() => _hp <= 0;

    public void MakeDamage(float retrievedHp)
    {
        _hp -= retrievedHp;
        HPChanged?.Invoke(this);
    }

   
}

