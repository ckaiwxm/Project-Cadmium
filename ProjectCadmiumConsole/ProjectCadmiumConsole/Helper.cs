using ProjectCadmiumConsole.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectCadmiumConsole
{
    public static class Helper
    {

        #region Sample Print
        public static void PrintRoles(List<Role> lstRoles)
        {
            for (int ii = 0; ii < lstRoles.Count; ii++)
            {
                var role = lstRoles[ii];
                PrintRole(role, ii);
            }
        }

        public static void PrintRole(Role role, int ii = 0)
        {
            var info = ii + " Role: " + role.Id + " - " + role.Name + " - " + role.IsActive + " - " + role.Description;
            Console.WriteLine(info);

        }
        #endregion

        #region Project Print
        public static void PrintProjects(List<Project> lstProjects)
        {
            for (int i = 0; i < lstProjects.Count; i++)
            {
                var project = lstProjects[i];
                string info = i + "Project: " + project.Id + " - " + project.Name + " - " + project.LastUsedTimestamp;
                Console.WriteLine(info);
            }
            Console.ReadKey();
        }

        public static void PrintProject(Project project, int i = 0)
        {
            string info = i + "Project: " + project.Id + " - " + project.Name + " - " + project.LastUsedTimestamp;
            Console.WriteLine(info);
            Console.ReadKey();
        }
        #endregion

        #region Client Print
        public static void PrintClients(List<Client> lstClients)
        {
            for (int i = 0; i < lstClients.Count; i++)
            {
                var client = lstClients[i];
                string info = i + "Client: " + client.Id + " - " + client.Name + " - " + client.PricePerHour + " - " + client.LastUsedTimestamp;
                Console.WriteLine(info);
            }
            Console.ReadKey();
        }

        public static void PrintClient(Client client, int i = 0)
        {
            string info = i + "Client: " + client.Id + " - " + client.Name + " - " + client.PricePerHour + " - " + client.LastUsedTimestamp;
            Console.WriteLine(info);
            Console.ReadKey();
        }
        #endregion

        #region QuoteVersion Print
        public static void PrintQuoteVersions(List<QuoteVersion> lstQuoteVersions)
        {
            for (int i = 0; i < lstQuoteVersions.Count; i++)
            {
                var QuoteVersion = lstQuoteVersions[i];
                Console.WriteLine($"{i}QuoteVersion");
                Console.WriteLine($"\tId: {QuoteVersion.Id}");
                Console.WriteLine($"\tUniqueID: {QuoteVersion.UniqueID}");
                Console.WriteLine($"\tVersion: {QuoteVersion.Version}");
                Console.WriteLine($"\tIsBillable: {QuoteVersion.IsBillable}");
                Console.WriteLine($"\tQuoteID: {QuoteVersion.QuoteID}");
                Console.WriteLine($"\tStatusID: {QuoteVersion.Status.ToString()}");
                Console.WriteLine($"\tProjectID: {QuoteVersion.ProjectID}");
                Console.WriteLine($"\tClientID: {QuoteVersion.ClientID}");
                Console.WriteLine($"\tCreationDate: {QuoteVersion.CreationDate}");
                Console.WriteLine($"\tCreateById: {QuoteVersion.CreatedById}");
              }
            Console.ReadKey();
        }

        public static void PrintQuoteVersion(QuoteVersion QuoteVersion, int i = 0)
        {
            Console.WriteLine($"{i}QuoteVersion");
            Console.WriteLine($"\tId: {QuoteVersion.Id}");
            Console.WriteLine($"\tUniqueID: {QuoteVersion.UniqueID}");
            Console.WriteLine($"\tVersion: {QuoteVersion.Version}");
            Console.WriteLine($"\tIsBillable: {QuoteVersion.IsBillable}");
            Console.WriteLine($"\tQuoteID: {QuoteVersion.QuoteID}");
            Console.WriteLine($"\tStatusID: {QuoteVersion.Status.ToString()}");
            Console.WriteLine($"\tProjectID: {QuoteVersion.ProjectID}");
            Console.WriteLine($"\tClientID: {QuoteVersion.ClientID}");
            Console.WriteLine($"\tCreationDate: {QuoteVersion.CreationDate}");
            Console.WriteLine($"\tCreateById: {QuoteVersion.CreatedById}");
            Console.ReadKey();
        }
        #endregion

        #region Quote Print
        public static void PrintQuotes(List<Quote> lstQuotes)
        {
            for (int i = 0; i < lstQuotes.Count; i++)
            {
                var Quote = lstQuotes[i];
                string info = i + "Quote: " + Quote.Id + " - " + (Quote.PublishVersion == null ? "NULL" : Convert.ToString(Quote.PublishVersion)) + 
                                                         " - " + (Quote.NewPricePerHour == null ? "NULL" : Convert.ToString(Quote.NewPricePerHour));
                Console.WriteLine(info);
            }
            Console.ReadKey();
        }

        public static void PrintQuote(Quote Quote, int i = 0)
        {
            string info = i + "Quote: " + Quote.Id + " - " + (Quote.PublishVersion == null ? "NULL" : Convert.ToString(Quote.PublishVersion)) +
                                                         " - " + (Quote.NewPricePerHour == null ? "NULL" : Convert.ToString(Quote.NewPricePerHour));
            Console.WriteLine(info);
            Console.ReadKey();
        }
        #endregion

        #region Payment Print
        public static void PrintPayments(List<Payment> lstPayments)
        {
            for (int i = 0; i < lstPayments.Count; i++)
            {
                var Payment = lstPayments[i];
                string info = i + "Payment: " + Payment.Id + " - " + Payment.Amount + " - " + Payment.PaymentDate + " - " + Payment.QuoteID;
                Console.WriteLine(info);
            }
            Console.ReadKey();
        }

        public static void PrintPayment(Payment Payment, int i = 0)
        {
            string info = i + "Payment: " + Payment.Id + " - " + Payment.Amount + " - " + Payment.PaymentDate + " - " + Payment.QuoteID;
            Console.WriteLine(info);
            Console.ReadKey();
        }
        #endregion

        #region Task Print
        public static void PrintTasks(List<Task> lstTasks)
        {
            for (int i = 0; i < lstTasks.Count; i++)
            {
                var Task = lstTasks[i];
                string info = i + "Task: " + Task.Id + " - " + Task.Name + " - " + Task.Hours + " - " + Task.QuoteID;
                Console.WriteLine(info);
            }
            Console.ReadKey();
        }

        public static void PrintTask(Task Task, int i = 0)
        {
            string info = i + "Task: " + Task.Id + " - " + Task.Name + " - " + Task.Hours + " - " + Task.QuoteID;
            Console.WriteLine(info);
            Console.ReadKey();
        }
        #endregion

        #region User Print
        public static void PrintUsers(List<User> lstUsers)
        {
            for (int i = 0; i < lstUsers.Count; i++)
            {
                var User = lstUsers[i];
                string info = i + "User: " + User.Id + " - " + (User.PublishVersion == null ? "NULL" : Convert.ToString(User.PublishVersion)) + " - " + User.IsActive + " - " + User.LastLoginTimestamp;
                Console.WriteLine(info);
            }
            Console.ReadKey();
        }

        public static void PrintUser(User User, int i = 0)
        {
            string info = i + "User: " + User.Id + " - " + (User.PublishVersion == null ? "NULL" : Convert.ToString(User.PublishVersion)) + " - " + User.IsActive + " - " + User.LastLoginTimestamp;
            Console.WriteLine(info);
            Console.ReadKey();
        }
        #endregion

        #region UserVersion Print
        public static void PrintUserVersions(List<UserVersion> lstUserVersions)
        {
            for (int i = 0; i < lstUserVersions.Count; i++)
            {
                var UserVersion = lstUserVersions[i];
                Console.WriteLine($"{i}UserVersion");
                Console.WriteLine($"\tId: {UserVersion.Id}");
                Console.WriteLine($"\tVersion: {UserVersion.Version}");
                Console.WriteLine($"\tUserName: {UserVersion.UserName}");
                Console.WriteLine($"\tPassword: {UserVersion.Password}");
                Console.WriteLine($"\tFirstName: {UserVersion.FirstName}");
                Console.WriteLine($"\tLastName: {UserVersion.LastName}");
                Console.WriteLine($"\tPhone: {UserVersion.Phone}");
                Console.WriteLine($"\tEmailName: {UserVersion.Email}");
                Console.WriteLine($"\tCreationDate: {UserVersion.CreationDate}");
                Console.WriteLine($"\tUserID: {UserVersion.UserID}");
            }
            Console.ReadKey();
        }

        public static void PrintUserVersion(UserVersion UserVersion, int i = 0)
        {
            Console.WriteLine($"{i}UserVersion");
            Console.WriteLine($"\tId: {UserVersion.Id}");
            Console.WriteLine($"\tVersion: {UserVersion.Version}");
            Console.WriteLine($"\tUserName: {UserVersion.UserName}");
            Console.WriteLine($"\tPassword: {UserVersion.Password}");
            Console.WriteLine($"\tFirstName: {UserVersion.FirstName}");
            Console.WriteLine($"\tLastName: {UserVersion.LastName}");
            Console.WriteLine($"\tPhone: {UserVersion.Phone}");
            Console.WriteLine($"\tEmailName: {UserVersion.Email}");
            Console.WriteLine($"\tCreationDate: {UserVersion.CreationDate}");
            Console.WriteLine($"\tUserID: {UserVersion.UserID}");
            Console.ReadKey();
        }
        #endregion
    }
}
