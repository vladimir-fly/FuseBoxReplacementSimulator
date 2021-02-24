namespace FBRS.DataTypes
{
    /// <summary>
    /// Contains step data and failed attempts
    /// </summary>
    public class StepResult
    {
        public Step Step;
        public int Attempts;

        public StepResult(Step step)
        {
            Step = step;
            Attempts = 0;
        }
    }
}