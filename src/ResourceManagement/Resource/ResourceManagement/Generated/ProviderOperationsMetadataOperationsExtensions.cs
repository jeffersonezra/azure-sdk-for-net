// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
// 
// Code generated by Microsoft (R) AutoRest Code Generator 0.12.0.0
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.

namespace Microsoft.Azure.Management.Resources
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Rest;
    using System.Linq.Expressions;
    using Microsoft.Rest.Azure;
    using Models;

    public static partial class ProviderOperationsMetadataOperationsExtensions
    {
            /// <summary>
            /// Gets provider operations metadata
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceProviderNamespace'>
            /// Namespace of the resource provider.
            /// </param>
            /// <param name='apiVersion'>
            /// </param>
            /// <param name='expand'>
            /// </param>
            public static ProviderOperationsMetadata Get(this IProviderOperationsMetadataOperations operations, string resourceProviderNamespace, string apiVersion, string expand = "resourceTypes")
            {
                return Task.Factory.StartNew(s => ((IProviderOperationsMetadataOperations)s).GetAsync(resourceProviderNamespace, apiVersion, expand), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Gets provider operations metadata
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceProviderNamespace'>
            /// Namespace of the resource provider.
            /// </param>
            /// <param name='apiVersion'>
            /// </param>
            /// <param name='expand'>
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<ProviderOperationsMetadata> GetAsync( this IProviderOperationsMetadataOperations operations, string resourceProviderNamespace, string apiVersion, string expand = "resourceTypes", CancellationToken cancellationToken = default(CancellationToken))
            {
                AzureOperationResponse<ProviderOperationsMetadata> result = await operations.GetWithHttpMessagesAsync(resourceProviderNamespace, apiVersion, expand, null, cancellationToken).ConfigureAwait(false);
                return result.Body;
            }

            /// <summary>
            /// Gets provider operations metadata list
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='apiVersion'>
            /// </param>
            /// <param name='expand'>
            /// </param>
            public static ProviderOperationsMetadataListResult List(this IProviderOperationsMetadataOperations operations, string apiVersion, string expand = "resourceTypes")
            {
                return Task.Factory.StartNew(s => ((IProviderOperationsMetadataOperations)s).ListAsync(apiVersion, expand), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Gets provider operations metadata list
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='apiVersion'>
            /// </param>
            /// <param name='expand'>
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<ProviderOperationsMetadataListResult> ListAsync( this IProviderOperationsMetadataOperations operations, string apiVersion, string expand = "resourceTypes", CancellationToken cancellationToken = default(CancellationToken))
            {
                AzureOperationResponse<ProviderOperationsMetadataListResult> result = await operations.ListWithHttpMessagesAsync(apiVersion, expand, null, cancellationToken).ConfigureAwait(false);
                return result.Body;
            }

    }
}
