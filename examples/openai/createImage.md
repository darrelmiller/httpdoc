<!DOCTYPE html><html><head><title>Creates an image given a prompt.</title><link rel="stylesheet" href="../OpenApi.css"/><meta charset="utf-8"/><meta name="viewport" content="width=device-width, initial-scale=1"/></head><body><article><section  class="requestOverview"><h1  class="requestSummary">Creates an image given a prompt.</h1><p  class="requestDescription"></p></section><section  class="http"><h3>HTTP Request</h3><pre  class="httpExample"><span  class="requestLine">POST</span> <span  class="httpTarget">\images\generations</span> <span  class="httpVersion">HTTP/1.1</span>
<span  class="headerLine">host</span>: <span  class="headerValue">api.openai.com:443</span>
<span  class="headerLine">accept</span>: <span  class="headerValue">application/json</span>
<span  class="headerLine">content-type</span>: <span  class="headerValue">application/json</span>
</pre></section><dl  class="parameters"><h3>Parameters</h3></dl><section  class="requestContent"><h3>Request Body Schema</h3><pre  class="schema">{
  "required": [
    "prompt"
  ],
  "type": "object",
  "properties": {
    "prompt": {
      "type": "string",
      "description": "A text description of the desired image(s). The maximum length is 1000 characters for `dall-e-2` and 4000 characters for `dall-e-3`.",
      "example": "A cute baby sea otter"
    },
    "model": {
      "anyOf": [
        {
          "type": "string"
        },
        {
          "enum": [
            "dall-e-2",
            "dall-e-3"
          ],
          "type": "string"
        }
      ],
      "description": "The model to use for image generation.",
      "default": "dall-e-2",
      "nullable": true,
      "example": "dall-e-3",
      "x-oaiTypeLabel": "string"
    },
    "n": {
      "maximum": 10,
      "minimum": 1,
      "type": "integer",
      "description": "The number of images to generate. Must be between 1 and 10. For `dall-e-3`, only `n=1` is supported.",
      "default": 1,
      "nullable": true,
      "example": 1
    },
    "quality": {
      "enum": [
        "standard",
        "hd"
      ],
      "type": "string",
      "description": "The quality of the image that will be generated. `hd` creates images with finer details and greater consistency across the image. This param is only supported for `dall-e-3`.",
      "default": "standard",
      "example": "standard"
    },
    "response_format": {
      "enum": [
        "url",
        "b64_json"
      ],
      "type": "string",
      "description": "The format in which the generated images are returned. Must be one of `url` or `b64_json`.",
      "default": "url",
      "nullable": true,
      "example": "url"
    },
    "size": {
      "enum": [
        "256x256",
        "512x512",
        "1024x1024",
        "1792x1024",
        "1024x1792"
      ],
      "type": "string",
      "description": "The size of the generated images. Must be one of `256x256`, `512x512`, or `1024x1024` for `dall-e-2`. Must be one of `1024x1024`, `1792x1024`, or `1024x1792` for `dall-e-3` models.",
      "default": "1024x1024",
      "nullable": true,
      "example": "1024x1024"
    },
    "style": {
      "enum": [
        "vivid",
        "natural"
      ],
      "type": "string",
      "description": "The style of the generated images. Must be one of `vivid` or `natural`. Vivid causes the model to lean towards generating hyper-real and dramatic images. Natural causes the model to produce more natural, less hyper-real looking images. This param is only supported for `dall-e-3`.",
      "default": "vivid",
      "nullable": true,
      "example": "vivid"
    },
    "user": {
      "type": "string",
      "description": "A unique identifier representing your end-user, which can help OpenAI to monitor and detect abuse. [Learn more](/docs/guides/safety-best-practices/end-user-ids).\n",
      "example": "user-1234"
    }
  }
}</pre></section><section  class="responses"><h2>Responses</h2><ul  class="responses"><li  class="response"><span  class="statusLine">200</span> <span  class="statusDescription">OK</span></li></ul></section></article></body></html>