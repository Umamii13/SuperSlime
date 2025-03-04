using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject Enemy;

    void LateUpdate()
    {
        transform.position = Enemy.transform.position;

    }
}
