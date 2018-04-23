//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//
//public class DM01State: MonoBehaviour
//	{
//	void Start()
//		{
//		Context context = new Context();
//
//		context.SetState(new ConcreteStateA(context));
//
//		context.Handle(5);
//		context.Handle(20);
//		context.Handle(30);
//		context.Handle(4);
//		}
//	}
//
//public class Context
//	{
//		private IState mState;
//
//		public void SetState(IState state)
//			{
//			mState = state;
//			}
//
//	public void Handle(int arg)
//		{
//		mState.Handle(arg);
//		}
//	}
//
//
//public interface IState
//	{
//
//	void Handle(int args);
//
//	}
//
//	public class ConcreteStateA: IState
//		{
//		private Context mContext;
//
//		public ConcreteStateA(Context context)
//			{
//			mContext = context;
//			}
//		
//		public  void Handle(int arg)
//			{
//			Debug.Log("ConcreteStateA.Handle " + arg);
//			if (arg > 10)
//				{
//				//->B
//				mContext.SetState(new ConcreteStateB(mContext));
//				}
//			}
//		}
//
//	public class ConcreteStateB: IState
//		{
//
//		private Context mContext;
//
//		public ConcreteStateB(Context context)
//			{
//			mContext = context;
//			}
//		
//		public  void Handle(int arg)
//			{
//			Debug.Log("ConcreteStateB.Handle " + arg);
//			if (arg < 10)
//				{
//				//->A
//				mContext.SetState(new ConcreteStateA(mContext));
//				}
//			}
//		}