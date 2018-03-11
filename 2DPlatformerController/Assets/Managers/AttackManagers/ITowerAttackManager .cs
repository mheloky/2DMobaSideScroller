using UnityEngine;
using UnityEditor;
using Assets.Abilities;

public interface ITowerAttackManager
{
    IAttack basic(int team);
}