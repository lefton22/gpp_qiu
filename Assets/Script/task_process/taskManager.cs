using System.Collections.Generic;
using UnityEngine;

	public class TaskManager {

	private readonly List<Task> _tasks = new List<Task>();

	public Task Do(Task task)
		{
		Debug.Assert(task != null);

		Debug.Assert(!task.IsAttached);
		_tasks.Add(task);
		task.SetStatus(Task.TaskStatus.Pending);
		return task;
		}

	public void Update()
		{

		for (var i = _tasks.Count - 1; i >= 0; --i)
			{
			var task = _tasks[i];


			if (task.IsPending)
				{
				task.SetStatus(Task.TaskStatus.Working);
				}

			if (task.IsFinished)
				{
				HandleCompletion(task, i);
				}
			else
				{
				task.Update();
				}

			}
		}

	private void HandleCompletion(Task task, int taskIndex)
		{

		if (task.NextTask != null && task.IsSuccessful)
			{
			Do(task.NextTask);
			}

		_tasks.RemoveAt(taskIndex);
		task.SetStatus(Task.TaskStatus.Detached);
		}
	}

