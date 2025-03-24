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
            //랜덤으로 패턴뽑기
            int p = 0;
            switch (p)
            {
                case 0:
                    yield return StartCoroutine(CrashAttackIE());
                    break;
                default:
                    break;
            }
            //애니메이션을 기본상태로
            yield return new WaitForSeconds(0.5f);
        }
    }
    IEnumerator CrashAttackIE()
    {
        for (int i = 0; i < 3; i++)
        {
            float elapsedTime = 0;
            while (elapsedTime < 3)
            {
                elapsedTime += Time.deltaTime;
                CrashAttackFollow();
                yield return null;
            }
            //찍어
            yield return new WaitForSeconds(1f);
        }

        yield break;
    }
    void CrashAttackFollow()
    {
        var newPos = new Vector3
            (player.position.x, player.position.y+armHeight, player.position.z);
        
        hecatonRightArm.transform.position = Vector2.MoveTowards
            (hecatonRightArm.transform.position, newPos, speed * Time.deltaTime);
    }
}
