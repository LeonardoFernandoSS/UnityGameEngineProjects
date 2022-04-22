using System;

namespace ScreenSystem
{
    public class ScreenStateMachine
    {
        Action<ScreenState> onChangedState;

        private ScreenState state;
        public ScreenUI Screen { get; private set; }

        public ScreenState State
        {
            get => state;
            set
            {
                state = value;

                onChangedState?.Invoke(state);
            }
        }

        public ScreenStateMachine(ScreenUI screen)
        {
            Screen = screen;

            //State = new InactiveScreen(this);
        }
    }
}