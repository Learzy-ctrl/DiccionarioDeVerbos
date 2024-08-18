using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DiccionarioDeVerbos.Infrastructure;
using DiccionarioDeVerbos.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace DiccionarioDeVerbos.ViewModels
{
    public class MainViewModel : ObservableObject
    {
        private readonly IVerbs _verbs;
        public ObservableCollection<string> Opciones { get; } = new ObservableCollection<string>
        {
            "Simple", "Past", "Past participle", "Spanish", "Pronunciation"
        };
        public ICommand SearchCommand { get; private set; }
        public MainViewModel(IVerbs verbs)
        {
            _verbs = verbs;
            SearchCommand = new AsyncRelayCommand(Search);
        }

        private string verbText;
        private string opcionSeleccionada;
        private string verbFound;
        private bool isLoading;
        public bool IsLoading
        {
            get => isLoading;
            set
            {
                if (isLoading != value)
                {
                    isLoading = value;
                    OnPropertyChanged();
                }
            }
        }
        public string OpcionSeleccionada
        {
            get => opcionSeleccionada;
            set
            {
                if (opcionSeleccionada != value)
                {
                    opcionSeleccionada = value;
                    OnPropertyChanged();
                }
            }
        }
        public string VerbText
        {
            get => verbText;
            set
            {
                if (verbText != value)
                {
                    verbText = value;
                    OnPropertyChanged();
                }
            }
        }
        public string VerbFound
        {
            get => verbFound;
            set
            {
                if (verbFound != value)
                {
                    verbFound = value;
                    OnPropertyChanged();
                }
            }
        }

        private async Task Search()
        {
            var data = new VerbDto
            {
                verb = VerbText,
                verbForm = OpcionSeleccionada
            };
            try
            {
                IsLoading = true;
                VerbFound = await _verbs.SearchVerb(data);
            }
            finally
            {
                IsLoading = false;
            }
        }
    }
}
