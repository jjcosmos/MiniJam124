using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointSystem : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "HandW")
        {
            //add to score
            UIManager.AddScore(Random.Range(1, 3));
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
    }
}
