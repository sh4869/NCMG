using UnityEngine;
using System.Collections;

public class NotesScript : MonoBehaviour
{

    int[,] positions = new int[,] { { 5, 5 }, { -5, 5 }, { 5, -5 }, { -5, -5 } };
    private float startTime;
    float time = 1;
    private Vector3 startPosition,endPosition;
    private bool startMovingToXY = false;
    // Use this for initialization
    void Start()
    {
        int space = Random.Range(0, 4);
		endPosition = new Vector3(positions[space, 0],positions[space, 1],-10);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        if (pos.z == endPosition.z)
        {
            Destroy(this.gameObject);
        }
        else if (pos.z < 5)
        {
            if (!startMovingToXY)
            {
                startTime = Time.timeSinceLevelLoad;
                startPosition = transform.position;
                startMovingToXY = true;
            } 
			var diff = Time.timeSinceLevelLoad - startTime;
			var rate = diff / time;
			pos = Vector3.Lerp(startPosition,endPosition,rate);
        }
        else
        {
            pos.z -= 0.5f;
        }

        transform.position = pos;
    }
    void OnCollisionEnter(Collision collision)
    {

    }
    void OnCollisionStay(Collision collision)
    {

    }
}
