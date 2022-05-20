using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Sprites;
public class StartImage : MonoBehaviour
{


    public Image[] SequenceImage;

    public Image SkipImage;

    [Range(0, 1)]
    [SerializeField] float ImagesTransparencyLimit;

    private float ImagesTransparency;
    float ImagesVeloctyTransparency = 0.3f;

    int TotalImage;
    
    float NextImag;

    // la imagen que se activa
    byte count = 1;
    int DesactivateImage = 1;

    bool NextActivation  = false;
    bool TransparecyActive = true;



    void Start()
    {
        TotalImage = SequenceImage.Length;
    }

   
    // Update is called once per frame
    void Update()
    {
   


        if (count <= TotalImage)
        {
            ImagenEneble();
        }
        else 
        {
            LevelLoader.LoadLevel("Level1");
        }
        SkipStoryBoard();
   

    }

    void SkipStoryBoard() 
    {
        if (Input.GetKey(KeyCode.X))
        {
            SkipImage.fillAmount += 0.5f * Time.deltaTime;
        }
        else if (Input.GetKeyUp(KeyCode.X))
        {
            SkipImage.fillAmount = 0;
        }

        if (SkipImage.fillAmount == 1)
        {
            LevelLoader.LoadLevel("Level1");
        }
    }

    public void ImagenEneble() 
    {
        // La activacion de las imagenes 

        // limite de transparencia
        if (TransparecyActive) 
        {
             if (ImagesTransparency < ImagesTransparencyLimit)
                  ImagesTransparency += ImagesVeloctyTransparency * Time.deltaTime;
        }

        NextImag += Time.deltaTime;

        // Adelantar Imagen
        if (NextImag >= 0.5f && Input.GetKeyDown(KeyCode.Space)) 
        {
            ImagesTransparency = 0;
            count += 1;
            NextImag = 0;
        }

    
        // pase automatico
        if (NextImag >= 12) 
        {
            NextActivation = true;
        }
    
            if (NextActivation)
            {
               count += 1;
                ImagesTransparency = 0;
                NextImag = 0;
                NextActivation = false;
            }

        //Imagenes que se van a desvanecer
        if (count >= 0 && count <= 3  || count == 9 ) 
        {
            if ( NextImag >= 8)
            {
                TransparecyActive = false;
                ImagesTransparency -= ImagesVeloctyTransparency * Time.deltaTime;
            }
            else 
            {
                TransparecyActive = true;
            }
        }
        else 
        {
            TransparecyActive = true;
        }

        // Imagenes Instantaneas y + velocidad de activacion
        if (count >= 4 && count <= 9 || count >= 10 && count <= 13 || count >= 14 && count <= 17)
        {
            ImagesTransparency = 1;
            NextImag += 1.5f * Time.deltaTime;
        }

        if (count >= 14 && count <= 17 || count >= 10 && count <= 10) 
        {
            ImagesTransparency = 1;
            NextImag += 6 * Time.deltaTime;
        }

        // Siguiente imagen

        for (int i = 0; i < count; i++) 
        {
            SequenceImage[i].gameObject.SetActive(true);
            // desactiva la anterior
            if (i >= 1) 
            {
                DesactivateImage = i ;
                DesactivateImage -= 1;
            }

            SequenceImage[ DesactivateImage].gameObject.SetActive(false);
           
            SequenceImage[i].color = new Color(SequenceImage[i].color.r, SequenceImage[i].color.g, SequenceImage[i].color.b, ImagesTransparency);
        }
    }
 
}
