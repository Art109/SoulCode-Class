using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

public class StarFill : MonoBehaviour
{
    [SerializeField] List<Image> stars;

    private void OnEnable()
    {
        StartCoroutine(FillStars());
    }

    IEnumerator FillStars()
    {
        int numberStars = 0;
        int playerPoins = GameManager.Instance.playerPoints;

        if (playerPoins > 10 && playerPoins < 20)
        {
            numberStars = 1;
        }
        else if (playerPoins > 20 && playerPoins < 30)
        {
            numberStars = 2;
        }
        else if (playerPoins >= 30)
        {
            numberStars = 3;
        }

        for (int i = 0; i < numberStars; i++)
        {
            float j = 0;
            while (j <= 1)
            {
                stars[i].fillAmount += j;
                j += 0.1f;
                yield return new WaitForSeconds(0.09f);
            }


        }
    }

}
