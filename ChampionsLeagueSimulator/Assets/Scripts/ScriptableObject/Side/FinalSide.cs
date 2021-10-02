using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalSide : SideBase
{
    public override void AddTeams(List<Team> teams)
    {
        ParticipatingTeams.AddRange(teams);
    }

    public override List<Team> CalculateNextStageTeams()
    {
        throw new System.NotImplementedException();
    }

    public override void RunMatches()
    {
        var results = Matches[0].CalculateMatchResult();

    }

    public override void ScheduleMatches()
    {
        Matches = new List<Match>();
        Match match = new Match("", System.DateTime.Now.AddDays(100), 10000);

        MatchTeam team0 = new MatchTeam(ParticipatingTeams[0], TeamCondition.Away);
        MatchTeam team1 = new MatchTeam(ParticipatingTeams[1], TeamCondition.Away);

        match.AddTeams(team0);
        match.AddTeams(team1);


        Matches.Add(match);
    }



    private void CheckChampion(List<TeamRanking> ranks)
    {
        if (ranks[0].GoalsScored > ranks[1].GoalsScored)
            UtilityLogger.LogResults(ranks[0].Team.TeamName + " Is Champion");

        else if (ranks[0].GoalsScored < ranks[1].GoalsScored)
            UtilityLogger.LogResults(ranks[1].Team.TeamName + " Is Champion");

        //assume team o always wins penalties

        else
            UtilityLogger.LogResults(ranks[0].Team.TeamName + " Is Champion");



    }



}
