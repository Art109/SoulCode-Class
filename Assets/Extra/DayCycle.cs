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
    [SerializeField] Gradient dayGradient;

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

        float cyclePercent = dayTime / dayLength; // Progresso do dia (0 a 1)

       
        if (cyclePercent < 0.25f) // 0% - 25% → Noite
            dayState = DayState.Night;
        else if (cyclePercent < 0.50f) // 25% - 50% → Manhã
            dayState = DayState.Morning;
        else if (cyclePercent < 0.75f) // 50% - 75% → Tarde
            dayState = DayState.Afternoon;
        else // 75% - 100% → Noite novamente
            dayState = DayState.Night;

        Debug.Log(dayState);

    }

    void LightOscilation()
    {
        

        float cyclePercent = dayTime / dayLength;
        dayLight.color = dayGradient.Evaluate(cyclePercent);

        float minIntensity = 0.2f; // O mínimo de brilho (deixe acima de 0 para evitar escuridão total)
        float maxIntensity = 0.8f; // O brilho máximo ao meio-dia
        dayLight.intensity = Mathf.Lerp(minIntensity, maxIntensity, Mathf.Sin(cyclePercent * Mathf.PI));
    }
}
