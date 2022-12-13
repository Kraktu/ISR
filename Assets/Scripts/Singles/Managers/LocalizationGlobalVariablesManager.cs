using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization.SmartFormat.Core.Extensions;
using UnityEngine.Localization.SmartFormat.PersistentVariables;
using UnityEngine.Localization.SmartFormat.Extensions;
using UnityEngine.Localization.Settings;

public class LocalizationGlobalVariablesManager: MonoBehaviour
{
	#region Singleton
	public static LocalizationGlobalVariablesManager Instance { get; private set; }
	public bool destroyOnLoad = true;
	#endregion
	private PersistentVariablesSource source;
	private StringVariable playerName;
	public void Awake()
	{
		source = LocalizationSettings.StringDatabase.SmartFormatter.GetSourceExtension<PersistentVariablesSource>();
		// Access the global data : source["Global"]["playerName"] = Global.playerName
		// Global : Localization => String Database => Smart Format => Sources => Global Variable 
		// playerName : Assets => Localization => VariableGroup => Globals 
		playerName = source["Global"]["playerName"] as StringVariable;

		#region Singleton
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
		#endregion
	}
	//Create Setters for future global data (pet ? ...) 
	public void SetNewDisplayPlayerName(string _newPlayerName)
	{
		playerName.Value = _newPlayerName;
	}
	
}
