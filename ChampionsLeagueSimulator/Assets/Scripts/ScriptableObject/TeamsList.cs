using System.Collections;
using System.Collections.Generic;
using UnityEngine;





[CreateAssetMenu(fileName = "Team", menuName = "ScriptableObjects/TeamsList", order = 1)]
public class TeamsList : ScriptableObject
{
    public List<Team> Teams;
}
