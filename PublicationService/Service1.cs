using PublicationService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace PublicationService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class Service1 : IService1
    {
        
        public List<documentfile> GetNoValidateDocument()
        {
            using (Model1Container db = new Model1Container())
            {
                var query = from document in db.DocumentSet where document.Prevalidate == false select document;
                List<Document> documentlist = query.ToList();
                List<documentfile> documentfilelist = new List<documentfile>();
                foreach (Document document in documentlist)
                {
                    documentfile documentfile = new documentfile();
                    documentfile.Id = document.Id;
                    documentfile.FileName = document.Name;
                    documentfilelist.Add(documentfile);
                }
                return documentfilelist;
            }
        }

        public Boolean PreValidateDocument(int documentid)
        {
            using (Model1Container db = new Model1Container())
            {
                Document documentToPrevalidate = new Document();
                var query = from document in db.DocumentSet where document.Id == documentid select document;
                documentToPrevalidate = query.First();
                documentToPrevalidate.Prevalidate=true;
                db.SaveChanges();
                return true;
            }
        }

        public Boolean ValidateDocument(int documentid)
        {
            using (Model1Container db = new Model1Container())
            {
                Document documentToValidate = new Document();
                var query = from document in db.DocumentSet where document.Id == documentid select document;
                documentToValidate = query.First();
                documentToValidate.Validate = true;
                db.SaveChanges();
                return true;
            }
        }

        public Boolean SubmitDocument(string filename)
        {
            using (Model1Container db = new Model1Container())
            {
                Document document = new Document();
                document.Name = filename;
                document.Prevalidate = false;
                document.Validate = false;
                db.DocumentSet.Add(document);
                db.SaveChanges();
                return true;
            }

        }

        public Boolean DeleteDocument(int documentid)
        {
            using (Model1Container db = new Model1Container())
            {
                var query = from document in db.DocumentSet where document.Id == documentid select document;
                Document documentToDelete = query.ToList().First();
                db.DocumentSet.Remove(documentToDelete);
                db.SaveChanges();
                return true;
            }
        }
        
        public Boolean UpdateDocument(int documentid,string documentname)
        {
            using (Model1Container db = new Model1Container())
            {
                var query = from document in db.DocumentSet where document.Id == documentid select document;
                Document documentToUpdate = query.ToList().First();
                documentToUpdate.Name = documentname;
                db.SaveChanges();
                return true;
            }
        }

        public List<documentfile> GetPreValidateDocument()
        {
            using (Model1Container db = new Model1Container())
            {
                var query = from document in db.DocumentSet where document.Prevalidate == true && document.Validate == false select document;
                List<Document> documentResult = query.ToList();
                List<documentfile> documentfilelist = new List<documentfile>();
                foreach (Document document in documentResult)
                {
                    documentfile documentfile = new documentfile();
                    documentfile.Id = document.Id;
                    documentfile.FileName = document.Name;
                    documentfilelist.Add(documentfile);
                }
                return documentfilelist;
            }
        }

        public List<documentfile> GetValidatedDocument()
        {
            using (Model1Container db = new Model1Container())
            {
                var query = from document in db.DocumentSet where document.Prevalidate == true && document.Validate == true select document;
                List<Document> documentResult = query.ToList();
                List<documentfile> documentfilelist = new List<documentfile>();
                foreach (Document document in documentResult)
                {
                    documentfile documentfile = new documentfile();
                    documentfile.Id = document.Id;
                    documentfile.FileName = document.Name;
                    documentfilelist.Add(documentfile);
                }
                return documentfilelist;
            }
        }

        public List<user> GetUsers()
        {
            using (Model1Container db = new Model1Container())
            {
                var query = from user in db.UserSet select user;
                List<User> userResult = query.ToList();
                List<user> userlist = new List<user>();
                foreach (User userresult in userResult)
                {
                    user user = new user();
                    user.Id = userresult.Id;
                    user.Username = userresult.Name;
                    user.Password = userresult.Pwd;
                    user.Role = userresult.Role;

                    userlist.Add(user);
                }
                return userlist;
            }
        }

        public Boolean AddUser(string username, string password, string role)
        {
            using (Model1Container db = new Model1Container())
            {
                User user = new User();
                user.Name = username;
                user.Pwd = password;
                user.Role = role;
                db.UserSet.Add(user);
                db.SaveChanges();
                return true;
            }
        }

        public Boolean UpdateUser(int userid, string password, string role)
        {
            using (Model1Container db = new Model1Container())
            {
                var query = from user in db.UserSet where user.Id == userid select user;
                User userToUpdate = query.ToList().First();
                userToUpdate.Pwd = password;
                userToUpdate.Role = role;
                db.SaveChanges();                
                return true;
            }
        }

        public Boolean DeleteUser(int userid)
        {
            using (Model1Container db = new Model1Container())
            {
                var query = from user in db.UserSet where user.Id == userid select user;
                User userToDelete = query.ToList().First();
                db.UserSet.Remove(userToDelete);
                db.SaveChanges();
                return true;
            }
        }
    }
}
