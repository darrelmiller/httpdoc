<!DOCTYPE html><html><head><title>Classifies if text violates OpenAI's Content Policy</title><link rel="stylesheet" href="../OpenApi.css"/><meta charset="utf-8"/><meta name="viewport" content="width=device-width, initial-scale=1"/></head><body><article><section  class="requestOverview"><h1  class="requestSummary">Classifies if text violates OpenAI's Content Policy</h1><p  class="requestDescription"></p></section><section  class="http"><h3>HTTP Request</h3><pre  class="httpExample"><span  class="requestLine">POST</span> <span  class="httpTarget">\moderations</span> <span  class="httpVersion">HTTP/1.1</span>
<span  class="headerLine">host</span>: <span  class="headerValue">api.openai.com:443</span>
<span  class="headerLine">accept</span>: <span  class="headerValue">application/json</span>
<span  class="headerLine">content-type</span>: <span  class="headerValue">application/json</span>
</pre></section><dl  class="parameters"><h3>Parameters</h3></dl><section  class="requestContent"><h3>Request Body Schema</h3><pre  class="schema">{
  "required": [
    "input"
  ],
  "type": "object",
  "properties": {
    "input": {
      "oneOf": [
        {
          "type": "string",
          "default": "",
          "example": "I want to kill them."
        },
        {
          "type": "array",
          "items": {
            "type": "string",
            "default": "",
            "example": "I want to kill them."
          }
        }
      ],
      "description": "The input text to classify"
    },
    "model": {
      "anyOf": [
        {
          "type": "string"
        },
        {
          "enum": [
            "text-moderation-latest",
            "text-moderation-stable"
          ],
          "type": "string"
        }
      ],
      "description": "Two content moderations models are available: `text-moderation-stable` and `text-moderation-latest`.\n\nThe default is `text-moderation-latest` which will be automatically upgraded over time. This ensures you are always using our most accurate model. If you use `text-moderation-stable`, we will provide advanced notice before updating the model. Accuracy of `text-moderation-stable` may be slightly lower than for `text-moderation-latest`.\n",
      "default": "text-moderation-latest",
      "example": "text-moderation-stable",
      "x-oaiTypeLabel": "string"
    }
  }
}</pre></section><section  class="responses"><h2>Responses</h2><ul  class="responses"><li  class="response"><span  class="statusLine">200</span> <span  class="statusDescription">OK</span></li></ul></section></article></body></html>