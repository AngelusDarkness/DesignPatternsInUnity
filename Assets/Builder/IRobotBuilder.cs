using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Builder {
    
    public interface IRobotBuilder {
        IRobotBuilder AddLeftArm(string arm);
        IRobotBuilder AddRightArm(string arm);
        IRobotBuilder AddBody(string body);
        IRobotBuilder AddHorn(string horn);
        IRobotBuilder AddLegs(string legs);
        IRobotBuilder AddBooster(string booster);
        
        Robot Build(string name);
    }    
}

