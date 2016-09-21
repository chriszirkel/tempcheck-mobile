using Amazon;
using Amazon.CognitoIdentity;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TempCheckMobile.Services
{
    public class AWSConfiguration
    {
        public static readonly RegionEndpoint AmazonCognitoRegion = RegionEndpoint.USEast1;
        public static readonly string AmazonCognitoIdentityPoolId = "us-east-1:44ed8f84-e002-4579-b2f7-e90504a85295";
        public static readonly RegionEndpoint AmazonDynamoDBRegion = RegionEndpoint.USEast1;
    }

    public class AmazonWebService
    {
        private static AmazonWebService instance;

        public static AmazonWebService Instance
        {
            get
            {
                return instance ?? (instance = new AmazonWebService());
            }
        }

        public CognitoAWSCredentials Credentials
        {
            get;
            private set;
        }

        public AmazonDynamoDBClient Client
        {
            get;
            private set;
        }

        public DynamoDBContext Context
        {
            get;
            private set;
        }

        private AmazonWebService()
        {
            //AWSConfigs.LoggingConfig.LogMetrics = true;
            //AWSConfigs.LoggingConfig.LogResponses = ResponseLoggingOption.Always;
            //AWSConfigs.LoggingConfig.LogMetricsFormat = LogMetricsFormatOption.JSON;
            //AWSConfigs.LoggingConfig.LogTo = LoggingOptions.SystemDiagnostics;

            Credentials = new CognitoAWSCredentials(AWSConfiguration.AmazonCognitoIdentityPoolId, AWSConfiguration.AmazonCognitoRegion);
            Client = new AmazonDynamoDBClient(Credentials, AWSConfiguration.AmazonDynamoDBRegion);
            Context = new DynamoDBContext(Client);
        }

        public async Task<T> LoadAsync<T>(object id)
        {
            return await Context.LoadAsync<T>(id);
        }

        public async Task SaveAsync<T>(T item)
        {
            await Context.SaveAsync(item);
        }

        public async Task DeleteAsync<T>(T item)
        {
            await Context.DeleteAsync(item);
        }
    }
}
