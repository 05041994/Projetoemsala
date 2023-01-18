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

namespace EscolaApp
{
    /// <summary>
    /// Lógica interna para Cad_Prof_TurmaWindow.xaml
    /// </summary>
    public partial class Cad_Prof_TurmaWindow : Window
    {
        public Cad_Prof_TurmaWindow()
        {
            InitializeComponent();
        }

        private void ListarClick(object sender, RoutedEventArgs e)
        {
            listTurmas.ItemsSource = null;
            listTurmas.ItemsSource = NTurma.Listar();
            listProfessor.ItemsSource = null;
            listProfessor.ItemsSource = NProfessor.Listar();
        }

        private void MatricularProfessorClick(object sender, RoutedEventArgs e)
        {
            if (listTurmas.SelectedItem != null &&
               listProfessor.SelectedItem != null)
            {
                Professor a = (Professor)listProfessor.SelectedItem;
                Turma t = (Turma)listTurmas.SelectedItem;
                NProfessor.Matricular(a, t);
                ListarClick(sender, e);
            }
            else
            {
                MessageBox.Show("É preciso selecionar um professor e uma turma");
            }
        }
    }
}
