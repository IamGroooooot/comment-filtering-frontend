// Given:
// rate = 0.1
// reply = "악플"
// SaveToString returns:
// {"rate":0.1,"reply":"악플"}
public class Comment
{
    public float filterRatio;
    public string reply;

    public string SaveToString()
    {
        return UnityEngine.JsonUtility.ToJson(this);
    }

    public Comment(float _ratio, string _reply)
    {
        filterRatio = _ratio;
        reply = _reply;
    }
}