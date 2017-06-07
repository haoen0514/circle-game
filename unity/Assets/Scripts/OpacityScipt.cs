using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class OpacityScipt : MonoBehaviour {

	public SpriteRenderer test;
	Color testColor;
	public Ease fadingFunction;


	// Use this for initialization
	void Start () {
		test.DOFade (0f, 2f).SetEase (Ease.OutElastic);;
	}
	
	// Update is called once per frame
	void Update () {
	}
}