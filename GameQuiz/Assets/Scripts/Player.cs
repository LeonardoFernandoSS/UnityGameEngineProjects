using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int id;
    public string description;
    public int rank;
    public int points;
    public float stopwatch;
    public int t_points;
    public float t_stopwatch;
    private string idPlayerLevel;

    /*
    Seleciona forma de carregamento da classificação de acordo com o parametro.
    */
    public void InitPlayer(int mode)
    {
        switch (mode)
        {
            case 0:
            RankToLevel();
            break;

            case 1:
            FinalRank();
            break;

            default:
            break;
        }
    }

    /*
    Carrega a informação de classificação de acordo com a pontuação e recorde.
    */
    public void RankToLevel()
    {
        if (points == 0 && stopwatch == 0)
        {
            return;
        }

        Player[] players = transform.parent.GetComponentsInChildren<Player>();

        transform.SetSiblingIndex(0);

        foreach (Player player in players)
        {
            if (player.points > points || (player.points == points && player.stopwatch < stopwatch && player.stopwatch > 0))
            {
                player.transform.SetSiblingIndex(transform.GetSiblingIndex());

                transform.SetSiblingIndex(player.transform.GetSiblingIndex() + 1);

                player.rank = player.transform.GetSiblingIndex() + 1;
            }
        }        

        rank = transform.GetSiblingIndex() + 1;
    }

    /*
    Carrega a informação de classificação de acordo com a pontuação total e total dos recordes.
    */
    public void FinalRank()
    {
        if (t_points == 0 && t_stopwatch == 0)
        {
            return;
        }

        Player[] players = transform.parent.GetComponentsInChildren<Player>();

        transform.SetSiblingIndex(1);

        foreach (Player player in players)
        {
            if (player.t_points > t_points || (player.t_points == t_points && player.t_stopwatch < t_stopwatch && player.stopwatch > 0))
            {
                player.transform.SetSiblingIndex(transform.GetSiblingIndex());

                transform.SetSiblingIndex(player.transform.GetSiblingIndex() + 1);

                player.rank = player.transform.GetSiblingIndex();
            }
        }        

        rank = transform.GetSiblingIndex();
    }
}
