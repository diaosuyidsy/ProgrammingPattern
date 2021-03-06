﻿using System;
using System.Collections.Generic;

public abstract class Manager<T>
{
	public int Population => ManagedObjects.Count;
	protected readonly List<T> ManagedObjects = new List<T>();

	protected abstract T CreateObject();
	protected virtual void DestroyObject(T obj) { }

	public T Create()
	{
		var obj = CreateObject();
		ManagedObjects.Add(obj);
		return obj;
	}

	public void Destroy(T obj)
	{
		ManagedObjects.Remove(obj);
		DestroyObject(obj);
	}

	public T Find(Predicate<T> predicate)
	{
		return ManagedObjects.Find(predicate);
	}

	public List<T> FinaAll(Predicate<T> predicate)
	{
		return ManagedObjects.FindAll(predicate);
	}
}