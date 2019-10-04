﻿using Azure.Storage.Blobs.PerfStress.Core;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Storage.Blobs.PerfStress
{
    public class DownloadTest : ParallelTransferTest<ParallelTransferOptionsOptions>
    {
        public DownloadTest(ParallelTransferOptionsOptions options) : base(options)
        {
            try
            {
                BlobClient.Delete();
            }
            catch (StorageRequestFailedException)
            {
            }

            BlobClient.Upload(RandomStream);
        }

        public override void Run(CancellationToken cancellationToken)
        {
            BlobClient.Download(Stream.Null, parallelTransferOptions: ParallelTransferOptions, cancellationToken: cancellationToken);
        }

        public override Task RunAsync(CancellationToken cancellationToken)
        {
            return BlobClient.DownloadAsync(Stream.Null, parallelTransferOptions: ParallelTransferOptions, cancellationToken: cancellationToken);
        }

        public override void Dispose()
        {
            BlobClient.Delete();
            base.Dispose();
        }
    }
}