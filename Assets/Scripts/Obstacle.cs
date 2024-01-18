using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;


public class Obstacle : MonoBehaviour
{

    /*
     * Two types of obstacles
     *      Vertical
     *      Horizontal
     * Vertical spawns on player's level
     * Horizontal spawn above player
     * 
     * 
     * 
     * 
    */


    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void FixedUpdate()
    {
        transform.Translate(Vector3.left * 2);
    }
}
