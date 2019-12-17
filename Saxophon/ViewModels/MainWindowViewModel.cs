namespace Saxophon.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        private string _test = "Hier könnte ihr tesxt stehen!";
        public string Test
        {
            get => _test;
            set
            {
                _test = value;
                OnPropertyChanged(nameof(Test));
            }
        }
    }
}