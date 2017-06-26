using System.Xml;

namespace DnDAssistant.Core
{
    /// <summary>
    /// Static class for reading and writing xml data
    /// </summary>
    public class XmlStream
    {
        /// <summary>
        /// Writes the data from the given object as xml data to the specified path
        /// </summary>
        /// <param name="obj">The object from wich the data will be retrieved to write</param>
        /// <param name="path">The path to the file to write the data. This should be inside the applications appdata folder</param>
        public static void Write(object obj, string path)
        {
            // Get the type from the object
            var objType = obj.GetType();

            
        }
    }
}
