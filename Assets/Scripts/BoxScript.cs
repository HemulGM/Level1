using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class BoxScript : MonoBehaviour {

	const int AnimateTime = 50;
	public Animator ani;
	public GameObject cat;
	bool DoClose = false;
	int TimeClose = AnimateTime;
	bool DoTerminate = false;
	int TimeTerminate = AnimateTime;
	bool NowTutorial = true;

	void ForceClose()
	{
		ani.SetBool ("State", false);
		cat.transform.position = gameObject.transform.position;
		cat.transform.localScale = new Vector3 (0.5f, 0.35f, 0.5f);
	}

	void ForceTerminate(){
		Destroy (cat);
		Destroy (gameObject);
		if (NowTutorial) {
			TutorialEnd ();
		};
	}

	public void OnMouseDown(){
		if (ani.GetBool("State")) {
			Close ();
		}
		else {
			Open ();
		};
	}

	public int Id = 0;
	public int CatType = 0;

	public void Open(){		
		ani.SetBool ("State", true);
		cat.transform.position = new Vector3 (gameObject.transform.position.x, gameObject.transform.position.y+1.0f, gameObject.transform.position.z);
		cat.transform.localScale = new Vector3 (0.5f, 0.5f, 0.5f);
		Cats.cats.SelectBox (this);
		if (NowTutorial) {
			TutorialStep ();
		}
		TimeClose = AnimateTime;
	}

	void TutorialEnd(){
		switch (gameObject.tag) {
		case "BStep2":
			{
				GameObject.FindGameObjectWithTag ("Plus").GetComponent<Step> ().Hide ();
				GameObject.FindGameObjectWithTag ("Step1").GetComponent<Step> ().SetTo (GameObject.FindGameObjectWithTag ("BStep3"));
				return;
			}
		case "BStep4":
			{
				GameObject.FindGameObjectWithTag ("Plus").GetComponent<Step> ().Hide ();
				GameObject.FindGameObjectWithTag ("Step1").GetComponent<Step> ().SetTo (GameObject.FindGameObjectWithTag ("BStep5"));
				return;
			}
		case "BStep6":
			{
				GameObject.FindGameObjectWithTag ("Plus").GetComponent<Step> ().Hide ();
				GameObject.FindGameObjectWithTag ("Step1").GetComponent<Step> ().SetTo (GameObject.FindGameObjectWithTag ("BStep7"));	
				return;
			}
		case "BStep8":
			{
				GameObject.FindGameObjectWithTag ("Plus").GetComponent<Step> ().Hide ();
				GameObject.FindGameObjectWithTag ("GameOver").transform.position = new Vector3 (0f, 0f, 0f);	
				return;
			}

		}
	}

	void TutorialStart(){
		if (gameObject.tag == "BStep1") {
			GameObject.FindGameObjectWithTag ("Step1").GetComponent<Step> ().SetTo (GameObject.FindGameObjectWithTag ("BStep1"));
		}
	}

	void TutorialStep(){
		switch (gameObject.tag)
		{
		case "BStep1":
			{
				GameObject.FindGameObjectWithTag ("Step1").GetComponent<Step> ().Hide ();
				GameObject.FindGameObjectWithTag ("Step2").GetComponent<Step> ().SetTo (GameObject.FindGameObjectWithTag ("BStep2"));	
				return;
			}
		case "BStep2":
			{
				GameObject.FindGameObjectWithTag ("Step2").GetComponent<Step> ().Hide ();
				GameObject b1 = GameObject.FindGameObjectWithTag ("BStep1");
				GameObject b2 = GameObject.FindGameObjectWithTag (gameObject.tag);
				GameObject.FindGameObjectWithTag ("Plus").GetComponent<Step> ().SetPlus (b1, b2);	
				return;
			}
		case "BStep3":
			{
				GameObject.FindGameObjectWithTag ("Step1").GetComponent<Step> ().Hide ();
				GameObject.FindGameObjectWithTag ("Step2").GetComponent<Step> ().SetTo (GameObject.FindGameObjectWithTag ("BStep4"));	
				return;
			}
		case "BStep4":
			{
				GameObject.FindGameObjectWithTag ("Step2").GetComponent<Step> ().Hide ();
				GameObject b1 = GameObject.FindGameObjectWithTag ("BStep3");
				GameObject b2 = GameObject.FindGameObjectWithTag (gameObject.tag);
				GameObject.FindGameObjectWithTag ("Plus").GetComponent<Step> ().SetPlus (b1, b2);	
				return;
			}
		case "BStep5":
			{
				GameObject.FindGameObjectWithTag ("Step1").GetComponent<Step> ().Hide ();
				GameObject.FindGameObjectWithTag ("Step2").GetComponent<Step> ().SetTo (GameObject.FindGameObjectWithTag ("BStep6"));	
				return;
			}
		case "BStep6":
			{
				GameObject.FindGameObjectWithTag ("Step2").GetComponent<Step> ().Hide ();
				GameObject b1 = GameObject.FindGameObjectWithTag ("BStep5");
				GameObject b2 = GameObject.FindGameObjectWithTag (gameObject.tag);
				GameObject.FindGameObjectWithTag ("Plus").GetComponent<Step> ().SetPlus (b1, b2);	
				return;
			}
		case "BStep7":
			{
				GameObject.FindGameObjectWithTag ("Step1").GetComponent<Step> ().Hide ();
				GameObject.FindGameObjectWithTag ("Step2").GetComponent<Step> ().SetTo (GameObject.FindGameObjectWithTag ("BStep8"));	
				return;
			}
		case "BStep8":
			{
				GameObject.FindGameObjectWithTag ("Step2").GetComponent<Step> ().Hide ();
				GameObject b1 = GameObject.FindGameObjectWithTag ("BStep7");
				GameObject b2 = GameObject.FindGameObjectWithTag (gameObject.tag);
				GameObject.FindGameObjectWithTag ("Plus").GetComponent<Step> ().SetPlus (b1, b2);	
				return;
			}
		}
	}

	public void Close(){
		DoClose = true;
	}

	public void Terminate()
	{
		DoTerminate = true;
	}

	// Use this for initialization
	void Start () {
		//System.Random rand = new System.Random (344535);
		if (!NowTutorial) {
			CatType = Random.Range (1, 3);
		} else {
			TutorialStart ();
		}
		if (Cats.cats == null) {
			Cats.cats = new Cats ();
		}
		cat = Instantiate(cat);
		cat.GetComponent<Cat>().CatType = CatType;
		ani.SetBool ("State", false);
		cat.transform.position = gameObject.transform.position;
		cat.transform.localScale = new Vector3 (0.5f, 0.35f, 0.5f);
	}
	
	// Update is called once per framera
	void Update () {
		if (DoClose) {
			TimeClose -= 1;
			if (TimeClose <= 0) {
				ForceClose ();
				DoClose = false;
			}
		}

		if (DoTerminate) {
			TimeTerminate -= 1;
			if (TimeTerminate <= 0) {
				ForceTerminate ();
				DoTerminate = false;
			}
		}
	}
}
