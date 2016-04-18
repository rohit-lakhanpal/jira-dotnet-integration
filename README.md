# Jira .NET Integration (REST API)


## Description
This is a Portable Class Library implementation of Atlassian's Jira REST API (Version 2). Powered by Newtonsoft.Json & System.Net.Http. Supports .NET 4.5,as well as .NET Core.

This project is not endorsed or supported by Atlassian but is developed with ♥ by Panviva.

It is currently tagged as a beta release & has a lot of scope for improvement. We'd appreciate any community engagement/comments/feedback.

To install Jira .NET Integration (jira-dotnet-integration), run the following command in the Package Manager Console:

### Commands
> Install-Package Panviva.JiraDotNetIntegration.Library -Pre

## Code Sample

Here's an example of querying the Jira API to run a custom query:

###Step 1: Instantiate an authentication provider & service location provider

```csharp
        // The _authentication provider
        IAuthenticationProvider _authenticationProvider;
        
        // The _jira server location provider
        IJiraServerLocationProvider _jiraServerLocationProvider;

        // Your credentials
        var _userName = "your_user_name";
        var _password = "your_password";
        var _hostName = "your-company.atlassian.net";

        // Instantiate the providers
        _authenticationProvider = new BasicAuthenticationProvider(_userName, _password);
        _jiraServerLocationProvider = new ExplicitJiraServerLocationProvider(true, _hostName);
```

###Step 2: Instantiate the ISearchService and call the RunJql method
```csharp
        // Initialise the Search Service
        var searchService = new SearchService(_authenticationProvider, _jiraServerLocationProvider);
        SearchResponse successResponse;
        ErrorResponse errorResponse;
        var jqlQuery = "status=open";
        
        // Call the Jira Query & utilize the response
        var result = searchService.RunJql(jqlQuery, 2, out successResponse, out errorResponse);
        if (searchService.RunJql(jqlQuery, 2, out successResponse, out errorResponse))
        {
            // Do something with the successResponse
            Console.WriteLine($"Got {successResponse.Issues.Count()} hits.");
        }
        else
        {
            // Do something with the errorResponse
            Console.WriteLine($"Got {errorResponse.Status} error code :(");
        }
```


##Release Notes
- 1.0.0-beta: We have started this project to query version 2 of the Search API.
