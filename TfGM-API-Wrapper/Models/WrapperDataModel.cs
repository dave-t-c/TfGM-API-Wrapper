using System;

namespace TfGM_API_Wrapper.Models
{
    /// <summary>
    /// Data model for the TfGM-API-Wrapper project.
    /// </summary>
    public sealed class WrapperDataModel
    {
        private static readonly Lazy<WrapperDataModel> WrapperInstance = new Lazy<WrapperDataModel>(
            () => new WrapperDataModel());
        
        public static WrapperDataModel Instance => WrapperInstance.Value;

        private WrapperDataModel()
        {
            
        }
    }
}