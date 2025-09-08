using System;
using UnityEngine.Events;

interface IDestroyable // for things that can be damaged and destroyed, like players or obstacles. 
{
    public void Damage(float damagePoints);
}