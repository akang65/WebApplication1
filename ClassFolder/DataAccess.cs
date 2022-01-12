/*
 * This class deals with connection to database regarding ,registeration 
 * verification, login,and reset password
 */

using System;
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
                //Check for existing Email That is already Verified with Otp
        public List<Person> CheckEmailVerification(string email)
        {
            using(IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("SampleDB")))

            {                                               //................|...|
                //CheckEmailverification (stored procedure)...................v...V
                var checkEmailAndVerification = connection.Query<Person>("CheckEmailverification @EmailAddress",
                    new {EmailAddress=email}).ToList();
                return  checkEmailAndVerification ;
            }
        }

        internal List<Person> InsertOtp(object body)
        {
            throw new NotImplementedException();
        }

        // Delete uSer data if otp verification= false before registering the new user 
        // if they use the same email address that has emai otp verification= false. 
        // [i believe this method can be shorten by using two "return" types(Tuple) in the previous CheckEmailVerification method ]
        // or maybe like do something about it in the database side.You try to do something about it.
        public List<Person> DeleteExistingUser(string email)
        {
            using(IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("SampleDB")))
            {
                var DeleteEmail = connection.Query<Person>("DeleteExistingEmail @EmailAddress",
                     new { EmailAddress = email }).ToList();
                return DeleteEmail;
            }
        }
                     //Register New User
        public void InsertPerson(string firstName, string lastName, string emailAddress, string phoneNumber, string password,string otp)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("SampleDB")))
            {
                //Person newPerson = new Person { FirstName = firstName, LastName = lastName, EmailAddress = emailAddress, PhoneNumber = phoneNumber }; 
                List<Person> people = new List<Person>();
                people.Add(new Person { FirstName = firstName, LastName = lastName, EmailAddress = emailAddress, PhoneNumber = phoneNumber, UserPassword= password, OTP=otp });
                connection.Execute("InsertPerson @FirstName, @LastName, @EmailAddress, @PhoneNumber, @UserPassword, @OTP", people);
               
            }
        }
                        //Verify OTP
        public void InsertOtp(string email, string otp)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("SampleDB")))
            {    
                List<Person> people = new List<Person>();
                people.Add(new Person { EmailAddress=email,OTP = otp });
                connection.Execute("VerifyOTP @Emailaddress, @OTP", people);

            }
        }
                        //Login User
        public List<Person> GetPeople(string email, string password)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("SampleDB")))
            {
                // var output = connection.Query<Person>($"select * from People where EmailAddress = '{ email }'").ToList();
                var output = connection.Query<Person>("UserAuth @EmailAddress , @UserPassword",
                   new { EmailAddress = email, UserPassword = password }).ToList();
                return output;
            }
        }
                //recover password by sending otp
        public void ReqNewPasswordOTP(string email,string password)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("SampleDB")))
            {
                List<Person> people = new List<Person>();
                people.Add(new Person { EmailAddress = email,TemporaryPassword=password});
                connection.Execute("SetTempPassword @Emailaddress,@TemporaryPassword", people);

            }
        }
                // reset passsword -->(Update old password)
        public void ResetPassword(string email, string nPassword, string otp)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("SampleDB")))
            {
                List<Person> people = new List<Person>();
                people.Add(new Person { EmailAddress = email, UserPassword=nPassword,TemporaryPassword = otp });
                connection.Execute("ResetpasswordViaOTP @EmailAddress, @UserPassword, @TemporaryPassword", people);

            }
        }
    }
}
