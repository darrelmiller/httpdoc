<!DOCTYPE html><html><head><title>Modifies an assistant.</title><link rel="stylesheet" href="../OpenApi.css"/><meta charset="utf-8"/><meta name="viewport" content="width=device-width, initial-scale=1"/></head><body><article><section  class="requestOverview"><h1  class="requestSummary">Modifies an assistant.</h1><p  class="requestDescription"></p></section><section  class="http"><h3>HTTP Request</h3><pre  class="httpExample"><span  class="requestLine">POST</span> <span  class="httpTarget">\assistants\{assistant_id}</span> <span  class="httpVersion">HTTP/1.1</span>
<span  class="headerLine">host</span>: <span  class="headerValue">api.openai.com:443</span>
<span  class="headerLine">accept</span>: <span  class="headerValue">application/json</span>
<span  class="headerLine">content-type</span>: <span  class="headerValue">application/json</span>
</pre></section><dl  class="parameters"><h3>Parameters</h3><dt  class="parameter"><span  class="parameterName">assistant_id</span> [ in: <span  class="parameterLocation">path</span> type: <span  class="parameterType">string</span> ]</dt><dd  class="parameter"><span  class="parameterDescription">The ID of the assistant to modify.</span> <span  class="parameterRequired">required</span></dd></dl><section  class="requestContent"><h3>Request Body Schema</h3><pre  class="schema">{
  "type": "object",
  "properties": {
    "model": {
      "anyOf": [
        {
          "type": "string"
        }
      ],
      "description": "ID of the model to use. You can use the [List models](/docs/api-reference/models/list) API to see all of your available models, or see our [Model overview](/docs/models/overview) for descriptions of them.\n"
    },
    "name": {
      "maxLength": 256,
      "type": "string",
      "description": "The name of the assistant. The maximum length is 256 characters.\n",
      "nullable": true
    },
    "description": {
      "maxLength": 512,
      "type": "string",
      "description": "The description of the assistant. The maximum length is 512 characters.\n",
      "nullable": true
    },
    "instructions": {
      "maxLength": 32768,
      "type": "string",
      "description": "The system instructions that the assistant uses. The maximum length is 32768 characters.\n",
      "nullable": true
    },
    "tools": {
      "maxItems": 128,
      "type": "array",
      "items": {
        "oneOf": [
          {
            "title": "Code interpreter tool",
            "required": [
              "type"
            ],
            "type": "object",
            "properties": {
              "type": {
                "enum": [
                  "code_interpreter"
                ],
                "type": "string",
                "description": "The type of tool being defined: `code_interpreter`"
              }
            }
          },
          {
            "title": "Retrieval tool",
            "required": [
              "type"
            ],
            "type": "object",
            "properties": {
              "type": {
                "enum": [
                  "retrieval"
                ],
                "type": "string",
                "description": "The type of tool being defined: `retrieval`"
              }
            }
          },
          {
            "title": "Function tool",
            "required": [
              "type",
              "function"
            ],
            "type": "object",
            "properties": {
              "type": {
                "enum": [
                  "function"
                ],
                "type": "string",
                "description": "The type of tool being defined: `function`"
              },
              "function": {
                "required": [
                  "name"
                ],
                "type": "object",
                "properties": {
                  "description": {
                    "type": "string",
                    "description": "A description of what the function does, used by the model to choose when and how to call the function."
                  },
                  "name": {
                    "type": "string",
                    "description": "The name of the function to be called. Must be a-z, A-Z, 0-9, or contain underscores and dashes, with a maximum length of 64."
                  },
                  "parameters": {
                    "type": "object",
                    "description": "The parameters the functions accepts, described as a JSON Schema object. See the [guide](/docs/guides/text-generation/function-calling) for examples, and the [JSON Schema reference](https://json-schema.org/understanding-json-schema/) for documentation about the format. \n\nOmitting `parameters` defines a function with an empty parameter list."
                  }
                }
              }
            }
          }
        ],
        "x-oaiExpandable": true
      },
      "description": "A list of tool enabled on the assistant. There can be a maximum of 128 tools per assistant. Tools can be of types `code_interpreter`, `retrieval`, or `function`.\n"
    },
    "file_ids": {
      "maxItems": 20,
      "type": "array",
      "items": {
        "type": "string"
      },
      "description": "A list of [File](/docs/api-reference/files) IDs attached to this assistant. There can be a maximum of 20 files attached to the assistant. Files are ordered by their creation date in ascending order. If a file was previously attached to the list but does not show up in the list, it will be deleted from the assistant.\n"
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