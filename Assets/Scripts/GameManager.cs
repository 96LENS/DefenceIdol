using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    [SerializeField] private Counter counter;
    [SerializeField] private EnemyManager enemyManager;
    [SerializeField] private IdolController idolController;
    [SerializeField] private UIManager uiManager;
    [SerializeField] private ObjectManager objectManager;

    [SerializeField] private float playTime;

    public bool decide, set, timeup, hpzero;
    
     public enum GameState{
        INIT,
        START,
        DICIDEPOSITION,
        READY,
        PLAY,
        GAMEOVER,
        CLEAR
    }

    public GameState gameState;
    

	void FixedUpdate () {

        switch (gameState){

            case GameState.INIT:
                counter.InitCounter();
                uiManager.InitUIManager(0, 1);
                objectManager.InitObjectManager(false);
                gameState = GameState.START;
                break;

            case GameState.START:
                gameState = GameState.DICIDEPOSITION;
                break;

            case GameState.DICIDEPOSITION:
                objectManager.SetDecideUI(true);
                objectManager.SetIdol(true);

                if (set) {
                    objectManager.SetStart(false);
                    objectManager.SetIdentify(true);

                    if (decide){
                        objectManager.SetDecideUI(false);
                        gameState = GameState.READY;
                    }
                }
                else{
                    objectManager.SetStart(true);
                    objectManager.SetIdentify(false);
                }

                break;

            case GameState.READY:
                counter.ReadyCounter(playTime);
                idolController.ReadyIdolController();;
                gameState = GameState.PLAY;
                break;

            case GameState.PLAY:
                counter.TimeCount();
                enemyManager.JudgeAppearEnemys(idolController.idolPos);

                if (timeup || uiManager.hpBar.value <= 0)
                    gameState = GameState.GAMEOVER;
                break;

            case GameState.GAMEOVER:
                break;

            case GameState.CLEAR:
                break;
        }		
	}
}
