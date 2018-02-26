using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//public enum GameEventType
//	{
//	Null,
//	EnemyKilled,
//	SoldierKilled,
//	NewStage
//	}
//
//public class GameEventSystem : IGameSystem 
//{
//
//	private Dictionary <GameEventType, IGameEventSubject> mGameEvents = new Dictionary<GameEventType, IGameEventSubject>();
//
//	public override void Init()
//		{
//		base.Init();
//		InitGameEvents();
//
//		}
//
//	private void InitGameEvents()
//		{
//		mGameEvents.Add(GameEventType.EnemyKilled, new EnemyKilledSubject());
//		}
//
//	public void RegisterObserver (GameEventType eventType, IGameEventObserver observer)
//		{
//		if (mGameEvents.ContainsKey(eventType) == false)
//			{
//			Debug.LogError("no regarding eventType " + eventType + "'s subject class");
//			return;
//			}
//
//		IGameEventSubject sub = mGameEvents[eventType];
//		sub.RegisterObserver(observer);
//		observer.SetSubject(sub);
//		}
//
//	public void RemoveObserver(GameEventType, IGameEventSubject)
//		{
//
//
//		IGameEventSubject sub = GetGameEvent(EventType);
//		if (sub == null) return;
//		sub.RemoveObserver(observer);
//		observer.SetSubject(null);
//		}
//
//	private void GetGameEvent(GameEventType eventType)
//		{
//		if (mGameEvents.ContainsKey(eventType) == false)
//			{
//			Debug.LogError("no regarding eventType " + eventType + "'s subject class"); 
//			return null;
//			}
//
//		IGameEventSubject sub = mGameEvents[eventType];
//
//		}
//
//	public void NotifySubject (GameEventType eventType)
//		{
//		IGameEventSubject sub = GetGameEvent(EventType);
//		if (sub == null) return;
//		sub.Notify();
//		}
//}
