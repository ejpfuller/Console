using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using Newtonsoft.Json;

namespace Test
{
    class MainClass
    {
        private enum Modes
        {
            WebRequest,
            EncrpytToFile,
            DecryptFromFile,
            EncryptString
        }

        public static void Main(string[] args)
        {
            Console.WriteLine("Please select an option");
            Console.WriteLine("0 = WebRequest" + "\n"+ "1 = EncrpytToFile" + "\n" + "2 = DecryptFromFile" + "\n" + "3 = EncryptString");

            int e = Convert.ToInt16(Console.ReadLine());
            Modes mode = (Modes)e;
            switch (mode)
            {
                case Modes.WebRequest:
                    Console.WriteLine("Selected: WebRequest");
                    string urlStr = "https://data.police.uk/api/forces";
                    string jsonStr = webQuery(urlStr);
                    string[] fString = formatJsonString(jsonStr);
                    for (int i = 0; i < fString.Length; i++)
                    {
                        Console.WriteLine(fString[i]);
                        Thread.Sleep(500);
                    }
                    break;

                case Modes.EncrpytToFile:
                    Console.WriteLine("Selected: EncrpytToFile");
                    Console.WriteLine("Please enter a string");
                    Cryptography.EncryptToFile();
                    break;

                case Modes.DecryptFromFile:
                    Console.WriteLine("Selected: DecryptFromFile");
                    Cryptography.DecryptFromFile();
                    break;

                case Modes.EncryptString:
                    Console.WriteLine("Selected: EncryptString");
                    Console.WriteLine("Please enter a string");
                    string str = Console.ReadLine();
                    string eStr = Cryptography.EncryptString(str);
                    Console.WriteLine(eStr);
                    break;

                default:
                    Console.WriteLine("Not an option");
                    break;
            }
        }






        static string webQuery(string url)
        {
            //string urlStr = "https://data.police.uk/api/forces";

            WebRequest request = WebRequest.Create(url);

            WebResponse response = request.GetResponse();

            //Console.WriteLine(((HttpWebResponse)response).StatusDescription + "\n");

            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string responseFromServer = reader.ReadToEnd();
            string jsonStr = responseFromServer;
            response.Close();
            return jsonStr;

        }

        static string[] formatJsonString(string str)
        {

            string[] strSplit = str.Split(',');

            char[] chars = { '[', ']', '{', '}', '\"', '"' };

            string[] trimStr = new string[strSplit.Length];
            string[] replStr = new string[strSplit.Length];

            for (int i = 0; i < strSplit.Length; i++)
            {
                trimStr[i] = strSplit[i].Trim(chars);

            }
            for (int j = 0; j < trimStr.Length; j++)
            {
                replStr[j] = trimStr[j].Replace("\"", string.Empty);
            }

            //string strTrim1 = str.Trim(chars);
            //string strReplace = strTrim1.Replace('\"', ' ');

            string[] trimmedStr = replStr;

            return trimmedStr;
        }

        //                      Collection Example
        ////////////////////////////////////////////////////////////////////////////
        //List<testObj> list = JsonConvert.DeserializeObject<List<testObj>>(jsonStr);

        //var list = JsonConvert.DeserializeObject<List<testObj>>(jsonStr);

        //testObj tObj = JsonConvert.DeserializeObject<testObj>(responseFromServer);

        //for(int i = 0; i < list.Count; i++)
        //{
        //    Console.WriteLine(list[i].id + "\n" +list[i].name +"\n");
        //}

        public class testObj
        {
            public string id { get; set; }
            public string name { get; set; }
        }

    }

}