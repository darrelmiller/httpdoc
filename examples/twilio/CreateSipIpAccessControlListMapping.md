<!DOCTYPE html><html><head><title></title><link rel="stylesheet" href="../OpenApi.css"/><meta charset="utf-8"/><meta name="viewport" content="width=device-width, initial-scale=1"/></head><body><article><section  class="requestOverview"><h1  class="requestSummary">CreateSipIpAccessControlListMapping</h1><p  class="requestDescription">Create a new IpAccessControlListMapping resource.</p></section><section  class="http"><h3>HTTP Request</h3><pre  class="httpExample"><span  class="requestLine">POST</span> <span  class="httpTarget">\2010-04-01\Accounts\{AccountSid}\SIP\Domains\{DomainSid}\IpAccessControlListMappings.json</span> <span  class="httpVersion">HTTP/1.1</span>
<span  class="headerLine">host</span>: <span  class="headerValue">api.twilio.com:443</span>
<span  class="headerLine">accept</span>: <span  class="headerValue">application/json</span>
<span  class="headerLine">content-type</span>: <span  class="headerValue">application/x-www-form-urlencoded</span>
</pre></section><dl  class="parameters"><h3>Parameters</h3><dt  class="parameter"><span  class="parameterName">AccountSid</span> [ in: <span  class="parameterLocation">path</span> type: <span  class="parameterType">string</span> ]</dt><dd  class="parameter"><span  class="parameterDescription">The unique id of the Account that is responsible for this resource.</span> <span  class="parameterRequired">required</span></dd><dt  class="parameter"><span  class="parameterName">DomainSid</span> [ in: <span  class="parameterLocation">path</span> type: <span  class="parameterType">string</span> ]</dt><dd  class="parameter"><span  class="parameterDescription">A 34 character string that uniquely identifies the SIP domain.</span> <span  class="parameterRequired">required</span></dd></dl><section  class="requestContent"><h3>Request Body Schema</h3><pre  class="schema">{
  "title": "CreateSipIpAccessControlListMappingRequest",
  "required": [
    "IpAccessControlListSid"
  ],
  "type": "object",
  "properties": {
    "IpAccessControlListSid": {
      "maxLength": 34,
      "minLength": 34,
      "pattern": "^AL[0-9a-fA-F]{32}$",
      "type": "string",
      "description": "The unique id of the IP access control list to map to the SIP domain."
    }
  }
}</pre></section><section  class="responses"><h2>Responses</h2><ul  class="responses"><li  class="response"><span  class="statusLine">201</span> <span  class="statusDescription">Created</span></li></ul></section></article></body></html>