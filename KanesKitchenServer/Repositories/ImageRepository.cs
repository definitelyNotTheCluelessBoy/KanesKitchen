using KanesKitchenServer.Data;
using KanesKitchenServer.Interfaces;
using SharedLibrary.DTOs.EShop;
using SharedLibrary.Models.Eshop;
using SharedLibrary.Responses;
using Azure.Storage;
using Azure.Storage.Blobs;
using Azure.Storage.Sas;

namespace KanesKitchenServer.Repositories
{
    public class ImageRepository : IImageRepository
    {
        private readonly AppDBContext _context;

        public ImageRepository(AppDBContext context)
        {
            _context = context;
        }

        public async Task<GeneralResponse> AddImage(int productId, string url)
        {
            var product = await _context.Products.FindAsync(productId);
            if (product == null) { return new GeneralResponse(false, "Product not found.");}
            await _context.Images.AddAsync(new Image { ImageUrl = url, ProductId = productId });
            await _context.SaveChangesAsync();
            return new GeneralResponse(true, "Image added.");
        }

        public async Task<GeneralResponse> DeleteImage(int imageId)
        {
            var image = await _context.Images.FindAsync(imageId);
            if (image == null) { return new GeneralResponse(false, "Image not found."); }
            _context.Images.Remove(image);
            await _context.SaveChangesAsync();
            return new GeneralResponse(true, "Image removed.");
        }

        public async Task<SasDto> GetSasToken()
        {
            string accountName = "picsforkitchen";
            string accountKey = "R3a32q2rmyRDkuM81O08Hx5XwcB8EhDgY8bWIl+LRT/0xUeSDBo5+fJGgfpzJxtpMq9NWRQp3p9I+AStKnXxsg==";
            string containerName = "pics";

            // Create a BlobServiceClient with a SharedKeyCredential
            var storageCredentials = new StorageSharedKeyCredential(accountName, accountKey);
            var blobServiceClient = new BlobServiceClient(
                new Uri($"https://{accountName}.blob.core.windows.net"),
                new StorageSharedKeyCredential(accountName, accountKey)
            );

            // Get a reference to the container
            var containerClient = blobServiceClient.GetBlobContainerClient(containerName);

            // Build a SAS token that grants write permissions to the container
            var sasBuilder = new BlobSasBuilder
            {
                BlobContainerName = containerName,
                Resource = "c",  // 'c' = container-level
                ExpiresOn = DateTimeOffset.UtcNow.AddMinutes(15) // SAS valid for 15 minutes
            };

            // Set the permissions your Blazor app needs. Typically:
            //  - Add:    Allows uploading of new blocks and metadata
            //  - Create: Allows creating new blobs
            //  - Write:  Allows writing to existing blobs
            sasBuilder.SetPermissions(BlobContainerSasPermissions.Create |
                                      BlobContainerSasPermissions.Write |
                                      BlobContainerSasPermissions.Add);

            // Generate the SAS token
            var sasToken = sasBuilder.ToSasQueryParameters(storageCredentials).ToString();

            // Construct the base URL of the container (no SAS appended)
            var containerUrl = containerClient.Uri.ToString();

            // Return JSON with container URL and SAS token separately
            return new SasDto{ContainerUrl = containerUrl,SasToken = sasToken};
        }
    }
}
