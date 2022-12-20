using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "RarityData", menuName = "ScriptableObjects/Rarity", order = 2)]
public class RaritySO : ScriptableObject
{
	#region Properties
	#region ShownProperties
	public string rarityName;
	public Color rarityColor;
	public float rarityWeight;
	#endregion
	#region HidedProperties
	[HideInInspector] public string rarityNameKey;
	[HideInInspector] public string rarityShortDescriptionKey;
	[HideInInspector] public string rarityLongDescriptionKey;
	#endregion
	#endregion
}
