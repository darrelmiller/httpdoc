<!DOCTYPE html><html><head><title></title><link rel="stylesheet" href="../OpenApi.css"/><meta charset="utf-8"/><meta name="viewport" content="width=device-width, initial-scale=1"/></head><body><article><section  class="requestOverview"><h1  class="requestSummary">CreateIncomingPhoneNumberLocal</h1><p  class="requestDescription"></p></section><section  class="http"><h3>HTTP Request</h3><pre  class="httpExample"><span  class="requestLine">POST</span> <span  class="httpTarget">\2010-04-01\Accounts\{AccountSid}\IncomingPhoneNumbers\Local.json</span> <span  class="httpVersion">HTTP/1.1</span>
<span  class="headerLine">host</span>: <span  class="headerValue">api.twilio.com:443</span>
<span  class="headerLine">accept</span>: <span  class="headerValue">application/json</span>
<span  class="headerLine">content-type</span>: <span  class="headerValue">application/x-www-form-urlencoded</span>
</pre></section><dl  class="parameters"><h3>Parameters</h3><dt  class="parameter"><span  class="parameterName">AccountSid</span> [ in: <span  class="parameterLocation">path</span> type: <span  class="parameterType">string</span> ]</dt><dd  class="parameter"><span  class="parameterDescription">The SID of the [Account](https://www.twilio.com/docs/iam/api/account) that will create the resource.</span> <span  class="parameterRequired">required</span></dd></dl><section  class="requestContent"><h3>Request Body Schema</h3><pre  class="schema">{
  "title": "CreateIncomingPhoneNumberLocalRequest",
  "required": [
    "PhoneNumber"
  ],
  "type": "object",
  "properties": {
    "AddressSid": {
      "maxLength": 34,
      "minLength": 34,
      "pattern": "^AD[0-9a-fA-F]{32}$",
      "type": "string",
      "description": "The SID of the Address resource we should associate with the new phone number. Some regions require addresses to meet local regulations."
    },
    "ApiVersion": {
      "type": "string",
      "description": "The API version to use for incoming calls made to the new phone number. The default is `2010-04-01`."
    },
    "BundleSid": {
      "maxLength": 34,
      "minLength": 34,
      "pattern": "^BU[0-9a-fA-F]{32}$",
      "type": "string",
      "description": "The SID of the Bundle resource that you associate with the phone number. Some regions require a Bundle to meet local Regulations."
    },
    "EmergencyAddressSid": {
      "maxLength": 34,
      "minLength": 34,
      "pattern": "^AD[0-9a-fA-F]{32}$",
      "type": "string",
      "description": "The SID of the emergency address configuration to use for emergency calling from the new phone number."
    },
    "EmergencyStatus": {
      "enum": [
        "Active",
        "Inactive"
      ],
      "type": "string"
    },
    "FriendlyName": {
      "type": "string",
      "description": "A descriptive string that you created to describe the new phone number. It can be up to 64 characters long. By default, this is a formatted version of the phone number."
    },
    "IdentitySid": {
      "maxLength": 34,
      "minLength": 34,
      "pattern": "^RI[0-9a-fA-F]{32}$",
      "type": "string",
      "description": "The SID of the Identity resource that we should associate with the new phone number. Some regions require an identity to meet local regulations."
    },
    "PhoneNumber": {
      "type": "string",
      "description": "The phone number to purchase specified in [E.164](https://www.twilio.com/docs/glossary/what-e164) format.  E.164 phone numbers consist of a + followed by the country code and subscriber number without punctuation characters. For example, +14155551234.",
      "format": "phone-number"
    },
    "SmsApplicationSid": {
      "maxLength": 34,
      "minLength": 34,
      "pattern": "^AP[0-9a-fA-F]{32}$",
      "type": "string",
      "description": "The SID of the application that should handle SMS messages sent to the new phone number. If an `sms_application_sid` is present, we ignore all of the `sms_*_url` urls and use those set on the application."
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
      "description": "The HTTP method that we should use to call `sms_fallback_url`. Can be: `GET` or `POST` and defaults to `POST`.",
      "format": "http-method"
    },
    "SmsFallbackUrl": {
      "type": "string",
      "description": "The URL that we should call when an error occurs while requesting or executing the TwiML defined by `sms_url`.",
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
      "description": "The HTTP method that we should use to call `sms_url`. Can be: `GET` or `POST` and defaults to `POST`.",
      "format": "http-method"
    },
    "SmsUrl": {
      "type": "string",
      "description": "The URL we should call when the new phone number receives an incoming SMS message.",
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
      "description": "The HTTP method we should use to call `status_callback`. Can be: `GET` or `POST` and defaults to `POST`.",
      "format": "http-method"
    },
    "TrunkSid": {
      "maxLength": 34,
      "minLength": 34,
      "pattern": "^TK[0-9a-fA-F]{32}$",
      "type": "string",
      "description": "The SID of the Trunk we should use to handle calls to the new phone number. If a `trunk_sid` is present, we ignore all of the voice urls and voice applications and use only those set on the Trunk. Setting a `trunk_sid` will automatically delete your `voice_application_sid` and vice versa."
    },
    "VoiceApplicationSid": {
      "maxLength": 34,
      "minLength": 34,
      "pattern": "^AP[0-9a-fA-F]{32}$",
      "type": "string",
      "description": "The SID of the application we should use to handle calls to the new phone number. If a `voice_application_sid` is present, we ignore all of the voice urls and use only those set on the application. Setting a `voice_application_sid` will automatically delete your `trunk_sid` and vice versa."
    },
    "VoiceCallerIdLookup": {
      "type": "boolean",
      "description": "Whether to lookup the caller's name from the CNAM database and post it to your app. Can be: `true` or `false` and defaults to `false`."
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
      "description": "The HTTP method that we should use to call `voice_fallback_url`. Can be: `GET` or `POST` and defaults to `POST`.",
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
      "description": "The HTTP method that we should use to call `voice_url`. Can be: `GET` or `POST` and defaults to `POST`.",
      "format": "http-method"
    },
    "VoiceReceiveMode": {
      "enum": [
        "voice",
        "fax"
      ],
      "type": "string"
    },
    "VoiceUrl": {
      "type": "string",
      "description": "The URL that we should call to answer a call to the new phone number. The `voice_url` will not be called if a `voice_application_sid` or a `trunk_sid` is set.",
      "format": "uri"
    }
  }
}</pre></section><section  class="responses"><h2>Responses</h2><ul  class="responses"><li  class="response"><span  class="statusLine">201</span> <span  class="statusDescription">Created</span></li></ul></section></article></body></html>