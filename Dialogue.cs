using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Dialogue : MonoBehaviour {

	public GameObject dialogueBox; 
	public GameObject Slide1;
	public GameObject Slide2;
	public GameObject Slide3;
	public GameObject Slide4;
	public string[] dialogues; // Массив строк диалога, которые будут отображаться

	private int currentIndex = 0; // Индекс текущей строки диалога

	void Start () {
		dialogueBox.SetActive(false); 
	}

	void Update () {
		// Если диалоговое окно открыто и нажата левая кнопка мыши
		if (dialogueBox.activeInHierarchy && Input.GetMouseButtonDown(0))
		{
			// Если еще не все строки диалога пройдены, перейти к следующей строке
			if (currentIndex < dialogues.Length - 1)
			{
				currentIndex++;
				// Обновить текст в диалоговом окне
				dialogueBox.GetComponentInChildren<Text>().text = dialogues[currentIndex];
			}
			else
			{
				// Если все строки диалога пройдены, закрыть диалоговое окно
				dialogueBox.SetActive(false);
				StartCoroutine(Door());
			}
		}

		// Если нажата клавиша пробела
		if (Input.GetKeyDown(KeyCode.Space))
		{
			// Если диалоговое окно уже открыто
			if (dialogueBox.activeInHierarchy)
			{
				// Закрыть диалоговое окно
				dialogueBox.SetActive(false);
			}
			else
			{
				// Открыть диалоговое окно и показать первую строку диалога
				dialogueBox.SetActive(true);
				currentIndex = 0;
				dialogueBox.GetComponentInChildren<Text>().text = dialogues[currentIndex];
			}
		}
	}
	IEnumerator Door()
	{
		Slide1.SetActive(false);
		Slide2.SetActive(true);
		yield return new WaitForSeconds(4);
		Slide2.SetActive(false);
		Slide3.SetActive(true);
		yield return new WaitForSeconds(2);
		Slide3.SetActive(false);
		Slide4.SetActive(true);
		yield return new WaitForSeconds(3);
		SceneManager.LoadScene("SampleScene");
	}
}
