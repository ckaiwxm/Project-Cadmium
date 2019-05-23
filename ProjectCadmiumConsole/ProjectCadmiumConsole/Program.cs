using System;
using System.Collections.Generic;
using ProjectCadmiumConsole.Database;
using ProjectCadmiumConsole.Database.DBManagers;
using ProjectCadmiumConsole.Database.Models;

namespace ProjectCadmiumConsole
{
    class Program
    {
        public static void Main(string[] args)
        {
            #region Sample
            //DbManager dbMgr = DbManager.getInstance();
            //Console.WriteLine("------------------------------------GET------------------------------------------------");
            //#region Sample Get
            //var lstRoles = dbMgr.GetRoles();
            //PrintRoles(lstRoles);
            //#endregion

            //System.Console.WriteLine("------------------------------------INSERT------------------------------------------------");
            //#region Sample Insert
            //var roleId = dbMgr.InsertRole("SuperAdmin", "All mighty access", true);
            //lstRoles = dbMgr.GetRoles();
            //PrintRoles(lstRoles);
            //#endregion

            //Console.WriteLine("------------------------------------UPDATE------------------------------------------------");
            //#region Sample Update
            //dbMgr.UpdateRole(roleId, "SuperDuperAdmin", "Godly access");
            //var role = dbMgr.GetRoleByName("SuperDuperAdmin");
            //PrintRole(role);
            //#endregion

            //Console.WriteLine("------------------------------------DELETE------------------------------------------------");
            //#region Sample Delete
            //dbMgr.DeleteRoleById(roleId);
            //lstRoles = dbMgr.GetRoles();
            //PrintRoles(lstRoles);
            //#endregion

            //dbMgr.Close();
            #endregion

            #region Project Test
            //ProjectDBManager PDBMgr = ProjectDBManager.GetInstance();
            //Console.WriteLine("------------------------------------GET------------------------------------------------");
            //var lstProjects = PDBMgr.GetProjects();
            //Helper.PrintProjects(lstProjects);

            //Console.WriteLine("------------------------------------GET BY ID------------------------------------------------");
            //Project project = PDBMgr.GetProjectById(new Guid("E9CFADBB-461D-477E-8DF8-2247139CA7A8"));
            //Helper.PrintProject(project);

            //System.Console.WriteLine("------------------------------------INSERT------------------------------------------------");
            //var projectId = PDBMgr.InsertProject(Guid.NewGuid(), "TEST PROJECT");
            //lstProjects = PDBMgr.GetProjects();
            //Helper.PrintProjects(lstProjects);


            //Console.WriteLine("------------------------------------UPDATE------------------------------------------------");
            //PDBMgr.UpdateProject(projectId, "TEST PROJECT1111");
            //project = PDBMgr.GetProjectById(projectId);
            //Helper.PrintProject(project);

            //Console.WriteLine("------------------------------------DELETE------------------------------------------------");
            //PDBMgr.DeleteProjectById(projectId);
            //lstProjects = PDBMgr.GetProjects();
            //Helper.PrintProjects(lstProjects);

            //PDBMgr.Close();
            #endregion

            #region Client Test
            //ClientDBManager CDBMgr = ClientDBManager.GetInstance();
            //Console.WriteLine("------------------------------------GET------------------------------------------------");
            //var lstClients = CDBMgr.GetClients();
            //Helper.PrintClients(lstClients);

            //Console.WriteLine("------------------------------------GET BY ID------------------------------------------------");
            //Client client = CDBMgr.GetClientById(new Guid("1CBB5B51-626E-4C34-8E81-649995F330DB"));
            //Helper.PrintClient(client);

            //System.Console.WriteLine("------------------------------------INSERT------------------------------------------------");
            //var clientId = CDBMgr.InsertClient(Guid.NewGuid(), "TEST CLIENT", 99.99m);
            //lstClients = CDBMgr.GetClients();
            //Helper.PrintClients(lstClients);


            //Console.WriteLine("------------------------------------UPDATE------------------------------------------------");
            //CDBMgr.UpdateClient(clientId, "TEST CLIENT1111", 999m);
            //client = CDBMgr.GetClientById(clientId);
            //Helper.PrintClient(client);

            //Console.WriteLine("------------------------------------DELETE------------------------------------------------");
            //CDBMgr.DeleteClientById(clientId);
            //lstClients = CDBMgr.GetClients();
            //Helper.PrintClients(lstClients);

            //CDBMgr.Close();
            #endregion

            #region QuoteVersion Test
            //QuoteVersionDBManager QVDBMgr = QuoteVersionDBManager.GetInstance();
            //Console.WriteLine("------------------------------------GET------------------------------------------------");
            //var lstQuoteVersions = QVDBMgr.GetQuoteVersions();
            //Helper.PrintQuoteVersions(lstQuoteVersions);

            //Console.WriteLine("------------------------------------GET BY ID------------------------------------------------");
            //QuoteVersion QuoteVersion = QVDBMgr.GetQuoteVersionById(new Guid("F1D1C34E-10DF-40F4-9B92-62F43D4D07E3"));
            //Helper.PrintQuoteVersion(QuoteVersion);

            //System.Console.WriteLine("------------------------------------INSERT------------------------------------------------");
            //var QuoteVersionId = QVDBMgr.InsertQuoteVersion(Guid.NewGuid(), "TEST UNIQUEID", Guid.NewGuid(), false, 
            //    new Guid("D4223D22-126F-46F1-8762-11355EED303A"), States.Cancelled, new Guid("01877B4C-6612-40D8-B0BA-8FF7C792D44E"), new Guid("1CBB5B51-626E-4C34-8E81-649995F330DB"),
            //    new Guid("2C10E2F1-F8B3-44C4-B5C8-7C83185DF645"));
            //lstQuoteVersions = QVDBMgr.GetQuoteVersions();
            //Helper.PrintQuoteVersions(lstQuoteVersions);


            //Console.WriteLine("------------------------------------UPDATE------------------------------------------------");
            //QVDBMgr.UpdateQuoteVersion(QuoteVersionId, "TEST UNIQUEID11111", Guid.NewGuid(), false,
            //    new Guid("D4223D22-126F-46F1-8762-11355EED303A"), States.Cancelled, new Guid("01877B4C-6612-40D8-B0BA-8FF7C792D44E"), new Guid("1CBB5B51-626E-4C34-8E81-649995F330DB"),
            //    DateTime.Now, new Guid("85AB2831-B7FF-4503-A4C0-7525F2048691"));
            //QuoteVersion = QVDBMgr.GetQuoteVersionById(QuoteVersionId);
            //Helper.PrintQuoteVersion(QuoteVersion);

            //Console.WriteLine("------------------------------------DELETE------------------------------------------------");
            //QVDBMgr.DeleteQuoteVersionById(QuoteVersionId);
            //lstQuoteVersions = QVDBMgr.GetQuoteVersions();
            //Helper.PrintQuoteVersions(lstQuoteVersions);

            //QVDBMgr.Close();
            #endregion

            #region Quote Test
            //QuoteDBManager QDBMgr = QuoteDBManager.GetInstance();
            //Console.WriteLine("------------------------------------GET------------------------------------------------");
            //var lstQuotes = QDBMgr.GetQuotes();
            //Helper.PrintQuotes(lstQuotes);

            //Console.WriteLine("------------------------------------GET BY ID------------------------------------------------");
            //Quote Quote = QDBMgr.GetQuoteById(new Guid("7630CB8A-C484-420C-A1D4-6ECDF11A00DE"));
            //Helper.PrintQuote(Quote);

            //Console.WriteLine("------------------------------------INSERT------------------------------------------------");
            //var QuoteId = QDBMgr.InsertQuote(Guid.NewGuid(), null, null);
            //lstQuotes = QDBMgr.GetQuotes();
            //Helper.PrintQuotes(lstQuotes);


            //Console.WriteLine("------------------------------------UPDATE------------------------------------------------");
            //QDBMgr.UpdateQuote(QuoteId, null, 999m);
            //Quote = QDBMgr.GetQuoteById(QuoteId);
            //Helper.PrintQuote(Quote);

            //Console.WriteLine("------------------------------------DELETE------------------------------------------------");
            //QDBMgr.DeleteQuoteById(QuoteId);
            //lstQuotes = QDBMgr.GetQuotes();
            //Helper.PrintQuotes(lstQuotes);

            //QDBMgr.Close();
            #endregion

            #region Client Test
            //PaymentDBManager PMDBMgr = PaymentDBManager.GetInstance();
            //Console.WriteLine("------------------------------------GET------------------------------------------------");
            //var lstPayments = PMDBMgr.GetPayments();
            //Helper.PrintPayments(lstPayments);

            //Console.WriteLine("------------------------------------GET BY ID------------------------------------------------");
            //Payment Payment = PMDBMgr.GetPaymentById(new Guid("32580C12-B6E8-4A6A-8ED1-D833F8EABDF1"));
            //Helper.PrintPayment(Payment);

            //System.Console.WriteLine("------------------------------------INSERT------------------------------------------------");
            //var PaymentId = PMDBMgr.InsertPayment(Guid.NewGuid(), 0m, DateTime.Now, new Guid("AAB4AF6B-8C3E-4B04-8756-5A400F5D3F7C"));
            //lstPayments = PMDBMgr.GetPayments();
            //Helper.PrintPayments(lstPayments);


            //Console.WriteLine("------------------------------------UPDATE------------------------------------------------");
            //PMDBMgr.UpdatePayment(PaymentId, 1m, DateTime.Now, new Guid("AAB4AF6B-8C3E-4B04-8756-5A400F5D3F7C"));
            //Payment = PMDBMgr.GetPaymentById(PaymentId);
            //Helper.PrintPayment(Payment);

            //Console.WriteLine("------------------------------------DELETE------------------------------------------------");
            //PMDBMgr.DeletePaymentById(PaymentId);
            //lstPayments = PMDBMgr.GetPayments();
            //Helper.PrintPayments(lstPayments);

            //PMDBMgr.Close();
            #endregion

            #region Task Test
            //TaskDBManager TDBMgr = TaskDBManager.GetInstance();
            //Console.WriteLine("------------------------------------GET------------------------------------------------");
            //var lstTasks = TDBMgr.GetTasks();
            //Helper.PrintTasks(lstTasks);

            //Console.WriteLine("------------------------------------GET BY ID------------------------------------------------");
            //Task Task = TDBMgr.GetTaskById(new Guid("B2064707-9394-45EA-81D1-A5552BA548D1"));
            //Helper.PrintTask(Task);

            //System.Console.WriteLine("------------------------------------INSERT------------------------------------------------");
            //var TaskId = TDBMgr.InsertTask(Guid.NewGuid(), "TEST TASK", 0m, new Guid("09029652-1D6B-40A8-907B-EC2E0FA58AA2"));
            //lstTasks = TDBMgr.GetTasks();
            //Helper.PrintTasks(lstTasks);


            //Console.WriteLine("------------------------------------UPDATE------------------------------------------------");
            //TDBMgr.UpdateTask(TaskId, "TEST TASK111", 1m, new Guid("D4223D22-126F-46F1-8762-11355EED303A"));
            //Task = TDBMgr.GetTaskById(TaskId);
            //Helper.PrintTask(Task);

            //Console.WriteLine("------------------------------------DELETE------------------------------------------------");
            //TDBMgr.DeleteTaskById(TaskId);
            //lstTasks = TDBMgr.GetTasks();
            //Helper.PrintTasks(lstTasks);

            //TDBMgr.Close();
            #endregion

            #region User Test
            //UserDBManager UDBMgr = UserDBManager.GetInstance();
            //Console.WriteLine("------------------------------------GET------------------------------------------------");
            //var lstUsers = UDBMgr.GetUsers();
            //Helper.PrintUsers(lstUsers);

            //Console.WriteLine("------------------------------------GET BY ID------------------------------------------------");
            //User User = UDBMgr.GetUserById(new Guid("355774AF-B010-46E7-85E7-6582734B0C71"));
            //Helper.PrintUser(User);

            //System.Console.WriteLine("------------------------------------INSERT------------------------------------------------");
            //var UserId = UDBMgr.InsertUser(Guid.NewGuid(), null, false, DateTime.Now);
            //lstUsers = UDBMgr.GetUsers();
            //Helper.PrintUsers(lstUsers);


            //Console.WriteLine("------------------------------------UPDATE------------------------------------------------");
            //UDBMgr.UpdateUser(UserId, null, true, DateTime.Now);
            //User = UDBMgr.GetUserById(UserId);
            //Helper.PrintUser(User);

            //Console.WriteLine("------------------------------------DELETE------------------------------------------------");
            //UDBMgr.DeleteUserById(UserId);
            //lstUsers = UDBMgr.GetUsers();
            //Helper.PrintUsers(lstUsers);

            //UDBMgr.Close();
            #endregion

            #region UserVersion Test
            UserVersionDBManager UVDBMgr = UserVersionDBManager.GetInstance();
            Console.WriteLine("------------------------------------GET------------------------------------------------");
            var lstUserVersions = UVDBMgr.GetUserVersions();
            Helper.PrintUserVersions(lstUserVersions);

            Console.WriteLine("------------------------------------GET BY ID------------------------------------------------");
            UserVersion UserVersion = UVDBMgr.GetUserVersionById(new Guid("25D2DE0A-6C77-43CC-B081-C12CD36B09B2"));
            Helper.PrintUserVersion(UserVersion);

            System.Console.WriteLine("------------------------------------INSERT------------------------------------------------");
            var UserVersionId = UVDBMgr.InsertUserVersion(Guid.NewGuid(), Guid.NewGuid(), "TESTUSER", "FAKEPASSWORD", "TEST", "USER",
                                                          "", "", new Guid("2C10E2F1-F8B3-44C4-B5C8-7C83185DF645"));
            lstUserVersions = UVDBMgr.GetUserVersions();
            Helper.PrintUserVersions(lstUserVersions);


            Console.WriteLine("------------------------------------UPDATE------------------------------------------------");
            UVDBMgr.UpdateUserVersion(UserVersionId, Guid.NewGuid(), "TESTUSER11111", "FAKEPASSWORD", "TEST1111", "USER",
                                      "", "", DateTime.Now, new Guid("2C10E2F1-F8B3-44C4-B5C8-7C83185DF645"));
            UserVersion = UVDBMgr.GetUserVersionById(UserVersionId);
            Helper.PrintUserVersion(UserVersion);

            Console.WriteLine("------------------------------------DELETE------------------------------------------------");
            UVDBMgr.DeleteUserVersionById(UserVersionId);
            lstUserVersions = UVDBMgr.GetUserVersions();
            Helper.PrintUserVersions(lstUserVersions);

            UVDBMgr.Close();
            #endregion

        }
    }
}
