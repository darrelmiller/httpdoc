<!DOCTYPE html><html><head><title>Cancels a run that is `in_progress`.</title><link rel="stylesheet" href="../OpenApi.css"/><meta charset="utf-8"/><meta name="viewport" content="width=device-width, initial-scale=1"/></head><body><article><section  class="requestOverview"><h1  class="requestSummary">Cancels a run that is `in_progress`.</h1><p  class="requestDescription"></p></section><section  class="http"><h3>HTTP Request</h3><pre  class="httpExample"><span  class="requestLine">POST</span> <span  class="httpTarget">+{baseUrl}\threads\{thread_id}\runs\{run_id}\cancel</span> <span  class="httpVersion">HTTP/1.1</span>
<span  class="headerLine">host</span>: <span  class="headerValue">example.org:443</span>
<span  class="headerLine">accept</span>: <span  class="headerValue">application/json</span>
</pre></section><dl  class="parameters"><h3>Parameters</h3><dt  class="parameter"><span  class="parameterName">thread_id</span> [ in: <span  class="parameterLocation">Path</span> type: <span  class="parameterType">string</span> ]</dt><dd  class="parameter"><span  class="parameterDescription">The ID of the thread to which this run belongs.</span> <span  class="parameterRequired">required</span></dd><dt  class="parameter"><span  class="parameterName">run_id</span> [ in: <span  class="parameterLocation">Path</span> type: <span  class="parameterType">string</span> ]</dt><dd  class="parameter"><span  class="parameterDescription">The ID of the run to cancel.</span> <span  class="parameterRequired">required</span></dd></dl><section  class="responses"><h2>Responses</h2><ul  class="responses"><li  class="response"><span  class="statusLine">200</span> <span  class="statusDescription">OK</span></li></ul></section></article></body></html>