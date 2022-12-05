using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conventions : MonoBehaviour
{
	public static Conventions Instance { get; private set; }
	public bool destroyOnLoad = true;

	[SerializeField] private string[] shortIntName = new string[] {"", "K", "M", "G", "T", "P", "E", "Z", "Y", "O", "N", "D", "UnD", "DuoD", "TreD", "QuaD", "QuinD", "SeD", "SepD", "OctD", "NovD", "V" };
	[SerializeField] private string[] longIntName = new string[] {"", "Kilo", "Mega", "Giga", "Tera", "Peta", "Exa", "Zeta", "Yotta", "Octillion", "Nonillion", "Decillion", "UnDecillion", "DuoDecillion", "TreDecillion", "QuaDecillion", "QuinDecillion", "SexDecillion", "SeptenDecillion", "OctoDecillion", "NovemDecillion","Vigintillion" };

	[SerializeField] private string[] longFloatName = new string[] {"m", "mi", "n", "p", "f", "a", "z", "y"};
	[SerializeField] private string[] shortFloatName = new string[] {"mili", "micro", "nano", "pico", "femto", "atto", "zepto", "yocto"};

	public string GetIntNumberDisplaySuffix(int _index)
	{
		switch (GameOptions.Instance.GetUserNumberDisplayStyle())
		{
			case NumberDisplayStyle.Short:
				return shortIntName[_index];
			case NumberDisplayStyle.Long:
				return longIntName[_index];
			case NumberDisplayStyle.Science:
				return "10e"+(_index*3);
			default:
				return shortIntName[_index];
		}
	}

	public string GetFloatNumberDisplaySuffix(int _index)
	{
		switch (GameOptions.Instance.GetUserNumberDisplayStyle())
		{
			case NumberDisplayStyle.Short:
				return shortFloatName[_index];
			case NumberDisplayStyle.Long:
				return longFloatName[_index];
			case NumberDisplayStyle.Science:
				return "10e-"+(_index*3);
			default:
				return shortFloatName[_index];
		}
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
