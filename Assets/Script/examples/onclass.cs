using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GC

	public abstract class GameEvent 
	{
	     public delegate void Handler (GameEvent e);
	}

	public class EventManager
		{


	private Dictionary<System.Type, GameEvent.Handler> handlers = new Dictionary<Types, GameEvent.Handler>();

//	public void  Register<T>(GameEvent.Handler handler) where T: GameEvent
	public void  Register<T>(GameEvent.Handler handler) where EventType: GameEvent
			{

		System Type t = typeof(EventType);

		if (_handlers.ContainKey(t))
			{
			_handlers[t] += handler;
			}
			else
			{
			_handlers[t] = handler;
			}
			}

		public void  Unregister()
			{

			}
		public void  fire()
			{
		              // Get te list of handlers or this event tye

		     //System.Type type = 
			}
		}
