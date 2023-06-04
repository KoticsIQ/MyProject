using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Horror : MonoBehaviour
{
	public GameObject pointLight;
	public AudioClip lamp;
	public AudioSource lamp1;
	public AudioClip horror;
	public AudioSource horror1;
	public AudioClip metal;
	public AudioSource metal1;
    // Start is called before the first frame update
    void Start()
    {
		pointLight.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	private void OnTriggerEnter(Collider collider)
	{
		if(collider.CompareTag("Trigger"))
		{
			StartCoroutine(Light());
		}
	}
	IEnumerator Light()
	{
		lamp1.PlayOneShot(lamp);
		pointLight.SetActive(false);
		yield return new WaitForSeconds(2);
		lamp1.PlayOneShot(lamp);
		pointLight.SetActive(true);
		yield return new WaitForSeconds(1);
		lamp1.PlayOneShot(lamp);
		pointLight.SetActive(false);
		horror1.PlayOneShot(horror);
		yield return new WaitForSeconds(4);
		metal1.PlayOneShot(metal);
		yield return new WaitForSeconds(9);
		Destroy(metal1);
	}
}
