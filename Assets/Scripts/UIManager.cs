using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    [SerializeField] private Text timer, score;
    [SerializeField] public Slider hpBar;

    public void InitUIManager(float m, float h){
        timer.text = m.ToString("00") + ":" + m.ToString("00");
        score.text = "Score: " + m.ToString("00");
        hpBar.value = h;
    }

    public void TimeUpdate(float m, float s){
        timer.text = m.ToString("00") + ":" + s.ToString("00");
    }

    public void HpUpdate(float hp){
        hpBar.value -= hp;
    }

    public void ScoreUpdate(int s){
        score.text = "Score: " + s.ToString("00");
    }
}
