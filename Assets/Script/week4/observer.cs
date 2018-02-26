using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;

public class observer : MonoBehaviour {

	ConcreteSubject1 sub1 = new ConcreteSubject1();
	void Start () 
	{



		ConcreteObserver1 ob1 = new ConcreteObserver1(sub1);
		sub1.RegisterObserver(ob1);

		ConcreteObserver1 ob2 = new ConcreteObserver1(sub1);
		sub1.RegisterObserver(ob2);

//		sub1.subjectState = "temperature 90";
	}
	

	void Update () 
	{
		sub1.subjectState = "temperature 90";
	}

	public abstract class Subject
	{
		List <Observer> mObesrvers = new List<Observer>();

		public void RegisterObserver(Observer ob)
			{
			mObesrvers.Add(ob);
			}

		public void RemoveObserver (Observer ob)
			{
			mObesrvers.Remove(ob);
			}
		
		public void NotifyObserver()
			{
			foreach (Observer ob in mObesrvers)
				{
				ob.Update();
				}
			}
	}

	public class ConcreteSubject1: Subject
	{
		public string mSubjectState;
		public string subjectState
			{
				set 
				{ mSubjectState = value;
				NotifyObserver();
				}
				get {return mSubjectState; }
			}
		
	}

	public abstract class Observer
	{

		public abstract void Update();
	}

	public class ConcreteObserver1: Observer
	{
		public ConcreteSubject1 mSub;
		public ConcreteObserver1(ConcreteSubject1 sub)
			{
			  mSub = sub;
			}
		public override void Update()
			{

			if (Enemy.isDead)
				{
				Debug.Log("dispaly Observer1 upDate " + mSub.subjectState);

				Enemy.isDead = false;

				GameObject.Find("enemy3").SendMessage("listen");
				}
//			if (!Enemy.isDead)
//				{
//				GameObject.Find("enemy3").SendMessage("listen2");
//				}
			}

	}




}
