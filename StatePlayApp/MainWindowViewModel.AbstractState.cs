namespace StatePlayApp
{
    public partial class MainWindowViewModel
    {
        private abstract class AbstractState
        {
            protected MainWindowViewModel _mwVM;
            public AbstractState(MainWindowViewModel  mainWindowViewModel)
            {
                _mwVM = mainWindowViewModel;
            }
            public abstract string DisplayName { get; }
            public abstract void EnterState();
            public abstract void WakeUp();
            public abstract void Walk();
            public abstract void Sleep();
            public abstract void Snore();

        }


    }
}
