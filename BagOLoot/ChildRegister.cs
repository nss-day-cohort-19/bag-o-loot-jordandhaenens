using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Data.Sqlite;

namespace BagOLoot
{
    public class ChildRegister
    {
        private int _lastId = 0; // Will store the id of the last inserted row
        private List<Child> _children = new List<Child>();
        private string _connectionString = $"Data Source={Environment.GetEnvironmentVariable("BAGOLOOT_DB")}";
        private SqliteConnection _connection;

        public ChildRegister()
        {
            _connection = new SqliteConnection(_connectionString);
        }

        public bool AddChild (string child) 
        {
            using (_connection)
            {
                _connection.Open ();
                SqliteCommand dbcmd = _connection.CreateCommand ();

                // Insert the new child
                dbcmd.CommandText = $"insert into child values (null, '{child}', 0)";
                Console.WriteLine(dbcmd.CommandText);
                dbcmd.ExecuteNonQuery ();

                // Get the id of the new row
                dbcmd.CommandText = $"select last_insert_rowid()";
                using (SqliteDataReader dr = dbcmd.ExecuteReader()) 
                {
                    if (dr.Read()) {
                        //This is the id of the last row added to table - NOT the childID
                        _lastId = dr.GetInt32(0);
                    } else {
                        throw new Exception("Unable to insert value");
                    }
                }

                // clean up
                dbcmd.Dispose ();
                _connection.Close ();
            }

            return _lastId != 0;
        }

        public List<Child> GetChildren ()
        {
            using (_connection)
            {
                _connection.Open();
                SqliteCommand dbcmd = _connection.CreateCommand();

                // Select the id and name of every child
                dbcmd.CommandText = "select id, name, delivered from child";

                using (SqliteDataReader dr = dbcmd.ExecuteReader())
                {
                    //read each row in the resultset from db
                    while (dr.Read())
                    {
                        //add child name to the list
                        _children.Add( new Child(dr.GetInt32(0), dr[1].ToString(), dr.GetInt32(2)) );
                    }
                }

                //clean up
                dbcmd.Dispose();
                _connection.Close();
            }
            
            return _children;
        }

        public string GetChild (string name)
        {
            // var child = _children.SingleOrDefault(c => c == name);

            // Inevitably, two children will have the same name. Then what?

            // return child;
            return "hello";
        }
    }
}