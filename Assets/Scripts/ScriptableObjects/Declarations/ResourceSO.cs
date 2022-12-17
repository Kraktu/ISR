using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "ResourceData", menuName = "ScriptableObjects/Resource", order = 1)]
public class ResourceSO : ScriptableObject
{
	public string resourceName;
	public Sprite resourceSprite;
	public int tier;
	public ResourceRarity rarity;

	[HideInInspector] public string resourceShortDescriptionKey;
	[HideInInspector] public string resourceLongDescriptionKey;
}
