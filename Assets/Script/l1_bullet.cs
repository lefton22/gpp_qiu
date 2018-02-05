using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class l1_bullet : MonoBehaviour {

//	Vector3 v3_current_ship;

	float t = 0.1f;
	float speed = 3f;

	Vector3 pos_bullet_dir;

	void Start () 
	{

//		v3_current_ship = GameObject.Find("ship").transform.position;
//		transform.position = v3_current_ship;
		
	}
	

	void Update () 
	{

			if (Time.time - t >0)
			{
			transform.SetParent(null);

//				float y;
//				y = transform.position.y;
//
//				float current_y;
//				current_y = y + 0.5f;
//
//				transform.DOMoveY(current_y,2f);
//
//				transform.position = new Vector3 (transform.position.x, current_y, transform.position.z);
//				//print("show me your distance.");

		//transform.position += Vector3.up * Time.deltaTime * 3f;

			pos_bullet_dir = this.gameObject.transform.GetChild(0).position;
			float step = speed * Time.deltaTime;
			transform.position = Vector3.MoveTowards(transform.position, pos_bullet_dir , step);


			}
		
	}
   void OnDrawGizmos()
		{
		DrawHelperAtCenter(this.transform.up, Color.blue, 2f);
		}
	void DrawHelperAtCenter( Vector3 direction, Color color, float scale)
		{
		Gizmos.color = color;
		Vector3 destination = transform.position + direction * scale;
		Gizmos.DrawLine(transform.position, destination);
		}
}
