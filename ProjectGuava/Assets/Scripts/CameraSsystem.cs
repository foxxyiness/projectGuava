using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSsystem : MonoBehaviour
{
    public GameObject player;
    public float minX, minY, maxX, maxY;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    private void LateUpdate()
    {
        float x = Mathf.Clamp(player.transform.position.x, minX, maxX);
        float y = Mathf.Clamp(player.transform.position.y, minY, maxY);
        gameObject.transform.position = new Vector3(x, y, gameObject.transform.position.z);
    }
}
