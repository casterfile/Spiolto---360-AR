using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Range : MonoBehaviour {
    public GameObject  Hit_White, Hit_Red;
    private int collisionCount = 0;
    // Use this for initialization
    void Start () {

        Hit_White.SetActive(true);
        Hit_Red.SetActive(false);

    }
	
	// Update is called once per frame
	void Update () {
        if (collisionCount == 0)
        {
            //Debug.Log("No collision");
            
        }
        else
        {
            
        }
        RaycastHit hit;
        var fwd = transform.TransformDirection(Vector3.forward);
        if (Physics.Raycast(transform.position, fwd, out hit, 20))
        {
            //string nameData = hit.collider.gameObject.name;
            //print("There is something in front of the object! : "+ nameData);

            Hit_White.SetActive(false);
            Hit_Red.SetActive(true);

            VapeController.isOnTarget = true;
            
            if (VapeController.isVapePress == true)
            {
                StartCoroutine(RemoveEnemy(hit.collider.gameObject));
                Hit_White.SetActive(true);
                Hit_Red.SetActive(false);
            }
        }
        else
        {
            Hit_White.SetActive(true);
            Hit_Red.SetActive(false);
            VapeController.isOnTarget = false;
        }

    }

    //void OnTriggerEnter(Collider col)
    //{
    //    print("Enter");
    //    collisionCount++;
    //    if (col.gameObject.tag == "Pain")
    //    {
            
           
    //    }
    //}

    IEnumerator RemoveEnemy(GameObject CurrentEnemy)
    {
        Animator Anim;
        Anim = CurrentEnemy.GetComponent<Animator>();
        

        Anim.SetBool("isAnim", true);
        Destroy(CurrentEnemy.GetComponent<BoxCollider>());
        yield return new WaitForSeconds(1.0f);
        Destroy(CurrentEnemy);
    }

    //void OnTriggerExit(Collider col)
    //{
    //    collisionCount--;
    //    print("Exit");
    //    if (col.gameObject.tag == "Pain")
    //    {
    //        VapeController.isOnTarget = false;
    //        HitTest();
    //    }
    //}

    //private void HitTest()
    //{
    //    print("Data 1234");
    //    print("isOnTarget: " + VapeController.isOnTarget);
    //    if (VapeController.isOnTarget == true)
    //    {
    //        Hit_White.SetActive(false);
    //        Hit_Red.SetActive(true);
    //    }
    //    else
    //    {
    //        Hit_White.SetActive(true);
    //        Hit_Red.SetActive(false);
    //    }
        
    //}

    
}
