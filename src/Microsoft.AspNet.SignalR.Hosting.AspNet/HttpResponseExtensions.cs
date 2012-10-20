// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved. See License.md in the project root for license information.

using System.Threading.Tasks;
using System.Web;

namespace Microsoft.AspNet.SignalR.Hosting.AspNet
{
    internal static class HttpResponseExtensions
    {
        public static Task FlushAsync(this HttpResponseBase response)
        {
            if (!response.IsClientConnected)
            {
                return TaskAsyncHelper.Empty;
            }
#if NET45
            if (response.SupportsAsyncFlush)
            {
                return Task.Factory.FromAsync((cb, state) => response.BeginFlush(cb, state), ar => response.EndFlush(ar), null);
            }      
#endif
            try
            {
                response.Flush();
            }
            catch
            {

            }

            return TaskAsyncHelper.Empty;
        }
    }
}
