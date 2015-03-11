using UnityEngine;
using System.Collections;

public class decor_menu : MonoBehaviour 
{
	// Update is called once per frame
	void Update () 
    {
        transform.Rotate(Vector3.forward * Time.deltaTime * 10);
	}
}
