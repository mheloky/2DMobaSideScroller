using UnityEngine;
using UnityEditor;

public interface IAnimatable
{
    SpriteRenderer GetSpriteRenderer();
    Animator GetAnimator();
}