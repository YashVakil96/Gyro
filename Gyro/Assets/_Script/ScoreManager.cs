using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    #region Variable

    public static int ScorePoints;
    public static int ScoreMilestone;

    public int SetScoreMilestone;
    #endregion


    #region System Methods
    private void Start()
    {
        ScoreMilestone = SetScoreMilestone;
    }
    private void Update()
    {
        if(ScorePoints >= ScoreMilestone)
        {
            ScoreMilestone += ScoreMilestone;
            SetScoreMilestone = ScoreMilestone;
            BallScript.SpeedStatic+=.3f;
            if(BallScript.SpeedStatic >= 5f)
            {
                BallScript.SpeedStatic = 5f;
            }
        }

    }
    #endregion


    #region User Define Methods


    #endregion

}
