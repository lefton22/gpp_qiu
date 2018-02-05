using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class l1_shipControl : MonoBehaviour {


	KeyCode input;

	float rotate_speed;

	void Start () 
	{
		rotate_speed = 5f;
		
	}
	

	void Update () 
	{
		if (Input.GetKey(KeyCode.W))
			{
//			//float x;
//			float y;
//
//			y = transform.position.y;
//			transform.DOMove(new Vector3( transform.position.x, y + speed, transform.position.z), 1f);
//
//			print("W");
			go(KeyCode.W,0f,2f);
			}

		if (Input.GetKey(KeyCode.S))
			{
			go(KeyCode.S,0f,-2f);

			}

		if (Input.GetKey(KeyCode.A))
			{
			go(KeyCode.A,-2f,0f);

			}
		if (Input.GetKey(KeyCode.D))
			{
			go(KeyCode.D,2f,0f);

			}


	//////
		///////// 
		/// 	//////
		///////// 
	/// 
		if (Input.GetKey(KeyCode.RightArrow))
			{
			transform.Rotate( new Vector3(0, 0, rotate_speed) );
//			print("right");
			}
		if (Input.GetKey(KeyCode.LeftArrow))
			{
			transform.Rotate( new Vector3(0, 0, -rotate_speed) );
//			print("left");
			}
	}

	void go(KeyCode input1, float speed_x, float speed_y)
		{
		if (Input.GetKey(input1))
			{
			float y;

			y = transform.position.y;
			transform.DOMove(new Vector3( transform.position.x + speed_x, y + speed_y, transform.position.z), 1f);

			//print(input1);
			}
		}
}
