using KanesKitchenServer.Interfaces;
using Microsoft.AspNetCore.Mvc;
using SharedLibrary.DTOs.EShop;
using Azure.Storage;
using Azure.Storage.Blobs;
using Azure.Storage.Sas;

namespace KanesKitchenServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {

        private readonly IImageRepository _imageRepository;

        public ImageController(IImageRepository imageRepository)
        {
            _imageRepository = imageRepository;
        }

        [HttpPost]
        public async Task<IActionResult> AddImage(DeleteImageDto deleteImageDto)
        {
            var response = await _imageRepository.AddImage(deleteImageDto.productId, deleteImageDto.imageUrl);
            if (!response.Success)
            {
                return BadRequest(response.Message);
            }
            return Ok(response.Message);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteImage([FromForm] int imageId)
        {
            var response = await _imageRepository.DeleteImage(imageId);
            if (!response.Success)
            {
                return BadRequest(response.Message);
            }
            return Ok(response.Message);
        }

        [HttpGet("getsas")]
        public async Task<IActionResult> GetSasToken()
        {
            string accountName = "picsforkitchen";
            string accountKey = "R3a32q2rmyRDkuM81O08Hx5XwcB8EhDgY8bWIl+LRT/0xUeSDBo5+fJGgfpzJxtpMq9NWRQp3p9I+AStKnXxsg==";
            string containerName = "pics";

            // 2. Create a BlobServiceClient with a SharedKeyCredential
            var storageCredentials = new StorageSharedKeyCredential(accountName, accountKey);
            var blobServiceClient = new BlobServiceClient(
                new Uri($"https://{accountName}.blob.core.windows.net"),
                new StorageSharedKeyCredential(accountName, accountKey)
            );

            // 3. Get a reference to the container
            var containerClient = blobServiceClient.GetBlobContainerClient(containerName);

            // Optional: Create the container if it doesn't exist
            // containerClient.CreateIfNotExists();

            // 4. Build a SAS token that grants write permissions to the container
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

            // 5. Generate the SAS token
            var sasToken = sasBuilder.ToSasQueryParameters(storageCredentials).ToString();

            // 6. Construct the base URL of the container (no SAS appended)
            var containerUrl = containerClient.Uri.ToString();

            // 7. Return JSON with container URL and SAS token separately
            //    This allows your Blazor WASM app to do: new BlobServiceClient($"{containerUrl}?{sasToken}")
            return Ok(new SasDto
            {
                ContainerUrl = containerUrl,
                SasToken = sasToken
            });
        }
    }
}
