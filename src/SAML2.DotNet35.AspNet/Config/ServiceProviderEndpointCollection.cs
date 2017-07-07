﻿using SAML2.DotNet35.Config;
using System.Configuration;
using System.Linq;

namespace SAML2.DotNet35.AspNet.Config
{
    /// <summary>
    /// Service Provider Endpoint configuration collection.
    /// </summary>
    [ConfigurationCollection(typeof(ServiceProviderEndpointElement), AddItemName = "endpoint", CollectionType = ConfigurationElementCollectionType.BasicMap)]
    public class ServiceProviderEndpointCollection : EnumerableConfigurationElementCollection<ServiceProviderEndpointElement>
    {
        /// <summary>
        /// Gets the log off endpoint.
        /// </summary>
        public ServiceProviderEndpointElement LogoutEndpoint
        {
            get { return this.FirstOrDefault(x => x.Type == EndpointType.Logout); }
        }

        /// <summary>
        /// Gets the sign on endpoint.
        /// </summary>
        public ServiceProviderEndpointElement SignOnEndpoint
        {
            get { return this.FirstOrDefault(x => x.Type == EndpointType.SignOn); }
        }
    }
}
