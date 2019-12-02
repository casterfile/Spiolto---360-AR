using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    
    private Transform target;
    private float speed = 3f;
    private Animator Anim;
    // Use this for initialization
    void Start () {
        target = GameObject.Find("Person").GetComponent<Transform>();
        Anim = gameObject.GetComponent<Animator>();
        
    }
	
	// Update is called once per frame
	void Update () {
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Person")
        {
            if (VapeController.isVapePress == false)
            {
                VapeController.LivesCount--;
                
            }

        }
    }

   
    


}
