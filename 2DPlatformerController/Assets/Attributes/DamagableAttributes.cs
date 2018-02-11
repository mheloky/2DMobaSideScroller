using UnityEngine;
using UnityEditor;
using System;
using UnityEngine.UI;
using System.Linq;

[Serializable]
public class DamagableAttributes
{
    public int AttackDamage;
    public float AttackDelaySeconds;
    public DateTime LastAttackTime;
    public float Radius;
    public int Cleave;
    public GameObject[] targets;
    public float HowFatItIs;
    public LayerMask ToAttack;
    public int WhichSideIsRight;
    public GameObject[] Range(GameObject gameObject)
    {
        RaycastHit2D[] hits;
        int WhichSide = (gameObject.GetComponent<SpriteRenderer>().flipX == false) ? 1*WhichSideIsRight : -1*WhichSideIsRight;
        hits = Physics2D.RaycastAll(gameObject.transform.position+new Vector3(HowFatItIs*WhichSide,0), gameObject.transform.forward, Radius,ToAttack);
        GameObject[] gb = new GameObject[Cleave];
        for (int i = 0; i < hits.Length; i++)
        {
             if (i >= Cleave)
            {
                break;
            }
            gb[i] = hits[i].collider.gameObject;
            Debug.DrawLine(gameObject.transform.position, gb[i].transform.position, Color.red);
        }
        return gb;
    }
}
