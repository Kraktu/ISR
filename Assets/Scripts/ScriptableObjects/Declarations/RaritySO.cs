using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "RarityData", menuName = "ScriptableObjects/Rarity", order = 2)]
public class RaritySO : ScriptableObject
{
	public string rarityName;
	public Color rarityColor;
	public float rarityWeight;

}
