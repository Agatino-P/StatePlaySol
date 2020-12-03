namespace StatePlayApp
{
    public partial class MainWindowViewModel
    {
        private class AwakeState : AbstractState
        {
            public override string DisplayName => "Awake";

            public AwakeState(MainWindowViewModel mainWindowViewModel) : base(mainWindowViewModel)
            { }
            public override void EnterState() { }
            public override void WakeUp() 
            {
                _mwVM.LastAction = ActionEnum.NotValid;
            }
            public override void Walk() 
            {
                _mwVM.LastAction = ActionEnum.Walk;
            }
            public override void Sleep() {
                _mwVM.GoToState(new AsleepState(_mwVM));
            }
            public override void Snore() {
                _mwVM.LastAction = ActionEnum.NotValid;

            }
        }


    }
}
