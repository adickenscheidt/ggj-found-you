using System.Collections;
using UnityEngine;

public class CreditsController : MonoBehaviour {

    public int EndPosition;
    public float ScrollSpeed;
    public float WaitTime = 0.01f;

    [SerializeField] private GameObject creditsPanel;
    [SerializeField] private GameObject gamePanel;
    [SerializeField] private RectTransform creditsTextObject;
    [SerializeField] private CanvasGroup creditsCanvasGroup;
    private Vector2 creditsTextPanelInitPosition;

    private Coroutine fadeInRoutine;
    private Coroutine scrollInRoutine;
    private Coroutine fadeOutRoutine;

    public void FadeInCredits() {
        creditsPanel.SetActive(true);
        creditsTextPanelInitPosition = creditsTextObject.anchoredPosition;
        fadeInRoutine = StartCoroutine(FadeIn());
    }

    private void RollCredits() {
        scrollInRoutine = StartCoroutine(Scroll());
    }

    private void StopCredits() {
        StopCoroutine(scrollInRoutine);
    }

    private void ResetCredits() {
        creditsTextObject.anchoredPosition = creditsTextPanelInitPosition;
    }

    public void FadeOutCredits() {
        fadeOutRoutine = StartCoroutine(FadeOut());
    }

    private IEnumerator FadeIn() {
        while (creditsCanvasGroup.alpha < 1) {
            yield return new WaitForSecondsRealtime(0.01f);
            creditsCanvasGroup.alpha += 0.025f;
        }
        RollCredits();
        StopCoroutine(fadeInRoutine);
    }

    private IEnumerator Scroll() {
        while (creditsTextObject.offsetMin.y < EndPosition) {
            creditsTextObject.anchoredPosition = new Vector2(creditsTextObject.anchoredPosition.x, creditsTextObject.anchoredPosition.y + ScrollSpeed);
            yield return new WaitForSecondsRealtime(0.01f);
        }
    }

    private IEnumerator FadeOut() {
        while (creditsCanvasGroup.alpha > 0) {
            yield return new WaitForSecondsRealtime(0.01f);
            creditsCanvasGroup.alpha -= 0.05f;
        }
        StopCredits();
        ResetCredits();
        StopCoroutine(fadeOutRoutine);
        creditsPanel.SetActive(false);
    }
}
