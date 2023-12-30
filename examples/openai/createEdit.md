<!DOCTYPE html><html><head><title>Creates a new edit for the provided input, instruction, and parameters.</title><link rel="stylesheet" href="../OpenApi.css"/><meta charset="utf-8"/><meta name="viewport" content="width=device-width, initial-scale=1"/></head><body><article><section  class="requestOverview"><h1  class="requestSummary">Creates a new edit for the provided input, instruction, and parameters.</h1><p  class="requestDescription"></p></section><section  class="http"><h3>HTTP Request</h3><pre  class="httpExample"><span  class="requestLine">POST</span> <span  class="httpTarget">\edits</span> <span  class="httpVersion">HTTP/1.1</span>
<span  class="headerLine">host</span>: <span  class="headerValue">api.openai.com:443</span>
<span  class="headerLine">accept</span>: <span  class="headerValue">application/json</span>
<span  class="headerLine">content-type</span>: <span  class="headerValue">application/json</span>
</pre></section><dl  class="parameters"><h3>Parameters</h3></dl><section  class="requestContent"><h3>Request Body Schema</h3><pre  class="schema">{
  "required": [
    "model",
    "instruction"
  ],
  "type": "object",
  "properties": {
    "instruction": {
      "type": "string",
      "description": "The instruction that tells the model how to edit the prompt.",
      "example": "Fix the spelling mistakes."
    },
    "model": {
      "anyOf": [
        {
          "type": "string"
        },
        {
          "enum": [
            "text-davinci-edit-001",
            "code-davinci-edit-001"
          ],
          "type": "string"
        }
      ],
      "description": "ID of the model to use. You can use the `text-davinci-edit-001` or `code-davinci-edit-001` model with this endpoint.",
      "example": "text-davinci-edit-001",
      "x-oaiTypeLabel": "string"
    },
    "input": {
      "type": "string",
      "description": "The input text to use as a starting point for the edit.",
      "default": "",
      "nullable": true,
      "example": "What day of the wek is it?"
    },
    "n": {
      "maximum": 20,
      "minimum": 1,
      "type": "integer",
      "description": "How many edits to generate for the input and instruction.",
      "default": 1,
      "nullable": true,
      "example": 1
    },
    "temperature": {
      "maximum": 2,
      "minimum": 0,
      "type": "number",
      "description": "What sampling temperature to use, between 0 and 2. Higher values like 0.8 will make the output more random, while lower values like 0.2 will make it more focused and deterministic.\n\nWe generally recommend altering this or `top_p` but not both.\n",
      "default": 1,
      "nullable": true,
      "example": 1
    },
    "top_p": {
      "maximum": 1,
      "minimum": 0,
      "type": "number",
      "description": "An alternative to sampling with temperature, called nucleus sampling, where the model considers the results of the tokens with top_p probability mass. So 0.1 means only the tokens comprising the top 10% probability mass are considered.\n\nWe generally recommend altering this or `temperature` but not both.\n",
      "default": 1,
      "nullable": true,
      "example": 1
    }
  }
}</pre></section><section  class="responses"><h2>Responses</h2><ul  class="responses"><li  class="response"><span  class="statusLine">200</span> <span  class="statusDescription">OK</span></li></ul></section></article></body></html>