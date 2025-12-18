using FCWProject.Database;

namespace FCWProject.API
{
    /// <summary>
    /// This class handles logic for processing HttpResponseMessages.
    /// </summary>
    public class ResponseHandler
    {
        private const int VALUE_ALERT_THRESHOLD = 90;

        private DataStorage storage;

        public ResponseHandler(DataStorage storage)
        {
            this.storage = storage;
        }

        public async virtual void Process(HttpResponseMessage response)
        {
            if (response is null)
                return;

            DataPoint data = await response.Content.ReadFromJsonAsync<DataPoint>();
            Console.WriteLine($"Received data: {data.value}");
            if (data.value >= VALUE_ALERT_THRESHOLD)
            {
                Console.WriteLine($"ALERT: {data.value} exceeded threshold of {VALUE_ALERT_THRESHOLD}.");
                // todo alert email
            }

            storage.Write(data);
        }
    }
}
