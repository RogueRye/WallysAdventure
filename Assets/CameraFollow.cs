using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public GameObject player;
  
    public float speed = 2;

    private float offset;
    private bool following = false;


    // Use this for initialization
    public void Init()
    {
        offset = transform.position.z - player.transform.position.z;

    }


    public void Tick()
    {
        Follow();
    }

    // Update is called once per frame
    public void LateTick()
    {

        transform.position = player.transform.position + (Vector3.forward * offset);
    }

    public void Follow()
    {
        transform.position = Vector3.Lerp(transform.position, player.transform.position + (Vector3.forward * offset), Time.deltaTime * speed);
    }

}
