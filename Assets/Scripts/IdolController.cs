using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdolController : MonoBehaviour {

    [SerializeField] Counter counter;    

    public Vector3 idolPos;
    private Animator animator;
    private bool isRunning;
    [SerializeField] private float poseChangeTime, maxHP, WaitTime;

    public void ReadyIdolController () {
        idolPos = gameObject.transform.position;
	}

    public void OnTriggerEnter(Collider hit){
        if (hit.gameObject.tag == "Enemy"){
            //Debug.Log("call OnTrrigerEnter");
            counter.ArriveObj.Add(hit.gameObject);
        }
    }

    public void OnTriggerStay(Collider hit){
        if (hit.gameObject.tag == "Enemy"){
            StartCoroutine("HP_Caluculate");
        }
    }

    public void IdolAnimation(){
        animator.SetFloat("Speed", poseChangeTime);
    }

    IEnumerator HP_Caluculate(){
        if (isRunning){
             yield break;
        }else{
            isRunning = true;
            maxHP = counter.HpCalculate(maxHP);
            yield return new WaitForSeconds(WaitTime);
            isRunning = false;
        }
    }
}
