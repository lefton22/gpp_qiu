using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using DG.Tweening;

	public class Monster1 : Enemy {


	protected override void MonsterMove(float moveX, float moveY, float moveZ )
		{
		moveY = transform.position.y + 0.5f;
		moveX = transform.position.x ;
		moveZ = transform.position.z;

		transform.DOMove(new Vector3(moveX, moveY, moveZ),1f);

//		pos_this= gameObject.transform.position;
//		float step = speed/100 * Time.deltaTime;
//		transform.position = Vector3.MoveTowards(new Vector3(moveX, moveY, moveZ), pos_this , step);
		}


}
