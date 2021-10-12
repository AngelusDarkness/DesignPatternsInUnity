

public class Robot {
    public string name;
    public string leftArm;
    public string rightArm;
    public string body;
    public string legs;
    public string horn;
    public string booster;
    
    public string PrintBodyParts() {
        return
            $"Building Robot {name} With:  {body} {leftArm} {rightArm} {legs} {booster} {horn}";
    }

}
