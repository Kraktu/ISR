using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TooltipManager : MonoBehaviour
{
	#region Singleton
	public static TooltipManager Instance { get; private set; }
	public bool destroyOnLoad = true;
	#endregion
	[SerializeField]private GameObject tooltipPrefab;
	[SerializeField] private Canvas frontCanvas;
	private TooltipScript instantiatedTooltip;

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


	public void ShowTooltip(string _headerKey, string _headerTableRef="", string _descriptionKey="", string _descTableRef="", Sprite _sprite=null, Color _rarityColor=default, Color _backgroundColor=default)
	{
		instantiatedTooltip = Instantiate(tooltipPrefab,frontCanvas.transform).GetComponent<TooltipScript>();
		instantiatedTooltip.SetTooltipInfo(_headerKey, _headerTableRef,_descriptionKey,_descTableRef, _sprite, _rarityColor, _backgroundColor);
	}
	public void HideTooltip()
	{
		if(instantiatedTooltip!=null)
		{
			Destroy(instantiatedTooltip.gameObject);
		}
	}
}
