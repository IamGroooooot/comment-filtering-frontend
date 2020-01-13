public class Comment
{
    public float rate;
    public string reply;

    public string SaveToString()
    {
        return UnityEngine.JsonUtility.ToJson(this);
    }

    public Comment(float _rate, string _reply)
    {
        rate = _rate;
        reply = _reply;
    }

    // Given:
    // rate = 0.1
    // reply = "악플"
    // SaveToString returns:
    // {"rate":0.1,"reply":"악플"}
}