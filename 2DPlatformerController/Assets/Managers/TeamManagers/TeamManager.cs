using UnityEngine;
using Assets.Attributes;

public class TeamManager:ITeamManager
{
    public Vector2 GetDirectionVector(TeamAttributes teamAttributes)
    {
        var move = Vector2.right;

        if (teamAttributes.Team == TAGS.Team2)
            move = Vector2.left;

        return move;
    }

    public bool GetShouldFlipNPCSprite(SpriteRenderer spriteRenderer, TeamAttributes teamAttributes)
    {
        bool flipSprite = (spriteRenderer.flipX ? (teamAttributes.Team == TAGS.Team2) : (teamAttributes.Team == TAGS.Team1));
        if (!flipSprite)
        {
            return !spriteRenderer.flipX;
        }

        return spriteRenderer.flipX;
    }
}