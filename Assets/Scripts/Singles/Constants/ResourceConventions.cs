using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ResourceRarity
{
	Common,
	Uncommon,
	Rare,
	SuperRare,
	Magic,
	Powerful,
	Dangerous
}

public class ResourceConventions : MonoBehaviour
{
	public static ResourceConventions Instance { get; private set; }
	public bool destroyOnLoad = true;
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
