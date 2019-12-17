using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using Saxophon.Models;
using Saxophon.Resources;

namespace Saxophon.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        public List<string> Shifts => Enum.GetNames(typeof(Resources.Shifts)).ToList();

        public List<string> Durations => Enum.GetNames(typeof(Resources.Durations)).ToList();

        public List<string> Notes => Enum.GetNames(typeof(Resources.Notes)).ToList();

        private List<Tone> _tones;
        private string _selectedShift;

        public MainWindowViewModel()
        {
            Tones = new List<Tone>();
            AddToneCommand = new RelayCommand(ExecuteAddToneCommand, CanExecuteAddToneCommand);
        }

        public List<Tone> Tones
        {
            get => _tones;
            set
            {
                _tones = value;
                OnPropertyChanged(nameof(Tones));
            }
        }

        public string SelectedShift
        {
            get => _selectedShift;
            set
            {
                _selectedShift = value;
                OnPropertyChanged(nameof(SelectedShift));
            }
        }

        public RelayCommand AddToneCommand { get; set; }

        private bool CanExecuteAddToneCommand(object parameter)
        {
            return true;
        }

        private void ExecuteAddToneCommand(object parameter)
        {
            var tone = new Tone();
            Enum.TryParse(SelectedShift, out Shifts shift);
            tone.shift = shift;
            Tones.Add(tone);
        }
    }
}