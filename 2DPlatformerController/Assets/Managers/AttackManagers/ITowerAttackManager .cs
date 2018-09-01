using UnityEngine;
using Assets.Abilities;

public interface ITowerAttackManager
{
    IAttack basic(int team);
}