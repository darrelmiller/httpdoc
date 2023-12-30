<!DOCTYPE html><html><head><title></title><link rel="stylesheet" href="../OpenApi.css"/><meta charset="utf-8"/><meta name="viewport" content="width=device-width, initial-scale=1"/></head><body><article><section  class="requestOverview"><h1  class="requestSummary">CreateAddress</h1><p  class="requestDescription"></p></section><section  class="http"><h3>HTTP Request</h3><pre  class="httpExample"><span  class="requestLine">POST</span> <span  class="httpTarget">\2010-04-01\Accounts\{AccountSid}\Addresses.json</span> <span  class="httpVersion">HTTP/1.1</span>
<span  class="headerLine">host</span>: <span  class="headerValue">api.twilio.com:443</span>
<span  class="headerLine">accept</span>: <span  class="headerValue">application/json</span>
<span  class="headerLine">content-type</span>: <span  class="headerValue">application/x-www-form-urlencoded</span>
</pre></section><dl  class="parameters"><h3>Parameters</h3><dt  class="parameter"><span  class="parameterName">AccountSid</span> [ in: <span  class="parameterLocation">path</span> type: <span  class="parameterType">string</span> ]</dt><dd  class="parameter"><span  class="parameterDescription">The SID of the [Account](https://www.twilio.com/docs/iam/api/account) that will be responsible for the new Address resource.</span> <span  class="parameterRequired">required</span></dd></dl><section  class="requestContent"><h3>Request Body Schema</h3><pre  class="schema">{
  "title": "CreateAddressRequest",
  "required": [
    "CustomerName",
    "Street",
    "City",
    "Region",
    "PostalCode",
    "IsoCountry"
  ],
  "type": "object",
  "properties": {
    "AutoCorrectAddress": {
      "type": "boolean",
      "description": "Whether we should automatically correct the address. Can be: `true` or `false` and the default is `true`. If empty or `true`, we will correct the address you provide if necessary. If `false`, we won't alter the address you provide."
    },
    "City": {
      "type": "string",
      "description": "The city of the new address."
    },
    "CustomerName": {
      "type": "string",
      "description": "The name to associate with the new address."
    },
    "EmergencyEnabled": {
      "type": "boolean",
      "description": "Whether to enable emergency calling on the new address. Can be: `true` or `false`."
    },
    "FriendlyName": {
      "type": "string",
      "description": "A descriptive string that you create to describe the new address. It can be up to 64 characters long."
    },
    "IsoCountry": {
      "type": "string",
      "description": "The ISO country code of the new address.",
      "format": "iso-country-code"
    },
    "PostalCode": {
      "type": "string",
      "description": "The postal code of the new address."
    },
    "Region": {
      "type": "string",
      "description": "The state or region of the new address."
    },
    "Street": {
      "type": "string",
      "description": "The number and street address of the new address."
    },
    "StreetSecondary": {
      "type": "string",
      "description": "The additional number and street address of the address."
    }
  }
}</pre></section><section  class="responses"><h2>Responses</h2><ul  class="responses"><li  class="response"><span  class="statusLine">201</span> <span  class="statusDescription">Created</span></li></ul></section></article></body></html>