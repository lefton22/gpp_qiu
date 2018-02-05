using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class l1_bulletBorn : MonoBehaviour {

    float t;// the gap time of shooting
	List <GameObject> l_livingBullets;

	GameObject a_bullets;

	public float shotSpeed;

	void Start () 
	{
		l_livingBullets = new List<GameObject>();	
		//t = 0.5f;
	}
	
	// Update is called once per frame
	void Update () 
		{

		if (Time.time - t > shotSpeed)
			{
//				if (l_livingBullets.Count < 15)
//					{
					GameObject bullets = Instantiate(Resources.Load("bullet_ori")) as GameObject;
					l_livingBullets.Add(bullets);

					//bullets.transform.SetParent(GameObject.Find("ship").transform);

					Vector3 v3_current_ship;
					v3_current_ship = GameObject.Find("ship").transform.position;
					bullets.transform.position = v3_current_ship;

			bullets.transform.eulerAngles = GameObject.Find("ship").transform.eulerAngles;

//				    shoot();
//				    a_bullets = bullets;
                    
//					}
				    t = Time.time;
			}

	   }

//		void shoot()
//		{
//
////		Vector3 v3_current_ship;
////		v3_current_ship = GameObject.Find("ship").transform.position;
//	//	a_bullets.transform.position = v3_current_ship;
//		}
}
