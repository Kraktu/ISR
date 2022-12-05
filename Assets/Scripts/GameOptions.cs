using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum NumberDisplayStyle
{
	Short,
	Long,
	Science
}

public class GameOptions : MonoBehaviour
{
	public static GameOptions Instance { get; private set; }
	public bool destroyOnLoad = true;
	private  NumberDisplayStyle userNumberDisplayStyle = NumberDisplayStyle.Short;

	public NumberDisplayStyle GetUserNumberDisplayStyle()
	{
		return userNumberDisplayStyle;
	}

	public void SetUserNumberDisplayStyle(NumberDisplayStyle _userNumberDisplayStyle)
	{
		userNumberDisplayStyle = _userNumberDisplayStyle;
	}

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
