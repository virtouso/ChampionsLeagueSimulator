using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Text;

public class Match : ScriptableObject
{
    private List<MatchTeam> _teams;
    public string Stadium;
    public DateTime MatchDate;
    public int Attendees;

    System.Random _random = new System.Random();
    public Match(string stadium, DateTime date, int attendees)
    {
        Stadium = stadium;
        MatchDate = date;
        Attendees = attendees;
    }



    public void AddTeams(MatchTeam team)
    {

        if (_teams == null)
            _teams = new List<MatchTeam>();
        if (_teams.Count >= 2)
        {
            Debug.Log("2 Teams Of The Match Already Defined");
            return;
        }

        _teams.Add(team);

    }



    public List<TeamRanking> CalculateMatchResult(string sideName)
    {
        // many configs can happen here. its my own logic
        // todo work more on it

        List<TeamRanking> matchStats = new List<TeamRanking>();


        _teams[0].GoalsScored = UtilityRandom.Random.Next(0, 5);
        _teams[1].GoalsScored = UtilityRandom.Random.Next(0, 5);


        StringBuilder result = new StringBuilder();
        result.Append(sideName).Append(Environment.NewLine)
            .Append(_teams[0].Team.TeamName).Append($"({_teams[0].Team.Nationality})").Append(_teams[0].GoalsScored).Append("-")
            .Append(_teams[1].GoalsScored).Append($"({_teams[1].Team.Nationality})").Append(_teams[1].Team.TeamName);

        UtilityLogger.LogResults(result.ToString());




        CalculateTeamsScores();


        matchStats.Add(new TeamRanking(_teams[0].Team, _teams[0].AchievedScore, _teams[0].GoalsScored, _teams[1].GoalsScored));
        matchStats.Add(new TeamRanking(_teams[1].Team, _teams[1].AchievedScore, _teams[1].GoalsScored, _teams[0].GoalsScored));
        return matchStats;


    }


    public List<KnockoutMatchResult> CalculateKnockoutMatchResult(string sideName)
    {
        List<KnockoutMatchResult> result = new List<KnockoutMatchResult>();



        _teams[0].GoalsScored = UtilityRandom.Random.Next(0, 5);
        _teams[1].GoalsScored = UtilityRandom.Random.Next(0, 5);


        StringBuilder stringResult = new StringBuilder();
        stringResult.Append(sideName).Append(Environment.NewLine)
            .Append(_teams[0].Team.TeamName).Append($"({_teams[0].Team.Nationality})").Append(_teams[0].GoalsScored).Append("-")
            .Append(_teams[1].GoalsScored).Append($"({_teams[1].Team.Nationality})").Append(_teams[1].Team.TeamName);

        UtilityLogger.LogResults(stringResult.ToString());





        result.Add(new KnockoutMatchResult(_teams[0].Team, _teams[0].TeamCondition, _teams[0].GoalsScored));
        result.Add(new KnockoutMatchResult(_teams[1].Team, _teams[1].TeamCondition, _teams[1].GoalsScored));

        return result;
    }



    private void CalculateTeamsScores()
    {
        if (_teams[0].GoalsScored > _teams[1].GoalsScored)
        {
            _teams[0].AchievedScore = 3;
            return;
        }
        if (_teams[0].GoalsScored < _teams[1].GoalsScored)
        {
            _teams[1].AchievedScore = 3;
            return;
        }

        if (_teams[0].GoalsScored == _teams[1].GoalsScored)
        {
            _teams[0].AchievedScore = 1;
            _teams[1].AchievedScore = 1;
            return;
        }

    }

}




public class MatchTeam
{
    public Team Team;
    public TeamCondition TeamCondition;
    public int GoalsScored;
    public int AchievedScore;
    [Range(0, 100)] public int AttendeesScore;
    public MatchTeam(Team team, TeamCondition teamCondition)
    {
        Team = team;
        TeamCondition = teamCondition;
    }
}



public enum TeamCondition
{
    Home,
    Away
}