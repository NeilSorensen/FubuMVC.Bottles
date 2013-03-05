using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Web;
using Dapper;

namespace SampleFubuApplication.DataAccess
{
    public class ConnectionManager
    {
        private readonly string fileLocation;

        public ConnectionManager()
        {
            fileLocation = Environment.CurrentDirectory + "\\Data\\SimpleDb.sqlite";
        }

        public ConnectionManager(string fileLocation)
        {
            this.fileLocation = fileLocation;
        }

        public SQLiteConnection DatabaseConnection()
        {
            if (!File.Exists(fileLocation))
            {
                CreateDatabase();
            }

            return new SQLiteConnection(GetConnectionString());
        }

        private string GetConnectionString()
        {
            return "DataSource=" + fileLocation;
        }

        private void CreateDatabase()
        {
            using (var connection = new SQLiteConnection(GetConnectionString()))
            {
                connection.Open();
                connection.Execute(@"create table User
              (
                 ID             integer identity primary key AUTOINCREMENT,
                 Name      varchar(100) not null,
              );
              create table WorkItem
               (
                    ID          integer identity primary key AUTOINCREMENT,
                    UserID      integer 
                    TaskName    varchar(100) not null,
                    Completed   bit not null,
                    CreatedDate datetime not null,
                    CompletedDate datetime,
                    
               );");
            }
            
        }
    }

    public class User
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }

    public class WorkItem
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public string TaskName { get; set; }
        public bool Completed { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime CompletedDate { get; set; }
    }
}