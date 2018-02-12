using UnityEngine;
using UnityEditor;

public interface ICharacter : IDamager, IDamagable, ITeamMember, IAnimatable, IMoveable
{
    GameObject GetGameObject();
}