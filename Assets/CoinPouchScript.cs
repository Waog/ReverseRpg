using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CoinPouchScript : MonoBehaviour {

	public Text coinText;
	int _collectedCoins = 0;
	public int collectedCoins {
	
		get{ 
			return _collectedCoins;
		}
		set {
			_collectedCoins = value;
			coinText.text = "" + _collectedCoins;
		}

	} 

}
