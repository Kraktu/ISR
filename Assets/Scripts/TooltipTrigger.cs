using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Localization;

public class TooltipTrigger : MonoBehaviour, IPointerEnterHandler,IPointerExitHandler
{

	[SerializeField] private string tooltipHeaderKey;
	[SerializeField] private string tooltipDescriptionKey = "";
	[SerializeField] private Sprite tooltipSprite = null;
	[SerializeField] private Color tooltipRarityColor = default;
	[SerializeField] private Color tooltipBackgroundColor=default;
	[SerializeField] private float delayBeforeShowingTooltip = 1f;
	[SerializeField] private string headerLSTable,descripionLSTable;

	Coroutine callTooltipCo;


	// Can be used if not initialized in Editor
	public void InitializeTooltipTrigger(string _headerKey, string _headerTableRef = "", string _descriptionKey = "", string _descTableRef = "", Sprite _sprite = null, Color _rarityColor = default, Color _backgroundColor = default)
	{
		tooltipHeaderKey = _headerKey;
		headerLSTable = _headerTableRef;
		tooltipDescriptionKey = _descriptionKey;
		descripionLSTable = _descTableRef;
		tooltipSprite = _sprite;
		tooltipRarityColor = _rarityColor;
		tooltipBackgroundColor = _backgroundColor;
	}

	public void OnPointerEnter(PointerEventData eventData)
	{


		callTooltipCo = StartCoroutine(DelayingBeforeShowingTooltip());
	}
	public void OnPointerExit(PointerEventData eventData)
	{
		if (callTooltipCo != null)
		{
			StopCoroutine(callTooltipCo);
		}
		TooltipManager.Instance.HideTooltip();
	}

	IEnumerator DelayingBeforeShowingTooltip()
	{
		float _time = 0;
		while (_time<delayBeforeShowingTooltip)
		{
			_time += Time.deltaTime;
			yield return null;
		}
		TooltipManager.Instance.ShowTooltip(tooltipHeaderKey,headerLSTable, tooltipDescriptionKey,descripionLSTable, tooltipSprite, tooltipRarityColor, tooltipBackgroundColor);
	}
}
