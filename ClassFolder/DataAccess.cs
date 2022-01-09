﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data;

namespace FormUI
{
    public class DataAccess
    {
     
        public List<Person> GetPeople(string email,string password)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("SampleDB")))
            {
               // var output = connection.Query<Person>($"select * from People where EmailAddress = '{ email }'").ToList();
                var output = connection.Query<Person>("UserAuth @EmailAddress , @UserPassword",
                   new { EmailAddress = email, UserPassword=password } ).ToList();
                return output;
            }
        }

        public void InsertPerson(string firstName, string lastName, string emailAddress, string phoneNumber, string password)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("SampleDB")))
            {
                //Person newPerson = new Person { FirstName = firstName, LastName = lastName, EmailAddress = emailAddress, PhoneNumber = phoneNumber };
                List<Person> people = new List<Person>();

                people.Add(new Person { FirstName = firstName, LastName = lastName, EmailAddress = emailAddress, PhoneNumber = phoneNumber, UserPassword= password });

                connection.Execute("InsertPerson @FirstName, @LastName, @EmailAddress, @PhoneNumber, @UserPassword", people);
               
            }
        }
    }
}
