<!DOCTYPE html><html><head><title>When a run has the `status: "requires_action"` and `required_action.type` is `submit_tool_outputs`, this endpoint can be used to submit the outputs from the tool calls once they're all completed. All outputs must be submitted in a single request.
</title><link rel="stylesheet" href="../OpenApi.css"/><meta charset="utf-8"/><meta name="viewport" content="width=device-width, initial-scale=1"/></head><body><article><section  class="requestOverview"><h1  class="requestSummary">When a run has the `status: "requires_action"` and `required_action.type` is `submit_tool_outputs`, this endpoint can be used to submit the outputs from the tool calls once they're all completed. All outputs must be submitted in a single request.
</h1><p  class="requestDescription"></p></section><section  class="http"><h3>HTTP Request</h3><pre  class="httpExample"><span  class="requestLine">POST</span> <span  class="httpTarget">\threads\{thread_id}\runs\{run_id}\submit_tool_outputs</span> <span  class="httpVersion">HTTP/1.1</span>
<span  class="headerLine">host</span>: <span  class="headerValue">api.openai.com:443</span>
<span  class="headerLine">accept</span>: <span  class="headerValue">application/json</span>
<span  class="headerLine">content-type</span>: <span  class="headerValue">application/json</span>
</pre></section><dl  class="parameters"><h3>Parameters</h3><dt  class="parameter"><span  class="parameterName">thread_id</span> [ in: <span  class="parameterLocation">path</span> type: <span  class="parameterType">string</span> ]</dt><dd  class="parameter"><span  class="parameterDescription">The ID of the [thread](/docs/api-reference/threads) to which this run belongs.</span> <span  class="parameterRequired">required</span></dd><dt  class="parameter"><span  class="parameterName">run_id</span> [ in: <span  class="parameterLocation">path</span> type: <span  class="parameterType">string</span> ]</dt><dd  class="parameter"><span  class="parameterDescription">The ID of the run that requires the tool output submission.</span> <span  class="parameterRequired">required</span></dd></dl><section  class="requestContent"><h3>Request Body Schema</h3><pre  class="schema">{
  "required": [
    "tool_outputs"
  ],
  "type": "object",
  "properties": {
    "tool_outputs": {
      "type": "array",
      "items": {
        "type": "object",
        "properties": {
          "tool_call_id": {
            "type": "string",
            "description": "The ID of the tool call in the `required_action` object within the run object the output is being submitted for."
          },
          "output": {
            "type": "string",
            "description": "The output of the tool call to be submitted to continue the run."
          }
        }
      },
      "description": "A list of tools for which the outputs are being submitted."
    }
  },
  "additionalProperties": false
}</pre></section><section  class="responses"><h2>Responses</h2><ul  class="responses"><li  class="response"><span  class="statusLine">200</span> <span  class="statusDescription">OK</span></li></ul></section></article></body></html>