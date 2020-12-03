namespace StatePlayApp
{
    public partial class MainWindowViewModel
    {
        private class AsleepState : AbstractState
        {
            public override string DisplayName => "Asleep";

            public AsleepState(MainWindowViewModel mainWindowViewModel) : base(mainWindowViewModel)
            { }
            public override void EnterState() { }
            public override void WakeUp()
            {
                _mwVM.GoToState(new AwakeState(_mwVM));
            }
            public override void Walk()
            {
                _mwVM.LastAction = ActionEnum.NotValid;
            }
            public override void Sleep()
            {
                _mwVM.LastAction = ActionEnum.NotValid;
            }
            public override void Snore() 
            {
                _mwVM.LastAction = ActionEnum.Snore;

            }
        }


    }
}
