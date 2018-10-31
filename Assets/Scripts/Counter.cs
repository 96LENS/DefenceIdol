using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Counter : MonoBehaviour {

    [SerializeField] UIManager uiManager;
    [SerializeField] GameManager gameManager;

    private int score;
    private float minutes, seconds, oldSeconds;
    public List<GameObject> ArriveObj = new List<GameObject>();

    [SerializeField] private float minDam, maxDam;

    public void InitCounter(){
        minutes = 0;
        seconds = 0;
        oldSeconds = 0;
        score = 0;
    }

    public void ReadyCounter(float time){
        minutes = time / 60;
        seconds = time % 60;
    }

    public void TimeCount(){
        seconds -= Time.deltaTime;
        
        if (seconds <= 0){
            minutes--;
            seconds = 59;
        }

        if (minutes < 0){
            uiManager.TimeUpdate(0, 0);
            gameManager.timeup = true;
            return;
        }

        if (seconds != oldSeconds){
            uiManager.TimeUpdate(minutes, seconds);
        }

        oldSeconds = seconds;
    }

    // Write Idol HitPoint Calculation Process  
    public float HpCalculate(float hp){
        float damagePoint = Random.Range(minDam, maxDam);
        hp -= damagePoint;
        uiManager.HpUpdate(damagePoint / hp * ArriveObj.Count);
        Debug.Log(damagePoint / hp);
        return hp;      
    }

    // Write number of defeated enemy
    public void ScoreCount(){
        score++;
        uiManager.ScoreUpdate(score);
        for(int i = 0; i < ArriveObj.Count; i++){
          //if (obj.name == ArriveObj[i].name){
          //      EnemyManager.EnemyDestroy(obj);
          //}
        }
    }
}
