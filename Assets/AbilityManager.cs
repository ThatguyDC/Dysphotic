using UnityEngine;
using System.Collections;
public class AbilityManager : MonoBehaviour
{
    public GameObject WaveObject;
    private Wave WaveScript;

    void Start(){

        WaveScript = WaveObject.GetComponent<Wave>();

    }

    void Update(){

     if(Input.GetKeyDown(KeyCode.Q)){

        if(!WaveObject.activeSelf){

            WaveObject.SetActive(true);
            WaveScript.StartCoroutine(WaveScript.SpawnWave());

        }

     }   
    }
}
