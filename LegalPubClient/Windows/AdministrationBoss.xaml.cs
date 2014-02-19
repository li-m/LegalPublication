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

namespace LegalPubClient
{
    /// <summary>
    /// Interaction logic for AdministrationBoss.xaml
    /// </summary>
    public partial class AdministrationBoss : Window
    {
        ServiceReference1.Service1Client service1 = new ServiceReference1.Service1Client();    
        List<ServiceReference1.user> userList = new List<ServiceReference1.user>();
        
        public AdministrationBoss()
        {
            InitializeComponent();
            refresh();
        }



        private void Update_Click(object sender, RoutedEventArgs e)
        {
            if (selectedID.GetLineText(0) != ""
                && selectedPassword.GetLineText(0).Trim() != ""
                && (string)selectedRole.Text != "")
            {
                int id = System.Int32.Parse(selectedID.GetLineText(0));
                string password = selectedPassword.GetLineText(0).Trim();
                string role = (string)selectedRole.Text;

                if (service1.UpdateUser(id, password, role))
                {
                    Status.Text = "User id: " + id + " updated";
                }
            }

            refresh();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (selectedID.GetLineText(0) != "")
            {
                int id = System.Int32.Parse(selectedID.GetLineText(0));

                if (service1.DeleteUser(id))
                {
                    Status.Text = "User id: " + id + " deleted";
                }
            }
            refresh();
        }

        private void Ok_Click(object sender, RoutedEventArgs e)
        {
            if (NewUsername.GetLineText(0).Trim() != "" && NewPassword.GetLineText(0).Trim() != "" && NewRole.Text != "")
            {
                string username = NewUsername.GetLineText(0).Trim();
                string password = NewPassword.GetLineText(0).Trim();
                string role = (string)NewRole.Text;
                Status.Text = role + username;

                if (service1.AddUser(username, password, role))
                {
                    Status.Text = "User " + username + " created";
                }
            }
            refresh();
        }

        private void refresh()
        {
            listView1.BeginInit();
            userList.Clear();
            foreach (ServiceReference1.user user in service1.GetUsers())
            {
                userList.Add(user);
            }
            listView1.ItemsSource = userList;
            listView1.EndInit();
        }
    }
}
