using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CutSceneScript : MonoBehaviour
{
   
    FraseWrite frase;
    public GameObject CutScene_Level_1;
    public GameObject CutScene_Level_1_Part_2;
    public GameObject CutScene_Level_2;
    public GameObject CutScene_Level_2_Part2;
    public GameObject CutScene_Level_3;
    public GameObject CutScene_Level_3_Part2;
    public GameObject Edgar;

    [SerializeField] private GameObject BoneLose;

    public GameObject[] Standarts;
    public Button Option1;
    public Button Option2;

    int Options;
    public int Scene = 2;
    int LoadScene;
    int index;

    string IsBoneLordFollow = "Si";



    bool IsSaveScene = true;
    private void Awake()
    {
        Scene = PlayerPrefs.GetInt("cutscenes", LoadScene);
    }
    // Start is called before the first frame update
    void Start()
    {
        Room.IsDefeatBoss = false;
        LevelAndOptionsToSelect();

        Option1.gameObject.SetActive(false);
        Option2.gameObject.SetActive(false);
      
        frase = FindObjectOfType<FraseWrite>();
        IsBoneLordFollow = PlayerPrefs.GetString("BoneLord");

      
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G)) 
        {
            SceneManager.LoadScene("Level1");
        }

        if (Scene == 0) 
        {
            Level1BeforeBoss();
            LoadScene = 1;
            Save();
        }
        if (Scene == 1) 
        {
            Level1LaterBoss();
            LoadScene = 2;
            Save();
        }
        if (Scene == 2) 
        {
            Level2BeforeBoss();
            LoadScene = 3;
            Save();
        }
        if (Scene == 3)
        {
            Level2LaterBoss();
            LoadScene = 4;
            Save();
        }
        if(Scene == 4) 
        {
            Level3BeforeBoss();
            LoadScene = 5;
            Save();
        }
        if (Scene == 5) 
        {
            LoadScene = 6;
            Save();
        }
        if (Scene == 6) 
        {
            LevelLoader.LoadLevel("VictoryScene");
        }
        StandartsTalking();



    }
    void StandartsTalking() 
    {
        if (BoneTalking.Standart)
        {
            Standarts[1].SetActive(true);
            //Standarts[0].SetActive(false);
            //Standarts[2].SetActive(false);
        }
        else
        {
            Standarts[1].SetActive(false);
        }
        if (PlayerTalking.Standart)
        {
            Standarts[0].SetActive(true);
            //Standarts[1].SetActive(false);
            //Standarts[2].SetActive(false);

        }
        else
        {
            Standarts[0].SetActive(false);
        }
        if (ElfTalking.Standart)
        {
            Standarts[2].SetActive(true);
            //Standarts[1].SetActive(false);
            //Standarts[0].SetActive(false);

        }
        else
        {
            Standarts[2].SetActive(false);
        }
    }
    void Save() 
    {
       PlayerPrefs.SetInt("cutscenes", LoadScene);
        PlayerPrefs.SetString("BoneLord", IsBoneLordFollow);
    }
    //private void OnDestroy()
    //{
    //    Save();
    //}
    void Level1BeforeBoss()
    {


        if (FraseWrite.index == 5 && Options == 0)
        {
            FraseWrite.IsSelectOptions = true;
            Option1.gameObject.SetActive(true);
            Option2.gameObject.SetActive(true);
        }
        else
        {
            FraseWrite.IsSelectOptions = false;
            Option1.gameObject.SetActive(false);
            Option2.gameObject.SetActive(false);
        }

        if (FraseWrite.IsCompleteDialogue) 
        {
            BoneTalking.IsTalkingBone = false;
            PlayerTalking.IsTalkingEdgar = false;
        }
        if (BoneTalking.Standart)
        {
            Standarts[1].SetActive(true);
        }
        else 
        {
            Standarts[1].SetActive(false);
        }
        if (PlayerTalking.Standart) 
        {
            Standarts[0].SetActive(true);

        }
        else
        {
            Standarts[0].SetActive(false);
        }

        switch (FraseWrite.index) 
        {
            case 0:
                Save();
                frase.SpeakCutScene("...");
                break;
            case 1:
                frase.SpeakCutScene("¡Alto ahí joven hechicero!");
                break;
            case 2:
                frase.SpeakCutScene("Genial, otro esqueleto...");
                if(!FraseWrite.IsCompleteDialogue)
                BoneTalking.IsTalkingBone = true;
                BoneTalking.Standart = true;
                PlayerTalking.IsTalkingEdgar = false;
                PlayerTalking.Standart = false;

                break;
            case 3:
                frase.SpeakCutScene("¿Otro esqueleto decís? ¡Soy Bonelord!¡Rey de los huesos y emperador de la fiesta!");
                if (!FraseWrite.IsCompleteDialogue)
                    PlayerTalking.IsTalkingEdgar = true;
                PlayerTalking.Standart = true;

                BoneTalking.IsTalkingBone = false;
                BoneTalking.Standart = false;

                break;
            case 4:
                frase.SpeakCutScene("Elige: ¿Fiesta? o ¡No me importa quien sos, la princesa me espera así que largo!");
                if (!FraseWrite.IsCompleteDialogue)
                    BoneTalking.IsTalkingBone = true;
                BoneTalking.Standart = true;

                PlayerTalking.IsTalkingEdgar = false;
                PlayerTalking.Standart = false;

                break;
            case 5:
                //if (!FraseWrite.CompleteDialogue)
                    PlayerTalking.IsTalkingEdgar = false;
                PlayerTalking.Standart = true;

                BoneTalking.IsTalkingBone = false;
                BoneTalking.Standart = false;

                if (Options == 1)
                    frase.SpeakCutScene("¡Obvion nene, no sabes lo que son mis fiestas en mi palacio del inframundo, muchas mujeres y el mejor vino del mundo!");
                if (Options == 2)
                    frase.SpeakCutScene("¡AH! ¡Otro heroe que busca el amor de una doncella en apuros! ¡No te preocupes! Cuando te mate y te reanime como esqueleto, vas a tener a todas las chicas esqueleto que desees.");
                break;
            case 6:
                if (!FraseWrite.IsCompleteDialogue)
                    BoneTalking.IsTalkingBone =true;
                BoneTalking.Standart = true;

                PlayerTalking.IsTalkingEdgar = false;
                PlayerTalking.Standart = false;
                if (Options == 1)
                    frase.SpeakCutScene("Mira, tengo algo de prisa pero te prometo que cuando me muera voy a ir a una de tus locas fiestas.");
                if (Options == 2)
                    frase.SpeakCutScene("Agradezco la oferta señor Bonelord, pero me gustan las chicas con algo de carne en los huesos, no es por ofender pero usted me entiende.");
                break;
            case 7:
                if (!FraseWrite.IsCompleteDialogue)
                    PlayerTalking.IsTalkingEdgar = true;
                PlayerTalking.Standart = true;

                BoneTalking.IsTalkingBone = false;
                BoneTalking.Standart = false;
                if (Options == 1)
                    frase.SpeakCutScene("¿Para que esperar? Te puedo ahorrar la espera matandote acá mismo ¡Que empiece la fiesta, niño mago!");
                if (Options == 2)
                    frase.SpeakCutScene("Ah esos gustos mortales, no importa, igual estoy necesitando mayordomos para mi proxima fiesta... !Así que anda preparandote que lo proximo que vas a ver va a ser una bandeja con copas!");
                break;
            default:
              
                if (!FraseWrite.IsCompleteDialogue)
                    BoneTalking.IsTalkingBone = true;
                BoneTalking.Standart = true;

                PlayerTalking.IsTalkingEdgar = false;
                PlayerTalking.Standart = false;

                if (Input.GetKeyDown(KeyCode.Space) && FraseWrite.IsCompleteDialogue)
                {
                    SceneManager.LoadScene("Level1");
                }
                break;
        }
    }
    void Level1LaterBoss() 
    {
        if (Options == 1) 
        {
            IsBoneLordFollow = "Si";
        }
        if (Options == 2)
        {
            IsBoneLordFollow = "No";

        }
        if (FraseWrite.IsCompleteDialogue)
        {
            BoneTalking.IsTalkingBone = false;
            PlayerTalking.IsTalkingEdgar = false;
        }
        if (BoneTalking.Standart)
        {
            Standarts[1].SetActive(true);
        }
        else
        {
            Standarts[1].SetActive(false);
        }
        if (PlayerTalking.Standart)
        {
            Standarts[0].SetActive(true);

        }
        else
        {
            Standarts[0].SetActive(false);
        }
        if (FraseWrite.index == 19 && Options == 0)
        {
            FraseWrite.IsSelectOptions = true;
            Option1.gameObject.SetActive(true);
            Option2.gameObject.SetActive(true);
        }
        else
        {
            FraseWrite.IsSelectOptions = false;
            Option1.gameObject.SetActive(false);
            Option2.gameObject.SetActive(false);
        }
        switch (FraseWrite.index) 
        {
           
            case 0:
                Save(); 
                frase.SpeakCutScene("...");
                break;
            case 1:
                frase.SpeakCutScene(" ¡Mi mágia! ¡Mis poderes! ¡Mi vino!");
                break;
            case 2:
                frase.SpeakCutScene("¡Listo, prearate huesudo que se viene el golpe de gracia!");

                if (!FraseWrite.IsCompleteDialogue)
                    BoneTalking.IsTalkingBone = true;
                BoneTalking.Standart = true;
                break;
            case 3:
                frase.SpeakCutScene("¡Espera! ¡Puedo ayudarte si me perdonas!¿Que me decís Eddy? ¿Me perdonas la no-vida y te doy una mano ? ");

                if (!FraseWrite.IsCompleteDialogue)
                    PlayerTalking.IsTalkingEdgar = true;
                PlayerTalking.Standart = true;

                BoneTalking.IsTalkingBone = false;
                BoneTalking.Standart = false;
                break;
            case 4:
                frase.SpeakCutScene("¿Como sabes mi nombre?");

                if (!FraseWrite.IsCompleteDialogue)
                    BoneTalking.IsTalkingBone = true;
                BoneTalking.Standart = true;

                PlayerTalking.IsTalkingEdgar = false;
                PlayerTalking.Standart = false;
                break;
            case 5:
                frase.SpeakCutScene("Lo gritaste bien fuerte afuera de la torre antes de entrar...");

                if (!FraseWrite.IsCompleteDialogue)
                    PlayerTalking.IsTalkingEdgar = true;
                PlayerTalking.Standart = true;

                BoneTalking.IsTalkingBone = false;
                BoneTalking.Standart = false;
                break;
            case 6:
                frase.SpeakCutScene("Bueno. ¿Me vas a ayudar o no?");

                if (!FraseWrite.IsCompleteDialogue)
                    BoneTalking.IsTalkingBone = true;
                BoneTalking.Standart = true;

                PlayerTalking.IsTalkingEdgar = false;
                PlayerTalking.Standart = false;
                break;
            case 7:
                frase.SpeakCutScene("Ya va, ya va. ¿Viste mis piernas por algún lado ? ¡Bueno, agarrate las botas que tenia puestas y te van a ayudar a moverte mas rápido!");

                if (!FraseWrite.IsCompleteDialogue)
                    PlayerTalking.IsTalkingEdgar = true;
                PlayerTalking.Standart = true;

                BoneTalking.IsTalkingBone = false;
                BoneTalking.Standart = false;
                break;
            case 8:
                frase.SpeakCutScene("La verdad que suena muy util, gracias huesitos");

                if (!FraseWrite.IsCompleteDialogue)
                    BoneTalking.IsTalkingBone = true;
                BoneTalking.Standart = true;

                PlayerTalking.IsTalkingEdgar = false;
                PlayerTalking.Standart = false;
                break;
            case 9:
                frase.SpeakCutScene("(edgar se desvanece y queda Bonelord hablando solo)");
                if (!FraseWrite.IsCompleteDialogue)
                    PlayerTalking.IsTalkingEdgar = true;
                PlayerTalking.Standart = true;

                BoneTalking.IsTalkingBone = false;
                BoneTalking.Standart = false;
                break;
            case 10:
                frase.SpeakCutScene("...");

                Edgar.gameObject.SetActive(false);

                PlayerTalking.IsTalkingEdgar = false;
                PlayerTalking.Standart = false;

                BoneTalking.IsTalkingBone = false;
                BoneTalking.Standart = false;
                break;
            case 11:
                frase.SpeakCutScene("¡Edgar espera!");

                PlayerTalking.IsTalkingEdgar = false;
                PlayerTalking.Standart = false;

                BoneTalking.IsTalkingBone = false;
                BoneTalking.Standart = false;
                break;
            case 12:
                frase.SpeakCutScene("(Edgar vuelve)");

                

                if (!FraseWrite.IsCompleteDialogue)
                    BoneTalking.IsTalkingBone = true;
                BoneTalking.Standart = true;

                PlayerTalking.IsTalkingEdgar = false;
                PlayerTalking.Standart = false;
                break;
            case 13:
                frase.SpeakCutScene("¿Que pasa?");

                PlayerTalking.IsTalkingEdgar = false;
                PlayerTalking.Standart = false;

                BoneTalking.IsTalkingBone = false;
                BoneTalking.Standart = false;
                break;
            case 14:
                frase.SpeakCutScene(" ¿Me llevas con vos?");

                Edgar.gameObject.SetActive(true);

                if (!FraseWrite.IsCompleteDialogue)
                    PlayerTalking.IsTalkingEdgar = true;
                PlayerTalking.Standart = true;

                BoneTalking.IsTalkingBone = false;
                BoneTalking.Standart = false;
                break;
            case 15:
                frase.SpeakCutScene("¿Desde cuando te interesa venir conmigo?");

                if (!FraseWrite.IsCompleteDialogue)
                    BoneTalking.IsTalkingBone = true;
                BoneTalking.Standart = true;

                PlayerTalking.IsTalkingEdgar = false;
                PlayerTalking.Standart = false;
                break;
            case 16:
                frase.SpeakCutScene("Desde que soy una cabeza sin cuerpo, entre acompañarte o morirme de aburrimiento acá prefiero ir con vos ¿Me llevas ? ");

                if (!FraseWrite.IsCompleteDialogue)
                    PlayerTalking.IsTalkingEdgar = true;
                PlayerTalking.Standart = true;

                BoneTalking.IsTalkingBone = false;
                BoneTalking.Standart = false;
                break;
            case 17:
                frase.SpeakCutScene("No se, intentaste matarme hace 5 minutos...");

                if (!FraseWrite.IsCompleteDialogue)
                    BoneTalking.IsTalkingBone = true;
                BoneTalking.Standart = true;

                PlayerTalking.IsTalkingEdgar = false;
                PlayerTalking.Standart = false;
                break;
            case 18:
                frase.SpeakCutScene("No dejemos que mi trabajo como protector de esta mazmorra arruine nuestra amistad. ¿Me llevas? ");

                if (!FraseWrite.IsCompleteDialogue)
                    PlayerTalking.IsTalkingEdgar = true;
                PlayerTalking.Standart = true;

                BoneTalking.IsTalkingBone = false;
                BoneTalking.Standart = false;

                break;
            case 19:
                if(Options == 1)
                    frase.SpeakCutScene("Sabía que eras un buen pibe Eddy, ahora vamos a salvar a esa chica ¡Dos amigos heroes en una aventura sin parangon!");
                if (Options == 2)
                    frase.SpeakCutScene("Tomo nota, la gente no acepta facilmente las solicitudes de amistad tras un intento de asesinato...");

                if (!FraseWrite.IsCompleteDialogue)
                    BoneTalking.IsTalkingBone = true;
                BoneTalking.Standart = true;

                PlayerTalking.IsTalkingEdgar = false;
                PlayerTalking.Standart = false;
                break;
            case 20:
                if (Options == 1)
                    frase.SpeakCutScene(" Ya me estoy arrepintiendo de esto...");
                if (Options == 2)
                    frase.SpeakCutScene("Bueno, intentemos rodar lentamente hacia mi copa de vino, debe estar por algún lado");

                if (!FraseWrite.IsCompleteDialogue)
                    BoneTalking.IsTalkingBone = true;
                BoneTalking.Standart = true;

                PlayerTalking.IsTalkingEdgar = false;
                PlayerTalking.Standart = false;
                break;
            case 21:
            
                if (Options == 1) 
                {
                    if (!FraseWrite.IsCompleteDialogue)
                        PlayerTalking.IsTalkingEdgar = true;
                    PlayerTalking.Standart = true;

                    BoneTalking.IsTalkingBone = false;
                    BoneTalking.Standart = false;
                }
                if (Options == 2) 
                {
                    if (!FraseWrite.IsCompleteDialogue)
                        BoneTalking.IsTalkingBone = true;
                    BoneTalking.Standart = true;

                    PlayerTalking.IsTalkingEdgar = false;
                    PlayerTalking.Standart = false;
                }

                if (Input.GetKeyDown(KeyCode.Space) && FraseWrite.IsCompleteDialogue) 
                {
                    SceneManager.LoadScene("Level1");
                }
                break;
            default:
                    SceneManager.LoadScene("Level1");
                break;


        }
    }
    void Level2BeforeBoss() 
    {
        if (FraseWrite.index == 5 && Options == 0)
        {
            FraseWrite.IsSelectOptions = true;
            Option1.gameObject.SetActive(true);
            Option2.gameObject.SetActive(true);
        }
        else
        {
            FraseWrite.IsSelectOptions = false;
            Option1.gameObject.SetActive(false);
            Option2.gameObject.SetActive(false);
        }
        if (IsBoneLordFollow == "Si") 
        {
            BoneLose.SetActive(true);
            switch (FraseWrite.index) 
            {
                case 0:
                    frase.SpeakCutScene("¡Alto ahí! ¿Acaso sabes lo dificil que es limpiar la sangre de mis compatriotas del piso ? ");
                    break;
                case 1:
                    Talking("Elfo");
                    frase.SpeakCutScene("Disculpa, pero ellos atacaron primero... ");
                    break;
                case 2:
                    Talking("Edgar");

                    frase.SpeakCutScene("En realidad vos entraste y empezaste a matar a todos los que se te cruzaban.");
                    break;
                case 3:
                    Talking("Bone");

                    frase.SpeakCutScene("¡No importa! ¡Es mi deber como guardian de este bosque acabar con la maldad y peligro que representa la gente como vos! ");
                    break;
                case 4:
                    Talking("Elfo");

                    frase.SpeakCutScene("¿Para que necesita un elfo guardian una mopa y una botella de limpiapisos ? o  ¿Que no estaba en una torre hace 5 minutos ? ¿Que hago en un bosque ?");
                    break;
                case 5:
                    Talking("Egar");

                    if (Options == 1)
                        frase.SpeakCutScene("No importa, mis artes antiguas de combate no son de tu incumbencia. ");
                    if (Options == 2)
                        frase.SpeakCutScene("Estabas en la Torre del Caos absoluto,tiene portales a todo el mundo. ");
                    break;
                case 6:


                    if (Options == 1) 
                    {
                        frase.SpeakCutScene("Voy a ahorrarte las explicaciones, muñeco. El tipo este es un limpiador celestial ");
                        Talking("Elfo");
                    }
                    if (Options == 2) 
                    {
                        frase.SpeakCutScene("El craneo tiene razón, es una estructura tan antigua como misteriosa. Dime joven, ¿Como accediste a la torre ? ");
                        Talking("Bone");
                    }
                    break;
                case 7:
                    Talking("Bone");

                    if (Options == 1) 
                    {
                        Talking("Bone");
                        frase.SpeakCutScene("¿Limpiador Celestial? ");
                    }
                    if (Options == 2) 
                    {
                        Talking("Elfo");
                        frase.SpeakCutScene("Mi maestro tenía un portal raro 	guardado en su armario, lo usa para ir a hacer las compras... ");
                    }
                    break;
                case 8:
                    Talking("Edgar");

                    if (Options == 1) 
                    {
                        frase.SpeakCutScene("En efecto, somos guerreros que emplean el antiguo arte de la magia de la limpieza para limpiar la maldad de este mundo.");
                    }
                    if (Options == 2) 
                    {
                        frase.SpeakCutScene("Una respuesta de lo mas peculiar cuanto menos... ");
                    }
                    break;
                case 9:
                    Talking("Elfo");

                    if (Options == 1) 
                    {

                        frase.SpeakCutScene("A mi se me hace que es un conserje con delirios de grandeza.");
                    }
                    if (Options == 2)
                    {
                        
                        frase.SpeakCutScene("Bueno ¿Vamos a hablar de armarios y portales o van a romperse la cara entre ustedes para mi entretenimiento ? ");
                    }
                    break;
                case 10:
                    Talking("Bone");

                    if (Options == 1)
                        frase.SpeakCutScene("¡Calla craneo mal hablado!¡No oses desprestigiar el arte milenario de mi gente!");
                    if (Options == 2)
                        frase.SpeakCutScene("¡Es verdad, no retrasemos mas este enfrentamiento! ¡Joven brujo, empuña tu escoba! ");
                    break;
                case 11:
                    Talking("Elfo");

                    if (Options == 1)
                        frase.SpeakCutScene(" ¿Van a seguir discutiendo mucho rato? Si es así puedo irme a la siguiente sala...");
                    if (Options == 2)
                        SceneManager.LoadScene("Level1");
                    break;
                case 12:
                    Talking("Edgar");

                    frase.SpeakCutScene("¡No tan rapido! ¡Tu amigo ha insultado mi honor! ¡Ahora pagaras por el!¡Apronta tu escoba, joven mago!");
                    break;
                default:
                    Talking("Elfo");

                    if (Input.GetKeyDown(KeyCode.Space))
                        SceneManager.LoadScene("Level1");
                    break;

            }
        }
        if (IsBoneLordFollow == "No")
        {
            BoneLose.SetActive(false);
            switch (FraseWrite.index) 
                {
                      case 0:
                        frase.SpeakCutScene("¡Alto ahí! ¿Acaso sabes lo dificil que es limpiar la sangre de mis compatriotas del piso ? ");
                    break;
                    case 1:
                        Talking("Elfo");
                        frase.SpeakCutScene("Disculpa, pero ellos atacaron primero... ");
                    break;
                    case 2:
                    Talking("Edgar");

                    frase.SpeakCutScene("En realidad vos entraste y empezaste a matar a todos los que se te cruzaban.");
                    break;
                    case 3:
                    Talking("Elfo");

                    frase.SpeakCutScene("¡No importa! ¡Es mi deber como guardian de este bosque acabar con la maldad y peligro que representa la gente como vos! ");
                    break;
                    case 4:
                    Talking("Edgar");

                    frase.SpeakCutScene("¿Para que necesita un elfo guardian una mopa y una botella de limpiapisos ? o   Me recuerdas a otro elfo rubio vestido de verde.");
                    break;
                    case 5:
                    Talking("Elfo");

                    if (Options == 1)
                        frase.SpeakCutScene("No importa, mis artes antiguas de combate no son de tu incumbencia. ");
                    if (Options == 2)
                        frase.SpeakCutScene("¡Silencio! ¡Esos tipos son muy atento en cuanto a derechos de autor! ");
                    break;
                    case 6:
                        if(Options == 1)
                        frase.SpeakCutScene("¿Como que no? La mopa te la enteindo. ¿Pero limpiapisos en medio de un bosque ? No tiene sentido...");
                        if (Options == 2)
                        frase.SpeakCutScene("Perdón, se me pasó por la cabeza y tenía que decirlo.");
                    break;
                    case 7:
                        Talking("Edgar");

                    if (Options == 1)
                        frase.SpeakCutScene("¡Calla! ¡No intentes comprender las costumbres ancestrales de mi gente!");
                        if (Options == 2)
                        frase.SpeakCutScene("¡Gracias! ¡Ya me perdí en mi discurso! ¿Donde me quedé ? ... ");
                    break;
                    case 8:
                       Talking("Elfo");

                    if (Options == 1)
                        frase.SpeakCutScene("Perdón, es que soy un poco curioso y se me hizo un detalle que no pude ignorar.");
                        if (Options == 2)
                        frase.SpeakCutScene("En algo de acabar con la maldad y el  peligro que representan los bananas como yo...");
                    break;
                    case 9:
                       Talking("Edgar");

                    if (Options == 1)
                        frase.SpeakCutScene("¡Basta de charla! ¡No pienso que sigas profanando la tierra de mi gente! ¡Ahora desenfunda tu escoba!");
                        if (Options == 2)
                        frase.SpeakCutScene("¡Cierto, gracias! ¡Ahora desenfunda tu escoba y preparate para una batalla de limpieza! ");
                    break;
                    default:
                       Talking("Elfo");

                    if (Input.GetKeyDown(KeyCode.Space))
                            SceneManager.LoadScene("Level1");
                        break;
                }
         }
    }
    void Level2LaterBoss() 
    {
        if (IsBoneLordFollow == "Si") 
        {
            BoneLose.SetActive(true);
            switch (FraseWrite.index) 
        {
            case 0:
                    
                frase.SpeakCutScene("¡Ya basta! ¡He visto suficiente!");
                break;
            case 1:
                    Talking("Elfo");

                    frase.SpeakCutScene("Pero si se estaba poniendo interesante...");
                break;
            case 2:
                    Talking("Bone");

                    frase.SpeakCutScene("¡Silencio calaca parlanchina! Joven, has demostrado ser digno del poder de los 'Limpiadores Celestiales', estoy impresionado...");
                break;
            case 3:
                    Talking("Elfo");

                    frase.SpeakCutScene("¿Y eso en que me beneficia?");
                break;
            case 4:
                    Talking("Edgar");

                    frase.SpeakCutScene("Nos Beneficia...");
                break;
            case 5:
                    Talking("Bone");

                    frase.SpeakCutScene("Como has demostrado tu valía enfrentandote a uno de los nuestros y prevalecido, te hago entrega de este hechizo. ¡Las 'Burbujas Purificadoras'!");
                break;
            case 6:
                    Talking("Elfo");

                    frase.SpeakCutScene("¡Genial, si nos atacan los demonios los matamos con burbujitas! Los magos son tan raros...");
                break;
            case 7:
                    Talking("Bone");

                    frase.SpeakCutScene("Agradezco el reconocimiento y el regalo pero en serio. ¿Burbujas ? ");
                break;
            case 8:
                    Talking("Edgar");

                    frase.SpeakCutScene("Comprendo tu eceptisismo, pero creeme que es un hechizo mas que digno cuando es usado por un limpiador celestial hecho y derecho.");
                break;
            case 9:
                    Talking("Elfo");

                    frase.SpeakCutScene("¿Me estás diciendo que el chico es uno de esos 'conserjes mágicos' ? ");
                break;
            case 10:
                    Talking("Bone");

                    frase.SpeakCutScene("¿Tengo que recordate que el 'conserje mágico' te redujo a una simple calavera parlante ? ");
                break;
            case 11:
                    Talking("Edgar");

                    frase.SpeakCutScene("Respondiendo a la pregunta de tu huesudo amigo, si, eres uno de los nuestros, pude sentir la pasión con la que empuñabas tu escoba y el poder de tu magia.");
                break;
            case 12:
                    Talking("Elfo");

                    frase.SpeakCutScene("Es lo mas bonito qu me dijeron en lo que va del día...");
                break;
            case 13:
                    Talking("Edgar");

                    frase.SpeakCutScene("¿Algo mas que quiera decirnos elfo con rasgos de depresión?");
                break;
            case 14:
                    Talking("Bone");

                    frase.SpeakCutScene("No de momento, solo me queda desearles la mejor de las suertes en su viaje, hasta luego Edgar, el aprendiz de Limpiador Celestial.");
                break;
            case 15:
                    Talking("Elfo");

                    frase.SpeakCutScene("¿Vos tambien sabes mi nombre?");
                break;
            case 16:
                    Talking("Edgar");

                    frase.SpeakCutScene("Seguramente el tambien lo escuchó cuando lo gritaste en la puerta...");
                break;
            case 17:
                    Talking("Bone");

                    frase.SpeakCutScene("Bueno, vamonos, seguramente se abrió otra puerta en la torre, a ver a donde nos lleba ahora.");
                break;
            case 18:
                    Talking("Edgar");

                    frase.SpeakCutScene("Espero que sea un buen bar por que tengo muy seca la garganta");
                break;
            case 19:
                    Talking("Bone");

                    frase.SpeakCutScene("Pero ni siquiera tenes garganta.");
                break;
            default:
                    Talking("Edgar");

                    if (Input.GetKeyDown(KeyCode.Space))
                        SceneManager.LoadScene("Level1");
                break;
        }
        }
        if (IsBoneLordFollow == "No") 
        {
            BoneLose.SetActive(false);
            switch (FraseWrite.index) 
            {
                case 0:
                 

                    frase.SpeakCutScene("¡Ya basta! ¡He visto suficiente!");
                    break; 
                case 1:
                    Talking("Elfo");

                    frase.SpeakCutScene("¿O sea que voy a conseguir novia?");
                    break;
                case 2:
                    Talking("Edgar");

                    frase.SpeakCutScene("¿Novia? ¡No seas ridiculo! ¡Tenes un deber mucho mas grande!");
                    break;
                case 3:
                    Talking("Elfo");

                    frase.SpeakCutScene("¿Que deber?");
                    break;
                case 4:
                    Talking("Edgar");

                    frase.SpeakCutScene("¡Vos y yo compartimos un mismo poder, un arte ancestral conocida como 'La limpiezacelestial'!");
                    break;
                case 5:
                    Talking("Elfo");

                    frase.SpeakCutScene("¿Limpieza Celestial? ¿Te afectó feo ese limpiapisos acaso ? ");
                    break;
                case 6:
                    Talking("Edgar");

                    frase.SpeakCutScene("Entiendo tu eceptisismo, pero los dos tenemos el don de limpiar la maldad.Somos guerreros que emplean la magia de la limpieza...");
                    break;
                case 7:
                    Talking("Elfo");

                    frase.SpeakCutScene("Esto es muy ridiculo...");
                    break;
                case 8:
                    Talking("Edgar");

                    frase.SpeakCutScene("¿Ridiculo? Veamos si seguis pensando lo mismo una vez que pruebes el poder que yace en tu interior ¡Aprende este hechizo ancestral!");
                    break;
                case 9:
                    Talking("Elfo");

                    frase.SpeakCutScene("¿Un pergamino? Huele a lisoform...");
                    break;
                case 10:
                    Talking("Edgar");

                    frase.SpeakCutScene("El hechizo antiguo de nuestra gente, las 'Burbujas Purificadoras', erradican el mal y huelen a lavanda.");
                    break;
                case 11:
                    Talking("Elfo");

                    frase.SpeakCutScene("Bueno, gracias. Si no me matan despues de esto voy a poder dejar el piso de mi casa con rico olor...");
                    break;
                case 12:
                    Talking("Edgar");

                    frase.SpeakCutScene("Hasta que nos veamos de nuevo, Edgar, el joven limpiador...");
                    break;
                case 13:
                    Talking("Elfo");

                    frase.SpeakCutScene("En serio. ¿Como es que todos saben mi nombre ?");
                    break;
                case 14:
                    Talking("Edgar");


                    frase.SpeakCutScene("Lo dijiste antes de entrar...");
                    break;
                case 15:
                    Talking("Elfo");

                    frase.SpeakCutScene("Ok, ya entendí, nos vemos otro día.");
                    break;
                default:
                    Talking("Edgar");


                    if (Input.GetKeyDown(KeyCode.Space))
                    SceneManager.LoadScene("Level1");
                    break;

             
            }
        }

    }
    void Level3BeforeBoss() 
    {
        GameManager.IsLevel3 = false;
     
        if (IsBoneLordFollow == "Si") 
        {
            if (FraseWrite.index == 9 && Options == 0)
            {
                FraseWrite.IsSelectOptions = true;
                Option1.gameObject.SetActive(true);
                Option2.gameObject.SetActive(true);
            }
            else
            {
                FraseWrite.IsSelectOptions = false;
                Option1.gameObject.SetActive(false);
                Option2.gameObject.SetActive(false);
            }
            BoneLose.SetActive(true);
            switch (FraseWrite.index) 
            {
                case 0:
                   
                    frase.SpeakCutScene("¡Glup!");
                    break;
                case 1:
                    Talking("Simo");

                    frase.SpeakCutScene("¿Eh?");
                    break;
                case 2:
                    Talking("Edgar");

                    frase.SpeakCutScene("Tranquilo muñeco, yo hablo algo de slime, deja que te traduzco...");
                    break;
                case 3:
                    Talking("Bone");

                    frase.SpeakCutScene("Ok...");
                    break;
                case 4:
                    Talking("Edgar");

                    frase.SpeakCutScene(" Dice que está enojado por que vinimos y empezamos a romper sus inventos así nomas...");
                    break;
                case 5:
                    Talking("Bone");

                    frase.SpeakCutScene("Oh, lo siento slimecito...");
                    break;
                case 6:
                    Talking("Edgar");

                    frase.SpeakCutScene("¡Glup!¡Glup!");
                    break;
                case 7:
                    Talking("Simo");
             
                    frase.SpeakCutScene("Dice que ya que lo entendemos, le paguemos los daños, si no entendieramos nada de lo que dice, nos dejaba ir sin drama...");
                    break;
                case 8:
                    Talking("Bone");
                    frase.SpeakCutScene("Pagar los daños o No pienso pagar");

             
                    break;
                case 9:
                    Talking("Simo");
                    if (Options == 1)
                    {
                        frase.SpeakCutScene("¡Glup!¡Glup!");
                    }
                    if (Options == 2)
                    {
                        frase.SpeakCutScene(" ¡Glup!¡Glup!¡Glup!¡Glup!");
                    }

                    break;
                case 10:
                    Talking("Simo");
               
                    if (Options == 1) 
                    {
                        frase.SpeakCutScene("(Edgar pierde 50 monedas y termina el nivel, si no puede pagar, empieza el combate)");
                      
                    }
                    if (Options == 2) 
                    {
                        if (Input.GetKeyDown(KeyCode.Space))
                            SceneManager.LoadScene("Level1");
                    }
                    break;
                default:
                    if (Options == 1) 
                    {
                        GameManager.PlayerGold += 50;
                    }
                    if (Input.GetKeyDown(KeyCode.Space))
                        SceneManager.LoadScene("Level1");
                    break;



            }

        }else if(IsBoneLordFollow == "No") 
        {
            if (FraseWrite.index == 5 && Options == 0)
            {
                FraseWrite.IsSelectOptions = true;
                Option1.gameObject.SetActive(true);
                Option2.gameObject.SetActive(true);
            }
            else
            {
                FraseWrite.IsSelectOptions = false;
                Option1.gameObject.SetActive(false);
                Option2.gameObject.SetActive(false);
            }
            BoneLose.SetActive(false);
            switch (FraseWrite.index) 
            {
                case 0:
                    frase.SpeakCutScene("¡Glup!");
                    break;
                case 1:
                    Talking("Simo");
                    frase.SpeakCutScene("¡¿Eh?!");
                    break;
                case 2:
                    Talking("Edgar");

                    frase.SpeakCutScene("¡Glup Glup Glup!");
                    break;
                case 3:
                    Talking("Simo");

                    frase.SpeakCutScene("No entiendo nada");
                    break;
                case 4:
                    Talking("Edgar");

                    frase.SpeakCutScene("¿Glup?");
                    break;
                case 5:

                    frase.SpeakCutScene("¡Glup! o ¡Glup! ¡Glup!");
                    break;
                case 6:
              
                    if (Options == 1) 
                    {
                        frase.SpeakCutScene(" ¡Glup! ¡Glup! ¡Glup!");

                    }
                    if (Options == 2) 
                    {
                        frase.SpeakCutScene("¡Glup!");

                    }
                    break;
                case 7:
                    Talking("Simo");
                    if (Options == 1)
                    {
                        frase.SpeakCutScene(" (Se inicia la pelea de jefe)");

                    }
                    if (Options == 2)
                    {
                        frase.SpeakCutScene("(Se omite la pelea de jefe y Slimo te regala 30 monedas)");
                    }
                    break;
                default:
                    if (Input.GetKeyDown(KeyCode.Space))
                        SceneManager.LoadScene("Level1");
                    break;
            }
        }
    }
    void Level3LaterBoss() 
    {
        if (IsBoneLordFollow == "Si")
        {
            switch (FraseWrite.index) 
            {
                case 0:
                    frase.SpeakCutScene(" Genial, mataste a un inocente, espero que estés contento...");

                    break;
                case 1:
                    Talking("Bone");
                    frase.SpeakCutScene("Callate, su inventos nos empezaron a atacar primero...");


                    break;
                case 2:
                    Talking("Edgar");
                    frase.SpeakCutScene(" Si claro, sigue alegando que fue en legitima defensa...");


                    break;
                case 3:
                    Talking("Bone");
                    frase.SpeakCutScene(" ¿Quieres que te deje tirado acá?");

                    break;
                case 4:
                    Talking("Edgar");
                    frase.SpeakCutScene(" Ahora que lo dices, el atacó primero...");

                    break;
                case 5:
                    Talking("Bone");
                    if(Input.GetKeyDown(KeyCode.Space))
                    SceneManager.LoadScene("Level1");

                    break;
                default:
                    SceneManager.LoadScene("Level1");
                    break;
            }
        }
        else if (IsBoneLordFollow == "No") 
        {
            SceneManager.LoadScene("Level1");
        }

    }
    public void Opcion1() 
    {
        Options = 1;
    }
    public void Opcion2()
    {
        Options = 2;
    }
    void LevelAndOptionsToSelect() 
    {
        if (Scene == 0)
        {
          
            
            CutScene_Level_1.gameObject.SetActive(true);
            
            Option1.GetComponentInChildren<Text>().text = "fiesta";
            Option2.GetComponentInChildren<Text>().text = "No, gracias";
        }

        if (Scene == 1)
        {
            
           CutScene_Level_1_Part_2.gameObject.SetActive(true);
            PlayerPrefs.SetString("BoneLord", IsBoneLordFollow);

            Option1.GetComponentInChildren<Text>().text = "LLevarse al Rarito";
            Option2.GetComponentInChildren<Text>().text = "No, que es un pesado";
        }
        if (Scene == 2) 
        {
            CutScene_Level_2.gameObject.SetActive(true);

            Option1.GetComponentInChildren<Text>().text = "1 ";
            Option2.GetComponentInChildren<Text>().text = "2 ";
        }

        if (Scene == 3) 
        {
            CutScene_Level_2_Part2.gameObject.SetActive(true);

            Option1.GetComponentInChildren<Text>().text = "1 ";
            Option2.GetComponentInChildren<Text>().text = "2 ";
        }
        if (Scene == 4) 
        {
            CutScene_Level_3.gameObject.SetActive(true);
            if(IsBoneLordFollow == "Si") 
            {
                Option1.GetComponentInChildren<Text>().text = "Si ";
                Option2.GetComponentInChildren<Text>().text = "No ";
            }
            if (IsBoneLordFollow == "No")
            {
                Option1.GetComponentInChildren<Text>().text = "¡Glup!";
                Option2.GetComponentInChildren<Text>().text = "¡Glup! ¡Glup!";
            }

        }
        if (Scene == 5) 
        {
            CutScene_Level_3_Part2.gameObject.SetActive(true);

        }
    }
    void Talking(string ID) 
    {


        if (ID == "Bone")
        {
            if (!FraseWrite.IsCompleteDialogue) 
            {
                BoneTalking.IsTalkingBone = true;
            }
            else 
            {
                BoneTalking.IsTalkingBone = false;

            }
            BoneTalking.Standart = true;
        }
        else 
        {
            BoneTalking.IsTalkingBone = false;
            BoneTalking.Standart = false;
        }
         
        if (ID == "Edgar") 
        {
            if (!FraseWrite.IsCompleteDialogue)
            {
                PlayerTalking.IsTalkingEdgar = true;
            }
            else 
            {
                PlayerTalking.IsTalkingEdgar = false;
            }
            PlayerTalking.Standart = true;
        }
        else 
        {
                 PlayerTalking.IsTalkingEdgar = false;
                 PlayerTalking.Standart = false;
        }
        if (ID == "Elfo")
        {
            ElfTalking.Standart = true;
        }
        else 
        {
            ElfTalking.Standart = false;

        }
        if (ID == "Simo")
        {
            Standarts[3].SetActive(true);
        }
        else 
        {
            Standarts[3].SetActive(false);

        }

    }
}
