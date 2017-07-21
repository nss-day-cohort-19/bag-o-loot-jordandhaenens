using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Data.Sqlite;

namespace BagOLoot
{
    public class SantasComptroller
    {
        private SqliteConnection _connection;
        private string _connectionString = $"Data Source={Environment.GetEnvironmentVariable("BAGOLOOT_DB")}";
        private List<Toy> _toyBag = new List<Toy>();

        public SantasComptroller()
        {
             _connection = new SqliteConnection(_connectionString);
        }

        public List<int> GetGoodKids()
        {
            return new List<int> () { 712, 432, 543, 124 };
        }

        public List<Toy> GetChildsToys(int childID)
        {
            using ( _connection )
            {
                _connection.Open();
                SqliteCommand dbcmd = _connection.CreateCommand();
                
                //Get list of toys for childID
                dbcmd.CommandText = $"SELECT ToyID, ToyName, ChildID FROM toy WHERE ChildID = {childID}";
                using ( SqliteDataReader dr = dbcmd.ExecuteReader() )
                {
                    while ( dr.Read() )
                    {
                        _toyBag.Add( new Toy(dr.GetInt32(0), dr[1].ToString(), dr.GetInt32(2)) );
                    }
                }

            }
            return _toyBag;
        }

        public void SetDeliveryStatus(int childID, string delivered) 
        {
            
        }

        public List<Child> GetDeliveredChildren()
        {
            return new List<Child>() { new Child(2, "jamal", 1) };
        }
    }

}