using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using  CMS.App;
using CMS.Inf;
using  Newtonsoft.Json;
using  System.Web;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CMS
{
    class CallMthodFromJson:ICallMethodFromJson
    {
        public void CallMethod(string nameClass)
        {
            string JsonStr = File.ReadAllText("Json.json");
            Console.WriteLine(JsonStr);
            JObject jObject = Newtonsoft.Json.Linq.JObject.Parse(JsonStr);
            var token = jObject["methodName"].ToString();
            JToken[] token2 = jObject["params"].ToArray();

            Console.WriteLine(token);


            Assembly a = Assembly.LoadFrom("CMS.App.dll"); // dll - "ClassLibrary3"
            Type t = a.GetType("CMS.App.Use"); // namespace - "MyPlayers" , class - "Player"
            Object instance = Activator.CreateInstance(t);
            MethodInfo m1 = t.GetMethod(token); // method

            m1.Invoke(instance, new object[] {token2});
            // m1.Invoke(instance, token2);

            MethodInfo[] m = t.GetMethods(); // method
            foreach (MethodInfo method in m)
            {
                string modificator = "";
                if (method.IsStatic)
                    modificator += "static ";
                if (method.IsVirtual)
                    modificator += "virtual ";
                Console.Write(modificator + method.ReturnType.Name + " " + method.Name + " (");
                //получаем все параметры
                ParameterInfo[] parameters = method.GetParameters();
                for (int i = 0; i < parameters.Length; i++)
                {
                    Console.Write(parameters[i].ParameterType.Name + " " + parameters[i].Name);
                    if (i + 1 < parameters.Length) Console.Write(", ");
                }
                Console.WriteLine(")");
            }

            

        }
    }
}
