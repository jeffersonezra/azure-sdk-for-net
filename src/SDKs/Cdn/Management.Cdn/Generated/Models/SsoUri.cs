// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator 1.0.0.0
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.

namespace Microsoft.Azure.Management.Cdn.Models
{
    using Azure;
    using Management;
    using Cdn;
    using Newtonsoft.Json;
    using System.Linq;

    /// <summary>
    /// SSO URI required to login to the supplemental portal.
    /// </summary>
    public partial class SsoUri
    {
        /// <summary>
        /// Initializes a new instance of the SsoUri class.
        /// </summary>
        public SsoUri() { }

        /// <summary>
        /// Initializes a new instance of the SsoUri class.
        /// </summary>
        /// <param name="ssoUriValue">The URI used to login to the supplemental
        /// portal.</param>
        public SsoUri(string ssoUriValue = default(string))
        {
            SsoUriValue = ssoUriValue;
        }

        /// <summary>
        /// Gets or sets the URI used to login to the supplemental portal.
        /// </summary>
        [JsonProperty(PropertyName = "ssoUriValue")]
        public string SsoUriValue { get; set; }

    }
}

