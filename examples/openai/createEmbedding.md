<!DOCTYPE html><html><head><title>Creates an embedding vector representing the input text.</title><link rel="stylesheet" href="../OpenApi.css"/><meta charset="utf-8"/><meta name="viewport" content="width=device-width, initial-scale=1"/></head><body><article><section  class="requestOverview"><h1  class="requestSummary">Creates an embedding vector representing the input text.</h1><p  class="requestDescription"></p></section><section  class="http"><h3>HTTP Request</h3><pre  class="httpExample"><span  class="requestLine">POST</span> <span  class="httpTarget">\embeddings</span> <span  class="httpVersion">HTTP/1.1</span>
<span  class="headerLine">host</span>: <span  class="headerValue">api.openai.com:443</span>
<span  class="headerLine">accept</span>: <span  class="headerValue">application/json</span>
<span  class="headerLine">content-type</span>: <span  class="headerValue">application/json</span>
</pre></section><dl  class="parameters"><h3>Parameters</h3></dl><section  class="requestContent"><h3>Request Body Schema</h3><pre  class="schema">{
  "required": [
    "model",
    "input"
  ],
  "type": "object",
  "properties": {
    "input": {
      "oneOf": [
        {
          "title": "string",
          "type": "string",
          "description": "The string that will be turned into an embedding.",
          "default": "",
          "example": "This is a test."
        },
        {
          "title": "array",
          "maxItems": 2048,
          "minItems": 1,
          "type": "array",
          "items": {
            "type": "string",
            "default": "",
            "example": "['This is a test.']"
          },
          "description": "The array of strings that will be turned into an embedding."
        },
        {
          "title": "array",
          "maxItems": 2048,
          "minItems": 1,
          "type": "array",
          "items": {
            "type": "integer"
          },
          "description": "The array of integers that will be turned into an embedding.",
          "example": "[1212, 318, 257, 1332, 13]"
        },
        {
          "title": "array",
          "maxItems": 2048,
          "minItems": 1,
          "type": "array",
          "items": {
            "minItems": 1,
            "type": "array",
            "items": {
              "type": "integer"
            }
          },
          "description": "The array of arrays containing integers that will be turned into an embedding.",
          "example": "[[1212, 318, 257, 1332, 13]]"
        }
      ],
      "description": "Input text to embed, encoded as a string or array of tokens. To embed multiple inputs in a single request, pass an array of strings or array of token arrays. The input must not exceed the max input tokens for the model (8192 tokens for `text-embedding-ada-002`), cannot be an empty string, and any array must be 2048 dimensions or less. [Example Python code](https://cookbook.openai.com/examples/how_to_count_tokens_with_tiktoken) for counting tokens.\n",
      "example": "The quick brown fox jumped over the lazy dog",
      "x-oaiExpandable": true
    },
    "model": {
      "anyOf": [
        {
          "type": "string"
        },
        {
          "enum": [
            "text-embedding-ada-002"
          ],
          "type": "string"
        }
      ],
      "description": "ID of the model to use. You can use the [List models](/docs/api-reference/models/list) API to see all of your available models, or see our [Model overview](/docs/models/overview) for descriptions of them.\n",
      "example": "text-embedding-ada-002",
      "x-oaiTypeLabel": "string"
    },
    "encoding_format": {
      "enum": [
        "float",
        "base64"
      ],
      "type": "string",
      "description": "The format to return the embeddings in. Can be either `float` or [`base64`](https://pypi.org/project/pybase64/).",
      "default": "float",
      "example": "float"
    },
    "user": {
      "type": "string",
      "description": "A unique identifier representing your end-user, which can help OpenAI to monitor and detect abuse. [Learn more](/docs/guides/safety-best-practices/end-user-ids).\n",
      "example": "user-1234"
    }
  },
  "additionalProperties": false
}</pre></section><section  class="responses"><h2>Responses</h2><ul  class="responses"><li  class="response"><span  class="statusLine">200</span> <span  class="statusDescription">OK</span></li></ul></section></article></body></html>