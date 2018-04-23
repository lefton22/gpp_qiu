//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;
//
//public class StartState : ISceneState
//
//	{
//	public StartState(SceneStateController controller): base("01", controller)
//		{
//		}
//
//	private Image mLogo;
//	private float mSmoothingTime = 6;
//
//
//	public override void StateStart()
//		{
//		mLogo = GameObject.Find("Logo").GetComponent<Image>();
//		mLogo.color = Color.black;
//
//		Debug.Log("ppp");
//		}
//
//	public override void StateUpdate()
//		{
//		mLogo.color = Color.Lerp(mLogo.color, Color.white, mSmoothingTime * Time.deltaTime);
//
//		}
//	}