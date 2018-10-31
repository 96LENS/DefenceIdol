using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour {

    public GameObject PlayerUI, DecideUI, Idol, Zone;
    public GameObject Switch;
    public GameObject StartText, IdentifyText; // textオブジェクト

    [SerializeField] private Material[] zoneMat;

    public void SetPlayerUI(bool b) {
        PlayerUI.SetActive(b);
    }

    public void SetDecideUI(bool b){
        DecideUI.SetActive(b);
    }

    public void SetIdol(bool b){
        Idol.SetActive(b);
    }

    public void SetZone(bool b){
        Zone.SetActive(b);
    }

    public void SetStart(bool b){
        StartText.SetActive(b);
    }

    public void SetIdentify(bool b){
        IdentifyText.SetActive(b);
        Switch.SetActive(b);
    }

    public void DesideIdolPos(Vector3 setPos){
        var front = Camera.main.transform.position - Idol.transform.position;
        Idol.transform.LookAt(new Vector3(front.x, 0, front.z));
        GameObject.Instantiate(Idol, setPos, Idol.transform.rotation);
    }

    public void DestroyObj(GameObject obj){
        Destroy(obj);
    }

    public void ChangeZoneMat(int i){
        Zone.GetComponent<Renderer>().material = zoneMat[i];
    }

    public void InitObjectManager(bool b){
        SetPlayerUI(b);
        SetDecideUI(b);
        SetIdol(b);
        SetZone(b);
        SetStart(b);
        SetIdentify(b);
    }
}
