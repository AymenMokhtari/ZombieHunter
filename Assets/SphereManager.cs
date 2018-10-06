using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereManager : MonoBehaviour {
  public  GameObject sphere;
    public static bool shooted = false;
	// Use this for initialization
	void Start () {
        
        Instantiate(sphere);	
	}
	
	// Update is called once per frame
	void Update () {
if (shooted)
        { shooted = false;
            Instantiate(sphere);
        }		
	}
}
