# FCWProject
This project features a react frontend, and a C# backend.
It was built from the .Asp with react project template as base.

A small overview of how it works:
The server creates a background service that will continuously poll an API endpoint, sleep for 10 seconds, and repeat. It passes the responses it gets to a ResponseHandler. 
This handler will read the data as a DataPoint struct. It then writes this data to the 'database'. It also raises an alert if the data value exceeds a threshold of 90. This is done by calling a static EmailManager to send a notification via a SmtpClient.

The 'database' is a simplified mock, which uses a queue to cache DataPoints. It automatically keeps its size at or below a set capacity (10). When it is read, it returns a list of the latest n DataPoints, with the first element being the newest.
There is an API GET endpoint available to fetch the last 10 DataPoints.

The frontend is a react application that polls the backend every 5 seconds to fetch the latest data. It displays the latest DataPoint, as well as the timestamp of the last received update.
The remaining data is processed to display a graph.

Future improvements
This is merely a proof of concept, so there are plenty of improvements and best practices that could be implemented if I were to continue work on it. To name a few:
- The APICaller could have configurable endpoints, so it can call multiple endpoints.
- The source of data could also be kept track of, so that you can keep track of multiple sources at the same time.
- The APICaller could also be moved onto a dedicated worker thread.
- The ResponseHandler should be turned into an abstract class, to allow different specific implementations to be swapped in and out when needed.
- An actual database should be set up to allow for persistent storage.
- The EmailManager could be turned into an async service to prevent slow processing from delaying the data processing.
- Many variables should be pulled into a centralized location to allow easy configuration (environment variables).
