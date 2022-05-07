using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuizManager : MonoBehaviour
{
    public bool playing;
    public bool commenting;
    public int t_questions;
    public int c_question;

    public int points;
    public float stopwatch;
    public string hunch;

    void Update()
    {
        if (playing)
        {
            stopwatch += Time.deltaTime;
        }        
    }

    void Start()
    {
        gameObject.SetActive(false);

        points = 0;
        stopwatch = 0f;
    }

    /*
    Inicia o teste e cronometro.
    */
    public void Play()
    {
        playing = true;

        gameObject.SetActive(true);
    }

    /*
    Para o cronometro.
    */
    public void Pause()
    {
        playing = false;
    }

    /*
    Para o teste e cronometro.
    */    
    public void Stop()
    {
        playing = false;

        gameObject.SetActive(false);        
    }

    /*
    Reinicia o teste.
    */    
    public void Reset(int questions)
    {
        t_questions = questions;
        c_question = 0;

        points = 0;
        stopwatch = 0f;
    }

    /*
    Seleciona proxima questão se existir.
    */    
    public void Next()
    {
        if(c_question < t_questions - 1)
        {
            c_question++;
        }       

        hunch = "";
    }

    /*
    Acumula os pontos se o palpite estiver correto.
    */
    public void CheckHunch(string correct, int multiplication)
    {
        if (correct == hunch)
        {
            points += Mathf.Clamp(multiplication, 1, 100);
        }
    }

    /*
    Defini o palpite de acordo com o parametro.
    */
    public void NewHunch(string c_hunch)
    {
        if (hunch == c_hunch)
        {
            c_hunch = "";
        }

        hunch = c_hunch;
    }
}
