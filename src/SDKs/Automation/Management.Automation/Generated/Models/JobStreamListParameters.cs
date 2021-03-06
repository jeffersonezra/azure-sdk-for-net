// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

// Warning: This code was generated by a tool.
// 
// Changes to this file may cause incorrect behavior and will be lost if the
// code is regenerated.

using System;
using System.Linq;
using Microsoft.Azure.Management.Automation.Models;

namespace Microsoft.Azure.Management.Automation.Models
{
    /// <summary>
    /// The parameters supplied to the list job stream's stream items operation.
    /// </summary>
    public partial class JobStreamListParameters : ParametersWithSkipToken
    {
        private string _streamType;
        
        /// <summary>
        /// Optional. The type of the job stream.
        /// </summary>
        public string StreamType
        {
            get { return this._streamType; }
            set { this._streamType = value; }
        }
        
        private string _time;
        
        /// <summary>
        /// Optional. Use the time filter to retrieve stream records created
        /// after this time. The value should be a datetime string in UTC
        /// format as defined in ISO 8601. For example,
        /// 2014-09-25T17:49:17.2252204Z
        /// </summary>
        public string Time
        {
            get { return this._time; }
            set { this._time = value; }
        }
        
        /// <summary>
        /// Initializes a new instance of the JobStreamListParameters class.
        /// </summary>
        public JobStreamListParameters()
        {
        }
    }
}
