<!DOCTYPE html><html><head><title></title><link rel="stylesheet" href="../OpenApi.css"/><meta charset="utf-8"/><meta name="viewport" content="width=device-width, initial-scale=1"/></head><body><article><section  class="requestOverview"><h1  class="requestSummary">CreateCallFeedbackSummary</h1><p  class="requestDescription">Create a FeedbackSummary resource for a call</p></section><section  class="http"><h3>HTTP Request</h3><pre  class="httpExample"><span  class="requestLine">POST</span> <span  class="httpTarget">\2010-04-01\Accounts\{AccountSid}\Calls\FeedbackSummary.json</span> <span  class="httpVersion">HTTP/1.1</span>
<span  class="headerLine">host</span>: <span  class="headerValue">api.twilio.com:443</span>
<span  class="headerLine">accept</span>: <span  class="headerValue">application/json</span>
<span  class="headerLine">content-type</span>: <span  class="headerValue">application/x-www-form-urlencoded</span>
</pre></section><dl  class="parameters"><h3>Parameters</h3><dt  class="parameter"><span  class="parameterName">AccountSid</span> [ in: <span  class="parameterLocation">path</span> type: <span  class="parameterType">string</span> ]</dt><dd  class="parameter"><span  class="parameterDescription">The unique id of the [Account](https://www.twilio.com/docs/iam/api/account) responsible for this resource.</span> <span  class="parameterRequired">required</span></dd></dl><section  class="requestContent"><h3>Request Body Schema</h3><pre  class="schema">{
  "title": "CreateCallFeedbackSummaryRequest",
  "required": [
    "StartDate",
    "EndDate"
  ],
  "type": "object",
  "properties": {
    "EndDate": {
      "type": "string",
      "description": "Only include feedback given on or before this date. Format is `YYYY-MM-DD` and specified in UTC.",
      "format": "date"
    },
    "IncludeSubaccounts": {
      "type": "boolean",
      "description": "Whether to also include Feedback resources from all subaccounts. `true` includes feedback from all subaccounts and `false`, the default, includes feedback from only the specified account."
    },
    "StartDate": {
      "type": "string",
      "description": "Only include feedback given on or after this date. Format is `YYYY-MM-DD` and specified in UTC.",
      "format": "date"
    },
    "StatusCallback": {
      "type": "string",
      "description": "The URL that we will request when the feedback summary is complete.",
      "format": "uri"
    },
    "StatusCallbackMethod": {
      "enum": [
        "HEAD",
        "GET",
        "POST",
        "PATCH",
        "PUT",
        "DELETE"
      ],
      "type": "string",
      "description": "The HTTP method (`GET` or `POST`) we use to make the request to the `StatusCallback` URL.",
      "format": "http-method"
    }
  }
}</pre></section><section  class="responses"><h2>Responses</h2><ul  class="responses"><li  class="response"><span  class="statusLine">201</span> <span  class="statusDescription">Created</span></li></ul></section></article></body></html>