using UnityEngine;
using System.Collections;

public class NotesScript : MonoBehaviour
{

    private float startTime;
    float time = 0.5f;
    private Vector3 startPosition, endPosition;
    private bool startMovingToXY = false;
    public static int removeNotesNum = 0;
    // Use this for initialization
    void Start()
    {

        float rand = Random.Range(0f, 360f);
        endPosition = new Vector3(8.0f * Mathf.Sin(rand * (Mathf.PI * 180)), 8.0f * Mathf.Cos(rand * (Mathf.PI * 180)), -5f);
        this.gameObject.transform.Rotate(new Vector3(90, 0, 0));
    }
    void OnEnable()
    {
        if (time <= 0)
        {
            transform.position = endPosition;
            enabled = false;
            Destroy(this.gameObject);
            return;
        }

        startTime = Time.timeSinceLevelLoad;
        startPosition = transform.position;
    }
    // Update is called once per frame
    void Update()
    {
        var diff = Time.timeSinceLevelLoad - startTime;
        if (diff > time)
        {
            transform.position = endPosition;
            enabled = false;
            Destroy(this.gameObject);
        }
        var rate = diff / time;
        //var pos = curve.Evaluate(rate);
        transform.position = Vector3.Lerp(startPosition, endPosition, rate);
        //transform.position = Vector3.Lerp (startPosition, endPosition, pos);

    }

    void OnCollisionEnter(Collision collision)
    {
        Destroy(this.gameObject);
        NotesScript.removeNotesNum++;
        Debug.Log("Hit");
        Singleton<SEPlayer>.instance.Play();
    }
}
