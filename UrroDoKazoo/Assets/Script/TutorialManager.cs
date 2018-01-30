using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialManager : MonoBehaviour {

    public GameObject gravando;


	public void Play()
	{
        StartCoroutine(Gravando());
	}


    IEnumerator Gravando()
    {
        {
            yield return new WaitForSecondsRealtime(0.5f);
            gravando.SetActive(true);
           // yield return new WaitForSecondsRealtime(1.5f);
            Debug.Log("Cabou");
            SceneManager.LoadScene(2);

        }
    }
}
