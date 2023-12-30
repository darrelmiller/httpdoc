<!DOCTYPE html><html><head><title></title><link rel="stylesheet" href="../OpenApi.css"/><meta charset="utf-8"/><meta name="viewport" content="width=device-width, initial-scale=1"/></head><body><article><section  class="requestOverview"><h1  class="requestSummary">UpdateShortCode</h1><p  class="requestDescription">Update a short code with the following parameters</p></section><section  class="http"><h3>HTTP Request</h3><pre  class="httpExample"><span  class="requestLine">POST</span> <span  class="httpTarget">\2010-04-01\Accounts\{AccountSid}\SMS\ShortCodes\{Sid}.json</span> <span  class="httpVersion">HTTP/1.1</span>
<span  class="headerLine">host</span>: <span  class="headerValue">api.twilio.com:443</span>
<span  class="headerLine">accept</span>: <span  class="headerValue">application/json</span>
<span  class="headerLine">content-type</span>: <span  class="headerValue">application/x-www-form-urlencoded</span>
</pre></section><dl  class="parameters"><h3>Parameters</h3><dt  class="parameter"><span  class="parameterName">AccountSid</span> [ in: <span  class="parameterLocation">path</span> type: <span  class="parameterType">string</span> ]</dt><dd  class="parameter"><span  class="parameterDescription">The SID of the [Account](https://www.twilio.com/docs/iam/api/account) that created the ShortCode resource(s) to update.</span> <span  class="parameterRequired">required</span></dd><dt  class="parameter"><span  class="parameterName">Sid</span> [ in: <span  class="parameterLocation">path</span> type: <span  class="parameterType">string</span> ]</dt><dd  class="parameter"><span  class="parameterDescription">The Twilio-provided string that uniquely identifies the ShortCode resource to update</span> <span  class="parameterRequired">required</span></dd></dl><section  class="requestContent"><h3>Request Body Schema</h3><pre  class="schema">{
  "title": "UpdateShortCodeRequest",
  "type": "object",
  "properties": {
    "ApiVersion": {
      "type": "string",
      "description": "The API version to use to start a new TwiML session. Can be: `2010-04-01` or `2008-08-01`."
    },
    "FriendlyName": {
      "type": "string",
      "description": "A descriptive string that you created to describe this resource. It can be up to 64 characters long. By default, the `FriendlyName` is the short code."
    },
    "SmsFallbackMethod": {
      "enum": [
        "HEAD",
        "GET",
        "POST",
        "PATCH",
        "PUT",
        "DELETE"
      ],
      "type": "string",
      "description": "The HTTP method that we should use to call the `sms_fallback_url`. Can be: `GET` or `POST`.",
      "format": "http-method"
    },
    "SmsFallbackUrl": {
      "type": "string",
      "description": "The URL that we should call if an error occurs while retrieving or executing the TwiML from `sms_url`.",
      "format": "uri"
    },
    "SmsMethod": {
      "enum": [
        "HEAD",
        "GET",
        "POST",
        "PATCH",
        "PUT",
        "DELETE"
      ],
      "type": "string",
      "description": "The HTTP method we should use when calling the `sms_url`. Can be: `GET` or `POST`.",
      "format": "http-method"
    },
    "SmsUrl": {
      "type": "string",
      "description": "The URL we should call when receiving an incoming SMS message to this short code.",
      "format": "uri"
    }
  }
}</pre></section><section  class="responses"><h2>Responses</h2><ul  class="responses"><li  class="response"><span  class="statusLine">200</span> <span  class="statusDescription">OK</span></li></ul></section></article></body></html>