using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandSegment : MonoBehaviour {
    public string startPoint;
    public string endPoint;

    private GameObject startObject;
    private GameObject endObject;
	// Use this for initialization
	void Start () {
        startObject = GameObject.Find("Point" + startPoint);
        endObject = GameObject.Find("Point" + endPoint);
	}
	
	// Update is called once per frame
	void Update ()
    {
        Vector3 pos = Vector3.Lerp(startObject.transform.position, endObject.transform.position, (float)0.5);
        transform.localScale = new Vector3(0.025f, Vector3.Distance(startObject.transform.position, endObject.transform.position) / 2, 0.025f) / transform.parent.localScale.x;
        transform.position = pos;
        transform.up = startObject.transform.position - endObject.transform.position;
    }
}
