using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections;


public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI exesScreen;
    private int exesnum=0;
    private string ex ="X";
    private string exes = " ";
    private Blade blade;
    private spawner spawner;
    public Image fadeimage;
    

    private void Awake()
    {
        blade = FindObjectOfType<Blade>();
        spawner = FindObjectOfType<spawner>();
    }

    private void Start()
    {
        NewGame();
    }

    private void NewGame() {
        Time.timeScale = 1f;
        blade.enabled = true;
        spawner.enabled = true;
        exesScreen.text = exes;
        ClearScene();
     
    }

    private void ClearScene() {
        GameObject[] fruits = GameObject.FindGameObjectsWithTag("Fruit");

            foreach (GameObject fruit in fruits)
        {
            Destroy(fruit.gameObject);
        }


        GameObject[] bombs = GameObject.FindGameObjectsWithTag("Bomb");

            foreach (GameObject bomb in bombs) {
            Destroy(bomb.gameObject);
        }
    }

    public void increse_exes() {
        exesnum++;
        exes = exes + ex ;
        if (exesnum <= 3)
        {
            exesScreen.text = exes;
        }
    }

    public void Bombed() {
        spawner.enabled = false;
        blade.enabled = false;
        StartCoroutine(explodesequence());

    
    }
    private IEnumerator explodesequence() {
        float elapsed = 0f;
        float duration = 0.5f;
        while (elapsed < duration) {

            float t = Mathf.Clamp01(elapsed / duration);
            fadeimage.color = Color.Lerp(Color.clear, Color.white, t);
            Time.timeScale = 1f - t;
            elapsed += Time.unscaledDeltaTime;
            yield return null;
        }

        yield return new WaitForSecondsRealtime(1f);


        NewGame();


        elapsed = 0f;
        while (elapsed < duration)
        {

            float t = Mathf.Clamp01(elapsed / duration);
            fadeimage.color = Color.Lerp(Color.white, Color.clear, t);
          
            elapsed += Time.unscaledDeltaTime;
            yield return null;
        }

    }


}
