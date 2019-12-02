using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    private GameObject EnemyHitYou, EnemyHitYouRegain;
    // Use this for initialization
    void Start () {
        EnemyHitYou = GameObject.Find("EnemyHitYou");
        EnemyHitYouRegain = GameObject.Find("EnemyHitYouRegain");

        EnemyHitYou.SetActive(false);
        EnemyHitYouRegain.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider col)
    {
        print("Enter");
        if (col.gameObject.tag == "Pain")
        {
            StartCoroutine(EnemyHit(col.gameObject));
        }
    }

    IEnumerator EnemyHit(GameObject CurrentGameObject)
    {
        EnemyHitYou.SetActive(true);
        EnemyHitYouRegain.SetActive(false);
        yield return new WaitForSeconds(1.0f);
        EnemyHitYou.SetActive(false);
        EnemyHitYouRegain.SetActive(true);
        yield return new WaitForSeconds(1.0f);
        EnemyHitYou.SetActive(false);
        EnemyHitYouRegain.SetActive(false);
        Destroy(CurrentGameObject);
    }
}
