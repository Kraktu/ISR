using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum NumberDisplayStyle
{
	Short,
	Long,
	ScienceDetailed,
	ScienceShort
}

public class GameOptions : MonoBehaviour
{
	public static GameOptions Instance { get; private set; }
	public bool destroyOnLoad = true;
	private  NumberDisplayStyle userNumberDisplayStyle = NumberDisplayStyle.Short;

	#region Magic
	#region Getters
	public NumberDisplayStyle GetUserNumberDisplayStyle()
	{
		return userNumberDisplayStyle;
	}
	#endregion

	#region Setters
	public void SetUserNumberDisplayStyle(NumberDisplayStyle _userNumberDisplayStyle)
	{
		userNumberDisplayStyle = _userNumberDisplayStyle;
	}
	#endregion
	#endregion

	private void Awake()
	{
		if (Instance != null && Instance != this)
		{
			Destroy(this);
		}
		else
		{
			Instance = this;
		}
		if (!destroyOnLoad)
		{
			DontDestroyOnLoad(gameObject);
		}
	}
}
