using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BreakInfinity;

public class Resource : MonoBehaviour
{

	[SerializeField] private string resourceName;
	[SerializeField] private BigDouble resourceNumber;

	#region Magic

	#region Getters
	public BigDouble GetResourceNumber()
	{
		return resourceNumber;
	}
	public string GetResourceName()
	{
		return resourceName;
	}
	#endregion

	#region Setters
	public void SetResourceNumber(BigDouble _resourceNumber)
	{
		resourceNumber = _resourceNumber;
	}
	public void SetResourceName(string _resourceName)
	{
		resourceName = _resourceName;
	}
	#endregion
	#endregion

}
