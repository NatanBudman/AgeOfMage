using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Canvas : MonoBehaviour
{
    GameManager manager;

    public AudioMixer Mixer;

    public Slider Music;
    public Slider Sound;
    public GameObject Pause;
    public GameObject Options;
    public GameObject Controls;
    // Start is called before the first frame update
    private void Awake()
    {
        Music.onValueChanged.AddListener(ChangeVolMaster);
        Sound.onValueChanged.AddListener(ChangeVolSound);
    }
    void Start()
    {
        manager = FindObjectOfType<GameManager>();
        //room = FindObjectOfType<Room>();
        //generator = FindObjectOfType<EnemyGenerator>();
    }
    // Update is called once per frame
    void Update()
    {
        MenuPause();
    }
    void MenuPause() 
    {
        if (manager.GamePuase)
        {
            Pause.SetActive(true);
        }
        else if(!manager.GamePuase ) 
        {
            Pause.SetActive(false);
        }
    }
         
   public  void OptionsEnable()
    {
        if (Options.activeInHierarchy == true)
        {
            Options.SetActive(false);
        }
        else if (Options.activeInHierarchy == false) 
        {
            Options.SetActive(false);
        }
    }
    public void EnableControls()
    {
        if (Controls.activeSelf == true)
        {
            Controls.SetActive(false);
        }
        else
        {
            Controls.SetActive(true);
        }
    }
    public void ChangeVolMaster(float Volumen)
    {
        Mixer.SetFloat("VolMaster", Volumen);
    }
    public void ChangeVolSound(float Volumen)
    {
        Mixer.SetFloat("VolSound", Volumen);
    }
}
