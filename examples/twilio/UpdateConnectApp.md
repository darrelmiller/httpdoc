<!DOCTYPE html><html><head><title></title><link rel="stylesheet" href="../OpenApi.css"/><meta charset="utf-8"/><meta name="viewport" content="width=device-width, initial-scale=1"/></head><body><article><section  class="requestOverview"><h1  class="requestSummary">UpdateConnectApp</h1><p  class="requestDescription">Update a connect-app with the specified parameters</p></section><section  class="http"><h3>HTTP Request</h3><pre  class="httpExample"><span  class="requestLine">POST</span> <span  class="httpTarget">\2010-04-01\Accounts\{AccountSid}\ConnectApps\{Sid}.json</span> <span  class="httpVersion">HTTP/1.1</span>
<span  class="headerLine">host</span>: <span  class="headerValue">api.twilio.com:443</span>
<span  class="headerLine">accept</span>: <span  class="headerValue">application/json</span>
<span  class="headerLine">content-type</span>: <span  class="headerValue">application/x-www-form-urlencoded</span>
</pre></section><dl  class="parameters"><h3>Parameters</h3><dt  class="parameter"><span  class="parameterName">AccountSid</span> [ in: <span  class="parameterLocation">path</span> type: <span  class="parameterType">string</span> ]</dt><dd  class="parameter"><span  class="parameterDescription">The SID of the [Account](https://www.twilio.com/docs/iam/api/account) that created the ConnectApp resources to update.</span> <span  class="parameterRequired">required</span></dd><dt  class="parameter"><span  class="parameterName">Sid</span> [ in: <span  class="parameterLocation">path</span> type: <span  class="parameterType">string</span> ]</dt><dd  class="parameter"><span  class="parameterDescription">The Twilio-provided string that uniquely identifies the ConnectApp resource to update.</span> <span  class="parameterRequired">required</span></dd></dl><section  class="requestContent"><h3>Request Body Schema</h3><pre  class="schema">{
  "title": "UpdateConnectAppRequest",
  "type": "object",
  "properties": {
    "AuthorizeRedirectUrl": {
      "type": "string",
      "description": "The URL to redirect the user to after we authenticate the user and obtain authorization to access the Connect App.",
      "format": "uri"
    },
    "CompanyName": {
      "type": "string",
      "description": "The company name to set for the Connect App."
    },
    "DeauthorizeCallbackMethod": {
      "enum": [
        "HEAD",
        "GET",
        "POST",
        "PATCH",
        "PUT",
        "DELETE"
      ],
      "type": "string",
      "description": "The HTTP method to use when calling `deauthorize_callback_url`.",
      "format": "http-method"
    },
    "DeauthorizeCallbackUrl": {
      "type": "string",
      "description": "The URL to call using the `deauthorize_callback_method` to de-authorize the Connect App.",
      "format": "uri"
    },
    "Description": {
      "type": "string",
      "description": "A description of the Connect App."
    },
    "FriendlyName": {
      "type": "string",
      "description": "A descriptive string that you create to describe the resource. It can be up to 64 characters long."
    },
    "HomepageUrl": {
      "type": "string",
      "description": "A public URL where users can obtain more information about this Connect App.",
      "format": "uri"
    },
    "Permissions": {
      "type": "array",
      "items": {
        "enum": [
          "get-all",
          "post-all"
        ],
        "type": "string"
      },
      "description": "A comma-separated list of the permissions you will request from the users of this ConnectApp.  Can include: `get-all` and `post-all`."
    }
  }
}</pre></section><section  class="responses"><h2>Responses</h2><ul  class="responses"><li  class="response"><span  class="statusLine">200</span> <span  class="statusDescription">OK</span></li></ul></section></article></body></html>