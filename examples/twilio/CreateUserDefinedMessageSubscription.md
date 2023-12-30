<!DOCTYPE html><html><head><title></title><link rel="stylesheet" href="../OpenApi.css"/><meta charset="utf-8"/><meta name="viewport" content="width=device-width, initial-scale=1"/></head><body><article><section  class="requestOverview"><h1  class="requestSummary">CreateUserDefinedMessageSubscription</h1><p  class="requestDescription">Subscribe to User Defined Messages for a given Call SID.</p></section><section  class="http"><h3>HTTP Request</h3><pre  class="httpExample"><span  class="requestLine">POST</span> <span  class="httpTarget">\2010-04-01\Accounts\{AccountSid}\Calls\{CallSid}\UserDefinedMessageSubscriptions.json</span> <span  class="httpVersion">HTTP/1.1</span>
<span  class="headerLine">host</span>: <span  class="headerValue">api.twilio.com:443</span>
<span  class="headerLine">accept</span>: <span  class="headerValue">application/json</span>
<span  class="headerLine">content-type</span>: <span  class="headerValue">application/x-www-form-urlencoded</span>
</pre></section><dl  class="parameters"><h3>Parameters</h3><dt  class="parameter"><span  class="parameterName">AccountSid</span> [ in: <span  class="parameterLocation">path</span> type: <span  class="parameterType">string</span> ]</dt><dd  class="parameter"><span  class="parameterDescription">The SID of the [Account](https://www.twilio.com/docs/iam/api/account) that subscribed to the User Defined Messages.</span> <span  class="parameterRequired">required</span></dd><dt  class="parameter"><span  class="parameterName">CallSid</span> [ in: <span  class="parameterLocation">path</span> type: <span  class="parameterType">string</span> ]</dt><dd  class="parameter"><span  class="parameterDescription">The SID of the [Call](https://www.twilio.com/docs/voice/api/call-resource) the User Defined Messages subscription is associated with. This refers to the Call SID that is producing the user defined messages.</span> <span  class="parameterRequired">required</span></dd></dl><section  class="requestContent"><h3>Request Body Schema</h3><pre  class="schema">{
  "title": "CreateUserDefinedMessageSubscriptionRequest",
  "required": [
    "Callback"
  ],
  "type": "object",
  "properties": {
    "Callback": {
      "type": "string",
      "description": "The URL we should call using the `method` to send user defined events to your application. URLs must contain a valid hostname (underscores are not permitted).",
      "format": "uri"
    },
    "IdempotencyKey": {
      "type": "string",
      "description": "A unique string value to identify API call. This should be a unique string value per API call and can be a randomly generated."
    },
    "Method": {
      "enum": [
        "HEAD",
        "GET",
        "POST",
        "PATCH",
        "PUT",
        "DELETE"
      ],
      "type": "string",
      "description": "The HTTP method Twilio will use when requesting the above `Url`. Either `GET` or `POST`. Default is `POST`.",
      "format": "http-method"
    }
  }
}</pre></section><section  class="responses"><h2>Responses</h2><ul  class="responses"><li  class="response"><span  class="statusLine">201</span> <span  class="statusDescription">Created</span></li></ul></section></article></body></html>