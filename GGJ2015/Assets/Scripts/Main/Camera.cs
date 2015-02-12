using UnityEngine;
using System.Collections;

public class Camera : MonoBehaviour {

    // the max x position where the camera can go (to the left and right)
    public float leftMargin;
    public float rightMargin;

    // the x pos that will move the camera when the player stands
    public float middle = 0;

    // the smoothness of how the camera will move
    public float smooth = 1.25f;

    // get the player position
    public Transform charPos;

    private Vector3 endMarker;
    
    // Use this for initialization
	void Start () {
        // endMaker starts where the camera is (dont move)
        endMarker = transform.position;
    }

    private Vector3 velocity = Vector3.zero;

	// Update is called once per frame
	void Update () {
        if (charPos.position.x >= middle && charPos.transform.localScale.x < 0) // going to the right
            endMarker = new Vector3(rightMargin, transform.position.y, transform.position.z);

        if (charPos.position.x <= middle && charPos.transform.localScale.x > 0) // going to the left
            endMarker = new Vector3(leftMargin, transform.position.y, transform.position.z);

        // move the camera to endMarker
        transform.position = Vector3.SmoothDamp(transform.position, endMarker, ref velocity, smooth);
    }

}

