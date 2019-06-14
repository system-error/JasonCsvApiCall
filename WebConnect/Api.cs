using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace WebConnect
{
    public class Api
    {
        public static string RequestJSON()
        {
            //Request from the web JSON
            // request from microsoft asychronous
            //return string
            string responseFromServer;
            // Create a request for the URL.   
            WebRequest request = WebRequest.Create(
                "http://api.nobelprize.org/v1/prize.json?");
            // If required by the server, set the credentials.  
            request.Credentials = CredentialCache.DefaultCredentials;

            // Get the response.  
            WebResponse response = request.GetResponse();
            // Display the status.  
            Console.WriteLine(((HttpWebResponse) response).StatusDescription);

            // Get the stream containing content returned by the server. 
            // The using block ensures the stream is automatically closed. 
            using (Stream dataStream = response.GetResponseStream())
            {
                // Open the stream using a StreamReader for easy access.  
                StreamReader reader = new StreamReader(dataStream);
                // Read the content.  
                responseFromServer = reader.ReadToEnd();
                // Display the content.  
                //Console.WriteLine(responseFromServer);
            }

            // Close the response.  
            response.Close();

            return responseFromServer;
        }

        public static List<string> RequestCsv()
        {

            string responseFromServer;
            List<string> csvFile = new List<string>();

            // Create a request for the URL.   
            WebRequest request = WebRequest.Create(
                "http://api.nobelprize.org/v1/prize.csv?");
            // If required by the server, set the credentials.  
            request.Credentials = CredentialCache.DefaultCredentials;

            // Get the response.  
            WebResponse response = request.GetResponse();
            // Display the status.  
            Console.WriteLine(((HttpWebResponse)response).StatusDescription);

            // Get the stream containing content returned by the server. 
            // The using block ensures the stream is automatically closed. 
            using (Stream dataStream = response.GetResponseStream())
            {
                // Open the stream using a StreamReader for easy access.  
                StreamReader reader = new StreamReader(dataStream);
                // Read the content.  
                while ((responseFromServer = reader.ReadLine()) != null)
                {

                    //string actualName = Regex.Replace(responseFromServer, @"[\r]+", " ");
                    string[] firstSpit = responseFromServer.Split('\n');

                    foreach (var item in firstSpit)
                    {
                        csvFile.Add(item);
                    }
                }

                // Display the content.  
                //Console.WriteLine(responseFromServer);
            }

            // Close the response.  
            response.Close();

            return csvFile;

        }
    }
}
