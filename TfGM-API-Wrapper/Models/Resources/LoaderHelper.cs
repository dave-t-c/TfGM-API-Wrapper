using System;
using System.IO;
using static System.AppDomain;

namespace TfGM_API_Wrapper.Models.Resources
{
    public class LoaderHelper
    {
        /// <summary>
        /// Checks the file requirements for a given file in a ResourceConfig
        /// </summary>
        /// <param name="filePath">File path to verify</param>
        /// <param name="argName">Name of the field associated with the file path</param>
        /// <returns>string - full file path for the resource.</returns>
        /// <exception cref="InvalidOperationException">
        /// Thrown when a null file path is given. StopLoaders cannot be created with null resource paths. 
        /// </exception>
        /// <exception cref="FileNotFoundException">
        /// Thrown when the file cannot be found from the base directory.
        /// </exception>
        public string CheckFileRequirements(string filePath, string argName)
        {
            if(filePath is null) 
                throw new InvalidOperationException(argName + " cannot be null");
            filePath = CurrentDomain.BaseDirectory + filePath;
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException("Could not find file " + filePath);
            }
            return filePath;
        }
    }
}