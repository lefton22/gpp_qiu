using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class l1_boundry : MonoBehaviour {



	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	void OnTriggerEnter2D(Collider2D other) 
	{
//	print("something hit me. -- one boundry");

		if (other.gameObject.tag == "l1_bullet")
			{
			Destroy(other.gameObject);
			//print("kill this bullet.");

			}


	}
}
