using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace Serialization
{
    public class Serializer
    {
        public string Serialize<T>(T obj)
        {
            string ret = "";
            try
            {
                ret = new JavaScriptSerializer().Serialize(obj);
            }
            catch (Exception)
            {
               
            }

            return ret;
        }

        public T Deserialize<T>(string json)
        {
            var jsonWNull = json.Replace("\"\"", " null").Replace(":0,",": null,");
            T ret = default(T);
            try
            {
                ret = new JavaScriptSerializer().Deserialize<T>(jsonWNull);
            }
            catch (Exception)
            {

            }

            return ret;
        }
    }
}
