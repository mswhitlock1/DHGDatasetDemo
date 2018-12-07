using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Globalization;

public class LoadGesture : MonoBehaviour {
    public string datasetPath;
    public string gestureNum;
    private List<GameObject> jointPoints;

    private string subjectNum;
    private string essaiNum;

    private StreamReader reader;

	// Use this for initialization
	void Start ()
    {
        jointPoints = new List<GameObject>();
		foreach (Transform child in transform)
        {
            jointPoints.Add(child.gameObject);
        }

        System.Random rnd = new System.Random();
        subjectNum = rnd.Next(1, 21).ToString();
        essaiNum = rnd.Next(1, 6).ToString();

        reader = new StreamReader(datasetPath + "gesture_" + gestureNum + "\\finger_1\\subject_" + subjectNum + "\\essai_" + essaiNum + "\\skeleton_world.txt");
    }
	
	// Update is called once per frame
	void Update ()
    {
        string line;
        if((line = reader.ReadLine()) != null)
        {
            string[] rawCoords = line.Split(' ');
            for (int i = 0; i < 22; i++)
            {
                jointPoints[i].transform.localPosition = new Vector3(float.Parse(rawCoords[3 * i], CultureInfo.InvariantCulture.NumberFormat),
                    float.Parse(rawCoords[3 * i + 1], CultureInfo.InvariantCulture.NumberFormat),
                    float.Parse(rawCoords[3 * i + 2], CultureInfo.InvariantCulture.NumberFormat));
            }

        }
        else
        {
            reader = new StreamReader(datasetPath + "gesture_" + gestureNum + "\\finger_1\\subject_" + subjectNum + "\\essai_" + essaiNum + "\\skeleton_world.txt");
        }
    }
}
