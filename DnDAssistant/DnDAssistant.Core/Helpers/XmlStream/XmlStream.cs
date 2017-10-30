using System;
using System.IO;
using System.Xml.Serialization;

namespace DnDAssistant.Core
{
    /// <summary>
    /// Static class for reading and writing xml data
    /// </summary>
    public class XmlStream : IDisposable
    {
        #region Private Members
        
        /// <summary>
        /// The filestream for serializing and deserializing
        /// </summary>
        private FileStream _Stream;

        /// <summary>
        /// Path to the appdata folder
        /// </summary>
        private string _Path = IoC.Get<ApplicationViewModel>().BaseDataPath;

        /// <summary>
        /// An object to be serialized
        /// </summary>
        private object _Obj;

        #endregion
        
        #region Serialization

        /// <summary>
        /// Serializes the data if a filename and an object were already given
        /// </summary>
        public void Serialize()
        {
            // If an object was given...
            if(_Obj != null)
            {
                // Create an xmlserializer
                var sr = new XmlSerializer(_Obj.GetType());

                // Serialize the data
                sr.Serialize(_Stream, _Obj);
            }
        }

        /// <summary>
        /// Serializes the data from the given object as xml data
        /// </summary>
        /// <param name="obj">The object from wich the data will be retrieved to write. This cannot write static properties</param>
        public void Serialize(object obj)
        {
            // Create a serializer
            var sr = new XmlSerializer(obj.GetType());

            // Serialize the data
            sr.Serialize(_Stream, obj);
        }

        /// <summary>
        /// Serializes the data from the given object as xml data
        /// </summary>
        /// <param name="obj">The object from wich the data will be retrieved to write. This cannot write static properties</param>
        /// <param name="filename">Name of the file to be saved</param>
        public void Serialize(object obj, string filename)
        {
            // Create a serializer
            var sr = new XmlSerializer(obj.GetType());

            // Serialize the data
            using (var writer = new FileStream(filename, FileMode.OpenOrCreate))
                sr.Serialize(writer, obj);
        }

        /// <summary>
        /// Deserializes the xml content from the given file to the wanted type
        /// </summary>
        /// <typeparam name="T">The type of the object wanted from the data</typeparam>
        /// <param name="filename">Name of the file from wich data should be retrieved</param>
        /// <returns>Object with the data from the given file</returns>
        public T Deserialize<T>(string filename)
            where T : new()
        {
            // Create an xmlserializer
            var sr = new XmlSerializer(typeof(T));

            // Create an object of the given type
            var obj = new T();

            // Deserialize the content of the given file to the newly created object
            using (var reader = new FileStream(filename, FileMode.Open))
                 obj = (T)sr.Deserialize(reader);

            // Return the object
            return obj;
        }
        
        #endregion

        #region Constructor

        /// <summary>
        /// Default Constructor
        /// </summary>
        public XmlStream()
        {

        }

        /// <summary>
        /// Constructor that instantiates a filestream
        /// </summary>
        /// <param name="filename">Name of the file to be saved</param>
        public XmlStream(string filename)
        {
            // Create the filestream
            _Stream = new FileStream(filename, FileMode.OpenOrCreate);
        }

        /// <summary>
        /// Constructor the instantiates a filestream with an object
        /// </summary>
        /// <param name="obj">Object to be serialized</param>
        /// <param name="filename">Name of the file to be saved</param>
        public XmlStream(object obj, string filename)
        {
            // Sets the object
            _Obj = obj;

            // Create the filestream
            _Stream = new FileStream(filename, FileMode.OpenOrCreate);
        }

        #endregion

        #region Interface Methods

        /// <summary>
        /// Method for disposing the <see cref="XmlStream"/>
        /// </summary>
        public void Dispose()
        {
            // If there is a stream...
            if (_Stream != null)
                // Dispose it
                _Stream.Dispose();

            // If there is an object...
            if (_Obj != null)
                // Set the object to null
                _Obj = null;
        }

        #endregion
    }
}
