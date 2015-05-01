using UnityEngine;
using System.Collections;

public class decor_menu : MonoBehaviour 
{
    void Start()
    {
        Time.timeScale = 1f;
    }

	// Update is called once per frame
	void Update () 
    {
        transform.Rotate(Vector3.forward * Time.deltaTime * 10);
	}
}
