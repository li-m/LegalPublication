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
    /// Interaction logic for AdministrationValidator.xaml
    /// </summary>
    public partial class AdministrationValidator : Window
    {
        ServiceReference1.Service1Client service1 = new ServiceReference1.Service1Client();
        List<ServiceReference1.documentfile> documentFileList1 = new List<ServiceReference1.documentfile>();
        List<ServiceReference1.documentfile> documentFileList2 = new List<ServiceReference1.documentfile>();


        public AdministrationValidator()
        {
            InitializeComponent();
            Status.Text = "Refreshing...";
            refresh();
            refresh2();
            Status.Text = "Ready";
        }

        private void Validate_Click(object sender, RoutedEventArgs e)
        {
            if (this.listView1.SelectedItems.Count != 0)
            {
                foreach (Object o in this.listView1.SelectedItems)
                {
                    ServiceReference1.documentfile documentSelected = (ServiceReference1.documentfile)o;
                    int id = documentSelected.Id;

                    if (service1.ValidateDocument(id))
                    {
                        Status.Text = listView1.SelectedItems.Count + " document(s) Validated";
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
            documentFileList1.Clear();
            foreach (ServiceReference1.documentfile file in service1.GetPreValidateDocument())
            {
                documentFileList1.Add(file);
            }
            listView1.ItemsSource = documentFileList1;
            listView1.EndInit();
            
        }

        private void refresh2()
        {
            listView2.BeginInit();
            documentFileList2.Clear();
            foreach (ServiceReference1.documentfile file in service1.GetValidatedDocument())
            {
                documentFileList2.Add(file);
            }
            listView2.ItemsSource = documentFileList2;
            listView2.EndInit();

        }

        private void Refresh2_Click(object sender, RoutedEventArgs e)
        {
            refresh2();
        }
    }
}
