using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Taskio.ViewModel
{
    public class BudgetCalculatorViewModel:BaseViewModel
    {
        private int _payPerHour;
        private List<double> _hours =new List<double>{ 1, 1.5, 2, 2.5, 3, 3.5, 4, 4.5, 5, 5.5, 6, 6.5, 7, 7.5 };
        private List<int> _numberOfDays = new List<int> { 7, 14, 30, 60, 365 };
        private bool _isCalculateButtonEnabled;
        private bool _isDisplayResultVisible;
        private string _displayResultText;
        private Color _textColor = Color.Green;
        private int _selectedHourIndex;
        private int _selectedNumberOfDaysIndex;
        public int PayPerHour
        {
            get { return _payPerHour; }
            set {
                _payPerHour = value;
                OnPropertyChanged(nameof(PayPerHour));
            }
        }
        public List<double> HourOptions
        {
            get { return _hours; }
            protected set { }
        }

        public List<int> NumberOfDays
        {
            get { return _numberOfDays; }
            set
            {
            }
        }

        public bool IsCalculateButtonEnabled
        {
            get { return _isCalculateButtonEnabled; }
            set
            {
                _isCalculateButtonEnabled = value;
                OnPropertyChanged(nameof(IsCalculateButtonEnabled));
            }
        }
        public bool IsDisplayResultVisible
        {
            get { return _isDisplayResultVisible; }
            set
            {
                _isDisplayResultVisible = value;
                OnPropertyChanged(nameof(IsDisplayResultVisible));
            }
        }

        public Color TextColor
        {
            get { return _textColor; }
            set
            {
                _textColor = value;
                OnPropertyChanged(nameof(TextColor));
            }
        }
        public int SelectedHourIndex
        {
            get { return _selectedHourIndex; }
            set
            {
                _selectedHourIndex = value;
                OnPropertyChanged(nameof(SelectedHourIndex));
            }
        }
        public int SelectedNumberOfDaysIndex
        {
            get { return _selectedNumberOfDaysIndex; }
            set
            {
                _selectedNumberOfDaysIndex = value;
                OnPropertyChanged(nameof(SelectedNumberOfDaysIndex));
            }
        }
        public ICommand EntryCompletedCommand { get; set; }
        public ICommand CalculateButtonClicked { get; set; }

        public string DisplayResultText
        {
            get { return _displayResultText; }
            set
            {
                _displayResultText = value;
                OnPropertyChanged(nameof(DisplayResultText));
            }
        }

        public BudgetCalculatorViewModel()
        {
            EntryCompletedCommand = new Command(EntryCompleted);
            CalculateButtonClicked = new Command(Calculate);
        }
        private void EntryCompleted()
        {
            if(PayPerHour <0 || PayPerHour > 1000)
            {
                IsCalculateButtonEnabled = false;
                IsDisplayResultVisible = true;
                TextColor = Color.Red;
                DisplayResultText = $"Entered Number, {PayPerHour} is not accept";
            }
            else
            {
                IsCalculateButtonEnabled = true;
                IsDisplayResultVisible = false;
                TextColor = Color.Green;
            }
        }
        private void Calculate()
        {
            double final = PayPerHour * _hours[SelectedHourIndex] * _numberOfDays[SelectedNumberOfDaysIndex];
            DisplayResultText = $"Your Calculated Amount for a Month is: {final}";
            IsDisplayResultVisible = true;
            TextColor = Color.Green;
        }
    }
}
