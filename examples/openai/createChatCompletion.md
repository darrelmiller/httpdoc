<!DOCTYPE html><html><head><title>Creates a model response for the given chat conversation.</title><link rel="stylesheet" href="../OpenApi.css"/><meta charset="utf-8"/><meta name="viewport" content="width=device-width, initial-scale=1"/></head><body><article><section  class="requestOverview"><h1  class="requestSummary">Creates a model response for the given chat conversation.</h1><p  class="requestDescription"></p></section><section  class="http"><h3>HTTP Request</h3><pre  class="httpExample"><span  class="requestLine">POST</span> <span  class="httpTarget">\chat\completions</span> <span  class="httpVersion">HTTP/1.1</span>
<span  class="headerLine">host</span>: <span  class="headerValue">api.openai.com:443</span>
<span  class="headerLine">accept</span>: <span  class="headerValue">application/json</span>
<span  class="headerLine">content-type</span>: <span  class="headerValue">application/json</span>
</pre></section><dl  class="parameters"><h3>Parameters</h3></dl><section  class="requestContent"><h3>Request Body Schema</h3><pre  class="schema">{
  "required": [
    "model",
    "messages"
  ],
  "type": "object",
  "properties": {
    "messages": {
      "minItems": 1,
      "type": "array",
      "items": {
        "oneOf": [
          {
            "title": "System message",
            "required": [
              "content",
              "role"
            ],
            "type": "object",
            "properties": {
              "content": {
                "type": "string",
                "description": "The contents of the system message."
              },
              "role": {
                "enum": [
                  "system"
                ],
                "type": "string",
                "description": "The role of the messages author, in this case `system`."
              },
              "name": {
                "type": "string",
                "description": "An optional name for the participant. Provides the model information to differentiate between participants of the same role."
              }
            }
          },
          {
            "title": "User message",
            "required": [
              "content",
              "role"
            ],
            "type": "object",
            "properties": {
              "content": {
                "oneOf": [
                  {
                    "title": "Text content",
                    "type": "string",
                    "description": "The text contents of the message."
                  },
                  {
                    "title": "Array of content parts",
                    "minItems": 1,
                    "type": "array",
                    "items": {
                      "oneOf": [
                        {
                          "title": "Text content part",
                          "required": [
                            "type",
                            "text"
                          ],
                          "type": "object",
                          "properties": {
                            "type": {
                              "enum": [
                                "text"
                              ],
                              "type": "string",
                              "description": "The type of the content part."
                            },
                            "text": {
                              "type": "string",
                              "description": "The text content."
                            }
                          }
                        },
                        {
                          "title": "Image content part",
                          "required": [
                            "type",
                            "image_url"
                          ],
                          "type": "object",
                          "properties": {
                            "type": {
                              "enum": [
                                "image_url"
                              ],
                              "type": "string",
                              "description": "The type of the content part."
                            },
                            "image_url": {
                              "required": [
                                "url"
                              ],
                              "type": "object",
                              "properties": {
                                "url": {
                                  "type": "string",
                                  "description": "Either a URL of the image or the base64 encoded image data.",
                                  "format": "uri"
                                },
                                "detail": {
                                  "enum": [
                                    "auto",
                                    "low",
                                    "high"
                                  ],
                                  "type": "string",
                                  "description": "Specifies the detail level of the image. Learn more in the [Vision guide](/docs/guides/vision/low-or-high-fidelity-image-understanding).",
                                  "default": "auto"
                                }
                              }
                            }
                          }
                        }
                      ],
                      "x-oaiExpandable": true
                    },
                    "description": "An array of content parts with a defined type, each can be of type `text` or `image_url` when passing in images. You can pass multiple images by adding multiple `image_url` content parts. Image input is only supported when using the `gpt-4-visual-preview` model."
                  }
                ],
                "description": "The contents of the user message.\n",
                "x-oaiExpandable": true
              },
              "role": {
                "enum": [
                  "user"
                ],
                "type": "string",
                "description": "The role of the messages author, in this case `user`."
              },
              "name": {
                "type": "string",
                "description": "An optional name for the participant. Provides the model information to differentiate between participants of the same role."
              }
            }
          },
          {
            "title": "Assistant message",
            "required": [
              "role"
            ],
            "type": "object",
            "properties": {
              "content": {
                "type": "string",
                "description": "The contents of the assistant message. Required unless `tool_calls` or `function_call` is specified.\n",
                "nullable": true
              },
              "role": {
                "enum": [
                  "assistant"
                ],
                "type": "string",
                "description": "The role of the messages author, in this case `assistant`."
              },
              "name": {
                "type": "string",
                "description": "An optional name for the participant. Provides the model information to differentiate between participants of the same role."
              },
              "tool_calls": {
                "type": "array",
                "items": {
                  "required": [
                    "id",
                    "type",
                    "function"
                  ],
                  "type": "object",
                  "properties": {
                    "id": {
                      "type": "string",
                      "description": "The ID of the tool call."
                    },
                    "type": {
                      "enum": [
                        "function"
                      ],
                      "type": "string",
                      "description": "The type of the tool. Currently, only `function` is supported."
                    },
                    "function": {
                      "required": [
                        "name",
                        "arguments"
                      ],
                      "type": "object",
                      "properties": {
                        "name": {
                          "type": "string",
                          "description": "The name of the function to call."
                        },
                        "arguments": {
                          "type": "string",
                          "description": "The arguments to call the function with, as generated by the model in JSON format. Note that the model does not always generate valid JSON, and may hallucinate parameters not defined by your function schema. Validate the arguments in your code before calling your function."
                        }
                      },
                      "description": "The function that the model called."
                    }
                  }
                },
                "description": "The tool calls generated by the model, such as function calls."
              },
              "function_call": {
                "required": [
                  "arguments",
                  "name"
                ],
                "type": "object",
                "properties": {
                  "arguments": {
                    "type": "string",
                    "description": "The arguments to call the function with, as generated by the model in JSON format. Note that the model does not always generate valid JSON, and may hallucinate parameters not defined by your function schema. Validate the arguments in your code before calling your function."
                  },
                  "name": {
                    "type": "string",
                    "description": "The name of the function to call."
                  }
                },
                "description": "Deprecated and replaced by `tool_calls`. The name and arguments of a function that should be called, as generated by the model.",
                "deprecated": true
              }
            }
          },
          {
            "title": "Tool message",
            "required": [
              "role",
              "content",
              "tool_call_id"
            ],
            "type": "object",
            "properties": {
              "role": {
                "enum": [
                  "tool"
                ],
                "type": "string",
                "description": "The role of the messages author, in this case `tool`."
              },
              "content": {
                "type": "string",
                "description": "The contents of the tool message."
              },
              "tool_call_id": {
                "type": "string",
                "description": "Tool call that this message is responding to."
              }
            }
          },
          {
            "title": "Function message",
            "required": [
              "role",
              "content",
              "name"
            ],
            "type": "object",
            "properties": {
              "role": {
                "enum": [
                  "function"
                ],
                "type": "string",
                "description": "The role of the messages author, in this case `function`."
              },
              "content": {
                "type": "string",
                "description": "The contents of the function message.",
                "nullable": true
              },
              "name": {
                "type": "string",
                "description": "The name of the function to call."
              }
            },
            "deprecated": true
          }
        ],
        "x-oaiExpandable": true
      },
      "description": "A list of messages comprising the conversation so far. [Example Python code](https://cookbook.openai.com/examples/how_to_format_inputs_to_chatgpt_models)."
    },
    "model": {
      "anyOf": [
        {
          "type": "string"
        },
        {
          "enum": [
            "gpt-4-1106-preview",
            "gpt-4-vision-preview",
            "gpt-4",
            "gpt-4-0314",
            "gpt-4-0613",
            "gpt-4-32k",
            "gpt-4-32k-0314",
            "gpt-4-32k-0613",
            "gpt-3.5-turbo",
            "gpt-3.5-turbo-16k",
            "gpt-3.5-turbo-0301",
            "gpt-3.5-turbo-0613",
            "gpt-3.5-turbo-1106",
            "gpt-3.5-turbo-16k-0613"
          ],
          "type": "string"
        }
      ],
      "description": "ID of the model to use. See the [model endpoint compatibility](/docs/models/model-endpoint-compatibility) table for details on which models work with the Chat API.",
      "example": "gpt-3.5-turbo",
      "x-oaiTypeLabel": "string"
    },
    "frequency_penalty": {
      "maximum": 2,
      "minimum": -2,
      "type": "number",
      "description": "Number between -2.0 and 2.0. Positive values penalize new tokens based on their existing frequency in the text so far, decreasing the model's likelihood to repeat the same line verbatim.\n\n[See more information about frequency and presence penalties.](/docs/guides/text-generation/parameter-details)\n",
      "default": 0,
      "nullable": true
    },
    "logit_bias": {
      "type": "object",
      "additionalProperties": {
        "type": "integer"
      },
      "description": "Modify the likelihood of specified tokens appearing in the completion.\n\nAccepts a JSON object that maps tokens (specified by their token ID in the tokenizer) to an associated bias value from -100 to 100. Mathematically, the bias is added to the logits generated by the model prior to sampling. The exact effect will vary per model, but values between -1 and 1 should decrease or increase likelihood of selection; values like -100 or 100 should result in a ban or exclusive selection of the relevant token.\n",
      "default": null,
      "nullable": true,
      "x-oaiTypeLabel": "map"
    },
    "logprobs": {
      "type": "boolean",
      "description": "Whether to return log probabilities of the output tokens or not. If true, returns the log probabilities of each output token returned in the `content` of `message`. This option is currently not available on the `gpt-4-vision-preview` model.",
      "default": false,
      "nullable": true
    },
    "top_logprobs": {
      "maximum": 5,
      "minimum": 0,
      "type": "integer",
      "description": "An integer between 0 and 5 specifying the number of most likely tokens to return at each token position, each with an associated log probability. `logprobs` must be set to `true` if this parameter is used.",
      "nullable": true
    },
    "max_tokens": {
      "type": "integer",
      "description": "The maximum number of [tokens](/tokenizer) that can be generated in the chat completion.\n\nThe total length of input tokens and generated tokens is limited by the model's context length. [Example Python code](https://cookbook.openai.com/examples/how_to_count_tokens_with_tiktoken) for counting tokens.\n",
      "nullable": true
    },
    "n": {
      "maximum": 128,
      "minimum": 1,
      "type": "integer",
      "description": "How many chat completion choices to generate for each input message. Note that you will be charged based on the number of generated tokens across all of the choices. Keep `n` as `1` to minimize costs.",
      "default": 1,
      "nullable": true,
      "example": 1
    },
    "presence_penalty": {
      "maximum": 2,
      "minimum": -2,
      "type": "number",
      "description": "Number between -2.0 and 2.0. Positive values penalize new tokens based on whether they appear in the text so far, increasing the model's likelihood to talk about new topics.\n\n[See more information about frequency and presence penalties.](/docs/guides/text-generation/parameter-details)\n",
      "default": 0,
      "nullable": true
    },
    "response_format": {
      "type": "object",
      "properties": {
        "type": {
          "enum": [
            "text",
            "json_object"
          ],
          "type": "string",
          "description": "Must be one of `text` or `json_object`.",
          "default": "text",
          "example": "json_object"
        }
      },
      "description": "An object specifying the format that the model must output. Compatible with `gpt-4-1106-preview` and `gpt-3.5-turbo-1106`.\n\nSetting to `{ \"type\": \"json_object\" }` enables JSON mode, which guarantees the message the model generates is valid JSON.\n\n**Important:** when using JSON mode, you **must** also instruct the model to produce JSON yourself via a system or user message. Without this, the model may generate an unending stream of whitespace until the generation reaches the token limit, resulting in a long-running and seemingly \"stuck\" request. Also note that the message content may be partially cut off if `finish_reason=\"length\"`, which indicates the generation exceeded `max_tokens` or the conversation exceeded the max context length.\n"
    },
    "seed": {
      "maximum": 9223372036854775807,
      "minimum": -9223372036854775808,
      "type": "integer",
      "description": "This feature is in Beta.\nIf specified, our system will make a best effort to sample deterministically, such that repeated requests with the same `seed` and parameters should return the same result.\nDeterminism is not guaranteed, and you should refer to the `system_fingerprint` response parameter to monitor changes in the backend.\n",
      "nullable": true,
      "x-oaiMeta": {
        "beta": true
      }
    },
    "stop": {
      "oneOf": [
        {
          "type": "string",
          "nullable": true
        },
        {
          "maxItems": 4,
          "minItems": 1,
          "type": "array",
          "items": {
            "type": "string"
          }
        }
      ],
      "description": "Up to 4 sequences where the API will stop generating further tokens.\n",
      "default": null
    },
    "stream": {
      "type": "boolean",
      "description": "If set, partial message deltas will be sent, like in ChatGPT. Tokens will be sent as data-only [server-sent events](https://developer.mozilla.org/en-US/docs/Web/API/Server-sent_events/Using_server-sent_events#Event_stream_format) as they become available, with the stream terminated by a `data: [DONE]` message. [Example Python code](https://cookbook.openai.com/examples/how_to_stream_completions).\n",
      "default": false,
      "nullable": true
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
    },
    "tools": {
      "type": "array",
      "items": {
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
            "description": "The type of the tool. Currently, only `function` is supported."
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
      },
      "description": "A list of tools the model may call. Currently, only functions are supported as a tool. Use this to provide a list of functions the model may generate JSON inputs for.\n"
    },
    "tool_choice": {
      "oneOf": [
        {
          "enum": [
            "none",
            "auto"
          ],
          "type": "string",
          "description": "`none` means the model will not call a function and instead generates a message. `auto` means the model can pick between generating a message or calling a function.\n"
        },
        {
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
              "description": "The type of the tool. Currently, only `function` is supported."
            },
            "function": {
              "required": [
                "name"
              ],
              "type": "object",
              "properties": {
                "name": {
                  "type": "string",
                  "description": "The name of the function to call."
                }
              }
            }
          },
          "description": "Specifies a tool the model should use. Use to force the model to call a specific function."
        }
      ],
      "description": "Controls which (if any) function is called by the model.\n`none` means the model will not call a function and instead generates a message.\n`auto` means the model can pick between generating a message or calling a function.\nSpecifying a particular function via `{\"type: \"function\", \"function\": {\"name\": \"my_function\"}}` forces the model to call that function.\n\n`none` is the default when no functions are present. `auto` is the default if functions are present.\n",
      "x-oaiExpandable": true
    },
    "user": {
      "type": "string",
      "description": "A unique identifier representing your end-user, which can help OpenAI to monitor and detect abuse. [Learn more](/docs/guides/safety-best-practices/end-user-ids).\n",
      "example": "user-1234"
    },
    "function_call": {
      "oneOf": [
        {
          "enum": [
            "none",
            "auto"
          ],
          "type": "string",
          "description": "`none` means the model will not call a function and instead generates a message. `auto` means the model can pick between generating a message or calling a function.\n"
        },
        {
          "required": [
            "name"
          ],
          "type": "object",
          "properties": {
            "name": {
              "type": "string",
              "description": "The name of the function to call."
            }
          },
          "description": "Specifying a particular function via `{\"name\": \"my_function\"}` forces the model to call that function.\n"
        }
      ],
      "description": "Deprecated in favor of `tool_choice`.\n\nControls which (if any) function is called by the model.\n`none` means the model will not call a function and instead generates a message.\n`auto` means the model can pick between generating a message or calling a function.\nSpecifying a particular function via `{\"name\": \"my_function\"}` forces the model to call that function.\n\n`none` is the default when no functions are present. `auto` is the default if functions are present.\n",
      "deprecated": true,
      "x-oaiExpandable": true
    },
    "functions": {
      "maxItems": 128,
      "minItems": 1,
      "type": "array",
      "items": {
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
        },
        "deprecated": true
      },
      "description": "Deprecated in favor of `tools`.\n\nA list of functions the model may generate JSON inputs for.\n",
      "deprecated": true
    }
  }
}</pre></section><section  class="responses"><h2>Responses</h2><ul  class="responses"><li  class="response"><span  class="statusLine">200</span> <span  class="statusDescription">OK</span></li></ul></section></article></body></html>