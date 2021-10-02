using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System;
using System.Text;

public class GroupSide : SideBase
{
    private Dictionary<Team, TeamRanking> _rankings;

    private string _sideName;
    public  GroupSide(string sideName)
    {
        _sideName = sideName;
    }

    public override void AddTeams(List<Team> teams)
    {
        ParticipatingTeams = teams;
    }

    public override List<Team> CalculateNextStageTeams()
    {
        var order = _rankings.OrderBy(x => x.Value.GoalsReceived).ThenByDescending(x => x.Value.GoalsScored).ThenByDescending(x => x.Value.TotalScore);
        List<Team> result = new List<Team>();
        result.Add(order.ElementAt(0).Value.Team);
        result.Add(order.ElementAt(1).Value.Team);

        return result;
    }

    public override void RunMatches()
    {
        if (_rankings == null)
        {
            _rankings = new Dictionary<Team, TeamRanking>();
            foreach (var item in ParticipatingTeams)
            {
                _rankings.Add(item, new TeamRanking(item, 0, 0, 0));
            }

        }


        foreach (var item in Matches)
        {
            var matchResults = item.CalculateMatchResult(_sideName);



    

            //StringBuilder result = new StringBuilder();
            //result.Append(this.name).Append(Environment.NewLine)
            //    .Append(matchResults[0].Team.TeamName).Append($"({matchResults[0].Team.Nationality})").Append(matchResults[0].GoalsScored).Append("-")
            //    .Append(matchResults[1].GoalsScored).Append($"({matchResults[1].Team.Nationality})").Append(matchResults[1].Team.TeamName);

            //UtilityLogger.LogResults(result.ToString());



            foreach (var subItem in matchResults)
            {
                _rankings[subItem.Team].GoalsScored += subItem.GoalsScored;
                _rankings[subItem.Team].GoalsReceived += subItem.GoalsReceived;
                _rankings[subItem.Team].TotalScore += subItem.TotalScore;

            }
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
                if (ParticipatingTeams[i] == ParticipatingTeams[j]) continue;
                Match match = new Match("something", System.DateTime.Now.AddDays(5), 10000);
                MatchTeam team1 = new MatchTeam(ParticipatingTeams[i], TeamCondition.Home);
                MatchTeam team2 = new MatchTeam(ParticipatingTeams[j], TeamCondition.Away);
                match.AddTeams(team1);
                match.AddTeams(team2);
                Matches.Add(match);


            }
        }


    }
}
