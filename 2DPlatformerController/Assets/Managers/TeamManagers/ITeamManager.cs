using UnityEngine;
using UnityEditor;
using Assets.Attributes;

public interface ITeamManager
{
    Vector2 GetDirectionVector(TeamAttributes teamAttributes);
    bool GetShouldFlipNPCSprite(SpriteRenderer spriteRenderer, TeamAttributes teamAttributes);
}