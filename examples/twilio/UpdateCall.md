<!DOCTYPE html><html><head><title></title><link rel="stylesheet" href="../OpenApi.css"/><meta charset="utf-8"/><meta name="viewport" content="width=device-width, initial-scale=1"/></head><body><article><section  class="requestOverview"><h1  class="requestSummary">UpdateCall</h1><p  class="requestDescription">Initiates a call redirect or terminates a call</p></section><section  class="http"><h3>HTTP Request</h3><pre  class="httpExample"><span  class="requestLine">POST</span> <span  class="httpTarget">\2010-04-01\Accounts\{AccountSid}\Calls\{Sid}.json</span> <span  class="httpVersion">HTTP/1.1</span>
<span  class="headerLine">host</span>: <span  class="headerValue">api.twilio.com:443</span>
<span  class="headerLine">accept</span>: <span  class="headerValue">application/json</span>
<span  class="headerLine">content-type</span>: <span  class="headerValue">application/x-www-form-urlencoded</span>
</pre></section><dl  class="parameters"><h3>Parameters</h3><dt  class="parameter"><span  class="parameterName">AccountSid</span> [ in: <span  class="parameterLocation">path</span> type: <span  class="parameterType">string</span> ]</dt><dd  class="parameter"><span  class="parameterDescription">The SID of the [Account](https://www.twilio.com/docs/iam/api/account) that created the Call resource(s) to update.</span> <span  class="parameterRequired">required</span></dd><dt  class="parameter"><span  class="parameterName">Sid</span> [ in: <span  class="parameterLocation">path</span> type: <span  class="parameterType">string</span> ]</dt><dd  class="parameter"><span  class="parameterDescription">The Twilio-provided string that uniquely identifies the Call resource to update</span> <span  class="parameterRequired">required</span></dd></dl><section  class="requestContent"><h3>Request Body Schema</h3><pre  class="schema">{
  "title": "UpdateCallRequest",
  "type": "object",
  "properties": {
    "FallbackMethod": {
      "enum": [
        "HEAD",
        "GET",
        "POST",
        "PATCH",
        "PUT",
        "DELETE"
      ],
      "type": "string",
      "description": "The HTTP method that we should use to request the `fallback_url`. Can be: `GET` or `POST` and the default is `POST`. If an `application_sid` parameter is present, this parameter is ignored.",
      "format": "http-method"
    },
    "FallbackUrl": {
      "type": "string",
      "description": "The URL that we call using the `fallback_method` if an error occurs when requesting or executing the TwiML at `url`. If an `application_sid` parameter is present, this parameter is ignored.",
      "format": "uri"
    },
    "Method": {
      "enum": [
        "HEAD",
        "GET",
        "POST",
        "PATCH",
        "PUT",
        "DELETE"
      ],
      "type": "string",
      "description": "The HTTP method we should use when calling the `url`. Can be: `GET` or `POST` and the default is `POST`. If an `application_sid` parameter is present, this parameter is ignored.",
      "format": "http-method"
    },
    "Status": {
      "enum": [
        "canceled",
        "completed"
      ],
      "type": "string"
    },
    "StatusCallback": {
      "type": "string",
      "description": "The URL we should call using the `status_callback_method` to send status information to your application. If no `status_callback_event` is specified, we will send the `completed` status. If an `application_sid` parameter is present, this parameter is ignored. URLs must contain a valid hostname (underscores are not permitted).",
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
      "description": "The HTTP method we should use when requesting the `status_callback` URL. Can be: `GET` or `POST` and the default is `POST`. If an `application_sid` parameter is present, this parameter is ignored.",
      "format": "http-method"
    },
    "TimeLimit": {
      "type": "integer",
      "description": "The maximum duration of the call in seconds. Constraints depend on account and configuration."
    },
    "Twiml": {
      "type": "string",
      "description": "TwiML instructions for the call Twilio will use without fetching Twiml from url. Twiml and url parameters are mutually exclusive",
      "format": "twiml"
    },
    "Url": {
      "type": "string",
      "description": "The absolute URL that returns the TwiML instructions for the call. We will call this URL using the `method` when the call connects. For more information, see the [Url Parameter](https://www.twilio.com/docs/voice/make-calls#specify-a-url-parameter) section in [Making Calls](https://www.twilio.com/docs/voice/make-calls).",
      "format": "uri"
    }
  }
}</pre></section><section  class="responses"><h2>Responses</h2><ul  class="responses"><li  class="response"><span  class="statusLine">200</span> <span  class="statusDescription">OK</span></li></ul></section></article></body></html>