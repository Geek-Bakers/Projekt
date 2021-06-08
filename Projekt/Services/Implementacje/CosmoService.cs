using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Projekt.ModelsDTO;
using Projekt.Services.Interfejsy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projekt.Services.Implementacje
{
    public class CosmoService : ICosmoService
    {
        private DocumentClient _cosmosConnection;
        private string _databaseName;
        private string _orderCollectionName;

        public CosmoService()
        {
            var url = "https://projcosmo.documents.azure.com:443/";
            var key = "DbFeAmHNbg7b1WZcueFpTNwaOmlyFtNLE9Br1huvGm1eXuGFfkJRZcU1btOwP28nLgR6uxj6C4x4HV8uS1PwBw==";

            _databaseName = "SorageDataHistory";
            _orderCollectionName = "UploadedFile";

            _cosmosConnection = new DocumentClient(new Uri(url), key);
            _cosmosConnection.CreateDatabaseIfNotExistsAsync(new Database { Id = _databaseName });
            _cosmosConnection.CreateDocumentCollectionIfNotExistsAsync(UriFactory.CreateDatabaseUri(
            _databaseName), new DocumentCollection { Id = _orderCollectionName });
        }

        public async Task<ResponseDTO> Save(ResorceDTO resource)
        {
            try
            {
                await _cosmosConnection.CreateDocumentAsync(UriFactory.CreateDocumentCollectionUri(_databaseName, _orderCollectionName), resource);

                return new ResponseDTO() { Code = "200", Status = "Success", Message = $"Uploaded data to CosmoDb." };
            }
            catch (Exception exception)
            {
                return new ResponseDTO() { Code = "400", Status = "Failed", Message = $"Upload data to cosmoDb failed. Error message: {exception.Message}" };
            }
        }
    }
}
