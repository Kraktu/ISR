using System.Collections;
using System.Collections.Generic;
using System;

public class Number
{
	private List<int> intTriplet = new List<int>();
	private List<int> floatTriplet = new List<int>();
	private bool isFloat = false;


	#region Magic
	public Number(List<int>_intTriplet,List<int>_floatTriplet)
	{
		intTriplet = _intTriplet;
		floatTriplet = _floatTriplet;
		
	}
	#region Getters
	public List<int> GetIntList()
	{
		return intTriplet;
	}
	public List<int> GetFloatList()
	{
		return floatTriplet;
	}
	public bool GetIsFloat()
	{
		return isFloat;
	}
	#endregion
	#region Setters
	public void SetIntList(List<int> _intTriplet)
	{
		intTriplet = _intTriplet;
	}
	public void SetFloatList(List<int> _floatTriplet)
	{
		floatTriplet = _floatTriplet;
	}
	public void SetIsFloat(bool _isFloat)
	{
		isFloat = _isFloat;
	}

	#endregion
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
	#region Operations Overload
	#region Math
	public static Number operator +(Number _a)
	{
		return _a;
	}
	public static Number operator -(Number _a)
	{
		for (int i = 0; i < _a.intTriplet.Count; i++)
		{
			_a.intTriplet[i] = -_a.intTriplet[i];
		}
		for (int i = 0; i < _a.floatTriplet.Count; i++)
		{
			_a.floatTriplet[i] = -_a.floatTriplet[i];
		}
		return _a ;
	}
	public static Number operator +(Number _a,Number _b)
	{
		Number _biggerNumber;
		Number _smallerNumber;
		if (_a>_b)
		{
			_biggerNumber = _a;
			_smallerNumber = _b;
		}
		else
		{
			_biggerNumber = _b;
			_smallerNumber = _a;
		}
		// A continuer, mais je pense que j'en aurais pas besoin en fait... Un double va jusque 1.7976931348623157E+308. Je vais préstige à E300 (par exemple), mécanique plus intéressantes.
	}
	#endregion
	#region Bool
	public static bool operator >(Number _a, Number _b)
	{
		int _aIntLength = _a.intTriplet.Count;
		int _bIntLength = _b.intTriplet.Count;
		int _aFloatLength = _a.floatTriplet.Count;
		int _bFloatLength = _b.floatTriplet.Count;

		if (_aIntLength > _bIntLength)
		{
			return true;
		}
		else if (_aIntLength == _bIntLength)
		{
			for (int i = _aIntLength-1;  i >= 0; i--)
			{
				if (_a.intTriplet[i] > _b.intTriplet[i])
				{
					return true;
				}
				else if (_a.intTriplet[i] < _b.intTriplet[i])
				{
					return false;
				}
			}

			int _lowestFloatCount = LowerOrEqualInt(_aFloatLength, _bFloatLength);
			for (int i = 0; i < _lowestFloatCount; i++)
			{
				if (_a.floatTriplet[i] > _b.floatTriplet[i])
				{
					return true;
				}
				else if (_aFloatLength > _bFloatLength)
				{
					return true;
				}
			}
		}
		return false;
	}
	public static bool operator >=(Number _a, Number _b)
	{
		int _aIntLength = _a.intTriplet.Count;
		int _bIntLength = _b.intTriplet.Count;
		int _aFloatLength = _a.floatTriplet.Count;
		int _bFloatLength = _b.floatTriplet.Count;

		if (_aIntLength > _bIntLength)
		{
			return true;
		}
		else if (_aIntLength == _bIntLength)
		{
			for (int i = _aIntLength - 1; i >= 0; i--)
			{
				if (_a.intTriplet[i] > _b.intTriplet[i])
				{
					return true;
				}
				else if (_a.intTriplet[i] < _b.intTriplet[i])
				{
					return false;
				}
			}

			int _lowestFloatCount = LowerOrEqualInt(_aFloatLength, _bFloatLength);
			for (int i = 0; i < _lowestFloatCount; i++)
			{
				if (_a.floatTriplet[i] > _b.floatTriplet[i])
				{
					return true;
				}
				else if (_aFloatLength >= _bFloatLength)
				{
					return true;
				}
			}
		}
		return false;
	}	
	public static bool operator <(Number _a, Number _b)
	{
		int _aIntLength = _a.intTriplet.Count;
		int _bIntLength = _b.intTriplet.Count;
		int _aFloatLength = _a.floatTriplet.Count;
		int _bFloatLength = _b.floatTriplet.Count;

		if (_aIntLength < _bIntLength)
		{
			return true;
		}
		else if (_aIntLength == _bIntLength)
		{
			for (int i = _aIntLength - 1; i >= 0; i--)
			{
				if (_a.intTriplet[i] < _b.intTriplet[i])
				{
					return true;
				}
				else if (_a.intTriplet[i] > _b.intTriplet[i])
				{
					return false;
				}
			}

			int _lowestFloatCount = LowerOrEqualInt(_aFloatLength, _bFloatLength);
			for (int i = 0; i < _lowestFloatCount; i++)
			{
				if (_a.floatTriplet[i] < _b.floatTriplet[i])
				{
					return true;
				}
				else if (_aFloatLength < _bFloatLength)
				{
					return true;
				}
			}
		}
		return false;
	}
	public static bool operator <=(Number _a, Number _b)
	{
		int _aIntLength = _a.intTriplet.Count;
		int _bIntLength = _b.intTriplet.Count;
		int _aFloatLength = _a.floatTriplet.Count;
		int _bFloatLength = _b.floatTriplet.Count;

		if (_aIntLength < _bIntLength)
		{
			return true;
		}
		else if (_aIntLength == _bIntLength)
		{
			for (int i = _aIntLength - 1; i >= 0; i--)
			{
				if (_a.intTriplet[i] < _b.intTriplet[i])
				{
					return true;
				}
				else if (_a.intTriplet[i] > _b.intTriplet[i])
				{
					return false;
				}
			}

			int _lowestFloatCount = LowerOrEqualInt(_aFloatLength, _bFloatLength);
			for (int i = 0; i < _lowestFloatCount; i++)
			{
				if (_a.floatTriplet[i] < _b.floatTriplet[i])
				{
					return true;
				}
				else if (_aFloatLength <= _bFloatLength)
				{
					return true;
				}
			}
		}
		return false;
	}
	public static bool operator ==(Number _a, Number _b)
	{
		int _aIntLength = _a.intTriplet.Count;
		int _bIntLength = _b.intTriplet.Count;
		int _aFloatLength = _a.floatTriplet.Count;
		int _bFloatLength = _b.floatTriplet.Count;

		if (_aIntLength == _bIntLength && _aFloatLength ==_bFloatLength)
		{
			if(!IsSameLengthNumberPartTheSame(_a.intTriplet, _b.intTriplet))
			{
				return false;
			}


			if (!IsSameLengthNumberPartTheSame(_a.floatTriplet, _b.floatTriplet))
			{
				return false;
			}
			return true;
		}
		return false;
	}	
	public static bool operator !=(Number _a, Number _b)
	{
		int _aIntLength = _a.intTriplet.Count;
		int _bIntLength = _b.intTriplet.Count;
		int _aFloatLength = _a.floatTriplet.Count;
		int _bFloatLength = _b.floatTriplet.Count;

		if (_aIntLength == _bIntLength && _aFloatLength == _bFloatLength)
		{
			if (!IsSameLengthNumberPartTheSame(_a.intTriplet, _b.intTriplet))
			{
				return true;
			}
			if (!IsSameLengthNumberPartTheSame(_a.floatTriplet, _b.floatTriplet))
			{
				return true;
			}
			return false;
		}
		return true;
	}

	#endregion

	#endregion

	#endregion

	#region Helpers
	private static void VerifyIfNumberIsFloat()
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
	private static int LowerOrEqualInt(int _a,int _b)
	{
		if (_a >= _b)
		{
			return _b;
		}
		else
		{
			return _a;
		}
	}
	private static int HigherOrEqualInt(int _a, int _b)
	{
		if (_a <= _b)
		{
			return _b;
		}
		else
		{
			return _a;
		}
	}
	private static bool IsSameLengthNumberPartTheSame(List<int> _a,List<int> _b)
	{
		for (int i = _a.Count - 1; i >= 0; i--)
		{
			if (_a[i] != _b[i])
			{
				return false;
			}
		}
		return true;
	}
	#endregion

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
