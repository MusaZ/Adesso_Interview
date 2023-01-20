using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;
using System.Runtime.CompilerServices;
using System.Net;

class Main_
{
  public static void Main()
  {
    WebRequest request = WebRequest.Create("https://coderbyte.com/api/challenges/json/json-cleaning");
    WebResponse response = request.GetResponseAsync().Result;

    Span<byte> respSPN = new Span<byte>();
    string sstr = "";
    using (Stream str = response.GetResponseStream())
    {
      StreamReader strRDR = new StreamReader(str);
      sstr = strRDR.ReadToEnd();
    }

    string asg = "";
    int commaknm = 0;

    for (int i = 0; i < sstr.Length; i++)
    {
      if (sstr[i] == ',')
        commaknm = i;
      if (sstr[i] != ':')
        asg += sstr[i];
      else
      {
        if (sstr[i + 1] == '{' || sstr[i + 1] == '[' || (sstr[i + 1] > (char)47 && sstr[i + 1] < (char)58))
        {
          asg += sstr[i];
          asg += sstr[i + 1];
          i++;
        }
        else
        {
          char cc = sstr[i + 1];
          string s2 = sstr[i].ToString();
          string s1 = "";
          int gg = i + 1;
          i++;
          do
          {
            s1 += sstr[i];
            i++;
            cc = sstr[i];
          } while (cc != '"');

          if (s1 != "" && s1 != "N/A" && s1 != "\"")
          {
            asg += s2;
            asg += s1 + "\"";
          }
          else
          {
            // int k1 = asg.LastIndexOf(",");
            int k1 = commaknm;
            asg = asg.Substring(0, k1);
          }
          // i = gg;
        }
      }
    }

    Console.WriteLine(asg);
    Console.ReadLine();
  }
}