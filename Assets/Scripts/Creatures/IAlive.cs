using System;
using UnityEngine.Events;

public interface IAlive
{
    event UnityAction<IAlive> HPChanged;

    float HP { get; }
    float MaxHP { get; }

    bool IsDead();
    float Heal(float addedHealth);
    void MakeDamage(float stolenHealth);
}

