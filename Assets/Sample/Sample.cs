using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sample : MonoBehaviour
{
    ClassA mA;
    // Start is called before the first frame update
    void Start()
    {
        var gameObject = FindObjectOfType<ClassA>();
        if(gameObject)
        {
            Debug.Log("Hit ClassA");

        }
    }


}
