using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{

    [SerializeField] GameObject player;

    // Update is called once per frame
    void Update()
    {
        Follow();
    }

    void Follow()
    {
        float x = player.transform.position.x;
        float y = player.transform.position.y;

        transform.position = new Vector3(x, y, -14);
    }
}
