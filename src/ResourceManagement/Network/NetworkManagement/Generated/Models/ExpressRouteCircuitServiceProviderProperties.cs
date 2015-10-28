// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
// 
// Code generated by Microsoft (R) AutoRest Code Generator 0.12.0.0
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.

namespace Microsoft.Azure.Management.Network.Models
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Microsoft.Rest;
    using Microsoft.Rest.Serialization;
    using Microsoft.Rest.Azure;

    /// <summary>
    /// Contains ServiceProviderProperties in an ExpressRouteCircuit
    /// </summary>
    public partial class ExpressRouteCircuitServiceProviderProperties
    {
        /// <summary>
        /// Initializes a new instance of the
        /// ExpressRouteCircuitServiceProviderProperties class.
        /// </summary>
        public ExpressRouteCircuitServiceProviderProperties() { }

        /// <summary>
        /// Initializes a new instance of the
        /// ExpressRouteCircuitServiceProviderProperties class.
        /// </summary>
        public ExpressRouteCircuitServiceProviderProperties(string serviceProviderName = default(string), string peeringLocation = default(string), int? bandwidthInMbps = default(int?))
        {
            ServiceProviderName = serviceProviderName;
            PeeringLocation = peeringLocation;
            BandwidthInMbps = bandwidthInMbps;
        }

        /// <summary>
        /// Gets or sets serviceProviderName.
        /// </summary>
        [JsonProperty(PropertyName = "serviceProviderName")]
        public string ServiceProviderName { get; set; }

        /// <summary>
        /// Gets or sets peering location.
        /// </summary>
        [JsonProperty(PropertyName = "peeringLocation")]
        public string PeeringLocation { get; set; }

        /// <summary>
        /// Gets or sets BandwidthInMbps.
        /// </summary>
        [JsonProperty(PropertyName = "bandwidthInMbps")]
        public int? BandwidthInMbps { get; set; }

    }
}
