using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;

namespace Archive.Models.Classes
{
    public static class MasterCls
    {
        [Obsolete]
        public static bool initProg()
        {
            try
            {
                int i = 0;
                string[] parts = new string[2];
                string[] con1 = new string[4];
                string path = HttpContext.Current.Server.MapPath("~/osc");

                using (Stream fileStream = File.Open(path, FileMode.Open))
                using (StreamReader reader = new StreamReader(fileStream))
                {
                    string line = null;
                    do
                    {
                        line = reader.ReadLine();
                        if (line == null)
                        {
                            break;
                        }
                        if (i == 1)
                        {
                            line = Crypto.DecryptStringAES(line, "Ipalestine1q2w3e4");
                            //parts = line.Split('|');
                            con1 = Crypto.DecryptStringAES(line, "1q2w3e4r5t6y7u8i9o0").Split(',');
                        }
                        i++;
                    } while (true);
                }
                if (parts.Length < 1)
                    return false;

                Constants.DB_SERVER_ORA = con1[0].ToString();
                Constants.DB_NAME_ORA = con1[1].ToString();
                Constants.DB_USERNAME_ORA = con1[2].ToString();
                Constants.DB_PASSWORD_ORA = con1[3].ToString();

                

               

                return true;
            }
            catch (Exception ex)
            {
                Log(ex.ToString() + Environment.NewLine + "initProg");
                return false;
            }
        }
        public static void Log(string text)
        {
            using (StreamWriter w = File.AppendText("log_" + DateTime.Now.ToString("yyyy-MM-dd") + ".txt"))
            {
                sLog(text, w);
            }
        }
        public static void sLog(string logMessage, TextWriter w)
        {
            w.Write("\r\nLog Entry : ");
            w.WriteLine("{0} {1}", DateTime.Now.ToLongTimeString(),
                DateTime.Now.ToLongDateString());
            w.WriteLine("  :");
            w.WriteLine("  :{0}", logMessage);
            w.WriteLine("-------------------------------");
        }
        public static string GetTimestamp(this DateTime value)
        {
            return ((int)(value - new DateTime(1970, 1, 1)).TotalSeconds).ToString();
        }
    }
}