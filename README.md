LegalPublication
================
The project consists of two programs written in C#. 

The server end provide services using WCF, allow users to query the database through the interface; the client end is a WPF program that consumes these services.

The services are in the form of synchronous mode.

Asynchronous services can be implemented likewise with minor differences.

As for the client, after role selection defined in ***LegalPubClient/MainWindow.xaml.cs***,  actions can be performed that defined in ***LegalPubClient/Windows/AdministrationBoss.xaml.cs***, ***LegalPubClient/Windows/AdministrationSecretary.xaml.cs***, ***LegalPubClient/Windows/AdministrationValidator.xaml.cs***, ***LegalPubClient/Windows/FirmRepresentative.xaml.cs***

As for the server, model defined in ***PublicationService/Model.Context.cs***, corresponding classes are ***PublicationService/Document.cs*** and ***PublicationService/User.cs***.  
Services are defined in ***PublicationService/Service1.cs***(where database connection is also defined) and corresponding interfaces are presented in ***PublicationService/IService1.cs***.  
