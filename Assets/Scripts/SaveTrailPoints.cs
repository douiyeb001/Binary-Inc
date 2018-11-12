using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveTrailPoints : MonoBehaviour {

    const int MAX_POSITIONS = 100;
    Vector3[] TrailRecorded = new Vector3[MAX_POSITIONS];

    void YourFunction()
    {
        int numberOfPositions = GetComponent<TrailRenderer>().GetPositions(TrailRecorded);
    }
}
