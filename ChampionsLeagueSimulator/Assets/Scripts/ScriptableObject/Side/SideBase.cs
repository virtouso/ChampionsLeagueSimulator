using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SideBase : ScriptableObject
{
    protected List<Team> ParticipatingTeams;
    protected List<Match> Matches;

    public abstract void AddTeams(List<Team> teams);
    public abstract void ScheduleMatches();
    public abstract void RunMatches();

    public abstract List<Team> CalculateNextStageTeams();



}
