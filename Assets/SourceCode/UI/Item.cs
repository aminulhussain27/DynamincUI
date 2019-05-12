using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;





public class Item : MonoBehaviour
{
    // Start is called before the first frame update
	public Text cost;
	public Text coinAmount;
	public Text discountPercentage;
	public Button buyButton;

	public ObjectType objectType;
	public enum ObjectType
	{
		SPECIAL,
		HITCOIN,
		MUSKETEER
	};

	//Updating the dummy data


	public void UpdateData(int index, StoreItemData data = null )
	{
		if (data != null) {

			if (objectType == ObjectType.HITCOIN) {
				cost.text = "$" + data.cost.ToString ();
				coinAmount.text = data.amount.ToString ();
			} else if (objectType == ObjectType.MUSKETEER) {
				cost.text = "$" + cost.ToString ();
				coinAmount.text = data.timePeriod + " MONTHS";
				discountPercentage.text = "SAVE " + Random.Range (15, 50) + "%";
			}
		}

		// Incase data is coming null--> we will set default random data
		else
		{
			if(objectType == ObjectType.HITCOIN)
			{
				cost.text ="$" + (20 * index).ToString();
				coinAmount.text = (50 * index).ToString();
			}
			else if(objectType == ObjectType.MUSKETEER)
			{
				cost.text ="$" + (10 * index).ToString();
				coinAmount.text =  index + " MONTHS";
				discountPercentage.text = "SAVE " + Random.Range (15, 50) + "%";
			}
		}
	}


}

