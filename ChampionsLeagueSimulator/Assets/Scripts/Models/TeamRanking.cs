using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamRanking 
{
    public Team Team;
    public int TotalScore;
    public int GoalsScored;
    public int GoalsReceived;

    public TeamRanking(Team team, int totalScore, int goalsScored, int goalsReceived)
    {
        Team = team;
        TotalScore = totalScore;
        GoalsScored = goalsScored;
        GoalsReceived = goalsReceived;
    }
}
