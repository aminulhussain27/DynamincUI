using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoreManager : MonoBehaviour {

	//References ot the Panels
	public Transform specialPanelTrans;
	public Transform hitCoinTrans;
	public Transform musketeerTrans;

	//Header buttons
	public Button specialPanelButton;
	public Button hitcoinButton;
	public Button musketeerButton;

	//The Items which wil instantiate at runtime
	public GameObject hitCoinObject;
	public GameObject musketeerObject;

	//Animator refrencess for the Top panel Buttons
	private Animator specialButtonAnim;
	private Animator hitcoinButtonAnim;
	private Animator musketeerButtonAnim;


	void Start () {

		specialPanelButton.onClick.RemoveAllListeners ();
		specialPanelButton.onClick.AddListener (() => {
			SpecialButtonAction();
			});

		hitcoinButton.onClick.RemoveAllListeners ();
		hitcoinButton.onClick.AddListener (() => {
			HitcoinButtonAction();
		});

		musketeerButton.onClick.RemoveAllListeners ();
		musketeerButton.onClick.AddListener (() => {
			MusketeerButtonAction();
		});


		specialButtonAnim = specialPanelButton.GetComponent<Animator> ();
		hitcoinButtonAnim = hitcoinButton.GetComponent<Animator> ();
		musketeerButtonAnim = musketeerButton.GetComponent<Animator> ();

		//Instantiating the objects which needs to show in Store panel
		InstantiateHitCoin ();
		InstantiateMusketeer ();
	}

	public void SpecialButtonAction()
	{
		specialButtonAnim.SetTrigger ("ButtonAnimation");

		specialPanelTrans.gameObject.SetActive (true);
		hitCoinTrans.gameObject.SetActive (false);
		musketeerTrans.gameObject.SetActive (false);


	}

	public void HitcoinButtonAction()
	{
		hitcoinButtonAnim.SetTrigger ("ButtonAnimation");

		specialPanelTrans.gameObject.SetActive (false);
		hitCoinTrans.gameObject.SetActive (true);
		musketeerTrans.gameObject.SetActive (false);
	}

	public void MusketeerButtonAction()
	{
		musketeerButtonAnim.SetTrigger ("ButtonAnimation");

		specialPanelTrans.gameObject.SetActive (false);
		hitCoinTrans.gameObject.SetActive (false);
		musketeerTrans.gameObject.SetActive (true);
	}

	//Instantiate all objects at start only

	void InstantiateHitCoin()
	{
		List<StoreItemData> StoreItemList = JsonData.Instance ().gameData.StoreItemList;
		int hitcoinCount;
		hitcoinCount = StoreItemList.Count == 0 ? 20:  StoreItemList.Count;

		for(int i=1; i <= hitcoinCount ; i++)
		{
			GameObject hitCoin = GameObject.Instantiate (hitCoinObject, hitCoinObject.transform.parent);
			hitCoin.name = "HitCoin_" + i;
			hitCoin.SetActive (true);

			if (i <= StoreItemList.Count && StoreItemList [i] != null) 
			{
				hitCoin.GetComponent<Item> ().UpdateData ( i, StoreItemList [i]);
			}
			else
			{
				hitCoin.GetComponent<Item> ().UpdateData (i);
			}
		}
	}

	void InstantiateMusketeer()
	{
		List<StoreItemData> StoreItemList = JsonData.Instance ().gameData.StoreItemList;
		int musketeerCount;
		musketeerCount = StoreItemList.Count == 0 ? 20:  StoreItemList.Count;

		for(int i=1; i <= musketeerCount ; i++)
		{
			GameObject musketeer = GameObject.Instantiate (musketeerObject, musketeerObject.transform.parent);
			musketeer.name = "Musketeer_" + i;
			musketeer.SetActive (true);

			if ( i <= StoreItemList.Count && StoreItemList [i] != null) 
			{
				musketeer.GetComponent<Item> ().UpdateData (i,StoreItemList [i]);
			}
			else
			{
				musketeer.GetComponent<Item> ().UpdateData (i);
			}
		}
	}

}
