using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class a_hook : MonoBehaviour {

    PlayerBehaviour owner;

	// Use this for initialization
	void Start () {
        owner = GetComponentInParent<PlayerBehaviour>();	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Push()
    {
        owner.Push();
    }
}
