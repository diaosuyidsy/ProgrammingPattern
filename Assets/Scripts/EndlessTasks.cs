using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using GPP;

public class DO : Task
{
	private readonly Action _action;

	public DO(Action _a)
	{
		_action = _a;
	}

	internal override void Update()
	{
		_action();
	}
}
