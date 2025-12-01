using System.Collections;
using UnityEngine;

public class CutsceneTrigger : MonoBehaviour
{
    public Camera cutsceneCamera;
    public Camera playerCamera;
    public GameObject cutsceneImage;

    public AudioSource shopMusic;
    public AudioSource gameplayMusic;

    private bool cutscenePlayed = false;
    private bool playerInside = false;
    private bool triggerEnabled = false;

    private void Start()
    {
        if (cutsceneCamera != null)
            cutsceneCamera.enabled = false;

        StartCoroutine(EnableAfterDelay());
    }

    IEnumerator EnableAfterDelay()
    {
        yield return new WaitForSeconds(1f);
        triggerEnabled = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!triggerEnabled) return;
        if (!other.CompareTag("Player")) return;

        if (!playerInside)
        {
            playerInside = true;

            if (!cutscenePlayed)
                StartCoroutine(PlayCutscene());

            if (shopMusic != null)
            {
                shopMusic.volume = PlayerPrefs.GetFloat("Volume", 1f);
                shopMusic.Play();
            }

            if (gameplayMusic != null)
                gameplayMusic.Pause();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        playerInside = false;

        if (shopMusic != null)
            shopMusic.Stop();

        if (gameplayMusic != null)
            gameplayMusic.UnPause();
    }

    private IEnumerator PlayCutscene()
    {
        cutscenePlayed = true;

        var player = GameObject.FindWithTag("Player");
        var controller = player.GetComponent<PlayerController>();
        var rb = player.GetComponent<Rigidbody>();

        if (controller != null)
            controller.enabled = false;

        if (rb != null)
            rb.constraints = RigidbodyConstraints.FreezeAll;

        playerCamera.enabled = false;
        cutsceneCamera.enabled = true;
        cutsceneImage.SetActive(true);

        Animator camAnim = cutsceneCamera.GetComponent<Animator>();
        Animator imgAnim = cutsceneImage.GetComponent<Animator>();

        yield return null; 

        float camAnimLength = 0f;
        float imgAnimLength = 0f;

        if (camAnim != null)
        {
            camAnim.Play("CutsceneCamAnim", 0, 0f);
            foreach (var clip in camAnim.runtimeAnimatorController.animationClips)
            {
                if (clip.name == "CutsceneCamAnim")
                {
                    camAnimLength = clip.length;
                    break;
                }
            }
        }

        if (imgAnim != null)
        {
            imgAnim.Play("CutsceneImageAnim", 0, 0f);
            foreach (var clip in imgAnim.runtimeAnimatorController.animationClips)
            {
                if (clip.name == "CutsceneImageAnim")
                {
                    imgAnimLength = clip.length;
                    break;
                }
            }
        }

        float waitTime = Mathf.Max(camAnimLength, imgAnimLength);
        if (waitTime > 0f)
            yield return new WaitForSeconds(waitTime);

        cutsceneImage.SetActive(false);
        cutsceneCamera.enabled = false;
        playerCamera.enabled = true;

        if (controller != null)
            controller.enabled = true;

        if (rb != null)
            rb.constraints = RigidbodyConstraints.None;
    }
}