using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Hecaton : MonoBehaviour
{
    [Header("General Settings")]
    public float speed = 2.0f;
    private Transform player;
    [Header("Down Crash")]
    public GameObject hecatonRightArm;
    public GameObject hecatonLeftArm;
    public Animator hecatonAnimator;
    public float armHeight; 
    
    public void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        StartCoroutine(Pattern());  
    }

    IEnumerator Pattern()
    {
        while (true)
        {
            int p = 0;
            switch (p)
            {
                case 0:
                    yield return StartCoroutine(CrashAttackIE());
                    break;
                default:
                    break;
            }
            yield return null;
        }
    }
    IEnumerator CrashAttackIE()
    {
        float timer = 0;
        while (timer < 5)
        {
            CrashAttackFollow();
            timer += Time.deltaTime;
            yield return null;
        }
        hecatonAnimator.SetTrigger("Attack");
        yield return new WaitForSeconds(hecatonAnimator.GetCurrentAnimatorStateInfo(0).length);
        yield return new WaitForSeconds(3f);
    }
    void CrashAttackFollow()
    {
        var newPos = new Vector3
            (player.position.x, player.position.y+armHeight, player.position.z);
        
        hecatonRightArm.transform.position = Vector2.MoveTowards
            (hecatonRightArm.transform.position, newPos, speed * Time.deltaTime);
    }
}
