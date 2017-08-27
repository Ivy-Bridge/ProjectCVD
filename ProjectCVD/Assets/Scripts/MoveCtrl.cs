using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCtrl : MonoBehaviour {
    [SerializeField]
    private bool isLeft = false;

    [SerializeField]
    private float speed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(isLeft)
            this.transform.Translate(new Vector2(0.01f, 0));
        else
            this.transform.Translate(new Vector2(-0.01f, 0));
    }
}
