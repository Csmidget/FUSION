using UnityEngine;
using System.Collections;

public class Modifier : Card {

	string structurePrefix;
	string unitPrefix;

	public Modifier (GameObject _prefab, CardType _type, SubType _subType, string _name, Sprite _cardImage, string _cardText, bool _prefabCard,string _structurePrefix,string _unitPrefix, int _range,int _attack,int _defence,int _speed) 
		: base (_prefab, _type, _subType, _name, _cardImage, _cardText, _prefabCard,_range,_attack,_defence,_speed)
	{
		structurePrefix = _structurePrefix;
		unitPrefix = _unitPrefix;
	}

	public string UnitPrefix {
		get {
			return unitPrefix;
		}
	}

	public string StructurePrefix {
		get {
			return structurePrefix;
		}
	}
}
