using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Button[] Buttons;
    [SerializeField] private Image Logo;
    [SerializeField] private TextMeshProUGUI ReleaseLogo;
    [SerializeField] private TextMeshProUGUI OptionsText;
    [SerializeField] private Image OptionsMenu;
    [SerializeField] private Image ExitMenu;
    [SerializeField] private CanvasGroup FadeImage;
    [SerializeField] private int sceneIndex;
    bool wantToStartGame = false;

    public void Options(){
        Logo.transform.LeanMoveLocal(new Vector2(3000, 780), 1f).setEaseInOutCubic();
        ReleaseLogo.transform.LeanMoveLocal(new Vector2(-2500, -1030), 1f).setEaseInOutCubic();
        StartCoroutine(ButtonsIEnumerator());
        StartCoroutine(Buttons2IEnumerator());
        StartCoroutine(OptionsMenuIEnumerator());
    }

    public void OptionsClose(){
        OptionsMenu.transform.LeanMoveLocal(new Vector2(0f, -2000f), 1f).setEaseInOutCubic();
        StartCoroutine(ButtonsIEnumeratorClose());
        StartCoroutine(Buttons2IEnumeratorClose());
        StartCoroutine(LogoIEnumeratorClose());
    }

    public void Exit(){
        Logo.transform.LeanMoveLocal(new Vector2(3000, 780), 1f).setEaseInOutCubic();
        ReleaseLogo.transform.LeanMoveLocal(new Vector2(-2500, -1030), 1f).setEaseInOutCubic();
        StartCoroutine(ButtonsIEnumerator());
        StartCoroutine(ExitMenuIEnumerator());
    }

    public void Yes(){
        Application.Quit();
        Debug.Log("Quit");
    }

    public void No(){
        ExitMenu.transform.LeanMoveLocal(new Vector2(0f, -2000f), 1f).setEaseInOutCubic();
        StartCoroutine(LogoIEnumeratorClose());
        StartCoroutine(ButtonsIEnumeratorClose());
    }

    public void NewNightAndContinue(){
        Logo.transform.LeanMoveLocal(new Vector2(3000, 780), 1f).setEaseInOutCubic();
        ReleaseLogo.transform.LeanMoveLocal(new Vector2(-2500, -1030), 1f).setEaseInOutCubic();
        StartCoroutine(ButtonsIEnumerator());
        wantToStartGame = true;
    }

    private void FixedUpdate() {
        FadeImage.alpha -= 0.01f;
    }

    private void Update() {
        if(Buttons[0].transform.localPosition.x == 3000 && wantToStartGame){
            StartCoroutine(LoadLevel(sceneIndex));
        }
    }

    private IEnumerator ButtonsIEnumerator(){
        yield return new WaitForSeconds(0.2f);
        Buttons[0].transform.LeanMoveLocal(new Vector2(3000, 133), 1f).setEaseInOutCubic();
        Buttons[1].transform.LeanMoveLocal(new Vector2(3000, -67), 1f).setEaseInOutCubic();
        Buttons[2].transform.LeanMoveLocal(new Vector2(3000, -267), 1f).setEaseInOutCubic();
    }
    private IEnumerator Buttons2IEnumerator(){
        yield return new WaitForSeconds(0.2f);
        Buttons[3].transform.LeanMoveLocal(new Vector2(-1710, -993), 1f).setEaseInOutCubic();
        OptionsText.transform.LeanMoveLocal(new Vector2(-1512, 906), 1f).setEaseInOutCubic();
    }

    private IEnumerator ButtonsIEnumeratorClose(){
        yield return new WaitForSeconds(0.2f);
        Buttons[0].transform.LeanMoveLocal(new Vector2(1170, 133), 1f).setEaseInOutCubic();
        Buttons[1].transform.LeanMoveLocal(new Vector2(1170, -67), 1f).setEaseInOutCubic();
        Buttons[2].transform.LeanMoveLocal(new Vector2(1170, -267), 1f).setEaseInOutCubic();
    }

    private IEnumerator Buttons2IEnumeratorClose(){
        yield return new WaitForSeconds(0.2f);
        Buttons[3].transform.LeanMoveLocal(new Vector2(-2130, -993), 1f).setEaseInOutCubic();
        OptionsText.transform.LeanMoveLocal(new Vector2(-2328, 906), 1f).setEaseInOutCubic();
    }

    private IEnumerator LogoIEnumeratorClose(){
        yield return new WaitForSeconds(0.4f);
        Logo.transform.LeanMoveLocal(new Vector2(1170, 780), 1f).setEaseInOutCubic();
        ReleaseLogo.transform.LeanMoveLocal(new Vector2(-1600, -1030), 1f).setEaseInOutCubic();
    }

    private IEnumerator OptionsMenuIEnumerator(){
        yield return new WaitForSeconds(0.3f);
        OptionsMenu.transform.LeanMoveLocal(new Vector2(0f, 0f), 1f).setEaseInOutCubic();
    }

    private IEnumerator ExitMenuIEnumerator(){
        yield return new WaitForSeconds(0.25f);
        ExitMenu.transform.LeanMoveLocal(new Vector2(0f, 0f), 1f).setEaseInOutCubic();
    }

    private IEnumerator LoadLevel(int sceneIndex){
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
        while(!operation.isDone){
            float progress = Mathf.Clamp01(operation.progress/.9f);
            Debug.Log(progress);

            yield return null;
        }
    }
}
