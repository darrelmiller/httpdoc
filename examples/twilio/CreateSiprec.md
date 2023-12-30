<!DOCTYPE html><html><head><title></title><link rel="stylesheet" href="../OpenApi.css"/><meta charset="utf-8"/><meta name="viewport" content="width=device-width, initial-scale=1"/></head><body><article><section  class="requestOverview"><h1  class="requestSummary">CreateSiprec</h1><p  class="requestDescription">Create a Siprec</p></section><section  class="http"><h3>HTTP Request</h3><pre  class="httpExample"><span  class="requestLine">POST</span> <span  class="httpTarget">\2010-04-01\Accounts\{AccountSid}\Calls\{CallSid}\Siprec.json</span> <span  class="httpVersion">HTTP/1.1</span>
<span  class="headerLine">host</span>: <span  class="headerValue">api.twilio.com:443</span>
<span  class="headerLine">accept</span>: <span  class="headerValue">application/json</span>
<span  class="headerLine">content-type</span>: <span  class="headerValue">application/x-www-form-urlencoded</span>
</pre></section><dl  class="parameters"><h3>Parameters</h3><dt  class="parameter"><span  class="parameterName">AccountSid</span> [ in: <span  class="parameterLocation">path</span> type: <span  class="parameterType">string</span> ]</dt><dd  class="parameter"><span  class="parameterDescription">The SID of the [Account](https://www.twilio.com/docs/iam/api/account) that created this Siprec resource.</span> <span  class="parameterRequired">required</span></dd><dt  class="parameter"><span  class="parameterName">CallSid</span> [ in: <span  class="parameterLocation">path</span> type: <span  class="parameterType">string</span> ]</dt><dd  class="parameter"><span  class="parameterDescription">The SID of the [Call](https://www.twilio.com/docs/voice/api/call-resource) the Siprec resource is associated with.</span> <span  class="parameterRequired">required</span></dd></dl><section  class="requestContent"><h3>Request Body Schema</h3><pre  class="schema">{
  "title": "CreateSiprecRequest",
  "type": "object",
  "properties": {
    "ConnectorName": {
      "type": "string",
      "description": "Unique name used when configuring the connector via Marketplace Add-on."
    },
    "Name": {
      "type": "string",
      "description": "The user-specified name of this Siprec, if one was given when the Siprec was created. This may be used to stop the Siprec."
    },
    "Parameter1.Name": {
      "type": "string",
      "description": "Parameter name"
    },
    "Parameter1.Value": {
      "type": "string",
      "description": "Parameter value"
    },
    "Parameter10.Name": {
      "type": "string",
      "description": "Parameter name"
    },
    "Parameter10.Value": {
      "type": "string",
      "description": "Parameter value"
    },
    "Parameter11.Name": {
      "type": "string",
      "description": "Parameter name"
    },
    "Parameter11.Value": {
      "type": "string",
      "description": "Parameter value"
    },
    "Parameter12.Name": {
      "type": "string",
      "description": "Parameter name"
    },
    "Parameter12.Value": {
      "type": "string",
      "description": "Parameter value"
    },
    "Parameter13.Name": {
      "type": "string",
      "description": "Parameter name"
    },
    "Parameter13.Value": {
      "type": "string",
      "description": "Parameter value"
    },
    "Parameter14.Name": {
      "type": "string",
      "description": "Parameter name"
    },
    "Parameter14.Value": {
      "type": "string",
      "description": "Parameter value"
    },
    "Parameter15.Name": {
      "type": "string",
      "description": "Parameter name"
    },
    "Parameter15.Value": {
      "type": "string",
      "description": "Parameter value"
    },
    "Parameter16.Name": {
      "type": "string",
      "description": "Parameter name"
    },
    "Parameter16.Value": {
      "type": "string",
      "description": "Parameter value"
    },
    "Parameter17.Name": {
      "type": "string",
      "description": "Parameter name"
    },
    "Parameter17.Value": {
      "type": "string",
      "description": "Parameter value"
    },
    "Parameter18.Name": {
      "type": "string",
      "description": "Parameter name"
    },
    "Parameter18.Value": {
      "type": "string",
      "description": "Parameter value"
    },
    "Parameter19.Name": {
      "type": "string",
      "description": "Parameter name"
    },
    "Parameter19.Value": {
      "type": "string",
      "description": "Parameter value"
    },
    "Parameter2.Name": {
      "type": "string",
      "description": "Parameter name"
    },
    "Parameter2.Value": {
      "type": "string",
      "description": "Parameter value"
    },
    "Parameter20.Name": {
      "type": "string",
      "description": "Parameter name"
    },
    "Parameter20.Value": {
      "type": "string",
      "description": "Parameter value"
    },
    "Parameter21.Name": {
      "type": "string",
      "description": "Parameter name"
    },
    "Parameter21.Value": {
      "type": "string",
      "description": "Parameter value"
    },
    "Parameter22.Name": {
      "type": "string",
      "description": "Parameter name"
    },
    "Parameter22.Value": {
      "type": "string",
      "description": "Parameter value"
    },
    "Parameter23.Name": {
      "type": "string",
      "description": "Parameter name"
    },
    "Parameter23.Value": {
      "type": "string",
      "description": "Parameter value"
    },
    "Parameter24.Name": {
      "type": "string",
      "description": "Parameter name"
    },
    "Parameter24.Value": {
      "type": "string",
      "description": "Parameter value"
    },
    "Parameter25.Name": {
      "type": "string",
      "description": "Parameter name"
    },
    "Parameter25.Value": {
      "type": "string",
      "description": "Parameter value"
    },
    "Parameter26.Name": {
      "type": "string",
      "description": "Parameter name"
    },
    "Parameter26.Value": {
      "type": "string",
      "description": "Parameter value"
    },
    "Parameter27.Name": {
      "type": "string",
      "description": "Parameter name"
    },
    "Parameter27.Value": {
      "type": "string",
      "description": "Parameter value"
    },
    "Parameter28.Name": {
      "type": "string",
      "description": "Parameter name"
    },
    "Parameter28.Value": {
      "type": "string",
      "description": "Parameter value"
    },
    "Parameter29.Name": {
      "type": "string",
      "description": "Parameter name"
    },
    "Parameter29.Value": {
      "type": "string",
      "description": "Parameter value"
    },
    "Parameter3.Name": {
      "type": "string",
      "description": "Parameter name"
    },
    "Parameter3.Value": {
      "type": "string",
      "description": "Parameter value"
    },
    "Parameter30.Name": {
      "type": "string",
      "description": "Parameter name"
    },
    "Parameter30.Value": {
      "type": "string",
      "description": "Parameter value"
    },
    "Parameter31.Name": {
      "type": "string",
      "description": "Parameter name"
    },
    "Parameter31.Value": {
      "type": "string",
      "description": "Parameter value"
    },
    "Parameter32.Name": {
      "type": "string",
      "description": "Parameter name"
    },
    "Parameter32.Value": {
      "type": "string",
      "description": "Parameter value"
    },
    "Parameter33.Name": {
      "type": "string",
      "description": "Parameter name"
    },
    "Parameter33.Value": {
      "type": "string",
      "description": "Parameter value"
    },
    "Parameter34.Name": {
      "type": "string",
      "description": "Parameter name"
    },
    "Parameter34.Value": {
      "type": "string",
      "description": "Parameter value"
    },
    "Parameter35.Name": {
      "type": "string",
      "description": "Parameter name"
    },
    "Parameter35.Value": {
      "type": "string",
      "description": "Parameter value"
    },
    "Parameter36.Name": {
      "type": "string",
      "description": "Parameter name"
    },
    "Parameter36.Value": {
      "type": "string",
      "description": "Parameter value"
    },
    "Parameter37.Name": {
      "type": "string",
      "description": "Parameter name"
    },
    "Parameter37.Value": {
      "type": "string",
      "description": "Parameter value"
    },
    "Parameter38.Name": {
      "type": "string",
      "description": "Parameter name"
    },
    "Parameter38.Value": {
      "type": "string",
      "description": "Parameter value"
    },
    "Parameter39.Name": {
      "type": "string",
      "description": "Parameter name"
    },
    "Parameter39.Value": {
      "type": "string",
      "description": "Parameter value"
    },
    "Parameter4.Name": {
      "type": "string",
      "description": "Parameter name"
    },
    "Parameter4.Value": {
      "type": "string",
      "description": "Parameter value"
    },
    "Parameter40.Name": {
      "type": "string",
      "description": "Parameter name"
    },
    "Parameter40.Value": {
      "type": "string",
      "description": "Parameter value"
    },
    "Parameter41.Name": {
      "type": "string",
      "description": "Parameter name"
    },
    "Parameter41.Value": {
      "type": "string",
      "description": "Parameter value"
    },
    "Parameter42.Name": {
      "type": "string",
      "description": "Parameter name"
    },
    "Parameter42.Value": {
      "type": "string",
      "description": "Parameter value"
    },
    "Parameter43.Name": {
      "type": "string",
      "description": "Parameter name"
    },
    "Parameter43.Value": {
      "type": "string",
      "description": "Parameter value"
    },
    "Parameter44.Name": {
      "type": "string",
      "description": "Parameter name"
    },
    "Parameter44.Value": {
      "type": "string",
      "description": "Parameter value"
    },
    "Parameter45.Name": {
      "type": "string",
      "description": "Parameter name"
    },
    "Parameter45.Value": {
      "type": "string",
      "description": "Parameter value"
    },
    "Parameter46.Name": {
      "type": "string",
      "description": "Parameter name"
    },
    "Parameter46.Value": {
      "type": "string",
      "description": "Parameter value"
    },
    "Parameter47.Name": {
      "type": "string",
      "description": "Parameter name"
    },
    "Parameter47.Value": {
      "type": "string",
      "description": "Parameter value"
    },
    "Parameter48.Name": {
      "type": "string",
      "description": "Parameter name"
    },
    "Parameter48.Value": {
      "type": "string",
      "description": "Parameter value"
    },
    "Parameter49.Name": {
      "type": "string",
      "description": "Parameter name"
    },
    "Parameter49.Value": {
      "type": "string",
      "description": "Parameter value"
    },
    "Parameter5.Name": {
      "type": "string",
      "description": "Parameter name"
    },
    "Parameter5.Value": {
      "type": "string",
      "description": "Parameter value"
    },
    "Parameter50.Name": {
      "type": "string",
      "description": "Parameter name"
    },
    "Parameter50.Value": {
      "type": "string",
      "description": "Parameter value"
    },
    "Parameter51.Name": {
      "type": "string",
      "description": "Parameter name"
    },
    "Parameter51.Value": {
      "type": "string",
      "description": "Parameter value"
    },
    "Parameter52.Name": {
      "type": "string",
      "description": "Parameter name"
    },
    "Parameter52.Value": {
      "type": "string",
      "description": "Parameter value"
    },
    "Parameter53.Name": {
      "type": "string",
      "description": "Parameter name"
    },
    "Parameter53.Value": {
      "type": "string",
      "description": "Parameter value"
    },
    "Parameter54.Name": {
      "type": "string",
      "description": "Parameter name"
    },
    "Parameter54.Value": {
      "type": "string",
      "description": "Parameter value"
    },
    "Parameter55.Name": {
      "type": "string",
      "description": "Parameter name"
    },
    "Parameter55.Value": {
      "type": "string",
      "description": "Parameter value"
    },
    "Parameter56.Name": {
      "type": "string",
      "description": "Parameter name"
    },
    "Parameter56.Value": {
      "type": "string",
      "description": "Parameter value"
    },
    "Parameter57.Name": {
      "type": "string",
      "description": "Parameter name"
    },
    "Parameter57.Value": {
      "type": "string",
      "description": "Parameter value"
    },
    "Parameter58.Name": {
      "type": "string",
      "description": "Parameter name"
    },
    "Parameter58.Value": {
      "type": "string",
      "description": "Parameter value"
    },
    "Parameter59.Name": {
      "type": "string",
      "description": "Parameter name"
    },
    "Parameter59.Value": {
      "type": "string",
      "description": "Parameter value"
    },
    "Parameter6.Name": {
      "type": "string",
      "description": "Parameter name"
    },
    "Parameter6.Value": {
      "type": "string",
      "description": "Parameter value"
    },
    "Parameter60.Name": {
      "type": "string",
      "description": "Parameter name"
    },
    "Parameter60.Value": {
      "type": "string",
      "description": "Parameter value"
    },
    "Parameter61.Name": {
      "type": "string",
      "description": "Parameter name"
    },
    "Parameter61.Value": {
      "type": "string",
      "description": "Parameter value"
    },
    "Parameter62.Name": {
      "type": "string",
      "description": "Parameter name"
    },
    "Parameter62.Value": {
      "type": "string",
      "description": "Parameter value"
    },
    "Parameter63.Name": {
      "type": "string",
      "description": "Parameter name"
    },
    "Parameter63.Value": {
      "type": "string",
      "description": "Parameter value"
    },
    "Parameter64.Name": {
      "type": "string",
      "description": "Parameter name"
    },
    "Parameter64.Value": {
      "type": "string",
      "description": "Parameter value"
    },
    "Parameter65.Name": {
      "type": "string",
      "description": "Parameter name"
    },
    "Parameter65.Value": {
      "type": "string",
      "description": "Parameter value"
    },
    "Parameter66.Name": {
      "type": "string",
      "description": "Parameter name"
    },
    "Parameter66.Value": {
      "type": "string",
      "description": "Parameter value"
    },
    "Parameter67.Name": {
      "type": "string",
      "description": "Parameter name"
    },
    "Parameter67.Value": {
      "type": "string",
      "description": "Parameter value"
    },
    "Parameter68.Name": {
      "type": "string",
      "description": "Parameter name"
    },
    "Parameter68.Value": {
      "type": "string",
      "description": "Parameter value"
    },
    "Parameter69.Name": {
      "type": "string",
      "description": "Parameter name"
    },
    "Parameter69.Value": {
      "type": "string",
      "description": "Parameter value"
    },
    "Parameter7.Name": {
      "type": "string",
      "description": "Parameter name"
    },
    "Parameter7.Value": {
      "type": "string",
      "description": "Parameter value"
    },
    "Parameter70.Name": {
      "type": "string",
      "description": "Parameter name"
    },
    "Parameter70.Value": {
      "type": "string",
      "description": "Parameter value"
    },
    "Parameter71.Name": {
      "type": "string",
      "description": "Parameter name"
    },
    "Parameter71.Value": {
      "type": "string",
      "description": "Parameter value"
    },
    "Parameter72.Name": {
      "type": "string",
      "description": "Parameter name"
    },
    "Parameter72.Value": {
      "type": "string",
      "description": "Parameter value"
    },
    "Parameter73.Name": {
      "type": "string",
      "description": "Parameter name"
    },
    "Parameter73.Value": {
      "type": "string",
      "description": "Parameter value"
    },
    "Parameter74.Name": {
      "type": "string",
      "description": "Parameter name"
    },
    "Parameter74.Value": {
      "type": "string",
      "description": "Parameter value"
    },
    "Parameter75.Name": {
      "type": "string",
      "description": "Parameter name"
    },
    "Parameter75.Value": {
      "type": "string",
      "description": "Parameter value"
    },
    "Parameter76.Name": {
      "type": "string",
      "description": "Parameter name"
    },
    "Parameter76.Value": {
      "type": "string",
      "description": "Parameter value"
    },
    "Parameter77.Name": {
      "type": "string",
      "description": "Parameter name"
    },
    "Parameter77.Value": {
      "type": "string",
      "description": "Parameter value"
    },
    "Parameter78.Name": {
      "type": "string",
      "description": "Parameter name"
    },
    "Parameter78.Value": {
      "type": "string",
      "description": "Parameter value"
    },
    "Parameter79.Name": {
      "type": "string",
      "description": "Parameter name"
    },
    "Parameter79.Value": {
      "type": "string",
      "description": "Parameter value"
    },
    "Parameter8.Name": {
      "type": "string",
      "description": "Parameter name"
    },
    "Parameter8.Value": {
      "type": "string",
      "description": "Parameter value"
    },
    "Parameter80.Name": {
      "type": "string",
      "description": "Parameter name"
    },
    "Parameter80.Value": {
      "type": "string",
      "description": "Parameter value"
    },
    "Parameter81.Name": {
      "type": "string",
      "description": "Parameter name"
    },
    "Parameter81.Value": {
      "type": "string",
      "description": "Parameter value"
    },
    "Parameter82.Name": {
      "type": "string",
      "description": "Parameter name"
    },
    "Parameter82.Value": {
      "type": "string",
      "description": "Parameter value"
    },
    "Parameter83.Name": {
      "type": "string",
      "description": "Parameter name"
    },
    "Parameter83.Value": {
      "type": "string",
      "description": "Parameter value"
    },
    "Parameter84.Name": {
      "type": "string",
      "description": "Parameter name"
    },
    "Parameter84.Value": {
      "type": "string",
      "description": "Parameter value"
    },
    "Parameter85.Name": {
      "type": "string",
      "description": "Parameter name"
    },
    "Parameter85.Value": {
      "type": "string",
      "description": "Parameter value"
    },
    "Parameter86.Name": {
      "type": "string",
      "description": "Parameter name"
    },
    "Parameter86.Value": {
      "type": "string",
      "description": "Parameter value"
    },
    "Parameter87.Name": {
      "type": "string",
      "description": "Parameter name"
    },
    "Parameter87.Value": {
      "type": "string",
      "description": "Parameter value"
    },
    "Parameter88.Name": {
      "type": "string",
      "description": "Parameter name"
    },
    "Parameter88.Value": {
      "type": "string",
      "description": "Parameter value"
    },
    "Parameter89.Name": {
      "type": "string",
      "description": "Parameter name"
    },
    "Parameter89.Value": {
      "type": "string",
      "description": "Parameter value"
    },
    "Parameter9.Name": {
      "type": "string",
      "description": "Parameter name"
    },
    "Parameter9.Value": {
      "type": "string",
      "description": "Parameter value"
    },
    "Parameter90.Name": {
      "type": "string",
      "description": "Parameter name"
    },
    "Parameter90.Value": {
      "type": "string",
      "description": "Parameter value"
    },
    "Parameter91.Name": {
      "type": "string",
      "description": "Parameter name"
    },
    "Parameter91.Value": {
      "type": "string",
      "description": "Parameter value"
    },
    "Parameter92.Name": {
      "type": "string",
      "description": "Parameter name"
    },
    "Parameter92.Value": {
      "type": "string",
      "description": "Parameter value"
    },
    "Parameter93.Name": {
      "type": "string",
      "description": "Parameter name"
    },
    "Parameter93.Value": {
      "type": "string",
      "description": "Parameter value"
    },
    "Parameter94.Name": {
      "type": "string",
      "description": "Parameter name"
    },
    "Parameter94.Value": {
      "type": "string",
      "description": "Parameter value"
    },
    "Parameter95.Name": {
      "type": "string",
      "description": "Parameter name"
    },
    "Parameter95.Value": {
      "type": "string",
      "description": "Parameter value"
    },
    "Parameter96.Name": {
      "type": "string",
      "description": "Parameter name"
    },
    "Parameter96.Value": {
      "type": "string",
      "description": "Parameter value"
    },
    "Parameter97.Name": {
      "type": "string",
      "description": "Parameter name"
    },
    "Parameter97.Value": {
      "type": "string",
      "description": "Parameter value"
    },
    "Parameter98.Name": {
      "type": "string",
      "description": "Parameter name"
    },
    "Parameter98.Value": {
      "type": "string",
      "description": "Parameter value"
    },
    "Parameter99.Name": {
      "type": "string",
      "description": "Parameter name"
    },
    "Parameter99.Value": {
      "type": "string",
      "description": "Parameter value"
    },
    "StatusCallback": {
      "type": "string",
      "description": "Absolute URL of the status callback.",
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
      "description": "The http method for the status_callback (one of GET, POST).",
      "format": "http-method"
    },
    "Track": {
      "enum": [
        "inbound_track",
        "outbound_track",
        "both_tracks"
      ],
      "type": "string"
    }
  }
}</pre></section><section  class="responses"><h2>Responses</h2><ul  class="responses"><li  class="response"><span  class="statusLine">201</span> <span  class="statusDescription">Created</span></li></ul></section></article></body></html>