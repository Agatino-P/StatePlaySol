using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace StatePlayApp
{
    public class MainWindowViewModel : ViewModelBase
    {
        public enum ActionEnum { None, WakeUp, Walk, Snore, Sleep }

        private ActionEnum lastAction;
        public ActionEnum LastAction
        {
            get { return lastAction; }
            private set
            {
                lastAction = value;
                LastActionDisplayName = LastAction.ToString();
            }
        }

        


        private string _lastActionDisplayName;
        public string LastActionDisplayName { get => _lastActionDisplayName; set { Set(() => LastActionDisplayName, ref _lastActionDisplayName, value); } }

        private AbstractState _currentState =new AwakeState();

        private string _currentStateDisplayName;

        public string CurrentStateDisplayName
        {
            get { return _currentStateDisplayName; }
            set { _currentStateDisplayName = value; }
        }


        private RelayCommand _walkCmd;
        public RelayCommand WalkCmd => _walkCmd ?? (_walkCmd = new RelayCommand(
                () => walk(),
                () => true,
                keepTargetAlive: true
                ));
        private void walk()
        {
        }


        private RelayCommand _snoreCmd;
        public RelayCommand SnoreCmd => _snoreCmd ?? (_snoreCmd = new RelayCommand(
            () => snore(),
            () => true,
			keepTargetAlive:true
            ));
		private void snore()
        {
        }

        private void GoToState(AbstractState newState)
        {
            _currentState = newState;
            newState.EnterState();
        }
        public MainWindowViewModel()
        {
            this.LastAction = ActionEnum.None;
        }
        private abstract class AbstractState
        {
            public abstract void EnterState();
            public abstract void WakeUp();
            public abstract void Walk();
            public abstract void Sleep();
            public abstract void Snore();

        }
        private class AwakeState : AbstractState
        {
            public override void EnterState() { }
            public override void WakeUp(){ }
            public override void Walk() { }
            public override void Sleep(){}
            public override void Snore() { }
        }

        private class AsleepState : AbstractState
        {
            public override void EnterState() { }
            public override void WakeUp() { }
            public override void Walk() { }
            public override void Sleep() { }
            public override void Snore() { }
        }


    }
}
