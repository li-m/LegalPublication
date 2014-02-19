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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LegalPubClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {


        public MainWindow()
        {
            InitializeComponent();            
        }



        private void ChooseFirmRepre_Click(object sender, RoutedEventArgs e)
        {
            Status.Text = "Loading";
            FirmRepresentative firmRepre = new FirmRepresentative();
            firmRepre.Show();
            this.Close();
        }

        private void ChooseAdminSecr_Click(object sender, RoutedEventArgs e)
        {
            Status.Text = "Loading";
            AdministrationSecretary adminSecr = new AdministrationSecretary();
            adminSecr.Show();
            this.Close();
        }

        private void ChooseAdminVald_Click(object sender, RoutedEventArgs e)
        {
            Status.Text = "Loading";
            AdministrationValidator adminVald = new AdministrationValidator();
            adminVald.Show();
            this.Close();
        }

        private void ChooseAdminBoss_Click(object sender, RoutedEventArgs e)
        {
            Status.Text = "Loading";
            AdministrationBoss adminBoss = new AdministrationBoss();
            adminBoss.Show();
            this.Close();
        }


    }
}
