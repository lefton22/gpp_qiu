using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class monster3 : Enemy
	{
//	protected override void MonsterMove(float moveX, float moveY, float moveZ )
//		{
//		moveY = transform.position.y + 0.5f;
//		moveX = transform.position.x ;
//		moveZ = transform.position.z;
//
//		transform.DOMove(new Vector3(moveX, moveY, moveZ),1f);
//	}

	SpriteRenderer sp_this;

	void Start()
		{
		sp_this = GetComponent<SpriteRenderer>();

		}
	
	void listen()
		{
		Debug.Log("I'm listening. " + transform.localScale.x);
		//sp_this.color = Color.red;

		float x = transform.localScale.x + 0.2f;
		float y = transform.localScale.y + 0.2f;

		transform.DOScale(new Vector3(x, y, transform.localScale.z), 0.2f);

		}

//	void listen2()
//		{
//		Debug.Log("2I'm listening2.");
//		sp_this.color = Color.black;
//
//		}
	}


