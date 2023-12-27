<!DOCTYPE html><html><head><title>Get fine-grained status updates for a fine-tune job.
</title><link rel="stylesheet" href="../OpenApi.css"/><meta charset="utf-8"/><meta name="viewport" content="width=device-width, initial-scale=1"/></head><body><article><section  class="requestOverview"><h1  class="requestSummary">Get fine-grained status updates for a fine-tune job.
</h1><p  class="requestDescription"></p></section><section  class="http"><h3>HTTP Request</h3><pre  class="httpExample"><span  class="requestLine">GET</span> <span  class="httpTarget">+{baseUrl}\fine-tunes\{fine_tune_id}\events{?stream*}</span> <span  class="httpVersion">HTTP/1.1</span>
<span  class="headerLine">host</span>: <span  class="headerValue">example.org:443</span>
<span  class="headerLine">accept</span>: <span  class="headerValue">application/json</span>
</pre></section><dl  class="parameters"><h3>Parameters</h3><dt  class="parameter"><span  class="parameterName">fine_tune_id</span> [ in: <span  class="parameterLocation">Path</span> type: <span  class="parameterType">string</span> ]</dt><dd  class="parameter"><span  class="parameterDescription">The ID of the fine-tune job to get events for.
</span> <span  class="parameterRequired">required</span></dd><dt  class="parameter"><span  class="parameterName">stream</span> [ in: <span  class="parameterLocation">Query</span> type: <span  class="parameterType">boolean</span> ]</dt><dd  class="parameter"><span  class="parameterDescription">Whether to stream events for the fine-tune job. If set to true,
events will be sent as data-only
[server-sent events](https://developer.mozilla.org/en-US/docs/Web/API/Server-sent_events/Using_server-sent_events#Event_stream_format)
as they become available. The stream will terminate with a
`data: [DONE]` message when the job is finished (succeeded, cancelled,
or failed).

If set to false, only events generated so far will be returned.
</span> <span  class="parameterRequired">optional</span></dd></dl><section  class="responses"><h2>Responses</h2><ul  class="responses"><li  class="response"><span  class="statusLine">200</span> <span  class="statusDescription">OK</span></li></ul></section></article></body></html>