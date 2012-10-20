// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved. See License.md in the project root for license information.

namespace Microsoft.AspNet.SignalR
{
    public interface IRequestCookieCollection
    {
        Cookie this[string name] { get; }
        int Count { get; }
    }
}
