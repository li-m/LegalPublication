using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace PublicationService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        
        [OperationContract]
        List<documentfile> GetNoValidateDocument();

       

        [OperationContract]
        Boolean SubmitDocument(string filename);

        [OperationContract]
        Boolean DeleteDocument(int documentid);

        [OperationContract]
        Boolean PreValidateDocument(int documentid);

        [OperationContract]
        Boolean ValidateDocument(int documentid);

        [OperationContract]
        Boolean UpdateDocument(int documentid,string documentname);

        [OperationContract]
        List<documentfile> GetPreValidateDocument();

        [OperationContract]
        List<documentfile> GetValidatedDocument();

        [OperationContract]
        List<user> GetUsers();

        [OperationContract]
        Boolean AddUser(string username, string password, string role);

        [OperationContract]
        Boolean UpdateUser(int userid, string password, string role);

        [OperationContract]
        Boolean DeleteUser(int userid);
    }

    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    // You can add XSD files into the project. After building the project, you can directly use the data types defined there, with the namespace "LegalPubService.ContractType".
    
    [DataContract]
    public class documentfile
    {
        int id;
        string filename = "";

        [DataMember]
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        [DataMember]
        public string FileName
        {
            get { return filename; }
            set { filename = value; }
        }
    }

    [DataContract]
    public class user
    {
        int id;
        string username;
        string password;
        string role;

        [DataMember]
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        [DataMember]
        public string Username
        {
            get { return username; }
            set { username = value; }
        }

        [DataMember]
        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        [DataMember]
        public string Role
        {
            get { return role; }
            set { role = value; }
        }
    
    }


}
