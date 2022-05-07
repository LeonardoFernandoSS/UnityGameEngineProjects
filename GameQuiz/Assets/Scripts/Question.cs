using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Question : MonoBehaviour
{
    public int id;
    public string description;
    public string correct;
    public string[] incorrects;
    public string comment;

    [TextArea]
    public string[] supports;

    [TextArea]
    public string support;
    
    /*
    Embaralha a ordem da questão.
    Embaralha as ordens das alternativas.
    */
    public void InitQuestion()
    {
        int i_question = Mathf.Clamp((int) Random.Range(0f, id), 0, id);

        transform.SetSiblingIndex(i_question);

        int t_incorrects = incorrects.Length;

        for (int o = 0; o < incorrects.Length; o++)
        {
            int i_incorrect = Mathf.Clamp((int) Random.Range(0f, t_incorrects), 0, t_incorrects);

            string aux = incorrects[i_incorrect];

            incorrects[i_incorrect] = incorrects[o];
            incorrects[o] = aux;
        }

        int i_correct = Mathf.Clamp((int) Random.Range(0f, t_incorrects), 0, t_incorrects);

        incorrects[i_correct] = correct;
    }
}
