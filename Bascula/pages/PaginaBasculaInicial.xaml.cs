using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Threading.Tasks;

namespace Bascula.pages
{
    /// <summary>
    /// Lógica de interacción para Window1.xaml
    /// </summary>
    public partial class PaginaBasculaInicial : Window
    {
        public PaginaBasculaInicial()
        {
            InitializeComponent();
            visibleObjects();

        }

        private async void visibleObjects()
        {
            await Task.Delay(000);
            BotonContinuar.Visibility = Visibility.Visible;
            CheckIcon.Visibility = Visibility.Visible;
        }

        
        

    }
}
