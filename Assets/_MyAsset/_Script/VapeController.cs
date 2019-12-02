using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VapeController : MonoBehaviour {
    public static bool isOnTarget = false, isVapePress = false, isWin = false;
    public static int LivesCount = 3;
    public GameObject Life3, Life2, Life1;
    public GameObject VapeSmoke;
    public Text Timer;
    private float timeLeft = 60;
    // Use this for initialization
    void Start () {
        LivesCount = 3;
        timeLeft = 60;
        isOnTarget = false;
        isVapePress = false;

        VapeSmoke.SetActive(false);
        Life3.SetActive(true);
        Life2.SetActive(false);
        Life1.SetActive(false);

    }

   

    // Update is called once per frame
    public void Vape () {
        StartCoroutine(Vsmoke());
    }

    IEnumerator Vsmoke()
    {
        VapeSmoke.SetActive(true);
        isVapePress = true;
        yield return new WaitForSeconds(1.0f);
        VapeSmoke.SetActive(false);
        isVapePress = false;
    }

    private void Update()
    {
        timeLeft -= Time.deltaTime;
        Timer.text = "" + (int)timeLeft;
        if (timeLeft < 0)
        {
            
            EndGame();
            isWin = true;
        }

        if (LivesCount == 3)
        {
            Life3.SetActive(true);
            Life2.SetActive(false);
            Life1.SetActive(false);
        }
        else if (LivesCount == 2)
        {
            Life3.SetActive(false);
            Life2.SetActive(true);
            Life1.SetActive(false);
        }
        else if (LivesCount == 1)
        {
            Life3.SetActive(false);
            Life2.SetActive(false);
            Life1.SetActive(true);
        }
        else if (LivesCount == 0)
        {
            isWin = false;
            EndGame();
        }

        if (GameObject.FindGameObjectsWithTag("Pain").Length == 0)
        {
            isWin = true;
            EndGame();
        }
    }

    public void EndGame()
    {
        print("End Game");
        Application.LoadLevel("Scene02");
    }
}
