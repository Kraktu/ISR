using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BreakInfinity;
using TMPro;
using UnityEngine.UI;

public class PlayerResource : MonoBehaviour
{
	#region PrivateProperties

	#region VsibleProperties

	[SerializeField] private TextMeshProUGUI playerResourceNbrTMP;
	[SerializeField] private Image playerResourceImage;

	#endregion

	#region HidedProperties

	private ResourceSO resourceSO;
	private BigDouble playerResourceNumber=0;

	#endregion

	#endregion

	#region Magic

	#region Getters
	public BigDouble GetResourceNumber()
	{
		return playerResourceNumber;
	}
	public TextMeshProUGUI GetResourceNbrTMP()
	{
		return playerResourceNbrTMP;
	}
	public ResourceSO GetResourceSO()
	{
		return resourceSO;
	}
	public Image GetPlayerResourceImage()
	{
		return playerResourceImage;
	} 
		
	#endregion

	#region Setters
	public void SetResourceNumber(BigDouble _resourceNumber)
	{
		playerResourceNumber = _resourceNumber;
	}
	public void SetResourceNbrTMP(TextMeshProUGUI _resourceNbrTMP)
	{
		playerResourceNbrTMP = _resourceNbrTMP;
	}
	public void SetResourceSO(ResourceSO _resourceSO)
	{
		resourceSO = _resourceSO;
	}
	public void SetPlayerResourceSprite(Sprite _newSprite)
	{
		playerResourceImage.sprite = _newSprite;
	}
	#endregion

	#endregion

	#region UnityFlow


	private void Update()
	{
		playerResourceNbrTMP.text = playerResourceNumber.GetFormatedBigDouble();
	}

	#endregion

	#region Initialization

	public void InitializePlayerResource(ResourceSO _resourceSO,BigDouble _initialResourceNbr)
	{
		resourceSO = _resourceSO;
		playerResourceNumber = _initialResourceNbr;
		playerResourceImage.sprite = _resourceSO.resourceSprite;
	}

	#endregion


}
