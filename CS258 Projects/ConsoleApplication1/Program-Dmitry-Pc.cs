using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace ConsoleApplication1
{
    class Program
    {
        public static void Main(string[] args)
        {

           
            Type[] ta = System.Reflection.Assembly.GetExecutingAssembly().GetTypes();
            foreach (Type t in ta)
            {
                Console.WriteLine(t.Namespace);
                foreach (Type a in GetTypesInNamespace(t.Namespace))
                {
                    Console.WriteLine("\t" + a.Name);
                    ShowMethods(a);
                }
                
            }
            Console.Write("");
            Console.ReadLine();
        }

        public static List<Type> GetTypesInNamespace( string nameSpace)
        {
            return Assembly.GetExecutingAssembly().GetTypes().ToList().Where(t => t.Namespace == nameSpace).ToList();
        }

       public static void ShowMethods(Type type)
        {
            foreach (var method in type.GetMethods())
            {
                var parameters = method.GetParameters();
                var parameterDescriptions = string.Join
                    (", ", method.GetParameters()
                                 .Select(x => x.ParameterType + " " + x.Name)
                                 .ToArray());

                //Console.WriteLine("{0} {1} ({2})",
                //                  method.ReturnType,
                //                  method.Name,
                //                  parameterDescriptions);
                if (method.Name != "ToString" && method.Name != "GetType" && method.Name != "GetHashCode" && method.Name != "Equals")
                {
                    Console.WriteLine("\t\t" + method.Name);
                }
                
            }
        }
       

    }
    
}