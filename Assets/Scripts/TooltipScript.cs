using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Localization.Components;
using UnityEngine.Localization;

public class TooltipScript : MonoBehaviour
{
	[SerializeField] private TextMeshProUGUI tooltipHeaderTMP, tooltipDescriptionTMP;
	[SerializeField] private LayoutElement tooltipLayoutElement;
	[SerializeField] private int characterWrapLimit;
	[SerializeField] private Image tooltipImage, tooltipRarityBackground, tooltipBackground;
	[SerializeField] private RectTransform tooltipRectTransform;
	[SerializeField] private float fadingInTime=1;
	[SerializeField] private LocalizeStringEvent headerLSEvent, descriptionLSEvent;
	Vector2 mousePos;


	#region UnityFlow

	private void Update()
	{
		mousePos = Input.mousePosition;
		SetTooltipPositionToCursor();
		SetTooltipPivotPosition();
	}

	#endregion
	// Je stop car crevé :
	// Add 2 LSTable reference in parameters, give it from tooltip trigger, replace LSEvent.LSKey by (LSTref,LSheaderkey)
	// It shoudl be enough, replace at runtime already

	public void SetTooltipInfo(string _headerKey,string _headerTableRef,string _descriptionKey,string _descTableRef, Sprite _sprite, Color _rarityColor, Color _backgroundColor)
	{
		if (_headerKey == string.Empty)
		{
			tooltipHeaderTMP.gameObject.SetActive(false);
		}
		else
		{
			headerLSEvent.StringReference.SetReference(_headerTableRef,_headerKey);
		}		

		if (_descriptionKey == string.Empty)
		{
			tooltipDescriptionTMP.gameObject.SetActive(false);
		}
		else
		{
			descriptionLSEvent.StringReference.SetReference(_descTableRef,_descriptionKey);
		}

		if (_sprite ==null)
		{
			tooltipImage.gameObject.SetActive(false);
		}
		else
		{
			tooltipImage.sprite = _sprite;
		}

		if(_rarityColor!= default)
		{
			tooltipRarityBackground.color = _rarityColor;
		}
		if (_backgroundColor != default)
		{
			tooltipBackground.color = _backgroundColor;
		}
		StartCoroutine(FadingInTooltip());
		SetTooltipSize();
	}

	private void SetTooltipSize()
	{
		int headerLength = tooltipHeaderTMP.text.Length;
		int contentLength = tooltipDescriptionTMP.text.Length;

		tooltipLayoutElement.enabled = (headerLength > characterWrapLimit || contentLength > characterWrapLimit);
	}
	private void SetTooltipPositionToCursor()
	{
		transform.position = mousePos;
	}
	private void SetTooltipPivotPosition()
	{
		if (mousePos.x > (Screen.width / 2))
		{
			tooltipRectTransform.pivot = new Vector2(1, tooltipRectTransform.pivot.y);
		}
		else
		{
			tooltipRectTransform.pivot = new Vector2(0, tooltipRectTransform.pivot.y);
		}
		if (mousePos.y > (Screen.height / 2))
		{
			tooltipRectTransform.pivot = new Vector2(tooltipRectTransform.pivot.x,1);
		}
		else
		{
			tooltipRectTransform.pivot = new Vector2(tooltipRectTransform.pivot.x,0);
		}
	}

	IEnumerator FadingInTooltip()
	{
		float _time = 0;
		float _ratio = 1;

		float _finalHeaderAlpha = tooltipHeaderTMP.color.a;
		float _finalDescAlpha = tooltipDescriptionTMP.color.a;
		float _finalImageAlpha = tooltipImage.color.a;
		float _finalRarityAlpha = tooltipRarityBackground.color.a;
		float _finalBackgroundAlpha = tooltipBackground.color.a;

		tooltipHeaderTMP.color = new Color(tooltipHeaderTMP.color.r, tooltipHeaderTMP.color.g, tooltipHeaderTMP.color.b, 0);
		tooltipDescriptionTMP.color = new Color(tooltipDescriptionTMP.color.r, tooltipDescriptionTMP.color.g, tooltipDescriptionTMP.color.b, 0);
		tooltipImage.color = new Color(tooltipImage.color.r, tooltipImage.color.g, tooltipImage.color.b, 0);
		tooltipRarityBackground.color = new Color(tooltipRarityBackground.color.r, tooltipRarityBackground.color.g, tooltipRarityBackground.color.b, 0);
		tooltipBackground.color = new Color(tooltipBackground.color.r, tooltipBackground.color.g, tooltipBackground.color.b, 0);

		while (_time < fadingInTime)
		{
			_ratio = _time / fadingInTime;
			_time += Time.deltaTime;
			tooltipHeaderTMP.color = new Color(tooltipHeaderTMP.color.r, tooltipHeaderTMP.color.g, tooltipHeaderTMP.color.b,_ratio);
			tooltipDescriptionTMP.color = new Color(tooltipDescriptionTMP.color.r, tooltipDescriptionTMP.color.g, tooltipDescriptionTMP.color.b, _ratio);
			tooltipImage.color = new Color(tooltipImage.color.r, tooltipImage.color.g, tooltipImage.color.b, _ratio);
			tooltipRarityBackground.color = new Color(tooltipRarityBackground.color.r, tooltipRarityBackground.color.g, tooltipRarityBackground.color.b, _ratio);
			tooltipBackground.color = new Color(tooltipBackground.color.r, tooltipBackground.color.g, tooltipBackground.color.b, _ratio);
			yield return null;

		}
		tooltipHeaderTMP.color = new Color(tooltipHeaderTMP.color.r, tooltipHeaderTMP.color.g, tooltipHeaderTMP.color.b, _finalHeaderAlpha);
		tooltipDescriptionTMP.color = new Color(tooltipDescriptionTMP.color.r, tooltipDescriptionTMP.color.g, tooltipDescriptionTMP.color.b, _finalDescAlpha);
		tooltipImage.color = new Color(tooltipImage.color.r, tooltipImage.color.g, tooltipImage.color.b, _finalImageAlpha);
		tooltipRarityBackground.color = new Color(tooltipRarityBackground.color.r, tooltipRarityBackground.color.g, tooltipRarityBackground.color.b, _finalRarityAlpha);
		tooltipBackground.color = new Color(tooltipBackground.color.r, tooltipBackground.color.g, tooltipBackground.color.b, _finalBackgroundAlpha);
	}
}
