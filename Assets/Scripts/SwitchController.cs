using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwitchController : MonoBehaviour {

    [SerializeField] private GameManager gameManager;

    public void YesSwitch(){
        gameManager.decide = true;
    }

    public void NoSwitch(){
        gameManager.set = false;
    }
}
