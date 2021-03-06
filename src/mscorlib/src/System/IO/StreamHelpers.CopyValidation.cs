// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace System.IO
{
    /// <summary>Provides methods to help in the implementation of Stream-derived types.</summary>
    internal static partial class StreamHelpers
    {
        /// <summary>Validate the arguments to CopyTo, as would Stream.CopyTo.</summary>
        public static void ValidateCopyToArgs(Stream source, Stream destination, int bufferSize)
        {
            if (destination == null)
            {
                throw new ArgumentNullException(nameof(destination));
            }

            if (bufferSize <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(bufferSize), bufferSize, Environment.GetResourceString("ArgumentOutOfRange_NeedPosNum"));
            }

            bool sourceCanRead = source.CanRead;
            if (!sourceCanRead && !source.CanWrite)
            {
                throw new ObjectDisposedException(null, Environment.GetResourceString("ObjectDisposed_StreamClosed"));
            }

            bool destinationCanWrite = destination.CanWrite;
            if (!destination.CanRead && !destinationCanWrite)
            {
                throw new ObjectDisposedException(nameof(destination), Environment.GetResourceString("ObjectDisposed_StreamClosed"));
            }

            if (!sourceCanRead)
            {
                throw new NotSupportedException(Environment.GetResourceString("NotSupported_UnreadableStream"));
            }

            if (!destinationCanWrite)
            {
                throw new NotSupportedException(Environment.GetResourceString("NotSupported_UnwritableStream"));
            }
        }
    }
}
