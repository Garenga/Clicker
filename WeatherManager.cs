using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeatherManager : MonoBehaviour
{
    public static WeatherManager wInsance;//stvaram static instancu jer trebam samo jedan WeatherManager
    public enum WeatherState { SUNNY,CLOUDY,RAINING,SNOWING,SCORCHING } //enum za odre?ivanje vrijednosti u wState
    public WeatherState wState;

    public float weatherEffect;//koristim ga u GameManager-u

    private void Awake()
    {
        wInsance = this;
    }

    private void Start()
    {
        GameManager.instance.onDayOver.AddListener(DailyWeather);//dodaje Listenera u UnityEvent u GameManager-u

    }
    public void DailyWeather()//metoda koja odreduje WeatherState
    {
        wState = (WeatherState)Random.Range(0, 5);

        switch (wState)
        {
            case (WeatherState)0: weatherEffect = 1f; 
                break;
            case (WeatherState)1: weatherEffect = .8f; 
                break;
            case (WeatherState)2: weatherEffect = .5f; 
                break;
            case (WeatherState)3: weatherEffect = .2f;
                break;
            case (WeatherState)4: weatherEffect = .1f; 
                break;
        }
        Debug.Log(wState);
        Debug.Log(weatherEffect);
    }




    private void OnDisable()//ako obrisemo ili ugasimo ovaj objekt neka makne Listener-a
    {
        GameManager.instance.onDayOver.RemoveListener(DailyWeather);
    }

}
