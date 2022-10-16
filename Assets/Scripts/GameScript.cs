using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameScript : MonoBehaviour
{
    [SerializeField] private CameraFollowScript Cam;
    [SerializeField] private Camera MainCam;
    [SerializeField] private GameObject post;
    [SerializeField] private GameObject GameStuff;
    [SerializeField] private GameObject MainMenu;
    [SerializeField] private AudioClip HoverSound;
    [SerializeField] private AudioSource BackgroundMusic;


    private AudioSource aSource;
    private float volume = 1f;

    private void Start()
    {
        aSource = GetComponent<AudioSource>();
        BackgroundMusic.Play();
    }

    private void Update()
    {
        aSource.volume = volume / 3;
        BackgroundMusic.volume = volume;
    }

    public void updateVolume(float newVolume)
    {
        volume = newVolume;
    }

    public void Hover()
    {
        aSource.PlayOneShot(HoverSound);
    }


    public void MoveTo(GameObject x)
    {
        Cam.SateliteView = x;
    }

    public void TweenEffectRight(GameObject x)
    {
        x.transform.position = new Vector3(x.transform.position.x + MainCam.pixelWidth, x.transform.position.y, x.transform.position.z);
        Cam.LeanIsCalled = true;
        Cam.SateliteViewPanel = x;
    }

    public void TweenEffectLeft(GameObject x)
    {
        x.transform.position = new Vector3(x.transform.position.x - MainCam.pixelWidth, x.transform.position.y, x.transform.position.z);
        Cam.LeanIsCalled = true;
        Cam.SateliteViewPanel = x;
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void StartGame(GameObject Menu)
    {
        Animator anim = post.GetComponent<Animator>();
        LeanTween.moveLocalY(Menu, -1000f, 0.8f);
        anim.SetTrigger("PostProcessingTrigger");
        StartCoroutine(EndMenu());
    }

    private IEnumerator EndMenu()
    {
        yield return new WaitForSeconds(2f);
        GameStuff.SetActive(true);
        MainMenu.SetActive(false);

    }
}
