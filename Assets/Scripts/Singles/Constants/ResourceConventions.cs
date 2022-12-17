using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ResourceRarity
{
	Trash,
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
	[SerializeField] private RaritySO defaultRarity;
	[SerializeField] private List<RaritySO> raritySOs;
	[SerializeField] private List<ResourceSO> resourceSOs;


	#region Singleton
	public static ResourceConventions Instance { get; private set; }
	public bool destroyOnLoad = true;
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

		InitializeResourceSOs();
	
	}

	private void InitializeResourceSOs()
	{
		for (int i = 0; i < resourceSOs.Count; i++)
		{
			resourceSOs[i].resourceName = "RNK" + resourceSOs[i].resourceName;
			resourceSOs[i].resourceShortDescriptionKey = "RSDK" + resourceSOs[i].resourceName;
			resourceSOs[i].resourceLongDescriptionKey = "RLDK" + resourceSOs[i].resourceName;
		}
	}

	public RaritySO GetRaritySO(ResourceRarity _resourceRarity)
	{
		for (int i = 0; i < raritySOs.Count; i++)
		{
			if (_resourceRarity.ToString() == raritySOs[i].name)
			{
				return raritySOs[i];
			}
		}
		return defaultRarity;
	}
}
