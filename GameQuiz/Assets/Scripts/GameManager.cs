using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Level[] levels;
    public Player[] players;
    public Question[] questions;

    public Player template;
    public Level level;
    public Player player;
    public Question question;

    void Awake()
    {
        //PlayerPrefs.DeleteAll();

        LoadPlayers();

        players = gameObject.GetComponentsInChildren<Player>();

        levels = gameObject.GetComponentsInChildren<Level>();
    }

    /* 
    Carrega as informações de descrição, pontuação total e total dos recordes conquistados de todos os jogados cadastrados.
    */
    public void LoadPlayers()
    {
        int t_players = PlayerPrefs.GetInt("t_players", 0);

        for (int p = 0; p < t_players; p++)
        {
            Player t_player = Instantiate(template.gameObject, gameObject.transform).GetComponent<Player>();

            t_player.name           = "Player" + p;
            t_player.id             = p;
            t_player.description    = PlayerPrefs.GetString("t_players" + "@" + t_player.id + "@description");

            t_player.t_points       = PlayerPrefs.GetInt("t_players@" + t_player.id + "@t_point", 0);
            t_player.t_stopwatch    = PlayerPrefs.GetFloat("t_players@" + t_player.id + "@t_stopwatch", 0f);
        }

        OrderToFinalScore();
    }

    /* 
    Carrega as questões do nível padrão.
    */
    public void LoadQuestions()
    {
        foreach(Question question in level.questions)
        {
            Question t_question = Instantiate(question, gameObject.transform).GetComponent<Question>();

            t_question.name     = "Question" + question.id;
        }
    }

    /* 
    Seleciona o nível do parametro como padrão.
    */
    public void PlayLevel(int c_level)
    {
        level = levels[c_level];

        ReloadPlayer();

        foreach(Player player in players)
        {
            player.transform.SetParent(level.transform);
        }

        OrderToScore();
    }

    /* 
    Seleciona o jogador do parametro como padrão.
    Carrega as informações de comentário do jogador padrão.
    */
    public void PlayPlayer(int c_player)
    {
        player = players[c_player];

        LoadQuestions();

        questions = gameObject.GetComponentsInChildren<Question>();

        foreach(Question question in questions)
        {
            question.comment  = PlayerPrefs.GetString("t_players@" + player.id + "@t_question@" + question.id + "@comment");

            question.transform.SetParent(player.gameObject.transform);
            question.InitQuestion();   
        }        

        questions = gameObject.GetComponentsInChildren<Question>();
        
        question = questions[0];
    }

    /* 
    Seleciona o nível do parametro como padrão.
    Carrega as questões do nível padrão.
    */
    public void PlayQuestions(int c_level)
    {
        level = levels[c_level];

        LoadQuestions();

        questions = gameObject.GetComponentsInChildren<Question>();
        question = questions[0];

        foreach(Question question in questions)
        {
            question.transform.SetParent(level.transform); 

            question.name = "Question" + question.id;
        }
    }

    /* 
    Seleciona a questão do parametro como padrão.
    */
    public void PlayQuestion(int c_question)
    {      
        if (questions.Length > c_question)
        {
            question = questions[c_question];                            
        }
    }

    /* 
    Recarrega as informações de descrição, pontuação total e total dos recordes conquistados dos jogados existentes.
    */
    public void ReloadPlayer()
    {
        foreach(Player player in players)
        {
            player.points       = PlayerPrefs.GetInt("t_players@" + player.id + "@t_levels" + level.id + "@point", 0);
            player.stopwatch    = PlayerPrefs.GetFloat("t_players@" + player.id + "@t_levels" + level.id + "@stopwatch", 0f);
            
            player.t_points       = PlayerPrefs.GetInt("t_players@" + player.id + "@t_point", 0);
            player.t_stopwatch    = PlayerPrefs.GetFloat("t_players@" + player.id + "@t_stopwatch", 0f);
        }  
    }

    /* 
    Grava um novo jogador de acordo com o parametro.
    */
    public void NewPlayer(string description)
    {
        int t_players = PlayerPrefs.GetInt("t_players");

        PlayerPrefs.SetString("t_players" + "@" + t_players + "@description", description);

        player = Instantiate(template, level.gameObject.transform).GetComponent<Player>();

        player.name           = "Player" + t_players;
        player.id             = t_players;
        player.description    = PlayerPrefs.GetString("t_players" + "@" + player.id + "@description");

        PlayerPrefs.SetInt("t_players", t_players + 1);

        players = gameObject.GetComponentsInChildren<Player>();

        OrderToScore();
    }

    /* 
    Grava um novo comentário de acordo com o parametro e questão padrão.
    */
    public void NewComment(string comment)
    {
        question.comment = comment;

        PlayerPrefs.SetString("t_players@" + player.id + "@t_question@" + question.id + "@comment", question.comment);
    }

    /* 
    Grava um novo recorde de acordo com os parametros, jogador padrão e nível padrão.
    */
    public void NewRecord(int points, float stopwatch)
    {
        if ((player.points < points) || (player.points == points && player.stopwatch > stopwatch) || (player.points == 0 && player.stopwatch == 0 && points == 0 && player.stopwatch < stopwatch))
        {
            PlayerPrefs.SetInt("t_players@" + player.id + "@t_levels" + level.id + "@point", points);
            PlayerPrefs.SetFloat("t_players@" + player.id + "@t_levels" + level.id + "@stopwatch", stopwatch);

            player.t_points += points - player.points;
            player.t_stopwatch -= player.stopwatch - stopwatch;

            PlayerPrefs.SetInt("t_players@" + player.id + "@t_point", player.t_points);
            PlayerPrefs.SetFloat("t_players@" + player.id + "@t_stopwatch", player.t_stopwatch);

            player.points = points;
            player.stopwatch = stopwatch;
        } 

        OrderToScore();
    }

    /* 
    Ordena os jogadores de acordo com pontuação total e total dos recordes. 
    */
    public void OrderToFinalScore()
    {
        foreach(Player player in players)
        {
            player.transform.SetParent(transform);

            player.InitPlayer(1);
        }

        players = gameObject.GetComponentsInChildren<Player>();
    }

    /* 
    Ordena os jogadores de acordo com pontuação, recorde e nível padrão.. 
    */    
    public void OrderToScore()
    {
        foreach(Player player in players)
        {
            player.transform.SetParent(level.transform);

            player.InitPlayer(0);
        }

        players = gameObject.GetComponentsInChildren<Player>();
    }

    /* 
    Apaga a questão padrão. 
    */
    public void DropQuestions()
    {      
        foreach (Question question in questions)
        {
            Destroy(question.gameObject);
        }
    }

    /*
    Valida se o jogador é unico com o parametro.
    */
    public bool ExistPlayer(string description)
    {
        foreach (Player player in players)
        {
            if (player.description == description)
            {
                return true;
            }
        }

        return false;
    }

    /* 
    Carrega os materiais de apoio do nível padrão.
    */
    public void PlaySupports(int c_level)
    {
        PlayQuestions(c_level);
        
        questions = gameObject.GetComponentsInChildren<Question>();

        foreach(Question question in questions)
        {
            int t_supports  = question.supports.Length;

            question.support = "Introdução incompleta.";
            
            if (c_level < t_supports)
            {
                question.support = question.supports[c_level];
            }
        }
    }

    /* 
    Formata o tempo de segundos para a máscara 00:00:00.
    */
    public string FormatStopwatch(float stopwatch)
    {
        int seconds = (int) stopwatch;
        int minutes = (int) (stopwatch/60);
        int hours   = (int) (minutes / 60);

        seconds -= minutes * 60;
        minutes -= hours * 60;

        return hours.ToString("D2")+":"+minutes.ToString("D2")+":"+seconds.ToString("D2");
    }
}
