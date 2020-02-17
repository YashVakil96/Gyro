using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUps : MonoBehaviour
{

    #region Variables
    public static bool StartDefender;

    public GameObject Defender_1;
    public GameObject Defender_2;
    public GameObject Defender_3;
    private Transform Player;
    public static bool DefenderBool;

    #endregion


    #region System Methods

    private void Start()
    {
        Player = GameObject.Find("Follow").GetComponent<Transform>();
    }//start

    private void Update()
    {
        if(StartDefender)
        {
            StartDefender = false;
            DefenderBool = true;
            StartCoroutine(Defender());
            Defender_1.SetActive(true);
            Defender_2.SetActive(true);
            Defender_3.SetActive(true);
        }
        if(DefenderBool)
        {
            Defenders();
        }
    }//update

    #endregion


    #region User Define Methods

    void Defenders()
    {
        Defender_1.transform.RotateAround(Player.position, Vector3.forward, 100 * Time.deltaTime);
        Defender_2.transform.RotateAround(Player.position, Vector3.forward, 100 * Time.deltaTime);
        Defender_3.transform.RotateAround(Player.position, Vector3.forward, 100 * Time.deltaTime);
    }//Defenders

    IEnumerator Defender()
    {
        yield return new WaitForSeconds(10) ;
        //Defender Bool False
        DefenderBool = false;

        Defender_1.SetActive(false);
        Defender_2.SetActive(false);
        Defender_3.SetActive(false);
    }
    #endregion
}//class
