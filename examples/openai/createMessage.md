<!DOCTYPE html><html><head><title>Create a message.</title><link rel="stylesheet" href="../OpenApi.css"/><meta charset="utf-8"/><meta name="viewport" content="width=device-width, initial-scale=1"/></head><body><article><section  class="requestOverview"><h1  class="requestSummary">Create a message.</h1><p  class="requestDescription"></p></section><section  class="http"><h3>HTTP Request</h3><pre  class="httpExample"><span  class="requestLine">POST</span> <span  class="httpTarget">\threads\{thread_id}\messages</span> <span  class="httpVersion">HTTP/1.1</span>
<span  class="headerLine">host</span>: <span  class="headerValue">api.openai.com:443</span>
<span  class="headerLine">accept</span>: <span  class="headerValue">application/json</span>
<span  class="headerLine">content-type</span>: <span  class="headerValue">application/json</span>
</pre></section><dl  class="parameters"><h3>Parameters</h3><dt  class="parameter"><span  class="parameterName">thread_id</span> [ in: <span  class="parameterLocation">path</span> type: <span  class="parameterType">string</span> ]</dt><dd  class="parameter"><span  class="parameterDescription">The ID of the [thread](/docs/api-reference/threads) to create a message for.</span> <span  class="parameterRequired">required</span></dd></dl><section  class="requestContent"><h3>Request Body Schema</h3><pre  class="schema">{
  "required": [
    "role",
    "content"
  ],
  "type": "object",
  "properties": {
    "role": {
      "enum": [
        "user"
      ],
      "type": "string",
      "description": "The role of the entity that is creating the message. Currently only `user` is supported."
    },
    "content": {
      "maxLength": 32768,
      "minLength": 1,
      "type": "string",
      "description": "The content of the message."
    },
    "file_ids": {
      "maxItems": 10,
      "minItems": 1,
      "type": "array",
      "items": {
        "type": "string"
      },
      "description": "A list of [File](/docs/api-reference/files) IDs that the message should use. There can be a maximum of 10 files attached to a message. Useful for tools like `retrieval` and `code_interpreter` that can access and use files."
    },
    "metadata": {
      "type": "object",
      "description": "Set of 16 key-value pairs that can be attached to an object. This can be useful for storing additional information about the object in a structured format. Keys can be a maximum of 64 characters long and values can be a maxium of 512 characters long.\n",
      "nullable": true,
      "x-oaiTypeLabel": "map"
    }
  },
  "additionalProperties": false
}</pre></section><section  class="responses"><h2>Responses</h2><ul  class="responses"><li  class="response"><span  class="statusLine">200</span> <span  class="statusDescription">OK</span></li></ul></section></article></body></html>