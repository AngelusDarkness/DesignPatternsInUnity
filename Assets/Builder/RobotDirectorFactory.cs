using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotDirectorFactory : MonoBehaviour {
    private List<Robot> _robots = new List<Robot>();
    
    // Start is called before the first frame update
    IEnumerator Start()
    {
        Debug.Log("Robot Factory Starts");
        yield return new WaitForSeconds(2);
        _robots.Add(BuildMazinger());
        yield return new WaitForSeconds(3);
        _robots.Add(BuildVoltron());
        yield return new WaitForSeconds(1);
        _robots.Add(BuildGreatMazinger());
        yield return new WaitForSeconds(2);
        Debug.Log("Robot Factory Finished");
        foreach (var robot in _robots) {
            Debug.Log($"Robot Factory Finished: {robot.PrintBodyParts()}");    
        }
        
    }

    private Robot BuildMazinger() {
        var robot = new RobotAssembler()
            .AddBody("Body 1")
            .AddLegs("Legs 1")
            .AddLeftArm("Left Arm 1")
            .AddHorn("Horn 1")
            .Build("Mazinger Z");

        return robot;
    }
    
    private Robot BuildGreatMazinger() {
        var robot = new RobotAssembler()
            .AddBody("Body 3")
            .AddLegs("Legs 5")
            .AddLeftArm("Left Arm 2")
            .AddRightArm("Right Arm 2")
            .AddBooster("Booster Super")
            .Build("Great Mazinger");

        return robot;
    }
    
    private static Robot BuildVoltron() {
        var robot = new RobotAssembler()
            .AddBody("Body 66")
            .AddLegs("Super Archi Ultra Voltron Legs")
            .AddLeftArm("Left Arm 22")
            .AddRightArm("Left Arm 990")
            .AddHorn("BMFHorn")
            .AddBooster("Ultra Super Booster")
            .Build("Voltron");

        return robot;
    }

    
}
