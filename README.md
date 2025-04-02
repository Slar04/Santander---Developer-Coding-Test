# Santander---Developer-Coding-Test

Hacker News Best Stories API

Overview

This project is an ASP.NET Core Web API that retrieves the top n best stories from the Hacker News API. It fetches story details asynchronously and sorts them by score in descending order

Features

Fetches the top n best stories from Hacker News.

Retrieves story details in parallel using Task.WhenAll for efficiency.

Uses Newtonsoft.Json for JSON deserialization.

Handles errors gracefully to ensure API stability.

Prerequisites

.NET 7.0 or later

Visual Studio 2022 or any compatible .NET IDE

Internet connection (for accessing the Hacker News API)

Getting Started

1. Clone the Repository

git clone https://github.com/Slar04/Santander---Developer-Coding-Test.git

2. Restore Dependencies

dotnet restore

3. Run the API

dotnet run

The API will be available at http://localhost:5000/api/beststories/{count}.

Usage

To retrieve the top n best stories, make a GET request:

GET http://localhost:5000/api/beststories/10

Example Response

[
  {
    "title": "A uBlock Origin update was rejected from the Chrome Web Store",
    "uri": "https://github.com/uBlockOrigin/uBlock-issues/issues/745",
    "postedBy": "ismaildonmez",
    "time": "2019-10-12T13:43:01+00:00",
    "score": 1716,
    "commentCount": 572
  },
  { ... }
]

Assumptions

Assumption: The Hacker News API is available and stable.

Further Improvements: Implementing pagination and rate-limiting to optimize API requests.