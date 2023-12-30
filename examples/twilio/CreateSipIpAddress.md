<!DOCTYPE html><html><head><title></title><link rel="stylesheet" href="../OpenApi.css"/><meta charset="utf-8"/><meta name="viewport" content="width=device-width, initial-scale=1"/></head><body><article><section  class="requestOverview"><h1  class="requestSummary">CreateSipIpAddress</h1><p  class="requestDescription">Create a new IpAddress resource.</p></section><section  class="http"><h3>HTTP Request</h3><pre  class="httpExample"><span  class="requestLine">POST</span> <span  class="httpTarget">\2010-04-01\Accounts\{AccountSid}\SIP\IpAccessControlLists\{IpAccessControlListSid}\IpAddresses.json</span> <span  class="httpVersion">HTTP/1.1</span>
<span  class="headerLine">host</span>: <span  class="headerValue">api.twilio.com:443</span>
<span  class="headerLine">accept</span>: <span  class="headerValue">application/json</span>
<span  class="headerLine">content-type</span>: <span  class="headerValue">application/x-www-form-urlencoded</span>
</pre></section><dl  class="parameters"><h3>Parameters</h3><dt  class="parameter"><span  class="parameterName">AccountSid</span> [ in: <span  class="parameterLocation">path</span> type: <span  class="parameterType">string</span> ]</dt><dd  class="parameter"><span  class="parameterDescription">The unique id of the [Account](https://www.twilio.com/docs/iam/api/account) responsible for this resource.</span> <span  class="parameterRequired">required</span></dd><dt  class="parameter"><span  class="parameterName">IpAccessControlListSid</span> [ in: <span  class="parameterLocation">path</span> type: <span  class="parameterType">string</span> ]</dt><dd  class="parameter"><span  class="parameterDescription">The IpAccessControlList Sid with which to associate the created IpAddress resource.</span> <span  class="parameterRequired">required</span></dd></dl><section  class="requestContent"><h3>Request Body Schema</h3><pre  class="schema">{
  "title": "CreateSipIpAddressRequest",
  "required": [
    "FriendlyName",
    "IpAddress"
  ],
  "type": "object",
  "properties": {
    "CidrPrefixLength": {
      "type": "integer",
      "description": "An integer representing the length of the CIDR prefix to use with this IP address when accepting traffic. By default the entire IP address is used."
    },
    "FriendlyName": {
      "type": "string",
      "description": "A human readable descriptive text for this resource, up to 255 characters long."
    },
    "IpAddress": {
      "type": "string",
      "description": "An IP address in dotted decimal notation from which you want to accept traffic. Any SIP requests from this IP address will be allowed by Twilio. IPv4 only supported today."
    }
  }
}</pre></section><section  class="responses"><h2>Responses</h2><ul  class="responses"><li  class="response"><span  class="statusLine">201</span> <span  class="statusDescription">Created</span></li></ul></section></article></body></html>