using UnityEngine;
using UnityEditor;

/// <summary>
/// Just a script for level objects like the floor - without this we error out on rdamage related collision
/// </summary>
public class LevelObject : MonoBehaviour, IDamagable
{
    public DamagableAttributes GetDamagableAttributes()
    {
        return null;
    }

    public void TakeDamage(int damage)
    {
        return;
    }
}