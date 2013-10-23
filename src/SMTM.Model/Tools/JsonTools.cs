using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Runtime.Serialization.Json;
using System.IO;
namespace SMTM.Model
{
    static public class JsonTools
    {
        #region ToObject
        /// <summary>
        /// Serializer a Object to Json
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string ObjectToJson(object obj)
        {
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(obj.GetType());
            MemoryStream stream = new MemoryStream();
            serializer.WriteObject(stream, obj);
            byte[] dataBytes = new byte[stream.Length];
            stream.Position = 0;
            stream.Read(dataBytes, 0, (int)stream.Length);
            return Encoding.UTF8.GetString(dataBytes);
        }
        /// <summary>
        /// Serializer a Object to Json
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string ToJson<T>(this T obj)
        {
            return ObjectToJson(obj);
        }
        #endregion

        #region ToJson
        /// <summary>
        /// Serializer a Json to Object
        /// </summary>
        /// <param name="jsonString">Json</param>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static object JsonToObject(string jsonString, object obj)
        {
            return JsonToObject(jsonString, obj.GetType());
        }

        /// <summary>
        /// Serializer a Json to Object
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="jsonString">Json</param>
        /// <returns></returns>
        public static T JsonToObject<T>(string jsonString) where T : new()
        {
            return (T)JsonToObject(jsonString, new T().GetType());
        }

        /// <summary>
        /// Serializer a Json to Object
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <param name="jsonString"></param>
        /// <returns></returns>
        public static T ToObject<T>(this string jsonString) where T : new()
        {
            return JsonToObject<T>(jsonString);
        }

        /// <summary>
        /// Serializer a Json to Object
        /// </summary>
        /// <param name="jsonString">json</param>
        /// <param name="objType"></param>
        /// <returns></returns>
        public static object JsonToObject(string jsonString, Type objType)
        {
            if (String.IsNullOrEmpty(jsonString))
            {
                return Activator.CreateInstance(objType);
            }
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(objType);
            MemoryStream mStream = new MemoryStream(Encoding.UTF8.GetBytes(jsonString));
            return serializer.ReadObject(mStream);
        }
        #endregion
    }
}
