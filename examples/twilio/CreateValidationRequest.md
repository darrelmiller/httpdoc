<!DOCTYPE html><html><head><title></title><link rel="stylesheet" href="../OpenApi.css"/><meta charset="utf-8"/><meta name="viewport" content="width=device-width, initial-scale=1"/></head><body><article><section  class="requestOverview"><h1  class="requestSummary">CreateValidationRequest</h1><p  class="requestDescription"></p></section><section  class="http"><h3>HTTP Request</h3><pre  class="httpExample"><span  class="requestLine">POST</span> <span  class="httpTarget">\2010-04-01\Accounts\{AccountSid}\OutgoingCallerIds.json</span> <span  class="httpVersion">HTTP/1.1</span>
<span  class="headerLine">host</span>: <span  class="headerValue">api.twilio.com:443</span>
<span  class="headerLine">accept</span>: <span  class="headerValue">application/json</span>
<span  class="headerLine">content-type</span>: <span  class="headerValue">application/x-www-form-urlencoded</span>
</pre></section><dl  class="parameters"><h3>Parameters</h3><dt  class="parameter"><span  class="parameterName">AccountSid</span> [ in: <span  class="parameterLocation">path</span> type: <span  class="parameterType">string</span> ]</dt><dd  class="parameter"><span  class="parameterDescription">The SID of the [Account](https://www.twilio.com/docs/iam/api/account) responsible for the new caller ID resource.</span> <span  class="parameterRequired">required</span></dd></dl><section  class="requestContent"><h3>Request Body Schema</h3><pre  class="schema">{
  "title": "CreateValidationRequestRequest",
  "required": [
    "PhoneNumber"
  ],
  "type": "object",
  "properties": {
    "CallDelay": {
      "type": "integer",
      "description": "The number of seconds to delay before initiating the verification call. Can be an integer between `0` and `60`, inclusive. The default is `0`."
    },
    "Extension": {
      "type": "string",
      "description": "The digits to dial after connecting the verification call."
    },
    "FriendlyName": {
      "type": "string",
      "description": "A descriptive string that you create to describe the new caller ID resource. It can be up to 64 characters long. The default value is a formatted version of the phone number."
    },
    "PhoneNumber": {
      "type": "string",
      "description": "The phone number to verify in [E.164](https://www.twilio.com/docs/glossary/what-e164) format, which consists of a + followed by the country code and subscriber number.",
      "format": "phone-number"
    },
    "StatusCallback": {
      "type": "string",
      "description": "The URL we should call using the `status_callback_method` to send status information about the verification process to your application.",
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
      "description": "The HTTP method we should use to call `status_callback`. Can be: `GET` or `POST`, and the default is `POST`.",
      "format": "http-method"
    }
  }
}</pre></section><section  class="responses"><h2>Responses</h2><ul  class="responses"><li  class="response"><span  class="statusLine">201</span> <span  class="statusDescription">Created</span></li></ul></section></article></body></html>