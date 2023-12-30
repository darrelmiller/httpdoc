<!DOCTYPE html><html><head><title>Creates an edited or extended image given an original image and a prompt.</title><link rel="stylesheet" href="../OpenApi.css"/><meta charset="utf-8"/><meta name="viewport" content="width=device-width, initial-scale=1"/></head><body><article><section  class="requestOverview"><h1  class="requestSummary">Creates an edited or extended image given an original image and a prompt.</h1><p  class="requestDescription"></p></section><section  class="http"><h3>HTTP Request</h3><pre  class="httpExample"><span  class="requestLine">POST</span> <span  class="httpTarget">\images\edits</span> <span  class="httpVersion">HTTP/1.1</span>
<span  class="headerLine">host</span>: <span  class="headerValue">api.openai.com:443</span>
<span  class="headerLine">accept</span>: <span  class="headerValue">application/json</span>
<span  class="headerLine">content-type</span>: <span  class="headerValue">multipart/form-data</span>
</pre></section><dl  class="parameters"><h3>Parameters</h3></dl><section  class="requestContent"><h3>Request Body Schema</h3><pre  class="schema">{
  "required": [
    "prompt",
    "image"
  ],
  "type": "object",
  "properties": {
    "image": {
      "type": "string",
      "description": "The image to edit. Must be a valid PNG file, less than 4MB, and square. If mask is not provided, image must have transparency, which will be used as the mask.",
      "format": "binary"
    },
    "prompt": {
      "type": "string",
      "description": "A text description of the desired image(s). The maximum length is 1000 characters.",
      "example": "A cute baby sea otter wearing a beret"
    },
    "mask": {
      "type": "string",
      "description": "An additional image whose fully transparent areas (e.g. where alpha is zero) indicate where `image` should be edited. Must be a valid PNG file, less than 4MB, and have the same dimensions as `image`.",
      "format": "binary"
    },
    "model": {
      "anyOf": [
        {
          "type": "string"
        },
        {
          "enum": [
            "dall-e-2"
          ],
          "type": "string"
        }
      ],
      "description": "The model to use for image generation. Only `dall-e-2` is supported at this time.",
      "default": "dall-e-2",
      "nullable": true,
      "example": "dall-e-2",
      "x-oaiTypeLabel": "string"
    },
    "n": {
      "maximum": 10,
      "minimum": 1,
      "type": "integer",
      "description": "The number of images to generate. Must be between 1 and 10.",
      "default": 1,
      "nullable": true,
      "example": 1
    },
    "size": {
      "enum": [
        "256x256",
        "512x512",
        "1024x1024"
      ],
      "type": "string",
      "description": "The size of the generated images. Must be one of `256x256`, `512x512`, or `1024x1024`.",
      "default": "1024x1024",
      "nullable": true,
      "example": "1024x1024"
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
    "user": {
      "type": "string",
      "description": "A unique identifier representing your end-user, which can help OpenAI to monitor and detect abuse. [Learn more](/docs/guides/safety-best-practices/end-user-ids).\n",
      "example": "user-1234"
    }
  }
}</pre></section><section  class="responses"><h2>Responses</h2><ul  class="responses"><li  class="response"><span  class="statusLine">200</span> <span  class="statusDescription">OK</span></li></ul></section></article></body></html>