using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroupSide : SideBase
{
    public override void AddTeams(List<Team> teams)
    {
        ParticipatingTeams = teams;
    }

    public override List<Team> CalculateNextStageTeams()
    {
        throw new System.NotImplementedException();
    }

    public override void RunMatches()
    {
        throw new System.NotImplementedException();
    }

    public override void ScheduleMatches()
    {
        throw new System.NotImplementedException();
    }
}
