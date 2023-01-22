using UnityEngine;

public class EnableOnPlay : MonoBehaviour
{
    void Start()
    {
        GetComponent<Renderer>().enabled = true;
    }
}
