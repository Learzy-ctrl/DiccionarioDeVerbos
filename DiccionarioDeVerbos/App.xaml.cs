using DiccionarioDeVerbos.Views;

namespace DiccionarioDeVerbos
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }
    }
}
