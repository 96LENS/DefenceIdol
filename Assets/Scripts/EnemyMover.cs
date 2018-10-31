using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour {

    [SerializeField] EnemyManager enemyManager;

    private CharacterController enemyController;
    private Animator animator;
    [SerializeField]private Vector3 velocity, direction, destination;  //速度、移動方向、目的地の位置

    void Start(){
        InitEnemyMover();
    }


    void Update(){
        GetIdolPosition();
        EnemyMove(enemyManager.walkSpeed);
    }

    public void InitEnemyMover () {
        velocity.x = 0f;
        velocity.z = 0f;
	}

    public void GetIdolPosition(){
        destination = GameObject.Find("Idol").transform.position;
    }

	public void EnemyMove (float walkSpeed) { 
        enemyController = gameObject.GetComponent<CharacterController>();
        direction = (destination - gameObject.transform.position).normalized;
        transform.LookAt(new Vector3(destination.x, transform.position.y, destination.z));
        velocity.x = direction.x * walkSpeed;
        velocity.z = direction.z * walkSpeed;
        enemyController.Move(velocity * Time.deltaTime);

	}
}
