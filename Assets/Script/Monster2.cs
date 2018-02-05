using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using DG.Tweening;

	public class Monster2 : Enemy 
	{

	protected override void MonsterMove(float moveX, float moveY, float moveZ )
		{
		moveY = transform.position.y +2f;
		moveX = transform.position.x + 0.5f;
		moveZ = transform.position.z;

		transform.DOMove(new Vector3(moveX, moveY, moveZ),1f);

//		pos_this= gameObject.transform.position;
//		float step = speed * Time.deltaTime;
//		transform.position = Vector3.MoveTowards(new Vector3(moveX, moveY, moveZ), pos_this , step);
		}
	}
