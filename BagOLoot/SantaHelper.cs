using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Data.Sqlite;

namespace BagOLoot
{

    public class SantaHelper
    {
        private int _lastID = 0;
        private List<Toy> _toyBag = new List<Toy>();
        private string _connectionString = $"Data Source ={Environment.GetEnvironmentVariable("BAGOLOOT_DB")}";
        private SqliteConnection _connection;

        public SantaHelper()
        {
             _connection = new SqliteConnection(_connectionString);
        }
        public bool AddToyToBag(int ChildID, string toyName)
        {
            using (_connection)
            {
                _connection.Open();
                SqliteCommand dbcmd = _connection.CreateCommand();

                //Insert new toy to toyTable
                dbcmd.CommandText = $"insert into toy values (null, '{toyName}', {ChildID})";
                Console.WriteLine(dbcmd.CommandText);
                dbcmd.ExecuteNonQuery();

                //Get the id of the new row
                dbcmd.CommandText = $"select last_insert_rowid()";
                using (SqliteDataReader dr = dbcmd.ExecuteReader())
                {
                    if ( dr.Read() ) {
                        _lastID = dr.GetInt32(0);
                    } else {
                        throw new Exception("Unable to insert value");
                    }
                }
                dbcmd.Dispose();
                _connection.Close();
            }

            return _lastID != 0;
        }

        public List<Toy> RemoveChildsToy(int childID, int toyID)
        {
           // _toyBag = 
            using (_connection)
            {
                _connection.Open();
                SqliteCommand dbcmd = _connection.CreateCommand();

                //Remove toy by toyID from toy table
                dbcmd.CommandText = $"DELETE FROM toy WHERE ToyID = {toyID}";
                Console.WriteLine(dbcmd.CommandText);
                dbcmd.ExecuteNonQuery();

                //Get list of toys for childID
                dbcmd.CommandText = $"SELECT ToyID, ToyName, ChildID FROM toy WHERE ChildID = {childID}";
                using ( SqliteDataReader dr = dbcmd.ExecuteReader() )
                {
                    while ( dr.Read() )
                    {
                        _toyBag.Add( new Toy(dr.GetInt32(0), dr[1].ToString(), dr.GetInt32(2)) );
                    }
                }

                dbcmd.Dispose();
                _connection.Close();
            }  

            //Return list of toys for child
            return _toyBag;
        }

        public List<int> GetChildsToys(int child)
        {

            return new List<int>() { 1,6,7,8 };
        }
    }
}