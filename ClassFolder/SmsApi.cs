using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data;

namespace WebApplication1.ClassFolder
     
{
    
    public class SmsApi
        
    {
       
        public async Task<string> GetNumber(string number)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                
                Method = HttpMethod.Post,
                RequestUri = new Uri("https://nexmo-nexmo-sms-verify-v1.p.rapidapi.com/send-verification-code?phoneNumber="+ number +"&brand=CabBooking "),
                Headers =
            {
                 { "x-rapidapi-host", "nexmo-nexmo-sms-verify-v1.p.rapidapi.com" },
                 { "x-rapidapi-key", "5128e9d115msha38a1543e690c30p1f704cjsnf524c670e658" },
            }

            };
            using(var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body=await response.Content.ReadAsStringAsync();
                Console.WriteLine(body);
                return body;
               
                
            }
        }
       
    }
           
}


