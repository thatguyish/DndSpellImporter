using System;
using System.Text;
using System.Net;

namespace DndSpellImporter
{
    public class Importer
    {
        

        public static string websitebase = "https://www.dndbeyond.com/";
        public string searchlink(string spell)
        {
            string searchurl = $"https://www.dndbeyond.com/spells?filter-class=0&filter-search={spell}&filter-verbal=&filter-somatic=&filter-material=&filter-concentration=&filter-ritual=&filter-sub-class=";
            

            return searchurl;
        }

       
        public static string websitecontent(string url)
            {
            HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;

            //request.Accept = "application/xrds+xml";  
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            WebHeaderCollection header = response.Headers;

            var encoding = ASCIIEncoding.ASCII;
            using (var reader = new System.IO.StreamReader(response.GetResponseStream(), encoding))
            {
                string responseText = reader.ReadToEnd();

                return responseText;
            }

            
        }
        
        public static string getUserin()
        {
            Console.WriteLine("what spell");
            var str = Console.ReadLine();

            string s = "";

            for (int i = 0; i < str.Length; ++i)
            {

                if (str[i] == ' ')
                    s += '-';

                else
                    s += str[i];

            }

            return s.ToLower();


        }

        
        public static string scrubdnd(string website, string desiredinfo) 
        {
            string itemlabel = "ddb-statblock-item-label";
            string itemvalue = "ddb-statblock-item-value";

            
            if (website.Contains(itemlabel)){
                string web = website;
                Console.WriteLine(desiredinfo);

                //
                for (int i = 0; i < 8; i++)
                {
                    web = web.Substring(web.IndexOf(itemlabel));
                    int labelstart = web.IndexOf(itemlabel)+itemlabel.Length+2;
                    int labelend = web.IndexOf("</");
                    int valuestart = web.IndexOf(itemvalue);
                    int valueend = valuestart + itemvalue.Length;
                    string spelllabel = web.Substring(labelstart,labelend-labelstart).Trim();
                    string spellvalue;
                    if (spelllabel == "Components")
                    {
                        string componentex = "component-asterisks";
                        int exending = web.IndexOf(componentex) + componentex.Length;
                        int endingofcom = web.IndexOf("*</span");

                        spellvalue = web.Substring(exending + 2, endingofcom-exending-2);
                    }else if (spelllabel == "Attack/Save")
                    {

                        int ase = web.IndexOf("<span>")+"<span>".Length;
                        int aseend = web.IndexOf("</span>");

                        spellvalue = web[ase..aseend];

                    }
                    else
                    {

                        spellvalue = web.Substring(valueend + 5, 50).Trim();
                    }
                    
                    web = web.Substring(valueend);

                    Console.WriteLine("\n"); 
                    Console.WriteLine(spelllabel);
                    Console.WriteLine(spellvalue);

                }
                return "0";
            }
            Console.WriteLine("info not found");
            return "0";
            ;
               
        }


    }
}

// might need


// string regscript = $@"<a href=""/spells/{scrubbedinput}""";
//Regex htmllinkan = new Regex(regscript);
//var isit = htmllinkan.IsMatch(website).ToString();

