using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Services
{
	private static StateManager _sm;
	public static StateManager SM
	{
		get
		{
			Debug.Assert(_sm != null);
			return _sm;
		}
		set
		{
			_sm = value;
		}
	}
}
