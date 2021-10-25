using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace BaixarDejt
{
    public class ExecutarTeste02
    {
        public static void Capturar()
        {

            #region FirefoxDriverService
            FirefoxDriverService service = FirefoxDriverService.CreateDefaultService(@"C:\Projetos\BaixarDejt\BaixarDejt\bin\Debug");
            #endregion

            #region Firefox
            FirefoxOptions options = new FirefoxOptions();
            options.SetPreference("browser.download.folderList", 2);
            options.SetPreference("browser.download.dir", "C:\\Pastas de Trabalho\\Projetos\\Captura Dados Processo\\DiarioOficialALer");
            options.SetPreference("browser.download.useDownloadDir", true);
            options.SetPreference("browser.download.viewableInternally.enabledTypes", "");
            options.SetPreference("browser.helperApps.neverAsk.saveToDisk", "application/pdf;text/plain;application/text;text/xml;application/xml");
            options.SetPreference("pdfjs.disabled", true);

            IWebDriver driver = new FirefoxDriver(service, options);
            driver.Url = "https://google.com";

            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            #endregion

            Type myTypeFfd = typeof(FirefoxDriver);
            Type myTypeFfds = typeof(FirefoxDriverService);
            Type myTypeDs = typeof(DriverService);
            
                       
            #region Funcionou
            var defa = myTypeFfd.GetField("DefaultPort", BindingFlags.Public | BindingFlags.Static).GetValue(myTypeFfd);
            var pidX = myTypeDs.GetProperty("ProcessId").GetValue(service, null);
            #endregion
            
            #region PegaApenasAsPropriedades
            var host = myTypeFfds.GetProperty("Host", BindingFlags.Public | BindingFlags.Instance);
            var bpat = myTypeFfds.GetProperty("FirefoxBinaryPath", BindingFlags.Public | BindingFlags.Instance);
            var isinit = myTypeDs.GetProperty("IsInitialized", BindingFlags.NonPublic | BindingFlags.Instance);
            #endregion
       
            Console.ReadKey();

        }

        private static void GetPropertyPublicValues(Type obj)
        {
            #region barrada
            //Type t = obj.GetType();
            //Console.WriteLine("Type is: {0}", t.Name);
            //PropertyInfo[] props = t.GetProperties();
            //Console.WriteLine("Properties (N = {0}):", props.Length);


            //foreach (var prop in props)
            //    if (prop.GetIndexParameters().Length == 0 && prop.Name != "GenericParameterAttributes" && prop.Name != "DeclaringMethod" && prop.Name != "GenericParameterPosition")
            //        Console.WriteLine("   {0} ({1}): {2}", prop.Name,
            //                          prop.PropertyType.Name,
            //                          prop.GetValue(obj));
            //    else
            //        Console.WriteLine("   {0} ({1}): <Indexed>", prop.Name,
            //                          prop.PropertyType.Name);

            //MyClass myClass = new MyClass("this is property1", "this is property2");

            //var myObject = (typeof(DriverService));
            //PropertyInfo[] pis = typeof(DriverService).GetProperties();
            //foreach (PropertyInfo pi in pis)
            //{
            //    string value = pi.GetValue(myObject, null).ToString();
            //    Console.WriteLine(value);
            //}

            //var myObject = (typeof(DriverService));

            //var teste = obj.GetType().GetNestedTypes();


            //foreach (PropertyInfo property in myObject.GetType().GetProperties())
            //{
            //    var name = property.Name;

            //    if (property.GetIndexParameters().Length == 0 &&
            //        property.Name != "GenericParameterAttributes" &&
            //        property.Name != "DeclaringMethod" &&
            //        property.Name != "GenericParameterPosition")
            //    {
            //        object objX = property.GetValue(myObject, null);
            //        if (objX != null)
            //            Console.WriteLine("Valor --->" + objX.ToString());
            //    }
            //}

            //Console.ReadKey();

            //Type type = typeof(FirefoxDriver);
            //object valueB;
            //// Loop over properties.
            //foreach (PropertyInfo propertyInfoB in type.GetProperties())
            //{
            //    // Get name.
            //    string name = propertyInfoB.Name;

            //    // Get value on the target instance.
            //    valueB = propertyInfoB.GetValue(obj, null);

            //    // Test value type.
            //    if (valueB is int)
            //    {
            //        Console.WriteLine("Int: {0} = {1}", name, valueB);
            //    }
            //    else if (valueB is string)
            //    {
            //        Console.WriteLine("String: {0} = {1}", name, valueB);

            //    }
            //}
            #endregion

            Type tX = obj.GetType();
            Console.WriteLine("Type is: {0}", tX.Name);
            PropertyInfo[] propsX = tX.GetProperties();
            Console.WriteLine("Properties (N = {0}):",
                              propsX.Length);
            foreach (var prop in propsX)
                if (prop.GetIndexParameters().Length == 0 &&
                     prop.Name != "GenericParameterAttributes" &&
                      prop.Name != "DeclaringMethod" &&
                      prop.Name != "GenericParameterPosition"

                    )
                    Console.WriteLine("   {0} ({1}): {2}", prop.Name,
                                      prop.PropertyType.Name,
                                      prop.GetValue(obj));
                else
                    Console.WriteLine("   {0} ({1}): <Indexed>", prop.Name,
                                      prop.PropertyType.Name);


            PropertyInfo[] propsid = obj.GetProperties();
            var propertyInfo = propsid.GetType().BaseType.BaseType.GetProperty("ProcessId");


            PropertyInfo[] props = obj.BaseType.GetProperties(
                                   BindingFlags.NonPublic | BindingFlags.Public |
                                   BindingFlags.Instance | BindingFlags.Static);

            PropertyInfo[] info = obj.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);

            MemberInfo[] members = obj.GetType().GetMembers(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);


            foreach (MemberInfo mInfo in members)
            {
                FieldInfo f = mInfo as FieldInfo;
                PropertyInfo p = mInfo as PropertyInfo;

                if (f != null || p != null &&
                      p.Name != "GenericParameterAttributes" &&
                      p.Name != "DeclaringMethod" &&
                      p.Name != "GenericParameterPosition"

                      )
                {
                    Type t = f != null ? f.FieldType : p.PropertyType;

                    if (t.IsValueType || t == typeof(string))
                    {
                        Console.WriteLine(f != null ? f.Name : "");

                        Console.WriteLine(f != null ? f.GetValue(obj) : p.GetValue(obj, null));
                    }
                }

            }

            Console.ReadKey();

        }

        private static IEnumerable<PropertyInfo> GetAllProperties(Type T)
        {
            IEnumerable<PropertyInfo> PropertyList = T.GetTypeInfo().DeclaredProperties;
            if (T.GetTypeInfo().BaseType != null)
            {
                PropertyList = PropertyList.Concat(GetAllProperties(T.GetTypeInfo().BaseType));




            }
            return PropertyList;
        }

        private static Object GetProperty(object srcObj, string propertyName)
        {

            PropertyInfo propInfoObj = srcObj.GetType().GetProperty(propertyName);

            if (propInfoObj == null)
                return null;

            // Get the value from property.
            object srcValue = srcObj
                      .GetType()
                      .InvokeMember(propInfoObj.Name,
                              BindingFlags.GetProperty,
                              null,
                              srcObj,
                              null);

            return srcValue;
        }

        private static string[] ObterValoresPropriedades(object objeto)
        {
            var val = new List<string>();

            foreach (var item in objeto.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance))
            {
                var pType = item.PropertyType;

                //if (pType ==  )
                //{

                //}

                Console.WriteLine("type --->  " + item.PropertyType + "name ---> " + item.Name);




                //val.Add((item.GetValue(objeto) ?? "").ToString());
            }

            Console.ReadKey();
            return val.ToArray();
        }

        private static object GetPropertyValue(object obj, string propertyName)
        {
            foreach (var prop in propertyName.Split('.').Select(s => obj.GetType().GetProperty(s)))
                obj = prop.GetValue(obj, null);

            return obj;
        }


    }
}
