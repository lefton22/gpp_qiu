//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//
//
//public class enemyState : MonoBehaviour
//{
//	GameObject lship;
//	GameObject lthis;
//	public float distance;
//	public Vector3 vec3_ship;
//
//	Context_Enemy context = new Context_Enemy();
//
//	void Start () 
//	{
//		lship = GameObject.Find("ship");
//		lthis = GameObject.Find("ememyState");
//
//		context.SetState(new Searching(context));
//
////		vec3_ship = lship.transform.position;
////
////		context.MoveTowardsShip(Vector3 v3_ship);
//	
//	}
//	void Update()
//		{
//		distance = Vector3.Distance(lthis.transform.position, lship.transform.position);
//		Debug.Log("dis: " + distance);
//
//
//
//		context.changeState(distance);
//
//
//
//		//transform.position = Vector3.MoveTowards(transform.position, lship.transform.position, 5000f);
//		}
//	
//
//}
//
//public class Context_Enemy
//	{
//	private State_Enemy mState;
//
//	public void SetState(State_Enemy state)
//		{
//		mState = new State_Enemy();
//
//		}
//
//
//	public void changeState(float dis)
//		{
//		mState.changeState( dis);
//
//		}
//
////	public void MoveTowardsShip(Vector3 v3_ship)
////		{
////		mState.MoveTowardsShip(v3_ship);
////		}
//
//
//	}
//
//
////public interface IState_Enemy
////	{
////	void changeState(float dis);
////	//void MoveTowardsShip();
////
////	}
//public abstract  class State_Enemy : MonoBehaviour
//	{
//	public void changeState(float dis);
//	}
//
//
//public class Searching: /* IState_Enemy*/  State_Enemy
//			{
//
//
//			private Context_Enemy mContext;
//
//			public Searching (Context_Enemy context) // construct
//				{
//				mContext = context;
//				}
//
////	        public void MoveTowardsShip(Vector3 v3_ship)
////				{
////				Debug.Log("move towards ship");
////
////				}
//			
//			public void changeState(float dis)
//				{
//				//Debug.Log("change to Searching.");
//		        
//				if (dis < 2f)
//					{
//					//mContext.SetState(new PreAttacking(mContext));
//					Debug.Log("ooo");
//					}
//				}
//
//	        }
//
//
////public class PreAttacking: IState_Enemy
////	{
////
////	}
////
////public class Attacking: IState_Enemy
////	{
////
////	}
////
////public class Fleeing: IState_Enemy
////	{
////
////	}