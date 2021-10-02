using System.Collections;
using System.Collections.Generic;
using UnityEngine;





[CreateAssetMenu(fileName = "Team", menuName = "ScriptableObjects/TeamsList", order = 1)]
public class TeamsList : ScriptableObject
{
  [SerializeField]  private List<Team> _teams;


    private Dictionary<TeamNamesEnum, Team> _teamsDictionary;

    public Dictionary<TeamNamesEnum, Team> TeamsDictionary
    {
        get
        {
            if (_teamsDictionary == null)
            {
                _teamsDictionary = new Dictionary<TeamNamesEnum, Team>(_teams.Count);
                foreach (var item in _teams)
                {
                    _teamsDictionary.Add(item.TeamName, item);
                }
            }
            return _teamsDictionary;
        }
    }





}



public enum TeamNamesEnum
{

    Ajax,
    Atalanta,
    Atletico,
    Barcelona,
    Bayern,
    Benfica,
    Besiktas,
    Chelsea,
    ClubBruges,
    Durtmond,
    DynamoKyiv,
    Inter,
    Juventus,
    Leipzig,
    LilleOsc,
    LiverPool,
    Malmo,
    ManCity,
    Manchester,
    Milan,
    Paris,
    Porto,
    Real,
    Salzburg,
    Sevilla,
    Shakhtar,
    Sheriff,
    Sporting,
    Villareal,
    Wolfsburg,
    YoungBoys,
    Zenit

}