using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ComandosYMenus
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string textoCopiado = "";
        public MainWindow()
        {
            miLista = new ListBox();
            InitializeComponent();
            
        }

        private void NewCommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            TextBlock tb = new TextBlock
            {
                Text = DateTime.Now + ""
            };
            miLista.Items.Add(tb);
        }


        private void NewCommandBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (miLista.Items.Count < 10)
                e.CanExecute = true;
            else
                e.CanExecute = false;
        }

        private void CopyCommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            textoCopiado = miLista.SelectedValue.ToString();
        }

        private void CopyCommandBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (miLista.SelectedItem == null)
                e.CanExecute = false;
            else
                e.CanExecute = true;
        }

        private void PasteCommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            TextBlock tb = new TextBlock
            {
                Text = textoCopiado
            };
            miLista.Items.Add(tb.Text);
            textoCopiado = "";
        }

        private void PasteCommandBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (textoCopiado != "")
                e.CanExecute = true;
            else
                e.CanExecute = false;
        }
    }
}
