using UnityEngine;
using Assets.Attributes;
public interface ICharacter : IDamager, IDamagable, ITeamMember, IAnimatable, IMoveable
{
    GameObject GetGameObject();
    SkillAttributes GetSkillAttributes();
    ExperienceAttribute GetExperienceAttributes();
    
}