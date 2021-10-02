using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class KnockoutSide : SideBase
{

    private string _sideName;
    public KnockoutSide(string sideName)
    {
        _sideName = sideName;
    }

    List<KnockoutMatchResult> _matchResults;
    public override void AddTeams(List<Team> teams)
    {
        if (ParticipatingTeams == null)
            ParticipatingTeams = new List<Team>(2);

        ParticipatingTeams.AddRange(teams);
    }

    public override List<Team> CalculateNextStageTeams()
    {
        return CalculatePassingTeam();
    }





    public override void RunMatches()
    {
        foreach (var item in Matches)
        {

            if (_matchResults == null)
                _matchResults = new List<KnockoutMatchResult>();

            var matchResults = item.CalculateKnockoutMatchResult(_sideName);
            _matchResults.AddRange(matchResults);




     



        }
    }

    public override void ScheduleMatches()
    {


        if (Matches == null)
            Matches = new List<Match>();

        for (int i = 0; i < ParticipatingTeams.Count; i++)
        {
            for (int j = 0; j < ParticipatingTeams.Count; j++)
            {
                if (i == j) continue;
                Match match = new Match("something", System.DateTime.Now.AddDays(5), 10000);
                MatchTeam team1 = new MatchTeam(ParticipatingTeams[i], TeamCondition.Home);
                MatchTeam team2 = new MatchTeam(ParticipatingTeams[j], TeamCondition.Away);
                match.AddTeams(team1);
                match.AddTeams(team2);
                Matches.Add(match);


            }


        }

    }


    private List<Team> CalculatePassingTeam()
    {
        List<Team> result = new List<Team>();


        int team0Scores = 0;
        int team0AwayScores = 0;

        var team0 = _matchResults.Where(x => x.Team == ParticipatingTeams[0]);
        var team0Away = _matchResults.Where(x => x.Team == ParticipatingTeams[0]).Where(x => x.Condition == TeamCondition.Away);

        foreach (var item in team0)
        {
            team0Scores += item.GoalsScored;
        }

        foreach (var item in team0Away)
        {
            team0AwayScores += item.GoalsScored;
        }




        int team1Scores = 0;
        int team1AwayScores = 0;

        var team1 = _matchResults.Where(x => x.Team == ParticipatingTeams[1]);
        var team1Away = _matchResults.Where(x => x.Team == ParticipatingTeams[1]).Where(x => x.Condition == TeamCondition.Away);

        foreach (var item in team1)
        {
            team1Scores += item.GoalsScored;
        }

        foreach (var item in team1Away)
        {
            team1AwayScores += item.GoalsScored;
        }




        if (team0Scores > team1Scores)
            result.Add(ParticipatingTeams[0]);

        if (team0Scores < team1Scores)
            result.Add(ParticipatingTeams[1]);

        if (team0Scores == team1Scores)
        {
            if (team0AwayScores > team1AwayScores)
                result.Add(ParticipatingTeams[0]);
            else if (team0AwayScores < team1AwayScores)
                result.Add(ParticipatingTeams[1]);

            //assume team 0 always wins penalties

            else result.Add(ParticipatingTeams[0]);
        }

        return result;
    }




}
