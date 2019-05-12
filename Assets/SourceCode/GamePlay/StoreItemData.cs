using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class StoreItemData 
{
	public int cost;

	public int amount;
	public int timePeriod;

}


[System.Serializable]
public class GameData 
{
	public List<StoreItemData> StoreItemList = new List<StoreItemData>();
}
