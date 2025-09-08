public class HeroStateContext
{
    public IHeroineState CurrentState { get; set; }

    private readonly HeroController _heroController;

    public HeroStateContext(HeroController heroController)
    {
        _heroController = heroController;
    }

    public void Transition()
    {
        CurrentState.Handle(_heroController);
    }

    public void Transition(IHeroineState state)
    {
        CurrentState = state;
        CurrentState.Handle(_heroController);
    }
}
