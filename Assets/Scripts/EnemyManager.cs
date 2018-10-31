using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour {

    [SerializeField] private GameObject[] enemys; //敵を格納する配列
    [SerializeField] private float appearNextTime, popRadius, heightdiff; // 出現インターバル, 出現する円周上の半径
    [SerializeField] private int maxNumOfEnemys;

    private int numberOfEnemys; //Scene上にある敵の数
    private float elapsedTime;  //経過時間
    public float walkSpeed;   //敵の歩くスピード

    public void InitEnemyManager(){
        numberOfEnemys = 0;
        elapsedTime = 0f;
    }
	
	public void JudgeAppearEnemys(Vector3 idolPos){

		if (numberOfEnemys >= maxNumOfEnemys){
            return;
        }
        elapsedTime += Time.deltaTime;

        if (elapsedTime > appearNextTime){
            elapsedTime = 0f;
            AppearEnemys(idolPos);
        }
	}

    void AppearEnemys(Vector3 idolPos) {
        var randomValue = Random.Range(0, enemys.Length);
        var randθ = Random.Range(0, 360);

        Vector3 popPos = new Vector3();
        popPos.x = idolPos.x + popRadius * Mathf.Cos(randθ); //円周のx地点を計算
        popPos.y = idolPos.y + heightdiff ;
        popPos.z = idolPos.z + popRadius * Mathf.Sin(randθ); //円周のz地点を計算

        // Debug.Log(idolPos.y);
        // Debug.Log(popPos.y);
        // Debug.Log(popPos);

        GameObject enemy = Instantiate(enemys[randomValue], popPos, Quaternion.Euler(0f, 0f, 0f));
        enemy.name += numberOfEnemys;
        numberOfEnemys++;
        elapsedTime = 0f;
    }
}
