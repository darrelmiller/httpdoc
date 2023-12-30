<!DOCTYPE html><html><head><title></title><link rel="stylesheet" href="../OpenApi.css"/><meta charset="utf-8"/><meta name="viewport" content="width=device-width, initial-scale=1"/></head><body><article><section  class="requestOverview"><h1  class="requestSummary">UpdateSipDomain</h1><p  class="requestDescription">Update the attributes of a domain</p></section><section  class="http"><h3>HTTP Request</h3><pre  class="httpExample"><span  class="requestLine">POST</span> <span  class="httpTarget">\2010-04-01\Accounts\{AccountSid}\SIP\Domains\{Sid}.json</span> <span  class="httpVersion">HTTP/1.1</span>
<span  class="headerLine">host</span>: <span  class="headerValue">api.twilio.com:443</span>
<span  class="headerLine">accept</span>: <span  class="headerValue">application/json</span>
<span  class="headerLine">content-type</span>: <span  class="headerValue">application/x-www-form-urlencoded</span>
</pre></section><dl  class="parameters"><h3>Parameters</h3><dt  class="parameter"><span  class="parameterName">AccountSid</span> [ in: <span  class="parameterLocation">path</span> type: <span  class="parameterType">string</span> ]</dt><dd  class="parameter"><span  class="parameterDescription">The SID of the [Account](https://www.twilio.com/docs/iam/api/account) that created the SipDomain resource to update.</span> <span  class="parameterRequired">required</span></dd><dt  class="parameter"><span  class="parameterName">Sid</span> [ in: <span  class="parameterLocation">path</span> type: <span  class="parameterType">string</span> ]</dt><dd  class="parameter"><span  class="parameterDescription">The Twilio-provided string that uniquely identifies the SipDomain resource to update.</span> <span  class="parameterRequired">required</span></dd></dl><section  class="requestContent"><h3>Request Body Schema</h3><pre  class="schema">{
  "title": "UpdateSipDomainRequest",
  "type": "object",
  "properties": {
    "ByocTrunkSid": {
      "maxLength": 34,
      "minLength": 34,
      "pattern": "^BY[0-9a-fA-F]{32}$",
      "type": "string",
      "description": "The SID of the BYOC Trunk(Bring Your Own Carrier) resource that the Sip Domain will be associated with."
    },
    "DomainName": {
      "type": "string",
      "description": "The unique address you reserve on Twilio to which you route your SIP traffic. Domain names can contain letters, digits, and \"-\" and must end with `sip.twilio.com`."
    },
    "EmergencyCallerSid": {
      "maxLength": 34,
      "minLength": 34,
      "pattern": "^PN[0-9a-fA-F]{32}$",
      "type": "string",
      "description": "Whether an emergency caller sid is configured for the domain. If present, this phone number will be used as the callback for the emergency call."
    },
    "EmergencyCallingEnabled": {
      "type": "boolean",
      "description": "Whether emergency calling is enabled for the domain. If enabled, allows emergency calls on the domain from phone numbers with validated addresses."
    },
    "FriendlyName": {
      "type": "string",
      "description": "A descriptive string that you created to describe the resource. It can be up to 64 characters long."
    },
    "Secure": {
      "type": "boolean",
      "description": "Whether secure SIP is enabled for the domain. If enabled, TLS will be enforced and SRTP will be negotiated on all incoming calls to this sip domain."
    },
    "SipRegistration": {
      "type": "boolean",
      "description": "Whether to allow SIP Endpoints to register with the domain to receive calls. Can be `true` or `false`. `true` allows SIP Endpoints to register with the domain to receive calls, `false` does not."
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
      "description": "The URL that we should call when an error occurs while retrieving or executing the TwiML requested by `voice_url`.",
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
      "description": "The HTTP method we should use to call `voice_url`",
      "format": "http-method"
    },
    "VoiceStatusCallbackMethod": {
      "enum": [
        "HEAD",
        "GET",
        "POST",
        "PATCH",
        "PUT",
        "DELETE"
      ],
      "type": "string",
      "description": "The HTTP method we should use to call `voice_status_callback_url`. Can be: `GET` or `POST`.",
      "format": "http-method"
    },
    "VoiceStatusCallbackUrl": {
      "type": "string",
      "description": "The URL that we should call to pass status parameters (such as call ended) to your application.",
      "format": "uri"
    },
    "VoiceUrl": {
      "type": "string",
      "description": "The URL we should call when the domain receives a call.",
      "format": "uri"
    }
  }
}</pre></section><section  class="responses"><h2>Responses</h2><ul  class="responses"><li  class="response"><span  class="statusLine">200</span> <span  class="statusDescription">OK</span></li></ul></section></article></body></html>