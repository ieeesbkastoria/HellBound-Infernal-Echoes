using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;


public class EnemyGFX: MonoBehaviour
{  
    public AIPath aiPath;
    private SpriteRenderer sprite;
    public float Scale;
    // Update is called once per frame
    void Update()
    {
        if(aiPath.desiredVelocity.x >= 0.01f)
        {
            transform.localScale = new Vector3(Scale, Scale, Scale);
        }
        else if (aiPath.desiredVelocity.x <= -0.01f)
        {
            transform.localScale = new Vector3(-Scale, Scale, Scale);
        }
    }
}