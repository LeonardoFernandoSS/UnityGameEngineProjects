namespace IntroductionSystem
{
    public interface IIntroductable
    {
        IntroductionData IntroductionData { get; }

        bool InitIntroduction();
    }
}
