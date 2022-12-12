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

public class NumberConventions : MonoBehaviour
{
	public static NumberConventions Instance { get; private set; }
	public bool destroyOnLoad = true;

	[SerializeField] private string[] shortIntNames = new string[] {"", "K", "M", "G", "T", "P", "E", "Z", "Y", "O", "N", "D", "UnD", "DuoD", "TreD", "QuaD", "QuinD", "SeD", "SepD", "OctD", "NovD", "V" };
	[SerializeField] private string[] longIntNames = new string[] {"", "Kilo", "Mega", "Giga", "Tera", "Peta", "Exa", "Zeta", "Yotta", "Octillion", "Nonillion", "Decillion", "UnDecillion", "DuoDecillion", "TreDecillion", "QuaDecillion", "QuinDecillion", "SexDecillion", "SeptenDecillion", "OctoDecillion", "NovemDecillion","Vigintillion" };

	[SerializeField] private string[] shortFloatNames = new string[] {"m", "mi", "n", "p", "f", "a", "z", "y"};
	[SerializeField] private string[] longFloatNames = new string[] {"mili", "micro", "nano", "pico", "femto", "atto", "zepto", "yocto"};

	#region Magic
	#region Getters
	public string[] GetShortIntName()
	{
		return shortIntNames;
	}	
	public string[] GetLongIntName()
	{
		return longIntNames;
	}	
	public string[] GetShortFloatName()
	{
		return shortFloatNames;
	}	
	public string[] GetLongFloatName()
	{
		return longFloatNames;
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
