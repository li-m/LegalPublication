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
    /// Interaction logic for AdministrationSecretary.xaml
    /// </summary>
    
    public partial class AdministrationSecretary : Window
    {

        ServiceReference1.Service1Client service1 = new ServiceReference1.Service1Client();
        List<ServiceReference1.documentfile> documentFileList = new List<ServiceReference1.documentfile>();

        public AdministrationSecretary()
        {
            InitializeComponent();

            Status.Text = "Refreshing...";
            refresh();
            Status.Text = "Ready";
        }

        private void Prevalidate_Click(object sender, RoutedEventArgs e)
        {
            if (this.listView1.SelectedItems.Count != 0)
            {
                foreach (Object o in this.listView1.SelectedItems)
                {
                    ServiceReference1.documentfile documentSelected = (ServiceReference1.documentfile)o;
                    int id = documentSelected.Id;

                    if (service1.PreValidateDocument(id))
                    {
                        Status.Text = listView1.SelectedItems.Count + " document(s) Prevalidated";
                    }
                }
            }

            refresh();
        }

        private void Reject_Click(object sender, RoutedEventArgs e)
        {
            if (this.listView1.SelectedItems.Count != 0) 
            {
                foreach (Object o in this.listView1.SelectedItems)
                {
                    ServiceReference1.documentfile documentSelected = (ServiceReference1.documentfile)o;
                    int id = documentSelected.Id;

                    if (service1.DeleteDocument(id))
                    {
                        Status.Text = listView1.SelectedItems.Count + " document(s) Deleteted";
                    }
                }
            }

            refresh();
        }
        
        private void refresh()
        {
            listView1.BeginInit();
            documentFileList.Clear();
            foreach(ServiceReference1.documentfile file in service1.GetNoValidateDocument())
            {
                documentFileList.Add(file);
            }
            listView1.ItemsSource = documentFileList;
            listView1.EndInit();
        }
        
    }
}
