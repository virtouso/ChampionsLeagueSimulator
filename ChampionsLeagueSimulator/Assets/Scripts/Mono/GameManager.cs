using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] TeamsList _teamsList;

    private void Start()
    {
        Stage groupStage = new Stage();
        groupStage.Sides = new List<SideBase>();

        GroupSide groupA = new GroupSide("Group A");
        groupA.AddTeams(new List<Team>() { _teamsList.TeamsDictionary[TeamNamesEnum.ManCity], _teamsList.TeamsDictionary[TeamNamesEnum.Paris], _teamsList.TeamsDictionary[TeamNamesEnum.Leipzig], _teamsList.TeamsDictionary[TeamNamesEnum.ClubBruges] });

        GroupSide groupB = new GroupSide("Group B");
        groupB.AddTeams(new List<Team>() { _teamsList.TeamsDictionary[TeamNamesEnum.Atletico], _teamsList.TeamsDictionary[TeamNamesEnum.LiverPool], _teamsList.TeamsDictionary[TeamNamesEnum.Porto], _teamsList.TeamsDictionary[TeamNamesEnum.Milan] });

        GroupSide groupC = new GroupSide("Group C");
        groupC.AddTeams(new List<Team>() { _teamsList.TeamsDictionary[TeamNamesEnum.Sporting], _teamsList.TeamsDictionary[TeamNamesEnum.Durtmond], _teamsList.TeamsDictionary[TeamNamesEnum.Ajax], _teamsList.TeamsDictionary[TeamNamesEnum.Besiktas] });


        GroupSide groupD = new GroupSide("Group D");
        groupD.AddTeams(new List<Team>() { _teamsList.TeamsDictionary[TeamNamesEnum.Inter], _teamsList.TeamsDictionary[TeamNamesEnum.Real], _teamsList.TeamsDictionary[TeamNamesEnum.Shakhtar], _teamsList.TeamsDictionary[TeamNamesEnum.Sheriff] });

        GroupSide groupE = new GroupSide("Group E");
        groupE.AddTeams(new List<Team>() { _teamsList.TeamsDictionary[TeamNamesEnum.Bayern], _teamsList.TeamsDictionary[TeamNamesEnum.Barcelona], _teamsList.TeamsDictionary[TeamNamesEnum.Benfica], _teamsList.TeamsDictionary[TeamNamesEnum.DynamoKyiv] });

        GroupSide groupF = new GroupSide("Group F");
        groupF.AddTeams(new List<Team>() { _teamsList.TeamsDictionary[TeamNamesEnum.Villareal], _teamsList.TeamsDictionary[TeamNamesEnum.Manchester], _teamsList.TeamsDictionary[TeamNamesEnum.Atalanta], _teamsList.TeamsDictionary[TeamNamesEnum.YoungBoys] });

        GroupSide groupG = new GroupSide("Group G");
        groupG.AddTeams(new List<Team>() { _teamsList.TeamsDictionary[TeamNamesEnum.LilleOsc], _teamsList.TeamsDictionary[TeamNamesEnum.Sevilla], _teamsList.TeamsDictionary[TeamNamesEnum.Salzburg], _teamsList.TeamsDictionary[TeamNamesEnum.Wolfsburg] });

        GroupSide groupH = new GroupSide("Group H");
        groupH.AddTeams(new List<Team>() { _teamsList.TeamsDictionary[TeamNamesEnum.Chelsea], _teamsList.TeamsDictionary[TeamNamesEnum.Juventus], _teamsList.TeamsDictionary[TeamNamesEnum.Zenit], _teamsList.TeamsDictionary[TeamNamesEnum.Malmo] });

        groupStage.Sides.Add(groupA);
        groupStage.Sides.Add(groupB);
        groupStage.Sides.Add(groupC);
        groupStage.Sides.Add(groupD);
        groupStage.Sides.Add(groupE);
        groupStage.Sides.Add(groupF);
        groupStage.Sides.Add(groupG);
        groupStage.Sides.Add(groupH);

        foreach (var item in groupStage.Sides)
        {
            item.ScheduleMatches();
        }

        foreach (var item in groupStage.Sides)
        {
            item.RunMatches();
        }



        List<List<Team>> groupsResults = new List<List<Team>>();


        foreach (var item in groupStage.Sides)
        {
            groupsResults.Add(item.CalculateNextStageTeams());
        }










        Stage finalEight = new Stage();

        finalEight.Sides = new List<SideBase>();




        for (int i = 0; i < groupsResults.Count; i++)
        {
            KnockoutSide side = new KnockoutSide("Final Eight");
            side.AddTeams(new List<Team>(2) {groupsResults[i][0], groupsResults[groupsResults.Count-1-i][1]});
            finalEight.Sides.Add(side);
        }

        foreach (var item in finalEight.Sides)
        {
            item.ScheduleMatches();
        }

        foreach (var item in finalEight.Sides)
        {
            item.RunMatches();
        }

        List<List<Team>> finalEightResults= new List<List<Team>>();


        foreach (var item in finalEight.Sides)
        {
            finalEightResults.Add(item.CalculateNextStageTeams());
        }





        Stage finalFour = new Stage();
        finalFour.Sides = new List<SideBase>();




        for (int i = 0; i <finalEightResults.Count; i+=2)
        {
            KnockoutSide side = new KnockoutSide("Final Four");
            side.AddTeams(new List<Team>(1) { finalEightResults[i][0] });
            side.AddTeams(new List<Team>(1) { finalEightResults[i+1][0] });
            finalFour.Sides.Add(side);
        }

        foreach (var item in finalFour.Sides)
        {
            item.ScheduleMatches();
        }

        foreach (var item in finalFour.Sides)
        {
            item.RunMatches();
        }

        List<List<Team>> finalFourResults = new List<List<Team>>();


        foreach (var item in finalFour.Sides)
        {
            finalFourResults.Add(item.CalculateNextStageTeams());
        }






        Stage semiFinal = new Stage();
        semiFinal.Sides = new List<SideBase>();
        for (int i = 0; i < finalFourResults.Count; i += 2)
        {
            KnockoutSide side = new KnockoutSide("Semi Final");
            side.AddTeams(new List<Team>(1) { finalFourResults[i][0] });
            side.AddTeams(new List<Team>(1) { finalFourResults[i + 1][0] });
            semiFinal.Sides.Add(side);
        }
        foreach (var item in semiFinal.Sides)
        {
            item.ScheduleMatches();
        }

        foreach (var item in semiFinal.Sides)
        {
            item.RunMatches();
        }

        List<List<Team>> semiFinalResults = new List<List<Team>>();


        foreach (var item in semiFinal.Sides)
        {
            semiFinalResults.Add(item.CalculateNextStageTeams());
        }





        Stage final = new Stage();

        final.Sides = new List<SideBase>();
        for (int i = 0; i < semiFinalResults.Count; i += 2)
        {
            FinalSide side = new FinalSide();
            side.AddTeams(new List<Team>(1) { semiFinalResults[i][0] });
            side.AddTeams(new List<Team>(1) { semiFinalResults[i + 1][0] });
            final.Sides.Add(side);
        }

        foreach (var item in final.Sides)
        {
            item.ScheduleMatches();
        }

        foreach (var item in final.Sides)
        {
            item.RunMatches();
        }

        List<List<Team>> finalResults = new List<List<Team>>();


        //foreach (var item in final.Sides)
        //{
        //    finalResults.Add(item.CalculateNextStageTeams());
        //}



    }


}
