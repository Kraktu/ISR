using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "ResourceData", menuName = "ScriptableObjects/Resource", order = 1)]
public class ResourceSO : ScriptableObject
{
	#region Properties
	#region ShownProperties
	public string resourceName;
	public Sprite resourceSprite;
	public int tier;
	public ResourceRarity rarity;
	public Color tooltipBackgroundColor = Color.black;
	#endregion
	#region HidedProperties
	[HideInInspector] public string resourceNameKey;
	[HideInInspector] public string resourceShortDescriptionKey;
	[HideInInspector] public string resourceLongDescriptionKey;
	#endregion
	#endregion
}
