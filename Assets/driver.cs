using UnityEngine;

public class driver : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0,0.01f,0);
        transform.Rotate(0,0,0.01f);
    }
}
