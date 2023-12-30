<!DOCTYPE html><html><head><title></title><link rel="stylesheet" href="../OpenApi.css"/><meta charset="utf-8"/><meta name="viewport" content="width=device-width, initial-scale=1"/></head><body><article><section  class="requestOverview"><h1  class="requestSummary">CreateApplication</h1><p  class="requestDescription">Create a new application within your account</p></section><section  class="http"><h3>HTTP Request</h3><pre  class="httpExample"><span  class="requestLine">POST</span> <span  class="httpTarget">\2010-04-01\Accounts\{AccountSid}\Applications.json</span> <span  class="httpVersion">HTTP/1.1</span>
<span  class="headerLine">host</span>: <span  class="headerValue">api.twilio.com:443</span>
<span  class="headerLine">accept</span>: <span  class="headerValue">application/json</span>
<span  class="headerLine">content-type</span>: <span  class="headerValue">application/x-www-form-urlencoded</span>
</pre></section><dl  class="parameters"><h3>Parameters</h3><dt  class="parameter"><span  class="parameterName">AccountSid</span> [ in: <span  class="parameterLocation">path</span> type: <span  class="parameterType">string</span> ]</dt><dd  class="parameter"><span  class="parameterDescription">The SID of the [Account](https://www.twilio.com/docs/iam/api/account) that will create the resource.</span> <span  class="parameterRequired">required</span></dd></dl><section  class="requestContent"><h3>Request Body Schema</h3><pre  class="schema">{
  "title": "CreateApplicationRequest",
  "type": "object",
  "properties": {
    "ApiVersion": {
      "type": "string",
      "description": "The API version to use to start a new TwiML session. Can be: `2010-04-01` or `2008-08-01`. The default value is the account's default API version."
    },
    "FriendlyName": {
      "type": "string",
      "description": "A descriptive string that you create to describe the new application. It can be up to 64 characters long."
    },
    "MessageStatusCallback": {
      "type": "string",
      "description": "The URL we should call using a POST method to send message status information to your application.",
      "format": "uri"
    },
    "PublicApplicationConnectEnabled": {
      "type": "boolean",
      "description": "Whether to allow other Twilio accounts to dial this applicaton using Dial verb. Can be: `true` or `false`."
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
      "description": "The HTTP method we should use to call `sms_fallback_url`. Can be: `GET` or `POST`.",
      "format": "http-method"
    },
    "SmsFallbackUrl": {
      "type": "string",
      "description": "The URL that we should call when an error occurs while retrieving or executing the TwiML from `sms_url`.",
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
      "description": "The HTTP method we should use to call `sms_url`. Can be: `GET` or `POST`.",
      "format": "http-method"
    },
    "SmsStatusCallback": {
      "type": "string",
      "description": "The URL we should call using a POST method to send status information about SMS messages sent by the application.",
      "format": "uri"
    },
    "SmsUrl": {
      "type": "string",
      "description": "The URL we should call when the phone number receives an incoming SMS message.",
      "format": "uri"
    },
    "StatusCallback": {
      "type": "string",
      "description": "The URL we should call using the `status_callback_method` to send status information to your application.",
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
      "description": "The HTTP method we should use to call `status_callback`. Can be: `GET` or `POST`.",
      "format": "http-method"
    },
    "VoiceCallerIdLookup": {
      "type": "boolean",
      "description": "Whether we should look up the caller's caller-ID name from the CNAM database (additional charges apply). Can be: `true` or `false`."
    },
    "VoiceFallbackMethod": {
      "enum": [
        "HEAD",
        "GET",
        "POST",
        "PATCH",
        "PUT",
        "DELETE"
      ],
      "type": "string",
      "description": "The HTTP method we should use to call `voice_fallback_url`. Can be: `GET` or `POST`.",
      "format": "http-method"
    },
    "VoiceFallbackUrl": {
      "type": "string",
      "description": "The URL that we should call when an error occurs retrieving or executing the TwiML requested by `url`.",
      "format": "uri"
    },
    "VoiceMethod": {
      "enum": [
        "HEAD",
        "GET",
        "POST",
        "PATCH",
        "PUT",
        "DELETE"
      ],
      "type": "string",
      "description": "The HTTP method we should use to call `voice_url`. Can be: `GET` or `POST`.",
      "format": "http-method"
    },
    "VoiceUrl": {
      "type": "string",
      "description": "The URL we should call when the phone number assigned to this application receives a call.",
      "format": "uri"
    }
  }
}</pre></section><section  class="responses"><h2>Responses</h2><ul  class="responses"><li  class="response"><span  class="statusLine">201</span> <span  class="statusDescription">Created</span></li></ul></section></article></body></html>