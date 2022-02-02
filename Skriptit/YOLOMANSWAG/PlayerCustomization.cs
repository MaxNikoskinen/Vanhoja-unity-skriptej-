using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCustomization : MonoBehaviour
{
    [SerializeField] private Image[] backgroundColorPreviewImage;
    [SerializeField] private Image[] backgroundPlayerPreviewImage;
    [SerializeField] private Image[] detailsColorPreviewImage;
    [SerializeField] private Image[] detailsPlayerPreviewImage;
    [SerializeField] private Image[] borderColorPreviewImage;
    [SerializeField] private Image[] borderPlayerPreviewImage;

    [Space]
    [SerializeField] private SpriteRenderer playerBackground;
    [SerializeField] private SpriteRenderer playerDetails;
    [SerializeField] private SpriteRenderer playerBorder;

    [Space]
    [Header("Sliders")]
    [SerializeField] private Slider backgroundRed;
    [SerializeField] private Slider backgroundGreen;
    [SerializeField] private Slider backgroundBlue;
    [SerializeField] private Slider backgroundAlpha;

    [Space]
    [SerializeField] private Slider detailsRed;
    [SerializeField] private Slider detailsGreen;
    [SerializeField] private Slider detailsBlue;
    [SerializeField] private Slider detailsAlpha;

    [Space]
    [SerializeField] private Slider borderRed;
    [SerializeField] private Slider borderGreen;
    [SerializeField] private Slider borderBlue;
    [SerializeField] private Slider borderAlpha;

    [Space]
    [Header("Sprites")]
    [SerializeField] private Sprite background1;
    [SerializeField] private Sprite background2;
    [SerializeField] private Sprite background3;
    [SerializeField] private Sprite background4;
    [SerializeField] private Sprite background5;

    [Space]
    [SerializeField] private Sprite details1;
    [SerializeField] private Sprite details2;
    [SerializeField] private Sprite details3;
    [SerializeField] private Sprite details4;
    [SerializeField] private Sprite details5;
    [SerializeField] private Sprite details6;

    [Space]
    [SerializeField] private Sprite border1;
    [SerializeField] private Sprite border2;
    [SerializeField] private Sprite border3;
    [SerializeField] private Sprite border4;
    [SerializeField] private Sprite border5;

    private Color playerBackgroundColor = Color.white;
    private Color playerDetailsColor = Color.white;
    private Color playerBorderColor = Color.white;

    private int playerBackgroundStyle = 2;
    private int playerDetailsStyle = 2;
    private int playerBorderStyle = 1;

    private void Start()
    {
        SetBackgroundColorRed();
        SetBackgroundColorGreen();
        SetBackgroundColorBlue();
        SetBackgroundColorAlpha();

        SetDetailsColorRed();
        SetDetailsColorGreen();
        SetDetailsColorBlue();
        SetDetailsColorAlpha();

        SetBorderColorRed();
        SetBorderColorGreen();
        SetBorderColorBlue();
        SetBorderColorAlpha();

        playerBackgroundStyle = PlayerPrefs.GetInt("BackgroundStyle", 2);
        playerDetailsStyle = PlayerPrefs.GetInt("DetailsStyle", 2);
        playerBorderStyle = PlayerPrefs.GetInt("BorderStyle", 1);

        SetPlayerBackground(playerBackgroundStyle);
        SetPlayerDetails(playerDetailsStyle);
        SetPlayerBorder(playerBorderStyle);
    }

    public void UpdateBackgroundColorRed()
    {
        playerBackgroundColor.r = backgroundRed.value;

        PlayerPrefs.SetFloat("BackgroundRed", playerBackgroundColor.r);

        playerBackground.material.color = playerBackgroundColor;

        for (int i = 0; i < backgroundColorPreviewImage.Length; i++)
        {
            backgroundColorPreviewImage[i].color = playerBackgroundColor;
        }

        for (int i = 0; i < backgroundPlayerPreviewImage.Length; i++)
        {
            backgroundPlayerPreviewImage[i].color = playerBackgroundColor;
        }
    }

    public void UpdateBackgroundColorGreen()
    {
        playerBackgroundColor.g = backgroundGreen.value;

        PlayerPrefs.SetFloat("BackgroundGreen", playerBackgroundColor.g);

        playerBackground.material.color = playerBackgroundColor;

        for (int i = 0; i < backgroundColorPreviewImage.Length; i++)
        {
            backgroundColorPreviewImage[i].color = playerBackgroundColor;
        }

        for (int i = 0; i < backgroundPlayerPreviewImage.Length; i++)
        {
            backgroundPlayerPreviewImage[i].color = playerBackgroundColor;
        }
    }

    public void UpdateBackgroundColorBlue()
    {
        playerBackgroundColor.b = backgroundBlue.value;

        playerBackground.material.color = playerBackgroundColor;

        PlayerPrefs.SetFloat("BackgroundBlue", playerBackgroundColor.b);

        for (int i = 0; i < backgroundColorPreviewImage.Length; i++)
        {
            backgroundColorPreviewImage[i].color = playerBackgroundColor;
        }

        for (int i = 0; i < backgroundPlayerPreviewImage.Length; i++)
        {
            backgroundPlayerPreviewImage[i].color = playerBackgroundColor;
        }
    }

    public void UpdateBackgroundColorAlpha()
    {
        playerBackgroundColor.a = backgroundAlpha.value;

        playerBackground.material.color = playerBackgroundColor;

        PlayerPrefs.SetFloat("BackgroundAlpha", playerBackgroundColor.a);

        for (int i = 0; i < backgroundColorPreviewImage.Length; i++)
        {
            backgroundColorPreviewImage[i].color = playerBackgroundColor;
        }

        for (int i = 0; i < backgroundPlayerPreviewImage.Length; i++)
        {
            backgroundPlayerPreviewImage[i].color = playerBackgroundColor;
        }
    }

    public void UpdateDetailsColorRed()
    {
        playerDetailsColor.r = detailsRed.value;

        playerDetails.material.color = playerDetailsColor;

        PlayerPrefs.SetFloat("DetailsRed", playerDetailsColor.r);

        for (int i = 0; i < detailsColorPreviewImage.Length; i++)
        {
            detailsColorPreviewImage[i].color = playerDetailsColor;
        }

        for (int i = 0; i < detailsPlayerPreviewImage.Length; i++)
        {
            detailsPlayerPreviewImage[i].color = playerDetailsColor;
        }
    }

    public void UpdateDetailsColorGreen()
    {
        playerDetailsColor.g = detailsGreen.value;

        playerDetails.material.color = playerDetailsColor;

        PlayerPrefs.SetFloat("DetailsGreen", playerDetailsColor.g);

        for (int i = 0; i < detailsColorPreviewImage.Length; i++)
        {
            detailsColorPreviewImage[i].color = playerDetailsColor;
        }

        for (int i = 0; i < detailsPlayerPreviewImage.Length; i++)
        {
            detailsPlayerPreviewImage[i].color = playerDetailsColor;
        }
    }

    public void UpdateDetailsColorBlue()
    {
        playerDetailsColor.b = detailsBlue.value;

        playerDetails.material.color = playerDetailsColor;

        PlayerPrefs.SetFloat("DetailsBlue", playerDetailsColor.b);

        for (int i = 0; i < detailsColorPreviewImage.Length; i++)
        {
            detailsColorPreviewImage[i].color = playerDetailsColor;
        }

        for (int i = 0; i < detailsPlayerPreviewImage.Length; i++)
        {
            detailsPlayerPreviewImage[i].color = playerDetailsColor;
        }
    }

    public void UpdateDetailsColorAlpha()
    {
        playerDetailsColor.a = detailsAlpha.value;

        playerDetails.material.color = playerDetailsColor;

        PlayerPrefs.SetFloat("DetailsAlpha", playerDetailsColor.a);

        for (int i = 0; i < detailsColorPreviewImage.Length; i++)
        {
            detailsColorPreviewImage[i].color = playerDetailsColor;
        }

        for (int i = 0; i < detailsPlayerPreviewImage.Length; i++)
        {
            detailsPlayerPreviewImage[i].color = playerDetailsColor;
        }
    }

    public void UpdateBorderColorRed()
    {
        playerBorderColor.r = borderRed.value;

        playerBorder.material.color = playerBorderColor;

        PlayerPrefs.SetFloat("BorderRed", playerBorderColor.r);

        for (int i = 0; i < borderColorPreviewImage.Length; i++)
        {
            borderColorPreviewImage[i].color = playerBorderColor;
        }

        for (int i = 0; i < borderPlayerPreviewImage.Length; i++)
        {
            borderPlayerPreviewImage[i].color = playerBorderColor;
        }
    }

    public void UpdateBorderColorGreen()
    {
        playerBorderColor.g = borderGreen.value;

        playerBorder.material.color = playerBorderColor;

        PlayerPrefs.SetFloat("BorderGreen", playerBorderColor.g);

        for (int i = 0; i < borderColorPreviewImage.Length; i++)
        {
            borderColorPreviewImage[i].color = playerBorderColor;
        }

        for (int i = 0; i < borderPlayerPreviewImage.Length; i++)
        {
            borderPlayerPreviewImage[i].color = playerBorderColor;
        }
    }

    public void UpdateBorderColorBlue()
    {
        playerBorderColor.b = borderBlue.value;

        playerBorder.material.color = playerBorderColor;

        PlayerPrefs.SetFloat("BorderBlue", playerBorderColor.b);

        for (int i = 0; i < borderColorPreviewImage.Length; i++)
        {
            borderColorPreviewImage[i].color = playerBorderColor;
        }

        for (int i = 0; i < borderPlayerPreviewImage.Length; i++)
        {
            borderPlayerPreviewImage[i].color = playerBorderColor;
        }
    }

    public void UpdateBorderColorAlpha()
    {
        playerBorderColor.a = borderAlpha.value;

        playerBorder.material.color = playerBorderColor;

        PlayerPrefs.SetFloat("BorderAlpha", playerBorderColor.a);

        for (int i = 0; i < borderColorPreviewImage.Length; i++)
        {
            borderColorPreviewImage[i].color = playerBorderColor;
        }

        for (int i = 0; i < borderPlayerPreviewImage.Length; i++)
        {
            borderPlayerPreviewImage[i].color = playerBorderColor;
        }
    }

    public void SetBackgroundColorRed()
    {
        backgroundRed.value = PlayerPrefs.GetFloat("BackgroundRed", 0.75f);

        playerBackgroundColor.r = backgroundRed.value;

        PlayerPrefs.SetFloat("BackgroundRed", playerBackgroundColor.r);

        playerBackground.material.color = playerBackgroundColor;

        for (int i = 0; i < backgroundColorPreviewImage.Length; i++)
        {
            backgroundColorPreviewImage[i].color = playerBackgroundColor;
        }

        for (int i = 0; i < backgroundPlayerPreviewImage.Length; i++)
        {
            backgroundPlayerPreviewImage[i].color = playerBackgroundColor;
        }
    }

    public void SetBackgroundColorGreen()
    {
        backgroundGreen.value = PlayerPrefs.GetFloat("BackgroundGreen", 0.75f);

        playerBackgroundColor.g = backgroundGreen.value;

        PlayerPrefs.SetFloat("BackgroundGreen", playerBackgroundColor.g);

        playerBackground.material.color = playerBackgroundColor;

        for (int i = 0; i < backgroundColorPreviewImage.Length; i++)
        {
            backgroundColorPreviewImage[i].color = playerBackgroundColor;
        }

        for (int i = 0; i < backgroundPlayerPreviewImage.Length; i++)
        {
            backgroundPlayerPreviewImage[i].color = playerBackgroundColor;
        }
    }

    public void SetBackgroundColorBlue()
    {
        backgroundBlue.value = PlayerPrefs.GetFloat("BackgroundBlue", 0.50f);

        playerBackgroundColor.b = backgroundBlue.value;

        playerBackground.material.color = playerBackgroundColor;

        PlayerPrefs.SetFloat("BackgroundBlue", playerBackgroundColor.b);

        for (int i = 0; i < backgroundColorPreviewImage.Length; i++)
        {
            backgroundColorPreviewImage[i].color = playerBackgroundColor;
        }

        for (int i = 0; i < backgroundPlayerPreviewImage.Length; i++)
        {
            backgroundPlayerPreviewImage[i].color = playerBackgroundColor;
        }
    }

    public void SetBackgroundColorAlpha()
    {
        backgroundAlpha.value = PlayerPrefs.GetFloat("BackgroundAlpha", 1.00f);

        playerBackgroundColor.a = backgroundAlpha.value;

        playerBackground.material.color = playerBackgroundColor;

        PlayerPrefs.SetFloat("BackgroundAlpha", playerBackgroundColor.a);

        for (int i = 0; i < backgroundColorPreviewImage.Length; i++)
        {
            backgroundColorPreviewImage[i].color = playerBackgroundColor;
        }

        for (int i = 0; i < backgroundPlayerPreviewImage.Length; i++)
        {
            backgroundPlayerPreviewImage[i].color = playerBackgroundColor;
        }
    }

    public void SetDetailsColorRed()
    {
        detailsRed.value = PlayerPrefs.GetFloat("DetailsRed", 1.00f);

        playerDetailsColor.r = detailsRed.value;

        playerDetails.material.color = playerDetailsColor;

        PlayerPrefs.SetFloat("DetailsRed", playerDetailsColor.r);

        for (int i = 0; i < detailsColorPreviewImage.Length; i++)
        {
            detailsColorPreviewImage[i].color = playerDetailsColor;
        }

        for (int i = 0; i < detailsPlayerPreviewImage.Length; i++)
        {
            detailsPlayerPreviewImage[i].color = playerDetailsColor;
        }
    }

    public void SetDetailsColorGreen()
    {
        detailsGreen.value = PlayerPrefs.GetFloat("DetailsGreen", 1.00f);

        playerDetailsColor.g = detailsGreen.value;

        playerDetails.material.color = playerDetailsColor;

        PlayerPrefs.SetFloat("DetailsGreen", playerDetailsColor.g);

        for (int i = 0; i < detailsColorPreviewImage.Length; i++)
        {
            detailsColorPreviewImage[i].color = playerDetailsColor;
        }

        for (int i = 0; i < detailsPlayerPreviewImage.Length; i++)
        {
            detailsPlayerPreviewImage[i].color = playerDetailsColor;
        }
    }

    public void SetDetailsColorBlue()
    {
        detailsBlue.value = PlayerPrefs.GetFloat("DetailsBlue", 1.00f);

        playerDetailsColor.b = detailsBlue.value;

        playerDetails.material.color = playerDetailsColor;

        PlayerPrefs.SetFloat("DetailsBlue", playerDetailsColor.b);

        for (int i = 0; i < detailsColorPreviewImage.Length; i++)
        {
            detailsColorPreviewImage[i].color = playerDetailsColor;
        }

        for (int i = 0; i < detailsPlayerPreviewImage.Length; i++)
        {
            detailsPlayerPreviewImage[i].color = playerDetailsColor;
        }
    }

    public void SetDetailsColorAlpha()
    {
        detailsAlpha.value = PlayerPrefs.GetFloat("DetailsAlpha", 0.25f);

        playerDetailsColor.a = detailsAlpha.value;

        playerDetails.material.color = playerDetailsColor;

        PlayerPrefs.SetFloat("DetailsAlpha", playerDetailsColor.a);

        for (int i = 0; i < detailsColorPreviewImage.Length; i++)
        {
            detailsColorPreviewImage[i].color = playerDetailsColor;
        }

        for (int i = 0; i < detailsPlayerPreviewImage.Length; i++)
        {
            detailsPlayerPreviewImage[i].color = playerDetailsColor;
        }
    }

    public void SetBorderColorRed()
    {
        borderRed.value = PlayerPrefs.GetFloat("BorderRed", 1.00f);

        playerBorderColor.r = borderRed.value;

        playerBorder.material.color = playerBorderColor;

        PlayerPrefs.SetFloat("BorderRed", playerBorderColor.r);

        for (int i = 0; i < borderColorPreviewImage.Length; i++)
        {
            borderColorPreviewImage[i].color = playerBorderColor;
        }

        for (int i = 0; i < borderPlayerPreviewImage.Length; i++)
        {
            borderPlayerPreviewImage[i].color = playerBorderColor;
        }
    }

    public void SetBorderColorGreen()
    {
        borderGreen.value = PlayerPrefs.GetFloat("BorderGreen", 1.00f);

        playerBorderColor.g = borderGreen.value;

        playerBorder.material.color = playerBorderColor;

        PlayerPrefs.SetFloat("BorderGreen", playerBorderColor.g);

        for (int i = 0; i < borderColorPreviewImage.Length; i++)
        {
            borderColorPreviewImage[i].color = playerBorderColor;
        }

        for (int i = 0; i < borderPlayerPreviewImage.Length; i++)
        {
            borderPlayerPreviewImage[i].color = playerBorderColor;
        }
    }

    public void SetBorderColorBlue()
    {
        borderBlue.value = PlayerPrefs.GetFloat("BorderBlue", 1.00f);

        playerBorderColor.b = borderBlue.value;

        playerBorder.material.color = playerBorderColor;

        PlayerPrefs.SetFloat("BorderBlue", playerBorderColor.b);

        for (int i = 0; i < borderColorPreviewImage.Length; i++)
        {
            borderColorPreviewImage[i].color = playerBorderColor;
        }

        for (int i = 0; i < borderPlayerPreviewImage.Length; i++)
        {
            borderPlayerPreviewImage[i].color = playerBorderColor;
        }
    }

    public void SetBorderColorAlpha()
    {
        borderAlpha.value = PlayerPrefs.GetFloat("BorderAlpha", 1.00f);

        playerBorderColor.a = borderAlpha.value;

        playerBorder.material.color = playerBorderColor;

        PlayerPrefs.SetFloat("BorderAlpha", playerBorderColor.a);

        for (int i = 0; i < borderColorPreviewImage.Length; i++)
        {
            borderColorPreviewImage[i].color = playerBorderColor;
        }

        for (int i = 0; i < borderPlayerPreviewImage.Length; i++)
        {
            borderPlayerPreviewImage[i].color = playerBorderColor;
        }
    }

    public void SetPlayerBackground(int backgroundNumber)
    {
        if(backgroundNumber == 1)
        {
            playerBackgroundStyle = 1;
            PlayerPrefs.SetInt("BackgroundStyle", playerBackgroundStyle);

            playerBackground.sprite = background1;

            for (int i = 0; i < backgroundPlayerPreviewImage.Length; i++)
            {
                backgroundPlayerPreviewImage[i].sprite = background1;
            }
        }

        else if(backgroundNumber == 2)
        {
            playerBackgroundStyle = 2;
            PlayerPrefs.SetInt("BackgroundStyle", playerBackgroundStyle);

            playerBackground.sprite = background2;

            for (int i = 0; i < backgroundPlayerPreviewImage.Length; i++)
            {
                backgroundPlayerPreviewImage[i].sprite = background2;
            }
        }

        else if(backgroundNumber == 3)
        {
            playerBackgroundStyle = 3;
            PlayerPrefs.SetInt("BackgroundStyle", playerBackgroundStyle);

            playerBackground.sprite = background3;

            for (int i = 0; i < backgroundPlayerPreviewImage.Length; i++)
            {
                backgroundPlayerPreviewImage[i].sprite = background3;
            }
        }

        else if(backgroundNumber == 4)
        {
            playerBackgroundStyle = 4;
            PlayerPrefs.SetInt("BackgroundStyle", playerBackgroundStyle);

            playerBackground.sprite = background4;

            for (int i = 0; i < backgroundPlayerPreviewImage.Length; i++)
            {
                backgroundPlayerPreviewImage[i].sprite = background4;
            }
        }

        else if(backgroundNumber == 5)
        {
            playerBackgroundStyle = 5;
            PlayerPrefs.SetInt("BackgroundStyle", playerBackgroundStyle);

            playerBackground.sprite = background5;

            for (int i = 0; i < backgroundPlayerPreviewImage.Length; i++)
            {
                backgroundPlayerPreviewImage[i].sprite = background5;
            }
        }
    }

    public void SetPlayerDetails(int detailsNumber)
    {
        if (detailsNumber == 1)
        {
            playerDetailsStyle = 1;
            PlayerPrefs.SetInt("DetailsStyle", playerDetailsStyle);

            playerDetails.sprite = details1;

            for (int i = 0; i < detailsPlayerPreviewImage.Length; i++)
            {
                detailsPlayerPreviewImage[i].sprite = details1;
            }
        }

        else if (detailsNumber == 2)
        {
            playerDetailsStyle = 2;
            PlayerPrefs.SetInt("DetailsStyle", playerDetailsStyle);

            playerDetails.sprite = details2;

            for (int i = 0; i < detailsPlayerPreviewImage.Length; i++)
            {
                detailsPlayerPreviewImage[i].sprite = details2;
            }
        }

        else if (detailsNumber == 3)
        {
            playerDetailsStyle = 3;
            PlayerPrefs.SetInt("DetailsStyle", playerDetailsStyle);

            playerDetails.sprite = details3;

            for (int i = 0; i < detailsPlayerPreviewImage.Length; i++)
            {
                detailsPlayerPreviewImage[i].sprite = details3;
            }
        }

        else if (detailsNumber == 4)
        {
            playerDetailsStyle = 4;
            PlayerPrefs.SetInt("DetailsStyle", playerDetailsStyle);

            playerDetails.sprite = details4;

            for (int i = 0; i < detailsPlayerPreviewImage.Length; i++)
            {
                detailsPlayerPreviewImage[i].sprite = details4;
            }
        }

        else if (detailsNumber == 5)
        {
            playerDetailsStyle = 5;
            PlayerPrefs.SetInt("DetailsStyle", playerDetailsStyle);

            playerDetails.sprite = details5;

            for (int i = 0; i < detailsPlayerPreviewImage.Length; i++)
            {
                detailsPlayerPreviewImage[i].sprite = details5;
            }
        }

        else if (detailsNumber == 6)
        {
            playerDetailsStyle = 6;
            PlayerPrefs.SetInt("DetailsStyle", playerDetailsStyle);

            playerDetails.sprite = details6;

            for (int i = 0; i < detailsPlayerPreviewImage.Length; i++)
            {
                detailsPlayerPreviewImage[i].sprite = details6;
            }
        }
    }

    public void SetPlayerBorder(int borderNumber)
    {
        if (borderNumber == 1)
        {
            playerBorderStyle = 1;
            PlayerPrefs.SetInt("BorderStyle", playerBorderStyle);

            playerBorder.sprite = border1;

            for (int i = 0; i < borderPlayerPreviewImage.Length; i++)
            {
                borderPlayerPreviewImage[i].sprite = border1;
            }
        }

        else if (borderNumber == 2)
        {
            playerBorderStyle = 2;
            PlayerPrefs.SetInt("BorderStyle", playerBorderStyle);

            playerBorder.sprite = border2;

            for (int i = 0; i < borderPlayerPreviewImage.Length; i++)
            {
                borderPlayerPreviewImage[i].sprite = border2;
            }
        }

        else if (borderNumber == 3)
        {
            playerBorderStyle = 3;
            PlayerPrefs.SetInt("BorderStyle", playerBorderStyle);

            playerBorder.sprite = border3;

            for (int i = 0; i < borderPlayerPreviewImage.Length; i++)
            {
                borderPlayerPreviewImage[i].sprite = border3;
            }
        }

        else if (borderNumber == 4)
        {
            playerBorderStyle = 4;
            PlayerPrefs.SetInt("BorderStyle", playerBorderStyle);

            playerBorder.sprite = border4;

            for (int i = 0; i < borderPlayerPreviewImage.Length; i++)
            {
                borderPlayerPreviewImage[i].sprite = border4;
            }
        }

        else if (borderNumber == 5)
        {
            playerBorderStyle = 5;
            PlayerPrefs.SetInt("BorderStyle", playerBorderStyle);

            playerBorder.sprite = border5;

            for (int i = 0; i < borderPlayerPreviewImage.Length; i++)
            {
                borderPlayerPreviewImage[i].sprite = border5;
            }
        }
    }
}
