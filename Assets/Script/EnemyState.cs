using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyState : MonoBehaviour {

	//public bool isBeat = false;
	public int state = 0;// 0 is null; 1 is alive; 2 is destroy;
	public int collideWith = 0; // 0 is null; 1 is wall; 2 is bullets; 3 is ship;

	public bool isExisted;

	void Start () 
	{

		state = 0;
	}

	void Update () 
	{

	}

	void OnTriggerEnter2D(Collider2D other)
		{

		if (other.tag == "boundry")
			{
//		print(gameObject + " collides with walls");
			collideWith = 1;
			state = 2;
			}
		if (other.tag == "l1_bullet")
			{
			//print(gameObject + " codllides with bullets");
			collideWith = 2;
			state = 2;
			}
		if (other.gameObject.name  == "ship")
			{
			//print(gameObject + " collides with walls");
			collideWith = 3;
			state = 2;
			}
		

		}

	void OnTriggerExit2D(Collider2D other)
		{
		collideWith = 0;

		}

	void Born()
		{
		isExisted = true;
		//print("born true");
		}
}
