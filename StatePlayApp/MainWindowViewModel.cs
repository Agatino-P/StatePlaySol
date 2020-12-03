using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace StatePlayApp
{
    public partial class MainWindowViewModel : ViewModelBase
    {
        public enum ActionEnum { None, WakeUp, Walk, Snore, Sleep, NotValid }

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

        private AbstractState _currentState; 
        private AbstractState CurrentState { 
            get => _currentState; 
            set { 
                Set(() => CurrentState, ref _currentState, value);
                CurrentStateDisplayName = CurrentState.DisplayName;
            }
        }

        private string _currentStateDisplayName; 
        public string CurrentStateDisplayName { get => _currentStateDisplayName; set { Set(() => CurrentStateDisplayName, ref _currentStateDisplayName, value); }}

        private RelayCommand _wakeUpCmd;
        public RelayCommand WakeUpCmd => _wakeUpCmd ?? (_wakeUpCmd = new RelayCommand(
            () => wakeUp(),
            () => true,
			keepTargetAlive:true
            ));
		private void wakeUp()
        {
            _currentState.WakeUp();
        }

        private RelayCommand _walkCmd;
        public RelayCommand WalkCmd => _walkCmd ?? (_walkCmd = new RelayCommand(
                () => walk(),
                () => true,
                keepTargetAlive: true
                ));
        private void walk()
        {
            _currentState.Walk();
        }


        private RelayCommand _snoreCmd;
        public RelayCommand SnoreCmd => _snoreCmd ?? (_snoreCmd = new RelayCommand(
            () => snore(),
            () => true,
            keepTargetAlive: true
            ));
        private void snore()
        {
            _currentState.Snore();
        }


        private RelayCommand _sleepCmd;
        public RelayCommand SleepCmd => _sleepCmd ?? (_sleepCmd = new RelayCommand(
            () => sleep(),
            () => true,
			keepTargetAlive:true
            ));
		private void sleep()
        {
            _currentState.Sleep();
        }


        private void GoToState(AbstractState newState)
        {
            CurrentState = newState;
            newState.EnterState();
        }
        public MainWindowViewModel()
        {
            this.LastAction = ActionEnum.None;
            this.CurrentState = new AwakeState(this);
        }
    }
}
