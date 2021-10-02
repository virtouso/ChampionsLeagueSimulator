using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockoutMatchResult 
{
    public Team Team;
    public TeamCondition Condition;
    public int GoalsScored;

    public KnockoutMatchResult(Team team, TeamCondition condition, int goalsScored)
    {
        Team = team;
        Condition = condition;
        GoalsScored = goalsScored;
    }
}
