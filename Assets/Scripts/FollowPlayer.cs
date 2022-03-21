using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FollowPlayer : MonoBehaviour
{
    /*
    [SerializeField] private GameObject player;
    [SerializeField] private Vector3 offset;
    [SerializeField] private float smoothness;

    private void Update()
    {
        if (player != null)
        {
            transform.position = Vector3.Lerp(transform.position, player.transform.position + offset, smoothness);
        }
    }
    */
    [SerializeField] private Text scoreText;
    public GameObject player; // drag player gameobject into this in inspector
    public float cameraFollowSpeed; // how fast it should follow
    public float offset; // how far u want the camera away
    public bool isSmoothFollow = true; // lerp or not
    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player)
        {
            Vector3 newCameraPosition = transform.position;
            newCameraPosition.x = player.transform.position.x;
            newCameraPosition.z = player.transform.position.z - offset;
            // you might need to change these

            if (!isSmoothFollow)
            {
                transform.position = newCameraPosition;
            }
            else
            {
                transform.position = Vector3.Lerp(transform.position, newCameraPosition, cameraFollowSpeed * Time.deltaTime);
            }
        }
    }
}
