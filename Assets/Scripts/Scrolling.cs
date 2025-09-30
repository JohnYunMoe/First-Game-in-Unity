using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scrolling : MonoBehaviour
{
    public float speed;
    public Renderer bkg; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bkg.material.mainTextureOffset += new Vector2(speed * Time.deltaTime, 0);
    }
}
