using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevation_Exit : MonoBehaviour
{
    // 玩家走下楼梯时，打开山体碰撞体，关闭山体边界碰撞体
    public Collider2D[] mountainColliders;
    public Collider2D[] boundaryColliders;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) 
        {
            foreach (Collider2D mountain in mountainColliders)
            {
                mountain.enabled = true;
            }
            foreach (Collider2D boundary in boundaryColliders)
            {
                boundary.enabled = false;
            }
            collision.gameObject.GetComponent<SpriteRenderer>().sortingOrder = 10;
        }
    }
}
