using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalizationTableConventions : MonoBehaviour
{
	#region Properties
	#region Singleton
	public static LocalizationTableConventions Instance { get; private set; }
	public bool destroyOnLoad = true;
	#endregion
	[SerializeField] private string RNTable, RSDTable, RLDTable, RarNTable, RarSDTable,DebugAndUnassignedTable;
	#endregion
	#region Unity Flow
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
	#endregion

	#region Getters
	public string GetRNTable()
	{
		return RNTable;
	}
	public string GetRSDTable()
	{
		return RSDTable;
	}
	public string GetRLDTable()
	{
		return RLDTable;
	}
	public string GetRarNTable()
	{
		return RarNTable;
	}
	public string GetRarSDTable()
	{
		return RarSDTable;
	}
	#endregion
}
