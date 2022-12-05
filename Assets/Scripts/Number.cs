using System.Collections;
using System.Collections.Generic;
using System;

public class Number
{
	private List<int> intTriplet = new List<int>();
	private List<int> floatTriplet = new List<int>();
	private bool isFloat = false;



	public Number(List<int>_intTriplet,List<int>_floatTriplet)
	{
		intTriplet = _intTriplet;
		floatTriplet = _floatTriplet;
		
	}
	public override string ToString()
	{
		string _displayString = "";
		VerifyIfNumberIsFloat();
		if(isFloat)
		{
			
			for (int i = 0; i < floatTriplet.Count; i++)
			{
				if(floatTriplet[i]>0)
				{
					_displayString += floatTriplet[i].ToString() + Conventions.Instance.GetFloatNumberDisplaySuffix(i);
					if(floatTriplet.Count-1>i&&floatTriplet[i+1]>0)
					{
						_displayString += floatTriplet[i + 1];
					}
					break;
				}
			}
		}
		else
		{
			int _index = intTriplet.Count - 1;
			_displayString += intTriplet[_index].ToString() + Conventions.Instance.GetIntNumberDisplaySuffix(_index);
			if (_index > 0)
			{
				_displayString += intTriplet[_index - 1];
			}
		}

		return _displayString;
	}

	public void VerifyIfNumberIsFloat()
	{
		if (intTriplet.Count < 1 && intTriplet[0] == 0)
		{
			isFloat = true;
		}
		else
		{
			isFloat = false;
		}
	}
	//private List<int> ParseToNumber(float _valueToParse)
	//{
	//	int index = 1;
	//	List<int> _parsedNumber = new();
	//	do
	//	{
	//		_parsedNumber.Add(_valueToParse % Math.Pow(10, (i*3));
	//	} while (true);


	//	return
	//}
}
