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
    /// Interaction logic for FirmRepresentative.xaml
    /// </summary>
    public partial class FirmRepresentative : Window
    {

        ServiceReference1.Service1Client service1 = new ServiceReference1.Service1Client();
        List<ServiceReference1.documentfile> documentFileList = new List<ServiceReference1.documentfile>();


        public FirmRepresentative()
        {
            InitializeComponent();
            refresh();
            Status.Text = "Ready";
        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            string name = DocumentName.GetLineText(0);

            if (name.Trim() != "")
            {
                Status.Text = "Submitting";

                if (service1.SubmitDocument(name))
                {
                    Status.Text = "Document " + name + " Submitted!";
                }
            }

            refresh();

        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            if (this.listView1.SelectedItems.Count != 0 && UpdateName.GetLineText(0).Trim() != "" )
            {
                ServiceReference1.documentfile documentSelected = (ServiceReference1.documentfile)this.listView1.SelectedItems[0];

                int id = documentSelected.Id;
                string name = UpdateName.GetLineText(0);

                if (service1.UpdateDocument(id, name))
                {
                    Status.Text = "Document " + documentSelected.Id + ": \"" + documentSelected.FileName + "\" Updated to \"" + name + "\"";
                }
            }

            refresh();
        }



        private void refresh()
        {
            listView1.BeginInit();
            documentFileList.Clear();
            foreach (ServiceReference1.documentfile file in service1.GetNoValidateDocument())
            {
                documentFileList.Add(file);
            }
            listView1.ItemsSource = documentFileList;
            listView1.EndInit();
        }


    }
}
