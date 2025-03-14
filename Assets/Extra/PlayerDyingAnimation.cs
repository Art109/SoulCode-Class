using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using UnityEngine;
using UnityEngine.UI;

public class PlayerDyingAnimation : MonoBehaviour
{

    [SerializeField] List<Sprite> imagens;
    [SerializeField] Image uiImage;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartAnimation());
    }

    
    IEnumerator StartAnimation()
    {
        for (int i = 0; i < imagens.Count; i++) 
        { 
            uiImage.sprite = imagens[i];
            yield return new WaitForSeconds(0.09f);
        }
    }
}
