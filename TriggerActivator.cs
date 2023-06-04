using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerActivator : MonoBehaviour
{
	public AudioSource audioSource;
	public GameObject Triger;

    // Start is called before the first frame update
    void Start()
    {
		audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	private void OnTriggerEnter(Collider collider)
	{
		  
		if(this.CompareTag("Trigger") & collider.CompareTag("Player"))
		{
			audioSource.Play();
		 
		}

	}
}
