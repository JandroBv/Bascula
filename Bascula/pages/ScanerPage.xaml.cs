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

namespace Bascula.pages
{
    /// <summary>
    /// Lógica de interacción para ScanerPage.xaml
    /// </summary>
    public partial class ScanerPage : Window
    {
        Dictionary<string, Color> coloresDiccionario = new Dictionary<String, Color>
        {
            {"rojo",Colors.Red },
            {"azul", Colors.Blue },
            {"amarillo", Colors.Yellow},
            {"naranja", Colors.Orange}
        };

        Dictionary<string, string>[] coloresList = 
        {
            new Dictionary<string, string>
            {
                {"nombre","rojo"},
                {"peso", "3.3"}
            },
            new Dictionary<string, string>
            {
                {"nombre","azul"},
                {"peso", "2"}
            },
            new Dictionary<string, string>
            {
                {"nombre","amarillo"},
                {"peso", "4.5"}
            },
            new Dictionary<string, string>
            {
                {"nombre","naranja"},
                {"peso", "5"}
            }

        };
        

        public ScanerPage()
        {
            InitializeComponent();
            for(int index = 0; index < coloresList.Length; index++)
            {
                AddPintura(coloresList[index], index);
            }
        }

        private void AddPintura(Dictionary<string, string> pintura, int indice)
        {
            var id = new TextBlock();
            var colorContainer = new Grid();
            var peso = new TextBlock();
            var borrar = new Button();
            var colorName = new TextBlock();
            var colorItem = new Border();
            var iconoBorrar = new Image();
            var borderId = new Border();
            var colorBorder = new Border();
            var pesoBorder = new Border();
            var borrarBorder = new Border();
            string nombrePintura = pintura["nombre"];

            //estilos para el id
            id.Text = (indice + 1).ToString();
            id.FontSize = 30;
            id.VerticalAlignment = VerticalAlignment.Center;
            id.TextAlignment = TextAlignment.Center;
           
            //estilos para color container
            colorContainer.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            colorContainer.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });

            colorContainer.Margin = new Thickness(0, 10, 0, 10);
            //colorContainer.HorizontalAlignment = HorizontalAlignment.Center;

            //estilos para el nombre de la pintura
            colorName.Text = nombrePintura.ToUpper();
            colorName.FontSize = 28;
            colorName.FontWeight = FontWeights.DemiBold;
            colorName.VerticalAlignment = VerticalAlignment.Center;
            colorName.Margin = new Thickness(0, 0, 20, 0);
            colorName.TextAlignment = TextAlignment.Center;
            Grid.SetColumn(colorName, 0);

            //estilos para el circulo de color
            colorItem.CornerRadius = new CornerRadius(50);
            colorItem.Background = new SolidColorBrush(coloresDiccionario[nombrePintura]);
            colorItem.HorizontalAlignment = HorizontalAlignment.Center;
            colorItem.Width = 50;
            colorItem.Height = 50;
            colorItem.VerticalAlignment = VerticalAlignment.Center;
            colorItem.Margin = new Thickness(20, 0, 0, 0);
            Grid.SetColumn(colorItem, 1);

            //estilos para el peso
            peso.FontSize = 30;
            peso.VerticalAlignment = VerticalAlignment.Center;
            peso.Padding = new Thickness(10,0,10,0);
            peso.TextAlignment = TextAlignment.Center;
            peso.Text = $"{pintura["peso"]}ml";

            //estilos para borrar
            borrar.Background = new SolidColorBrush(Colors.Transparent);
            borrar.BorderThickness = new Thickness(0,0,0,0);
            borrar.Content = iconoBorrar;

            //estilos para icono borrar
            iconoBorrar.Source = new BitmapImage(new Uri("/assets/TrashIcon.png", UriKind.RelativeOrAbsolute));
            iconoBorrar.Width = 55;
            iconoBorrar.Height = 55;

            //agregar numero de columna y filas para cada elemento
            Grid.SetColumn(borderId, 0);
            Grid.SetColumn(colorBorder, 1);
            Grid.SetRow(colorBorder, indice + 2);
            Grid.SetRow(borderId, indice + 2);
            Grid.SetRow(pesoBorder, indice + 2);
            Grid.SetRow(borrarBorder, indice + 2);
            Grid.SetColumn(pesoBorder, 2);
            Grid.SetColumn(borrarBorder, 3);

            //agregar children al contenedor del color (nombre, color)
            colorContainer.Children.Add(colorName);
            colorContainer.Children.Add(colorItem);

            //estilos para los bordes
            borderId.BorderBrush = new SolidColorBrush(Color.FromRgb(0, 0, 0));
            borderId.BorderThickness = new Thickness(2, 0, 2, 2);

            colorBorder.BorderBrush = new SolidColorBrush(Color.FromRgb(0, 0, 0));
            colorBorder.BorderThickness = new Thickness(0, 0, 2, 2);

            pesoBorder.BorderBrush = new SolidColorBrush(Color.FromRgb(0, 0, 0));
            pesoBorder.BorderThickness = new Thickness(0, 0, 2, 2);

            borrarBorder.BorderBrush = new SolidColorBrush(Color.FromRgb(0, 0, 0));
            borrarBorder.BorderThickness = new Thickness(0, 0, 2, 2);
            
            if(indice == 0)
            {
                borderRectangle.BorderThickness = new Thickness(0,0,0,2);
            }

            borderId.Child = id;
            colorBorder.Child = colorContainer;
            pesoBorder.Child = peso;
            borrarBorder.Child = borrar;

            TablaColores.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
            TablaColores.Children.Add(borderId);
            TablaColores.Children.Add(colorBorder);
            TablaColores.Children.Add(pesoBorder);
            TablaColores.Children.Add(borrarBorder);

        }
    }
    
}
