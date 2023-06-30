using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour {

    public int index;

    private float timer = 0;

    private bool carregando;

    private void Update()
    {
        if (!carregando)
        {
            timer += Time.deltaTime;
            if (timer > 0.5f)
            {
                LoadLevel(index);
                carregando = true;
                timer = 0;
            }
        }

    }


    public void LoadLevel(int sceneIndex)
    {
        StartCoroutine(LoadAsync(sceneIndex));
    }

    //mostrar o progresso
    IEnumerator LoadAsync(int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);

        while (!operation.isDone)
        {
            //progresso
            float progress = Mathf.Clamp01(operation.progress / 0.9f);
            yield return null;
        }
        
    }

}
