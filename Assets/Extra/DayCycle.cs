using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.Rendering.Universal;


public enum DayState { Morning, Afternoon, Night}
public class DayCycle : MonoBehaviour
{

    public static DayCycle Instance;


    [SerializeField] float dayLength;

    [SerializeField]float dayTime = 0;
    public float DayTime{ get { return dayTime; } }

    DayState dayState = DayState.Morning;
    public DayState DayState { get { return dayState; } }


    [Header("Day Light Settings")]
    [SerializeField]Light2D dayLight;
    [SerializeField]Color dayColorOffSetBright;
    [SerializeField]Color dayColorOffSetDark;

    // Start is called before the first frame update
    void Start()
    {
        if (Instance != null && Instance != this)
            Destroy(Instance);
        else
            Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        DayPass();
        LightOscilation();
    }

    void DayPass()
    {
        dayTime += Time.deltaTime;
        if (dayTime > dayLength)
            dayTime = 0;

    }

    void LightOscilation()
    {
        float t = (dayTime / dayLength) * 2 * Mathf.PI;
        float lightFactor = (Mathf.Cos(t) + 1) / 2;

        dayLight.color = Color.Lerp(dayColorOffSetDark, dayColorOffSetBright, lightFactor);


        // Ajustar os estados do dia para coincidir com a luz
        if (lightFactor > 0.6f) // Iluminação forte -> manhã
            dayState = DayState.Morning;
        else if (lightFactor > 0.3f) // Iluminação média -> tarde
            dayState = DayState.Afternoon;
        else // Iluminação baixa -> noite
            dayState = DayState.Night;

        Debug.Log(dayState);
    }
}
