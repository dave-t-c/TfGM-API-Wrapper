using System.Collections.Generic;
using Microsoft.AspNetCore.Authentication;

namespace TfGM_API_Wrapper.Models.Services
{
    public class ServiceFormatter
    {

        public ServiceFormatter()
        {
            
        }

        public FormattedServices FormatServices(List<UnformattedServices> unformattedServices)
        {
            FormattedServices formattedServices = new FormattedServices();
            foreach (UnformattedServices service in unformattedServices)
            {
                Tram tram = new Tram(service.Dest0, service.Carriages0, service.Status0,
                    service.Wait0);
                formattedServices.AddService(tram);
                
                tram = new Tram(service.Dest1, service.Carriages1, service.Status1,
                    service.Wait1);
                formattedServices.AddService(tram);
                
                tram = new Tram(service.Dest2, service.Carriages2, service.Status2,
                    service.Wait2);
                formattedServices.AddService(tram);
                
                formattedServices.AddMessage(service.MessageBoard);
            }
            
            return formattedServices;
        }
    }
}