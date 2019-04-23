using UnityEngine;
using System.Collections;

public class StarScript : MonoBehaviour
{

    public float scrollSpeed;
    public float tileSizeZ;
    private Vector3 startPosition;
    public Done_GameController gameController;
    private bool beenset;

    // Use this for initialization
    void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        if (!beenset && gameController.score >= 200)
        {
            beenset = true;
            scrollSpeed = scrollSpeed * 50;
        }
        float newPosition = Mathf.Repeat(Time.time * scrollSpeed, tileSizeZ);
        transform.position = startPosition + Vector3.forward * newPosition;
    }
}