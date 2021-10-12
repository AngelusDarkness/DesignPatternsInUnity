using System.Collections;
using System.Collections.Generic;
using Builder;
using UnityEngine;
using UnityEngine.Assertions;

public class RobotAssembler : IRobotBuilder {
    private readonly Robot _robot = new Robot();
    
    public IRobotBuilder AddLeftArm(string arm) {
        _robot.leftArm = arm;
        return this;
    }

    public IRobotBuilder AddRightArm(string arm) {
        _robot.rightArm = arm;
        return this;
    }

    public IRobotBuilder AddBody(string body) {
        _robot.body = body;
        return this;
    }

    public IRobotBuilder AddHorn(string horn) {
        _robot.horn = horn;
        return this;
    }

    public IRobotBuilder AddLegs(string legs) {
        _robot.legs = legs;
        return this;
    }

    public IRobotBuilder AddBooster(string booster) {
        _robot.booster = booster;
        return this;
    }

    public Robot Build(string name) {
        _robot.name = name;
        Debug.Log($"Building Robot: {name}");
        CheckPreconditions();
        return _robot;
    }
    
    private void CheckPreconditions() {
        Assert.IsNotNull(_robot.body,"Robot doesn't have a body set");
        Assert.IsNotNull(_robot.legs,"Robot doesn't have legs");
    }
}
