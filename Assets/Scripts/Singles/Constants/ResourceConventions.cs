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
	#region Properties	
	#region Singleton
	public static ResourceConventions Instance { get; private set; }
	public bool destroyOnLoad = true;
	#endregion

	[SerializeField] private RaritySO defaultRarity;
	[SerializeField] private ResourceSO defaultResource;
	[SerializeField] private List<RaritySO> raritySOs;
	[SerializeField] private List<ResourceSO> resourceSOs;
	#endregion
	#region Magic
	#region Getters
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
	#region ResourceGet
	#region SingleGetter
	public ResourceSO GetResourceSO(string _ResourceName)
	{
		for (int i = 0; i < resourceSOs.Count; i++)
		{
			if(resourceSOs[i].name==_ResourceName)
			{
				return resourceSOs[i];
			}
		}
		return defaultResource;
	}
	public ResourceSO GetResourceSO(int _ResourceID)
	{
		if(_ResourceID>=0 && _ResourceID<resourceSOs.Count)
		{
			return resourceSOs[_ResourceID];
		}
		return defaultResource;
	}
	#endregion

	#region ListGetter
	public List<ResourceSO> GetResourceSOs(ResourceRarity _resourceRarity)
	{
		List<ResourceSO> _RSOs = new List<ResourceSO>();

		for (int i = 0; i < resourceSOs.Count; i++)
		{
			if (resourceSOs[i].rarity == _resourceRarity)
			{
				_RSOs.Add(resourceSOs[i]);
			}
		}
		return _RSOs;
	}
	public List<ResourceSO> GetResourceSOs(int _tier)
	{
		List<ResourceSO> _RSOs = new List<ResourceSO>();

		for (int i = 0; i < resourceSOs.Count; i++)
		{
			if (resourceSOs[i].tier == _tier)
			{
				_RSOs.Add(resourceSOs[i]);
			}
		}
		return _RSOs;
	}
	#endregion
	#endregion
	#endregion
	#endregion
	#region UnityFlow
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

		InitializeResourceKeySOs();
		InitializeRarityKeySOs();
	}
	#endregion
	#region Methods
	private void InitializeResourceKeySOs()
	{
		for (int i = 0; i < resourceSOs.Count; i++)
		{
			resourceSOs[i].resourceNameKey = "RNK" + resourceSOs[i].resourceName;
			resourceSOs[i].resourceShortDescriptionKey = "RSDK" + resourceSOs[i].resourceName;
			resourceSOs[i].resourceLongDescriptionKey = "RLDK" + resourceSOs[i].resourceName;
		}
	}
	private void InitializeRarityKeySOs()
	{
		for (int i = 0; i < raritySOs.Count; i++)
		{
			raritySOs[i].rarityNameKey = "RarNK" + raritySOs[i].rarityName;
			raritySOs[i].rarityShortDescriptionKey = "RarSDK" + raritySOs[i].rarityName;
			raritySOs[i].rarityLongDescriptionKey = "RarLDK" + raritySOs[i].rarityName;
		}
	}
	#endregion

}
