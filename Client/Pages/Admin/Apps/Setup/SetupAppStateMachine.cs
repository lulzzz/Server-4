using System;
using System.Collections.Generic;
using AuthServer.Client.Pages.Admin.Apps.Setup.Steps;
using AuthServer.Shared.Admin;

namespace AuthServer.Client.Pages.Admin.Apps.Setup
{
    public class SetupAppStateMachine
    {
        public event Action? OnChange;
        IStep? _currentStep;
        private Stack<IStep> PreviousSteps = new Stack<IStep>();
        private IStep? NextStep;
        private AddNewAppRequest _addNewAppRequest = new AddNewAppRequest();

        internal void Initialize()
        {
            _currentStep = new ChooseAuthMethodStep();
        }

        internal AddNewAppRequest GetAddNewAppRequest()
        {
            return _addNewAppRequest;
        }

        public void FinishStep(IStep step)
        {
            switch (step)
            {

            }

            PreviousSteps.Push(step);
            _currentStep = NextStep;
            NextStep = null;
        }

        public void GoBack(IStep step)
        {
            _currentStep = PreviousSteps.Pop();
        }

        public void SetNextStep(IStep? step)
        {
            NextStep = step;
            OnChange?.Invoke();
        }

        public bool HasNextStep()
        {
            return (NextStep != null);
        }

        public bool HasPreviousStep()
        {
            return PreviousSteps.Count > 0;
        }

        public IStep GetCurrentStep()
        {
            return _currentStep;
        }
    }
}
