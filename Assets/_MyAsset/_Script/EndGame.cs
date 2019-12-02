using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour {
    private GameObject ScreenWin, ScreenLose;
	// Use this for initialization
	void Start () {
        ScreenWin = GameObject.Find("ScreenWin");
        ScreenLose = GameObject.Find("ScreenLose");
        if (VapeController.isWin == true)
        {
            ScreenWin.SetActive(true);
            ScreenLose.SetActive(false);
        }
        else
        {
            ScreenWin.SetActive(false);
            ScreenLose.SetActive(true);
        }

    }
	
	// Update is called once per frame
	public void PlayAgain () {
        Application.LoadLevel("Scene01");
    }
}
