using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Elevator : MonoBehaviour
{
	public GameObject animationObject;
	public GameObject animationObject1;
	public List<Transform> levels;
	public float speed = 0.01f;
	[HideInInspector]public int n;
	bool motion = false;
	public AudioSource audioSource;
	public GameObject audioSource1;
	public Collider collider1;
	public GameObject audio;
	public void MyVoid(int level)
	{
		n = level;
		motion = true;
	}
    // Start is called before the first frame update
    void Start()
    {
		audioSource1.SetActive(false);
		animationObject.GetComponent<Animator>().Play("elevatorStay");
		audioSource = GetComponent<AudioSource>();
		 
    }
	private void OnTriggerEnter(Collider collider)
	{
		if(this.CompareTag("Elevator") & collider.CompareTag("Player"))
		{
			animationObject.GetComponent<Animator>().Play("elevatorOpen");
			Destroy(audio);
			Destroy(collider1);
			animationObject.GetComponent<Animator>().Play("elevatorClose");
			animationObject.GetComponent<Animator>().Play("elevatorStay");
			StartCoroutine(elevator1());
		}
		 
	}

	private void OnTriggerExit(Collider collider)
	{
		if(collider.gameObject.tag == "Player")
		{
			StartCoroutine(elevator());
		}

	}
	private void OnTriggerStay(Collider collider)
	{
		if(collider.gameObject.tag == "")
		{
			 
		}

	}
	private void OnCollisionEnter(Collision collision)
	{
		if(collision.gameObject.tag == "Player")
		{
			 
			MyVoid(1);
		 

		}
		 
	}
    // Update is called once per frame
    void Update()
    {
		if (motion == true)
		{
			transform.position = Vector3.MoveTowards(transform.position, levels[n].GetComponent<Transform>().position,speed);
			if (transform.position == levels[n].GetComponent<Transform>().position)
			{
				motion = false;	
				animationObject.GetComponent<Animator>().Play("elevatorOpen");
			}
		}
    }
	IEnumerator elevator()
	{
		animationObject.GetComponent<Animator>().Play("elevatorClose");
		yield return new WaitForSeconds(5);
		animationObject.GetComponent<Animator>().Play("elevatorStay");
	}
	IEnumerator elevator1()
	{
		audioSource.Play(); 
		yield return new WaitForSeconds(30);
		audioSource1.SetActive(true);
		yield return new WaitForSeconds(7);
		animationObject.GetComponent<Animator>().Play("elevatorOpen");
		yield return new WaitForSeconds(15);
		SceneManager.LoadScene("level1");
	}
}
